[<AutoOpen>]
module MyLogs.UI.LogsDaysView

open System
open FSharp.Control.Reactive
open FSharp.Data.Adaptive
open Feliz
open Fun.Result
open Fun.Blazor
open MudBlazor
open MyLogs.Core
open MyLogs.Services
open type Styles


type private DragingLog = {
    Date: DateOnly
    Log: Log
}


let private secondsOfDay = 60 * 60 * 24


let private currentTime = html.inject <| fun (hook: IComponentHook) ->
    let time = hook.UseStore DateTimeOffset.Now

    hook.OnFirstAfterRender.Add <| fun _ ->
        TimeSpan.FromSeconds 1
        |> Observable.interval
        |> Observable.subscribe (fun _ -> time.Publish DateTimeOffset.Now)
        |> hook.AddDispose

    html.watch (time, fun time ->
        html.text (time.ToString("HH:mm:ss"))
    )


let private currentTimeline = html.inject <| fun (hook: IComponentHook) ->
    let time = hook.UseStore DateTime.Now

    hook.OnFirstAfterRender.Add <| fun _ ->
        TimeSpan.FromMinutes 1
        |> Observable.interval
        |> Observable.subscribe (fun _ -> time.Publish DateTime.Now)
        |> hook.AddDispose

    html.watch (time, fun time ->
        let widthPerc = int(TimeOnly(time.Hour, time.Minute, time.Second).ToTimeSpan().TotalSeconds) * 100 / secondsOfDay
        div(){
            styles [
                style.positionAbsolute; style.top 0; style.bottom 0; style.left 0; style.width (length.percent widthPerc)
                style.borderRight (length.px 1, borderStyle.dashed, "rgb(196 232 123 / 35%)"); style.zIndex -1
            ]
        }
    )


let private dayHeader (date: DateOnly) days isToday = html.inject <| fun (store: IShareStore) ->
    adaptiview(){
        let! i18n = store.UseI18n()
        let! theme = store.UseThemeValue()
        let! showNext, showPreview =
            adaptive {
                let! startTime = store.UseStartTime()
                let! viewType = store.UseViewType()
                return
                    match viewType with
                    | ViewType.Day -> false, false
                    | ViewType.Week ->
                        let canNext = date = startTime.AddDays(days - 1)
                        let canPreview = date = startTime
                        canNext, canPreview
            }

        div(){
            styles [ yield! lineStyles(); style.userSelectNone ]
            childContent [
                if showPreview then
                    MudIconButton'(){
                        Icon Icons.Filled.ArrowBackIos
                        OnClick (fun _ -> store.GotoNextOrPreviousDays false)
                        Styles [ style.opacity 0.6; style.marginRight -10 ]
                    }
                div(){
                    styles [
                        style.fontSize 14; style.textAlignCenter; style.width (length.perc 100)
                        style.padding (length.px 12, length.px (if showNext then 0 else 12), length.px 12, length.px (if showPreview then 0 else 12))
                        style.margin (length.px 0, length.px (if showNext then -12 else 0), length.px 0, length.px (if showPreview then -12 else 0))
                        if isToday then
                            style.color (string theme.Palette.TextPrimary)
                        else
                            style.color (string theme.Palette.TextSecondary)
                    ]
                    childContent [
                        html.text  (date.DayOfWeek |> formatWeekDay i18n)
                        div(){
                            styles [ style.fontSize 10; style.paddingTop 4; style.displayFlex; style.alignItemsCenter; style.justifyContentCenter ]
                            childContent [ 
                                html.text (date.ToString("yyyy/MM/dd"))
                                if isToday then
                                    spaceH2
                                    currentTime
                            ]
                        }
                    ]
                }
                if showNext then
                    MudIconButton'(){
                        Icon Icons.Filled.ArrowForwardIos
                        OnClick (fun _ -> store.GotoNextOrPreviousDays true)
                        Styles [ style.opacity 0.6; style.marginLeft -10 ]
                    }
            ]
        }
    }


let schedulerBar log = html.inject <| fun (store: IShareStore) ->
    adaptiview(){
        let! theme = store.UseThemeValue()

        match log.Schedule with
        | Schedule.Alarm s ->
            div(){
                styles [ style.positionRelative; style.height 12 ]
                childContent [
                    MudIcon'(){
                        Styles [
                            style.height 12; style.width 12
                            style.positionAbsolute; style.top 0
                            style.custom ("left", $"calc({int(s.ToTimeSpan().TotalSeconds) * 100 / secondsOfDay}%% - {6}px)")
                            style.color (theme.Palette.Warning.ToString())
                        ]
                        Icon Icons.Filled.Alarm
                    }
                ]
            }
        | Schedule.Range (s, e) ->
            div(){
                styles [ style.positionRelative; style.height 4 ]
                childContent [
                    div(){
                        styles [
                            style.height 4; style.backgroundColor (theme.Palette.Warning.ToString())
                            style.positionAbsolute; style.top 0; style.bottom 0
                            style.left (length.percent(int(s.ToTimeSpan().TotalSeconds) * 100 / secondsOfDay))
                            style.width (length.percent(int((e - s).TotalSeconds) * 100 / secondsOfDay))
                        ]
                    }
                ]
            }
        | Schedule.Anytime ->
            html.none
    }


