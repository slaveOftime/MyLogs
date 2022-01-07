[<AutoOpen>]
module MyLogs.UI.LogDialog

open System
open FSharp.Data.Adaptive
open FSharp.Control.Reactive
open Feliz
open Fun.Blazor
open MudBlazor
open MyLogs.Core
open MyLogs.Services

open type Styles


type Action =
    | CreateLog
    | EditLog of Log
    | DeleteLog of Log


let todoEditor size' showInput isDisabled disableCheckbox (todos: TodoItem list) onChanged =
    html.inject
    <| fun (store: IShareStore) ->
        adaptiview () {
            let! i18n = store.UseI18n()
            div () {
                childContent [
                    for index, item in List.indexed todos do
                        div () {
                            styles [
                                yield! lineStyles ()
                                if size' = Size.Small && (showInput || index < todos.Length - 1) then
                                    style.marginBottom -18
                            ]
                            childContent [
                                MudCheckBox'() {
                                    Checked item.IsDone
                                    CheckedChanged(fun x -> todos |> List.updateAt index { item with IsDone = x } |> onChanged)
                                    Size size'
                                    Disabled disableCheckbox
                                }
                                adaptiview () {
                                    let! content', setContent = cval(item.Content).WithSetter()

                                    let update () =
                                        if content' <> item.Content then
                                            todos |> List.updateAt index { item with Content = content' } |> onChanged

                                    MudTextField'() {
                                        Value'(content', setContent)
                                        Immediate true
                                        OnKeyDown(fun e ->
                                            if e.Key = "Enter" then
                                                update ()
                                            elif (e.Key = "Backspace" || e.Key = "Delete") && String.IsNullOrEmpty content' then
                                                todos |> List.removeAt index |> onChanged
                                        )
                                        OnBlur(ignore >> update)
                                        FullWidth true
                                        DisableUnderLine true
                                        ReadOnly isDisabled
                                        Styles [ style.marginTop -5 ]
                                        stopPropagation "onkeypress" true
                                        preventDefault "onkeypress" true
                                    }
                                }
                            ]
                        }
                    if showInput then
                        adaptiview () {
                            let! txt, setTxt = cval("").WithSetter()
                            MudTextField'() {
                                Value txt
                                ValueChanged setTxt
                                Immediate true
                                Placeholder i18n.App.LogDialog.ToDoPlaceholder
                                OnKeyDown(fun e ->
                                    if e.Key = "Enter" then
                                        todos @ [ { Content = txt; IsDone = false } ] |> onChanged
                                )
                                Styles [ style.marginLeft 41 ]
                                ReadOnly isDisabled
                            }
                        }
                ]
            }
        }


