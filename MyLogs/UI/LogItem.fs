[<AutoOpen>]
module MyLogs.UI.LogItem

open System
open System.Linq
open FSharp.Control.Reactive
open FSharp.Data.Adaptive
open Fun.Blazor
open MudBlazor
open Fun.Result
open MyLogs.Core
open MyLogs.Services


let private logHeader (log: Log) =
    html.inject (fun (store: IShareStore, settingsSvc: ISettingsService, hook: IComponentHook) ->
        adaptiview () {
            let! settings = settingsSvc.Settings

            div {
                style'' {
                    positionAbsolute
                    top -8
                    left 0
                    right 0
                    zIndex 0
                    paddingRight 4
                    paddingLeft 4
                    justifyContentSpaceBetween
                    lineStyles
                }
                if not settings.EnableHideHeaderTags then
                    div {
                        style'' { lineStyles }
                        fragment {
                            for tag in log.Tags.Take 3 do
                                let tagColor = store.GetTagColor tag
                                MudTooltip'() {
                                    Text tag
                                    Arrow true
                                    Color Color.Primary
                                    div {
                                        style'' {
                                            backgroundColor tagColor
                                            color "white"
                                            overflowHidden
                                            borderRadius 8
                                            height 16
                                            fontSize 8
                                            whiteSpaceNowrap
                                            textAlignCenter
                                            padding 3
                                            marginRight 2
                                        }
                                        tag |> trim 3
                                    }
                                }
                        }
                    }
                spaceHF
                match log.Status with
                | Status.Done ->
                    MudIcon'() {
                        Icon Icons.Filled.DoneOutline
                        Color Color.Success
                    }
                | Status.Created -> ()
            }
        }
    )


let private logActions (date, log) onSaved =
    html.inject (fun (logsService: ILogsService, snackbar: ISnackbar, hook: IComponentHook, dialog: IDialogService, store: IShareStore) ->
        let duplicate () =
            let newLog =
                { log with
                    Status = Status.Created
                    Detail =
                        match log.Detail with
                        | Detail.Markdown _ -> log.Detail
                        | Detail.Todo ls -> ls |> List.map (fun x -> { x with IsDone = false }) |> Detail.Todo
                }
            logsService.CreateLog(date, newLog)
            |> Observable.ofTask
            |> Observable.subscribe (
                function
                | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
                | Ok _ -> ()
            )
            |> hook.AddDispose

        let markAsDone () =
            logsService.MarkLogAsDone(date, log)
            |> Observable.ofTask
            |> Observable.subscribe (
                function
                | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
                | Ok _ -> ()
            )
            |> hook.AddDispose


        adaptiview () {
            let! windowSize = store.UseWindowSize()
            let size' =
                if windowSize = ExtraSmall || windowSize = Small then
                    Size.Medium
                else
                    Size.Small

            let dialogOptions =
                DialogOptions(
                    FullScreen = (windowSize = Small || windowSize = ExtraSmall),
                    MaxWidth =
                        match windowSize with
                        | Small
                        | ExtraSmall -> MaxWidth.Large
                        | _ -> MaxWidth.Medium
                )

            div {
                style'' {
                    displayFlex
                    alignItemsCenter
                    justifyContentFlexEnd
                    overflowXAuto
                }
                MudIconButton'() {
                    Size size'
                    Icon Icons.Filled.Transform
                    OnClick(fun _ ->
                        let x = 123
                        dialog.Show(fun dia -> moveLogToDateDialog (date, log) (fun _ -> dia.Close()) (fun _ -> dia.Close()))
                    )
                }
                spaceH2
                //MudIconButton'(){
                //    Size size'
                //    Icon Icons.Filled.EditNote
                //    OnClick (fun _ ->
                //        dialog.Show (fun dia ->
                //            logDialog (date, Action.EditLog log) false
                //                (fun _ -> onSaved(); dia.Close())
                //                (fun _ -> dia.Close())
                //        ))
                //}
                //spaceH2
                match log.Status with
                | Status.Done -> ()
                | Status.Created ->
                    MudIconButton'() {
                        Size size'
                        Icon Icons.Filled.Done
                        OnClick(ignore >> markAsDone)
                    }
                    spaceH2
                MudIconButton'() {
                    Size size'
                    Icon Icons.Filled.RemoveRedEye
                    OnClick(fun _ -> dialog.Show(dialogOptions, logDialog (date, Action.EditLog log) true onSaved))
                }
                spaceH2
                MudIconButton'() {
                    Size size'
                    Icon Icons.Filled.Delete
                    OnClick(fun _ -> dialog.Show(dialogOptions, logDialog (date, Action.DeleteLog log) true onSaved))
                }
                spaceH2
                MudIconButton'() {
                    Size size'
                    Icon Icons.Filled.CopyAll
                    OnClick(ignore >> duplicate)
                }
            }
        }
    )