let logsDaysView (days: int) = html.inject ($"days-view-{days}", fun (store: IShareStore, hook: IComponentHook, logsSvc: ILogsService, settingsSvc: ISettingsService, platformSvc: IPlatformService, dialog: IDialogService, snackbar: ISnackbar) ->
    let startTime = store.UseStartTime()
    let innerWidth = store.UseInnerWidth()
    let filter = store.UseFilter()

    let today = cval(DateOnly.FromDateTime DateTime.Now)
    let canDragToNextWeek = hook.UseStore false
    let draggingLog = cval Option<DragingLog>.None
    let isLoading = hook.UseStore false
    let logs = cval Map.empty<DateOnly, Logs>
    
    let isMouseEnter = hook.UseStore -1
    let isMouseEnterFinal = cval -1
    
    isMouseEnter.Observable
    |> Observable.throttle (TimeSpan.FromMilliseconds 100)
    |> Observable.subscribe isMouseEnterFinal.Publish
    |> hook.AddDispose


    let loadLogs (date: DateOnly) =
        logsSvc.LoadLogs date
        |> Task.map (function
            | Ok _ -> ()
            | Error e -> snackbar.Add(e, Severity.Error) |> ignore
        )

    let loadAllLogs (startDate: DateOnly) =
        task {
            isLoading.Publish true

            if draggingLog.Value |> Option.isNone then
                logsSvc.ClearLogsCache()

            for i in [0..6] do
                do! loadLogs (startDate.AddDays(i))

            isLoading.Publish false
        }
        |> ignore


    let dragToNextWeek (x: float) =
        let delta = 20.
        let width = float innerWidth.Value

        if draggingLog.Value |> Option.isSome && canDragToNextWeek.Current then
            if x < delta then
                startTime.Publish (fun s -> s.AddDays -7)
                canDragToNextWeek.Publish false
            else
                if width - x < delta then
                    startTime.Publish (fun s -> s.AddDays 7)
                    canDragToNextWeek.Publish false

        let threshhold = delta + 10.
        if (x < width / 2. && x > threshhold) || (x > width / 2. && width - x > threshhold) then
            canDragToNextWeek.Publish true


    let handleDrop (dragingLog': DragingLog option) (targetDate, targetLog) =
        let handleResult onOk =
            Observable.ofTask
            >> Observable.subscribe (function
                | Error WriteDataError.DataIsChanged ->
                    loadAllLogs startTime.Value
                    snackbar.Add("My logs is changed outsize of the app, will reload it now", Severity.Warning) |> ignore
                | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
                | Ok _ -> onOk())
            >> hook.AddDispose
            
        match dragingLog', targetLog with
        | Some source, None when source.Date <> targetDate ->
            taskResult {
                do! logsSvc.CreateLog (targetDate, source.Log)
                do! logsSvc.ModifyLog (source.Date, source.Log, true)
            }
            |> handleResult (fun _ ->
                loadLogs(targetDate) |> ignore
                loadLogs(source.Date) |> ignore
            )
        | Some source, Some targetLog ->
            logsSvc.OrderLog(source.Date, source.Log, targetDate, targetLog)
            |> handleResult ignore
        | _ ->
            ()

        draggingLog.Publish None


    hook.OnFirstAfterRender.Add <| fun _ ->
        hook.AddDisposes [
            logsSvc.Logs.AddLazyCallback logs.Publish
            startTime.AddLazyCallback loadAllLogs
            settingsSvc.Settings.AddLazyCallback (fun _ -> startTime.Value |> loadAllLogs)

            TimeSpan.FromSeconds 1
            |> Observable.interval
            |> Observable.subscribe (fun _ -> DateOnly.FromDateTime DateTime.Now |> today.Publish)

            today.AddLazyCallback (fun today ->
                if today > startTime.Value.AddDays(days - 1) then
                    store.GoToToday settingsSvc
            )
        ]

        loadAllLogs startTime.Value


    adaptiview(){
        let! settings = settingsSvc.Settings
        let! windowSize = store.UseWindowSize()
        let! bgColor = store.UsePreferredBackground()
        let! today = today
        let! startTime' = startTime

        let dialogOptions =
            DialogOptions(
                FullScreen = (windowSize = Small || windowSize = ExtraSmall),
                MaxWidth =
                    match windowSize with
                    | Small | ExtraSmall -> MaxWidth.Large
                    | _ -> MaxWidth.Medium)

        html.watch (isLoading, function
            | true ->
                MudProgressLinear'(){
                    Size Size.Small
                    Color Color.Success
                    Indeterminate true
                }
            | false ->
                html.none
        )
        MudSwipeArea'(){
            Styles [
                style.height (length.percent 100); style.positionRelative
                style.displayFlex; style.flexDirectionRow; style.alignItemsStretch
            ]
            OnSwipe (function
                | SwipeDirection.LeftToRight -> store.GotoNextOrPreviousDays false
                | SwipeDirection.RightToLeft -> store.GotoNextOrPreviousDays true
                | _ -> ()
            )
            childContent [
                for indexOfWeek in [0..(days - 1)] do
                    let date = startTime'.AddDays indexOfWeek
                    let isToday = date = today

                    div(){
                        styles [
                            style.height (length.percent 100); style.flex 1; style.overflowHidden
                            style.positionRelative; style.displayFlex; style.flexDirectionColumn; style.alignItemsStretch
                            if isToday then
                                style.boxShadow $"0 0 15px {(Utilities.MudColor(bgColor).SetAlpha(0.6).ChangeLightness(0.5).ToString())}"
                                yield! blurStyles (Utilities.MudColor(bgColor).SetAlpha(0.3).ChangeLightness(0.2).ToString(), 20)
                            elif date.DayOfWeek = DayOfWeek.Saturday || date.DayOfWeek = DayOfWeek.Sunday then
                                style.backgroundColor (Utilities.MudColor(bgColor).SetAlpha(0.15).ChangeLightness(0.08).ToString())
                            if indexOfWeek <> 6 then
                                style.borderRight (length.px 1, borderStyle.dashed, (Utilities.MudColor(bgColor).SetAlpha(0.4).ChangeLightness(0.3).ToString()))
                        ]
                        ondblclick (fun _ ->
                            dialog.Show
                                (dialogOptions
                                ,logDialog (date, Action.CreateLog) false
                                    (fun _ ->
                                        loadLogs date |> ignore
                                        if date <> today then
                                            loadLogs today |> ignore))
                        )
                        childContent [
                            dayHeader date days isToday
                            adaptiview(){
                                let! logs = logs
                                let! draggingLog' = draggingLog
                                let! isMouseEnterFinal = isMouseEnterFinal

                                let day = date
                                let logsOfDay = Map.tryFind day logs
                                    
                                let showTimeLine = 
                                    logsOfDay
                                    |> Option.map (fun x -> x.Logs) |> Option.defaultValue []
                                    |> List.exists (fun x -> match x.Schedule with Schedule.Alarm _ | Schedule.Range _ -> true | _ -> false)

                                if not settings.EnableHideTimeline && isToday && showTimeLine then
                                    currentTimeline

                                div(){
                                    styles [
                                        style.height (length.percent 100)
                                        style.displayFlex; style.flexDirectionColumn
                                        style.opacity (
                                            if today > date && isMouseEnterFinal <> indexOfWeek then 0.85
                                            elif isToday then 1.0
                                            else 0.95
                                        )
                                        if isMouseEnterFinal = indexOfWeek || isToday || days = 1
                                        then style.overflowYAuto
                                        else style.overflowHidden
                                    ]
                                    onmousemove (fun _ -> isMouseEnter.Publish indexOfWeek)
                                    stopPropagation "ondrop" true
                                    stopPropagation "ondragenter" true
                                    stopPropagation "ondragend" true
                                    stopPropagation "ondragover" true
                                    stopPropagation "ondragleave" true
                                    stopPropagation "ondragstart" true
                                    preventDefault "ondragover" true
                                    preventDefault "ondragenter" true
                                    preventDefault "ondrop" true
                                    ondragenter ignore
                                    ondragover (fun e -> dragToNextWeek e.ClientX)
                                    ondrop (fun _ -> handleDrop draggingLog' (day, None))
                                    childContent [
                                        match logsOfDay with
                                        | Some logsOfDay when logsOfDay.Logs.Length > 0 ->
                                            adaptiview(){
                                                let! filter = filter

                                                let logs =
                                                    if filter.Tags.Length = 0 then
                                                        logsOfDay.Logs
                                                    else
                                                        logsOfDay.Logs
                                                        |> List.filter (fun log -> filter.Tags |> Seq.exists (fun tag -> Seq.contains tag log.Tags))

                                                for log in logs do
                                                    div(){
                                                        styles [
                                                            if log.Status = Status.Done then style.opacity 0.7
                                                            style.marginTop 8; style.marginBottom 10
                                                        ]
                                                        draggable true
                                                        ondragstart (fun e ->
                                                            e.DataTransfer.DropEffect <- "move"
                                                            e.DataTransfer.EffectAllowed <- "move"
                                                            draggingLog.Publish (Some { Date = day; Log = log })
                                                            canDragToNextWeek.Publish true
                                                        )
                                                        preventDefault "ondragover" true
                                                        preventDefault "ondragenter" true
                                                        stopPropagation "ondrop" true
                                                        ondragenter ignore
                                                        ondragover (fun e -> dragToNextWeek e.ClientX)
                                                        ondrop (fun _ -> handleDrop draggingLog' (day, Some log))
                                                        childContent [
                                                            logItem (date, log) (fun _ -> 
                                                                loadLogs date |> ignore
                                                                if date <> today then loadLogs today |> ignore)
                                                            schedulerBar log
                                                        ]
                                                    }
                                            }
                                        | _ ->
                                            html.none
                                    ]
                                }
                            }
                        ]
                    }
            ]
        }
    })
