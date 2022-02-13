[<AutoOpen>]
module MyLogs.UI.LogsDaysView

open System
open FSharp.Control.Reactive
open FSharp.Data.Adaptive
open Fun.Result
open Fun.Blazor
open MudBlazor
open MyLogs.Core
open MyLogs.Services


type private DragingLog = { Date: DateOnly; Log: Log }


let private secondsOfDay = 60 * 60 * 24


let private currentTime =
    html.inject (fun (hook: IComponentHook) ->
        let time = hook.UseStore DateTimeOffset.Now

        hook.OnFirstAfterRender.Add(fun _ ->
            TimeSpan.FromSeconds 1
            |> Observable.interval
            |> Observable.subscribe (fun _ -> time.Publish DateTimeOffset.Now)
            |> hook.AddDispose
        )

        html.watch (time, (fun time -> html.text (time.ToString("HH:mm:ss"))))
    )


let private currentTimeline =
    html.inject (fun (hook: IComponentHook) ->
        let time = hook.UseStore DateTime.Now

        hook.OnFirstAfterRender.Add
        <| fun _ ->
            TimeSpan.FromMinutes 1
            |> Observable.interval
            |> Observable.subscribe (fun _ -> time.Publish DateTime.Now)
            |> hook.AddDispose

        html.watch (
            time,
            fun time ->
                let widthPerc =
                    int (TimeOnly(time.Hour, time.Minute, time.Second).ToTimeSpan().TotalSeconds) * 100 / secondsOfDay
                    |> sprintf "%d%%"
                div {
                    style'' {
                        positionAbsolute
                        top 0
                        bottom 0
                        left 0
                        width widthPerc
                        borderRightWidth 1
                        borderRightStyle "dashed"
                        borderRightColor "rgb(196 232 123 / 35%)"
                        zIndex -1
                    }
                }
        )
    )

let private dayHeader (date: DateOnly) days isToday =
    html.inject
    <| fun (store: IShareStore) ->
        adaptiview () {
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

            div {
                style'' {
                    lineStyles
                    userSelectNone
                }
                if showPreview then
                    MudIconButton'() {
                        style'' {
                            opacity 0.6
                            marginRight -20
                            marginLeft 10
                        }
                        Size Size.Small
                        Icon Icons.Filled.ArrowBackIos
                        OnClick(fun _ -> store.GotoNextOrPreviousDays false)
                    }
                div {
                    style'' {
                        fontSize 14
                        textAlignCenter
                        width "100%"
                        padding 12 (if showNext then 0 else 12) 12 (if showPreview then 0 else 12)
                        margin 0 (if showNext then -12 else 0) 0 (if showPreview then -12 else 0)
                        color (
                            if isToday then
                                string theme.Palette.TextPrimary
                            else
                                string theme.Palette.TextSecondary
                        )
                    }
                    html.text (date.DayOfWeek |> formatWeekDay i18n)
                    div {
                        style'' {
                            fontSize 10
                            paddingTop 4
                            displayFlex
                            alignItemsCenter
                            justifyContentCenter
                        }
                        html.text (date.ToString("yyyy/MM/dd"))
                        if isToday then
                            spaceH2
                            currentTime
                    }
                }
                if showNext then
                    MudIconButton'() {
                        style'' {
                            opacity 0.6
                            marginLeft -20
                            marginRight 10
                        }
                        Size Size.Small
                        Icon Icons.Filled.ArrowForwardIos
                        OnClick(fun _ -> store.GotoNextOrPreviousDays true)
                    }
            }
        }


let schedulerBar log =
    html.inject (fun (store: IShareStore) ->
        adaptiview () {
            let! theme = store.UseThemeValue()

            match log.Schedule with
            | Schedule.Alarm s ->
                div {
                    style'' {
                        positionRelative
                        height 12
                    }
                    MudIcon'() {
                        style'' {
                            height 12
                            width 12
                            positionAbsolute
                            top 0
                            left $"calc({int (s.ToTimeSpan().TotalSeconds) * 100 / secondsOfDay}%% - {6}px)"
                            color (theme.Palette.Warning.ToString())
                        }
                        Icon Icons.Filled.Alarm
                    }
                }
            | Schedule.Range (s, e) ->
                div {
                    style'' {
                        positionRelative
                        height 4
                    }
                    div {
                        style'' {
                            height 4
                            backgroundColor (theme.Palette.Warning.ToString())
                            positionAbsolute
                            top 0
                            bottom 0
                            left (sprintf "%d%%" (int (s.ToTimeSpan().TotalSeconds) * 100 / secondsOfDay))
                            width (sprintf "%d%%" (int ((e - s).TotalSeconds) * 100 / secondsOfDay))
                        }
                    }
                }
            | Schedule.Anytime -> html.none
        }
    )