let logItem (date: DateOnly, log: Log) onSaved =
    html.inject (
        log.Id,
        fun (store: IShareStore, hook: IComponentHook, logsService: ILogsService, dialog: IDialogService) ->
            let statuses = store.UseStatuses()
            let today = cval (DateOnly.FromDateTime(DateTime.Now))
            let isMouseEnter = hook.UseStore false
            let isMouseEnterFinal = cval false
            let detail = cval log.Detail
            let editingContent = cval None
            let charLimit = 400
            let lineLimit = 8

            let saveContent detail' =
                if detail' <> log.Detail then
                    logsService.ModifyLog(date, { log with Detail = detail' }, false)
                    |> TaskResult.mapError string
                    |> Observable.ofTask
                    |> Observable.subscribe (
                        function
                        | Ok _ ->
                            try
                                editingContent.Publish None
                                detail.Publish detail'
                                onSaved ()
                                statuses.Publish(fun x -> List.append x [ "Log changed successfully" ])
                            with
                                | _ -> ()
                        | Error e -> statuses.Publish(fun x -> List.append x [ e ])
                    )
                    |> hook.AddDispose
                else
                    editingContent.Publish None


            hook.OnFirstAfterRender.Add
            <| fun _ ->
                hook.AddDisposes [
                    TimeSpan.FromSeconds 1
                    |> Observable.interval
                    |> Observable.subscribe (fun _ -> DateOnly.FromDateTime DateTime.Now |> today.Publish)

                    isMouseEnter.Observable
                    |> Observable.throttle (TimeSpan.FromMilliseconds 100)
                    |> Observable.subscribe isMouseEnterFinal.Publish
                ]


            adaptiview () {
                let! i18n = store.UseI18n()
                let! windowSize = store.UseWindowSize()
                let! theme = store.UseTheme()
                let theme =
                    match theme with
                    | Dark t
                    | Light t -> t
                let defaultColor = theme.Palette.Primary.ToString()

                let! tags = store.UseTagsMap()
                let! editingContent' = editingContent

                let dialogOptions =
                    DialogOptions(
                        FullScreen = (windowSize = Small || windowSize = ExtraSmall),
                        MaxWidth =
                            match windowSize with
                            | Small
                            | ExtraSmall -> MaxWidth.Large
                            | _ -> MaxWidth.Medium
                    )

                let tag =
                    option {
                        let! tag = log.Tags |> List.tryHead
                        return! tags |> Map.tryFind tag
                    }

                let isActive =
                    match editingContent' with
                    | Some _ -> true
                    | _ -> false

                let normalBgColor (x: string) = Utilities.MudColor(x).SetAlpha(0.2).ToString()
                let normalBorderColor (x: string) = Utilities.MudColor(x).SetAlpha(0.7).ToString()
                let activeBorderColor (x: string) =
                    Utilities.MudColor(x).SetAlpha(0.9).ChangeLightness(0.1).ToString()


                let todoEditor showInput isDisabled todos =
                    adaptiview () {
                        let! todos', setTodos = cval(todos).WithSetter()

                        div {
                            style'' {
                                custom "zoom" "0.84"
                                marginLeft -14
                            }
                            todoEditor
                                Size.Small
                                showInput
                                isDisabled
                                false
                                todos'
                                (if not showInput && isDisabled then Detail.Todo >> saveContent else setTodos)
                        }
                        if not isDisabled then
                            div {
                                style'' {
                                    lineStyles
                                    justifyContentFlexEnd
                                }
                                MudIconButton'() {
                                    Size Size.Small
                                    Icon Icons.Filled.Cancel
                                    OnClick(fun _ -> editingContent.Publish None)
                                }
                                spaceH2
                                MudIconButton'() {
                                    Size Size.Small
                                    Icon Icons.Filled.Save
                                    OnClick(fun _ -> Detail.Todo todos' |> saveContent)
                                    Disabled(todos' = todos)
                                }
                            }
                    }


                div {
                    style'' {
                        padding 10
                        fontSize 11
                        fontWeight 100
                        positionRelative
                        color (string theme.Palette.TextPrimary)
                        match tag with
                        | None when isActive -> css'' { border $"4px solid {activeBorderColor defaultColor}" }
                        | None -> css'' { borderBottom $"4px solid {normalBorderColor defaultColor}" }
                        | Some t when isActive -> css'' { border $"4px solid {activeBorderColor t.Color}" }
                        | Some t -> css'' { borderBottom $"4px solid {normalBorderColor t.Color}" }
                    }
                    ondblclick (fun _ ->
                        match log.Detail with
                        | Detail.Markdown str ->
                            if str.Length <= charLimit && str.Split("\r\n").Length <= lineLimit && log.Status <> Status.Done then
                                editingContent.Publish(Some log.Detail)
                            else
                                dialog.Show(dialogOptions, logDialog (date, Action.EditLog log) false onSaved)
                        | Detail.Todo _ -> editingContent.Publish(Some log.Detail)
                    )
                    preventDefault "ondblclick" true
                    stopPropagation "ondblclick" true
                    onmouseover (fun _ ->
                        try
                            isMouseEnter.Publish true
                        with
                            | _ -> ()
                    )
                    onmouseout (fun _ ->
                        try
                            isMouseEnter.Publish false
                        with
                            | _ -> ()
                    )
                    div {
                        style'' {
                            positionAbsolute
                            left 0
                            right 0
                            top 0
                            bottom 0
                            userSelectNone
                            zIndex -1
                            backgroundColor (
                                match tag with
                                | None -> normalBgColor defaultColor
                                | Some t -> normalBgColor t.Color
                            )
                        }
                    }
                    logHeader log
                    match editingContent' with
                    | None ->
                        adaptiview () {
                            match! detail with
                            | Detail.Markdown str ->
                                div {
                                    style'' {
                                        whiteSpaceNowrap
                                        overflowHidden
                                        paddingTop 4
                                    }
                                    str |> trim charLimit |> trimLines lineLimit |> markdown
                                }
                            | Detail.Todo todos -> todoEditor false true todos
                        }
                    | Some (Detail.Markdown x) ->
                        MudTextField'() {
                            style'' { fontSize "0.9rem" }
                            Lines 10
                            Value x
                            Label i18n.App.LogDialog.Detail
                            ValueChanged(Detail.Markdown >> Some >> editingContent.Publish)
                            AutoFocus true
                            OnBlur(fun _ -> editingContent.Value |> Option.iter saveContent)
                            draggable true
                            preventDefault "ondragstart" true
                            stopPropagation "ondragstart" true
                        }
                    | Some (Detail.Todo todos) -> todoEditor true false todos
                    adaptiview () {
                        let! isHover = isMouseEnterFinal
                        if isHover && editingContent'.IsNone then
                            spaceV1
                            logActions (date, log) onSaved
                    }
                }
            }
    )
