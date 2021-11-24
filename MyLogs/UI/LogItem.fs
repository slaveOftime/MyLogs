[<AutoOpen>]
module MyLogs.UI.LogItem

open System
open System.Linq
open FSharp.Control.Reactive
open FSharp.Data.Adaptive
open Feliz
open Fun.Blazor
open MudBlazor
open Fun.Result
open MyLogs.Core
open MyLogs.Services
open type Styles


let private logHeader (log: Log) = html.inject <| fun (store: IShareStore, settingsSvc: ISettingsService, hook: IComponentHook) ->
    adaptiview(){
        let! settings = settingsSvc.Settings

        div(){
            styles [
                style.positionAbsolute; style.top -8; style.left 0; style.right 0; style.zIndex 0
                style.paddingRight 4; style.paddingLeft 4
                yield! lineStyles(); style.justifyContentSpaceBetween
            ]
            childContent [
                if not settings.EnableHideHeaderTags then
                    div(){
                        styles [ yield! lineStyles() ]
                        childContent [
                            for tag in log.Tags.Take 3 do
                                let tagColor = store.GetTagColor tag
                                MudTooltip'(){
                                    Text tag
                                    Arrow true
                                    Color Color.Primary
                                    childContent [
                                        div(){
                                            styles [
                                                style.backgroundColor tagColor; style.color "white"; style.overflowHidden
                                                style.borderRadius 8; style.height 16; style.fontSize 8; style.whiteSpaceNowrap
                                                style.textAlignCenter; style.padding (length.px 3, length.px 3); style.marginRight 2
                                            ]
                                            childContent (tag |> trim 3)
                                        }
                                    ]
                                }
                        ]
                    }
                spaceHF
                match log.Status with
                | Status.Done ->
                    MudIcon'(){
                        Icon Icons.Filled.DoneOutline
                        Color Color.Success
                    }
                | Status.Created ->
                    ()
            ]
        }
    }


let private logActions (date, log) onSaved = html.inject <| fun (logsService: ILogsService, snackbar: ISnackbar, hook: IComponentHook, dialog: IDialogService, store: IShareStore) ->
    let duplicate() =
        let newLog =
            { log with
                Status = Status.Created
                Detail =
                    match log.Detail with
                    | Detail.Markdown _ -> log.Detail
                    | Detail.Todo ls -> ls |> List.map (fun x -> { x with IsDone = false }) |> Detail.Todo }
        logsService.CreateLog (date, newLog)
        |> Observable.ofTask
        |> Observable.subscribe (function
            | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
            | Ok _ -> ())
        |> hook.AddDispose

    let markAsDone() =
        logsService.MarkLogAsDone (date, log)
        |> Observable.ofTask
        |> Observable.subscribe (function
            | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
            | Ok _ -> ())
        |> hook.AddDispose


    adaptiview(){
        let! windowSize = store.UseWindowSize()
        let size' = if windowSize = ExtraSmall || windowSize = Small then Size.Medium else Size.Small
    
        let dialogOptions =
            DialogOptions(
                FullScreen = (windowSize = Small || windowSize = ExtraSmall),
                MaxWidth =
                    match windowSize with
                    | Small | ExtraSmall -> MaxWidth.Large
                    | _ -> MaxWidth.Medium)

        div(){
            styles [ style.displayFlex; style.alignItemsCenter; style.justifyContentFlexEnd; style.overflowXAuto ]
            childContent [
                MudIconButton'(){
                    Size size'
                    Icon Icons.Filled.Transform
                    OnClick (fun _ ->
                        let x = 123
                        dialog.Show (fun dia ->
                            moveLogToDateDialog (date, log)
                                (fun _ -> dia.Close())
                                (fun _ -> dia.Close())
                        ))
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
                    MudIconButton'(){
                        Size size'
                        Icon Icons.Filled.Done
                        OnClick (ignore >> markAsDone)
                    }
                    spaceH2
                MudIconButton'(){
                    Size size'
                    Icon Icons.Filled.RemoveRedEye
                    OnClick (fun _ ->
                        dialog.Show
                            (dialogOptions
                            ,logDialog (date, Action.EditLog log) true onSaved))
                }
                spaceH2
                MudIconButton'(){
                    Size size'
                    Icon Icons.Filled.Delete
                    OnClick (fun _ ->
                        dialog.Show
                            (dialogOptions
                            ,logDialog (date, Action.DeleteLog log) true onSaved))
                }
                spaceH2
                MudIconButton'(){
                    Size size'
                    Icon Icons.Filled.CopyAll
                    OnClick (ignore >> duplicate)
                }
            ]
        }
    }