let logsDaysView (days: int) =
    html.inject (
        $"days-view-{days}",
        fun (store: IShareStore,
             hook: IComponentHook,
             logsSvc: ILogsService,
             settingsSvc: ISettingsService,
             dialog: IDialogService,
             snackbar: ISnackbar) ->
            let startTime = store.UseStartTime()
            let innerWidth = store.UseInnerWidth()
            let filter = store.UseFilter()

            let today = cval (DateOnly.FromDateTime DateTime.Now)
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
                |> Task.map (
                    function
                    | Ok _ -> ()
                    | Error e -> snackbar.Add(e, Severity.Error) |> ignore
                )

            let loadAllLogs (startDate: DateOnly) =
                task {
                    isLoading.Publish true

                    if draggingLog.Value |> Option.isNone then logsSvc.ClearLogsCache()

                    for i in [ 0 .. 6 ] do
                        do! loadLogs (startDate.AddDays(i))

                    isLoading.Publish false
                }
                |> ignore


            let dragToNextWeek (x: float) =
                let delta = 20.
                let width = float innerWidth.Value

                if draggingLog.Value |> Option.isSome && canDragToNextWeek.Current then
                    if x < delta then
                        startTime.Publish(fun s -> s.AddDays -7)
                        canDragToNextWeek.Publish false
                    else if width - x < delta then
                        startTime.Publish(fun s -> s.AddDays 7)
                        canDragToNextWeek.Publish false

                let threshhold = delta + 10.
                if (x < width / 2. && x > threshhold) || (x > width / 2. && width - x > threshhold) then
                    canDragToNextWeek.Publish true


            let handleDrop (dragingLog': DragingLog option) (targetDate, targetLog) =
                let handleResult onOk =
                    Observable.ofTask
                    >> Observable.subscribe (
                        function
                        | Error WriteDataError.DataIsChanged ->
                            loadAllLogs startTime.Value
                            snackbar.Add("My logs is changed outsize of the app, will reload it now", Severity.Warning)
                            |> ignore
                        | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
                        | Ok _ -> onOk ()
                    )
                    >> hook.AddDispose

                match dragingLog', targetLog with
                | Some source, None when source.Date <> targetDate ->
                    taskResult {
                        do! logsSvc.CreateLog(targetDate, source.Log)
                        do! logsSvc.ModifyLog(source.Date, source.Log, true)
                    }
                    |> handleResult (fun _ ->
                        loadLogs (targetDate) |> ignore
                        loadLogs (source.Date) |> ignore
                    )
                | Some source, Some targetLog -> logsSvc.OrderLog(source.Date, source.Log, targetDate, targetLog) |> handleResult ignore
                | _ -> ()

                draggingLog.Publish None


            hook.OnFirstAfterRender.Add
            <| fun _ ->
                hook.AddDisposes [
                    logsSvc.Logs.AddLazyCallback logs.Publish
                    startTime.AddLazyCallback loadAllLogs
                    settingsSvc.Settings.AddLazyCallback(fun _ -> startTime.Value |> loadAllLogs)

                    TimeSpan.FromSeconds 1
                    |> Observable.interval
                    |> Observable.subscribe (fun _ -> DateOnly.FromDateTime DateTime.Now |> today.Publish)

                    today.AddLazyCallback(fun today -> if today > startTime.Value.AddDays(days - 1) then store.GoToToday settingsSvc)
                ]

                loadAllLogs startTime.Value


            adaptiview () {
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
                            | Small
                            | ExtraSmall -> MaxWidth.Large
                            | _ -> MaxWidth.Medium
                    )

                html.watch (
                    isLoading,
                    function
                    | true ->
                        MudProgressLinear'() {
                            Size Size.Small
                            Color Color.Success
                            Indeterminate true
                        }
                    | false -> html.none
                )
                MudSwipeArea'() {
                    style'' {
                        height "100%"
                        positionRelative
                        displayFlex
                        flexDirectionRow
                        alignItemsStretch
                    }
                    OnSwipe(
                        function
                        | SwipeDirection.LeftToRight -> store.GotoNextOrPreviousDays false
                        | SwipeDirection.RightToLeft -> store.GotoNextOrPreviousDays true
                        | _ -> ()
                    )
                    fragment {
                        for indexOfWeek in [ 0 .. (days - 1) ] do
                            let date = startTime'.AddDays indexOfWeek
                            let isToday = date = today

                            div {
                                style'' {
                                    height "100%"
                                    overflowHidden
                                    positionRelative
                                    displayFlex
                                    flexGrow 1
                                    flexShrink 0
                                    flexBasis 0
                                    flexDirectionColumn
                                    alignItemsStretch
                                    if isToday then
                                        css'' {
                                            boxShadow $"0 0 15px {(Utilities.MudColor(bgColor).SetAlpha(0.6).ChangeLightness(0.5).ToString())}"
                                            blurStyles (Utilities.MudColor(bgColor).SetAlpha(0.3).ChangeLightness(0.2).ToString()) 20
                                        }
                                    elif date.DayOfWeek = DayOfWeek.Saturday || date.DayOfWeek = DayOfWeek.Sunday then
                                        css'' { backgroundColor (Utilities.MudColor(bgColor).SetAlpha(0.15).ChangeLightness(0.08).ToString()) }
                                    if indexOfWeek <> 6 then
                                        css'' {
                                            borderRight $"1px dashed {Utilities.MudColor(bgColor).SetAlpha(0.4).ChangeLightness(0.3).ToString()}"
                                        }
                                }
                                ondblclick (fun _ ->
                                    dialog.Show(
                                        dialogOptions,
                                        logDialog
                                            (date, Action.CreateLog)
                                            false
                                            (fun _ ->
                                                loadLogs date |> ignore
                                                if date <> today then loadLogs today |> ignore
                                            )
                                    )
                                )
                                dayHeader date days isToday
                                adaptiview () {
                                    let! logs = logs
                                    let! draggingLog' = draggingLog
                                    let! isMouseEnterFinal = isMouseEnterFinal

                                    let day = date
                                    let logsOfDay = Map.tryFind day logs

                                    let showTimeLine =
                                        logsOfDay
                                        |> Option.map (fun x -> x.Logs)
                                        |> Option.defaultValue []
                                        |> List.exists (fun x ->
                                            match x.Schedule with
                                            | Schedule.Alarm _
                                            | Schedule.Range _ -> true
                                            | _ -> false
                                        )

                                    if not settings.EnableHideTimeline && isToday && showTimeLine then
                                        currentTimeline

                                    div {
                                        style'' {
                                            height "100%"
                                            displayFlex
                                            flexDirectionColumn
                                            opacity (
                                                if today > date && isMouseEnterFinal <> indexOfWeek then 0.85
                                                elif isToday then 1.0
                                                else 0.95
                                            )
                                            if isMouseEnterFinal = indexOfWeek || isToday || days = 1 then
                                                css'' { overflowYAuto }
                                            else
                                                css'' { overflowHidden }
                                        }
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
                                        match logsOfDay with
                                        | Some logsOfDay when logsOfDay.Logs.Length > 0 ->
                                            adaptiview () {
                                                let! filter = filter

                                                let logs =
                                                    if filter.Tags.Length = 0 then
                                                        logsOfDay.Logs
                                                    else
                                                        logsOfDay.Logs
                                                        |> List.filter (fun log -> filter.Tags |> Seq.exists (fun tag -> Seq.contains tag log.Tags))

                                                fragment {
                                                    for log in logs do
                                                        div {
                                                            style'' {
                                                                marginTop 8
                                                                marginBottom 10
                                                                if log.Status = Status.Done then opacity 0.7
                                                            }
                                                            draggable true
                                                            ondragstart (fun e ->
                                                                e.DataTransfer.DropEffect <- "move"
                                                                e.DataTransfer.EffectAllowed <- "move"
                                                                draggingLog.Publish(Some { Date = day; Log = log })
                                                                canDragToNextWeek.Publish true
                                                            )
                                                            preventDefault "ondragover" true
                                                            preventDefault "ondragenter" true
                                                            stopPropagation "ondrop" true
                                                            ondragenter ignore
                                                            ondragover (fun e -> dragToNextWeek e.ClientX)
                                                            ondrop (fun _ -> handleDrop draggingLog' (day, Some log))
                                                            logItem
                                                                (date, log)
                                                                (fun _ ->
                                                                    loadLogs date |> ignore
                                                                    if date <> today then loadLogs today |> ignore
                                                                )
                                                            schedulerBar log
                                                        }
                                                }
                                            }
                                        | _ -> html.none
                                    }
                                }
                            }
                    }
                }
            }
    )