let logDialog (date: DateOnly, action': Action) (renderMarkdown: bool) onSaved (dialogProps: FunDialogProps) =
    html.inject
    <| fun (hook: IComponentHook, store: IShareStore, logsSvc: ILogsService) ->
        let statuses = store.UseStatuses()
        let renderMarkdown = cval renderMarkdown
        let focused = cval false

        let detailCache = cval None
        let isDetailChanged = cval false

        let logForm =
            hook.UseAdaptiveForm<_, string>(
                match action' with
                | EditLog l
                | DeleteLog l -> l
                | CreateLog _ -> Log.DefaultValue()
            )

        let isDisabled =
            match action' with
            | DeleteLog _ -> true
            | _ -> false

        let toggelTodo detail' =
            logForm.UseFieldSetter
                (fun x -> x.Detail)
                (match detail' with
                 | Detail.Todo ls ->
                     ls
                     |> List.map (fun x -> x.Content)
                     |> String.concat (Environment.NewLine + Environment.NewLine)
                     |> Detail.Markdown
                 | Detail.Markdown str ->
                     str.Split(Environment.NewLine)
                     |> Seq.filter (String.IsNullOrEmpty >> not)
                     |> Seq.map (fun x -> { Content = x.Trim(); IsDone = false })
                     |> Seq.toList
                     |> Detail.Todo)
            renderMarkdown.Publish false


        let saveLog () =
            match action' with
            | Action.CreateLog -> logsSvc.CreateLog(date, logForm.GetValue())
            | Action.EditLog _ -> logsSvc.ModifyLog(date, logForm.GetValue(), false)
            | Action.DeleteLog log -> logsSvc.ModifyLog(date, log, true)
            |> Observable.ofTask
            |> Observable.subscribe (
                function
                | Error e -> statuses.Publish(fun x -> List.append x [ string e ])
                | Ok _ ->
                    dialogProps.Close()
                    logsSvc.WriteLogDetailCache None |> ignore
                    onSaved ()
                    statuses.Publish(fun x -> List.append x [ "Log changed successfully" ])
            )
            |> hook.AddDispose


        hook.AddDisposes [
            logsSvc.ReadLogDetailCache() |> Observable.ofTask |> Observable.subscribe detailCache.Publish

            logForm
                .UseFieldValue(fun x -> x.Detail)
                .AddLazyCallback(
                    function
                    | Detail.Markdown _ -> ()
                    | Detail.Todo ls ->
                        let setStatus = logForm.UseFieldSetter(fun x -> x.Status)
                        if ls.Length > 0 && ls |> Seq.exists (fun x -> not x.IsDone) |> not then
                            setStatus Status.Done
                        else
                            setStatus Status.Created
                )
            logForm
                .UseFieldValue(fun x -> x.Status)
                .AddLazyCallback(
                    function
                    | Status.Done ->
                        adaptive {
                            let! detail, setDetail = logForm.UseField(fun x -> x.Detail)
                            match detail with
                            | Detail.Todo ls -> ls |> List.map (fun x -> { x with IsDone = true }) |> Detail.Todo |> setDetail
                            | _ -> ()
                            return ()
                        }
                        |> AVal.force
                    | _ -> ()
                )

            Observable.interval (TimeSpan.FromSeconds 10)
            |> Observable.subscribe (fun _ ->
                if isDetailChanged.Value then
                    logForm.UseFieldValue(fun x -> x.Detail)
                    |> AVal.force
                    |> Some
                    |> logsSvc.WriteLogDetailCache
                    |> ignore
            )
        ]


        adaptiview () {
            let! i18n = store.UseI18n()
            let! theme = store.UseThemeValue()

            MudDialog'() {
                DisableSidePadding true
                TitleContent [
                    match action' with
                    | DeleteLog l ->
                        MudText'() {
                            Color Color.Warning
                            Typo Typo.h5
                            childContent $"{i18n.App.Common.Delete} {l.Title}"
                        }
                    | _ ->
                        adaptiview () {
                            let! title' = logForm.UseField(fun x -> x.Title)
                            MudTextField'() {
                                Label i18n.App.LogDialog.Title
                                Value' title'
                                FullWidth true
                                Disabled isDisabled
                            }
                        }
                ]
                DialogContent [
                    MudContainer'() {
                        Styles [
                            style.overflowHidden
                            style.displayFlex
                            style.flexDirectionColumn
                            if dialogProps.Options.FullScreen = Nullable true then
                                style.height (length.percent 100)
                            else
                                style.maxHeight (length.vh 70)
                                style.width 720
                        ]
                        childContent [
                            adaptiview () {
                                let! tags', setTags = logForm.UseField(fun x -> x.Tags)
                                MudChipSet'() {
                                    ReadOnly isDisabled
                                    childContent [
                                        for i, tag in List.indexed tags' do
                                            tagChip
                                                isDisabled
                                                tag
                                                (fun _ -> setTags (tags' |> List.removeAt i))
                                                (fun t -> setTags (tags' |> List.removeAt i |> List.insertAt i t))
                                        if not isDisabled then
                                            if tags'.Length > 0 then spaceH3
                                            newTagChip i18n.App.LogDialog.SelectATag (fun t -> (tags' @ [ t ]) |> List.distinct |> setTags)
                                    ]
                                }
                            }
                            spaceV2
                            adaptiview () {
                                let! detail', setDetail = logForm.UseField(fun x -> x.Detail)
                                let! isRenderMarkdown = renderMarkdown
                                let isChecked =
                                    match detail' with
                                    | Detail.Todo _ -> true
                                    | _ -> false

                                let setDetail x =
                                    isDetailChanged.Publish true
                                    setDetail x

                                if isChecked || not isRenderMarkdown then
                                    MudCheckBox'() {
                                        Color(if isChecked then Color.Success else Color.Default)
                                        Checked isChecked
                                        CheckedChanged(fun _ -> toggelTodo detail')
                                        childContent i18n.App.LogDialog.IsTodo
                                    }
                                    spaceV2
                                match detail' with
                                | Detail.Markdown str ->
                                    if isRenderMarkdown then
                                        div () {
                                            ondblclick (fun _ ->
                                                match action' with
                                                | Action.DeleteLog _ -> ()
                                                | Action.EditLog _
                                                | Action.CreateLog -> renderMarkdown.Publish false
                                            )
                                            childContent [ markdown str ]
                                            styles [
                                                style.height (length.percent 100)
                                                style.minHeight 50
                                                style.overflowYAuto
                                                style.padding (length.px 0, length.px 5)
                                                style.marginTop 20
                                            ]
                                        }
                                    else
                                        adaptiview () {
                                            let! focused, setFocused = focused |> Adapt.withSetter
                                            textarea () {
                                                value str
                                                oninput (fun e -> e.Value |> string |> Detail.Markdown |> setDetail)
                                                autofocus true
                                                placeholder i18n.App.LogDialog.MarkdownPlaceholder
                                                styles [
                                                    style.height (length.percent 100)
                                                    style.width (length.percent 100)
                                                    style.backgroundColor "transparent"
                                                    style.resizeNone
                                                    style.padding 5
                                                    style.minHeight 200
                                                    style.color (theme.Palette.TextPrimary.ToString())
                                                    style.marginTop 20
                                                    if focused then
                                                        style.borderBottom (length.px 2, borderStyle.solid, theme.Palette.Primary.ToString())
                                                    else
                                                        style.borderBottom (length.px 2, borderStyle.solid, theme.Palette.PrimaryDarken.ToString())
                                                ]
                                                onfocus (fun _ -> setFocused true)
                                                onblur (fun _ -> setFocused false)
                                            }
                                        }
                                | Detail.Todo todos ->
                                    div () {
                                        styles [
                                            style.height (length.perc 100)
                                        ]
                                        childContent [
                                            todoEditor Size.Medium (not isDisabled) isDisabled isDisabled todos (Detail.Todo >> setDetail)
                                        ]
                                    }
                            }
                            spaceV4
                            spaceV4
                            adaptiview () {
                                let! schedule, setSchedule = logForm.UseField(fun x -> x.Schedule)

                                scheduleEditor DateTime.Now schedule isDisabled setSchedule
                                adaptiview () {
                                    let! status, setStatus = logForm.UseField(fun x -> x.Status)
                                    let isDone' = status = Status.Done
                                    MudCheckBox'() {
                                        Label i18n.App.LogDialog.MarkAsDoneNow
                                        Color(if isDone' then Color.Success else Color.Default)
                                        Checked isDone'
                                        CheckedChanged(
                                            function
                                            | true -> setStatus Status.Done
                                            | false -> setStatus Status.Created
                                        )
                                        Disabled isDisabled
                                    }
                                }
                            }
                            spaceV4
                        ]
                    }
                ]
                DialogActions [
                    adaptiview () {
                        let! cache, setCache = detailCache.WithSetter()
                        match cache with
                        | None -> ()
                        | Some cache ->
                            MudButton'() {
                                OnClick(fun _ ->
                                    logForm.UseFieldSetter(fun x -> x.Detail) (cache)
                                    setCache None
                                )
                                childContent i18n.App.LogDialog.UseLastDetail
                            }
                    }
                    adaptiview () {
                        let! renderMarkdown' = renderMarkdown
                        let! detail = logForm.UseFieldValue(fun x -> x.Detail)
                        match detail with
                        | Detail.Todo _ -> ()
                        | Detail.Markdown _ ->
                            MudIconButton'() {
                                Size Size.Small
                                Icon(if renderMarkdown' then Icons.Filled.Edit else Icons.Filled.RemoveRedEye)
                                OnClick(fun _ -> renderMarkdown.Publish not)
                            }
                    }
                    MudButton'() {
                        Size Size.Small
                        OnClick(ignore >> dialogProps.Close)
                        childContent i18n.App.Common.Close
                    }
                    adaptiview () {
                        let! hasChanges = isDetailChanged
                        if hasChanges then
                            MudButton'() {
                                Size Size.Small
                                OnClick(fun _ ->
                                    logsSvc.WriteLogDetailCache None |> ignore
                                    dialogProps.Close()
                                )
                                childContent i18n.App.LogDialog.Discard
                            }
                    }
                    adaptiview () {
                        let! hasChanges = logForm.UseHasChanges()
                        MudButton'() {
                            Size Size.Small
                            Variant Variant.Filled
                            Color(
                                match action' with
                                | Action.CreateLog -> Color.Success
                                | Action.EditLog _ -> Color.Info
                                | Action.DeleteLog _ -> Color.Warning
                            )
                            OnClick(fun _ -> saveLog ())
                            Disabled(
                                match action' with
                                | Action.EditLog _ when not hasChanges -> true
                                | _ -> false
                            )
                            childContent (
                                match action' with
                                | Action.CreateLog -> i18n.App.Common.Create
                                | Action.EditLog _ -> i18n.App.Common.Save
                                | Action.DeleteLog _ -> i18n.App.Common.Delete
                            )
                        }
                    }
                ]
            }
        }