let logItem (date: DateOnly, log: Log) onSaved = html.inject (log.Id, fun (store: IShareStore, hook: IComponentHook, logsService: ILogsService, dialog: IDialogService) ->
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
            logsService.ModifyLog (date, { log with Detail = detail' }, false)
            |> TaskResult.mapError string
            |> Observable.ofTask
            |> Observable.subscribe (function
                | Ok _ -> 
                    try
                        editingContent.Publish None; detail.Publish detail'; onSaved()
                        statuses.Publish (fun x -> List.append x ["Log changed successfully"])
                    with _ ->
                        ()
                | Error e ->
                    statuses.Publish (fun x -> List.append x [e])
            )
            |> hook.AddDispose
        else
            editingContent.Publish None


    hook.OnFirstAfterRender.Add <| fun _ ->
        hook.AddDisposes [
            TimeSpan.FromSeconds 1
            |> Observable.interval
            |> Observable.subscribe (fun _ -> DateOnly.FromDateTime DateTime.Now |> today.Publish)
            
            isMouseEnter.Observable
            |> Observable.throttle (TimeSpan.FromMilliseconds 100)
            |> Observable.subscribe isMouseEnterFinal.Publish
        ]


    adaptiview(){
        let! i18n = store.UseI18n()
        let! windowSize = store.UseWindowSize()
        let! theme = store.UseTheme()
        let theme = match theme with Dark t | Light t -> t
        let defaultColor = theme.Palette.Primary.ToString()
        
        let! tags = store.UseTagsMap()
        let! editingContent' = editingContent

        let dialogOptions =
            DialogOptions(
                FullScreen = (windowSize = Small || windowSize = ExtraSmall),
                MaxWidth =
                    match windowSize with
                    | Small | ExtraSmall -> MaxWidth.Large
                    | _ -> MaxWidth.Medium)

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
        let activeBorderColor (x: string) = Utilities.MudColor(x).SetAlpha(0.9).ChangeLightness(0.1).ToString()


        let todoEditor showInput isDisabled todos =
            adaptiview(){
                let! todos', setTodos = cval(todos).WithSetter()
                
                div(){
                    styles [ style.custom ("zoom", "0.84"); style.marginLeft -14 ]
                    childContent [
                        todoEditor Size.Small showInput isDisabled false todos' (
                            if not showInput && isDisabled then
                                Detail.Todo >> saveContent
                            else
                                setTodos
                        )
                    ]
                }
                if not isDisabled then
                    div(){
                        styles [ yield! lineStyles(); style.justifyContentFlexEnd ]
                        childContent [
                            MudIconButton'(){
                                Size Size.Small
                                Icon Icons.Filled.Cancel
                                OnClick (fun _ -> editingContent.Publish None)
                            }
                            spaceH2
                            MudIconButton'(){
                                Size Size.Small
                                Icon Icons.Filled.Save
                                OnClick (fun _ -> Detail.Todo todos' |> saveContent)
                                Disabled (todos' = todos)
                            }
                        ]
                    }
            }


        div(){
            styles [
                style.padding 10; style.fontSize 11; style.fontWeight 100; style.positionRelative; style.color (string theme.Palette.TextPrimary)
                match tag with
                | None when isActive ->
                    style.border (length.px 4, borderStyle.solid, activeBorderColor defaultColor)
                | None ->
                    style.borderBottom (length.px 4, borderStyle.solid, normalBorderColor defaultColor)
                | Some t when isActive ->
                    style.border ("4px", borderStyle.solid, activeBorderColor t.Color)
                | Some t ->
                    style.borderBottom (length.px 4, borderStyle.solid, normalBorderColor t.Color)
            ]
            ondblclick (fun _ ->
                match log.Detail with
                | Detail.Markdown str ->
                    if str.Length <= charLimit &&
                        str.Split("\r\n").Length <= lineLimit &&
                        log.Status <> Status.Done
                    then
                        editingContent.Publish (Some log.Detail)
                    else
                        dialog.Show
                            (dialogOptions
                            ,logDialog (date, Action.EditLog log) false onSaved)
                | Detail.Todo _ ->
                    editingContent.Publish (Some log.Detail)
            )
            preventDefault "ondblclick" true
            stopPropagation "ondblclick" true
            onmouseover (fun _ -> try isMouseEnter.Publish true with _ -> ())
            onmouseout (fun _ -> try isMouseEnter.Publish false with _ -> ())
            childContent [
                div(){
                    styles [
                        style.positionAbsolute; style.left 0; style.right 0; style.top 0; style.bottom 0; style.userSelectNone; style.zIndex -1
                        match tag with
                        | None -> style.backgroundColor (normalBgColor defaultColor)
                        | Some t -> style.backgroundColor (normalBgColor t.Color)
                    ]
                }
                logHeader log
                match editingContent' with
                | None ->
                    adaptiview(){
                        match! detail with
                        | Detail.Markdown str ->
                            div(){
                                styles [ style.whiteSpaceNowrap; style.overflowHidden; style.paddingTop 4 ]
                                childContent [ str |> trim charLimit |> trimLines lineLimit |> markdown ]
                            }
                        | Detail.Todo todos ->
                            todoEditor false true todos
                    }
                | Some (Detail.Markdown x) ->
                    MudTextField'(){
                        Lines 10
                        Value x
                        Label i18n.App.LogDialog.Detail
                        ValueChanged (Detail.Markdown >> Some >> editingContent.Publish)
                        AutoFocus true
                        OnBlur (fun _ -> editingContent.Value |> Option.iter saveContent)
                        Styles [ style.fontSize (length.rem 0.9) ]
                        draggable true
                        preventDefault "ondragstart" true
                        stopPropagation "ondragstart" true
                    }
                | Some (Detail.Todo todos) ->
                    todoEditor true false todos
                adaptiview(){
                    let! isHover = isMouseEnterFinal
                    if isHover && editingContent'.IsNone then
                        spaceV1
                        logActions (date, log) onSaved
                }
            ]
        }
    })
