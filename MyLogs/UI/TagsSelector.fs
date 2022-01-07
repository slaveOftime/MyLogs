[<AutoOpen>]
module MyLogs.UI.TagsSelector

open System
open FSharp.Data.Adaptive
open FSharp.Control.Reactive
open Feliz
open Fun.Result
open Fun.Blazor
open MudBlazor
open MyLogs.Core
open MyLogs.Services


let private colorPicker color onChanged =
    adaptiview () {
        let! color', setColor = cval(Utilities.MudColor color).WithSetter()
        div () {
            styles [ style.width 200 ]
            childContent [
                MudColorPicker'() {
                    Value color'
                    ValueChanged setColor
                    PickerVariant PickerVariant.Dialog
                    PickerClosed(fun _ -> color'.ToString() |> onChanged)
                }
            ]
        }
    }


let tagsSelector onClose onSelect =
    html.inject
    <| fun (store: IShareStore, hook: IComponentHook, logsSvc: ILogsService, snackbar: ISnackbar) ->
        let tagsMap = store.UseTagsMap()
        let filter = cval ""
        let editingTag = cval None
        let changedTags = cval Map.empty<string, Tag>
        let removedTags = cval<string list> []
        let defaultColor = "#e585d6ff"

        let reloadTags () =
            logsSvc.LoadLogTags()
            |> Observable.ofTask
            |> Observable.subscribe (
                function
                | Error e -> snackbar.Add(e, Severity.Error) |> ignore
                | Ok _ -> ()
            )
            |> hook.AddDispose

        let updateTagUsageCount tag =
            let tag = tagsMap.Value |> Map.tryFind tag
            match tag with
            | None -> ()
            | Some tag ->
                tagsMap.Value
                |> Map.add tag.Name { tag with UsageCount = tag.UsageCount + 1L }
                |> Map.toList
                |> List.map snd
                |> logsSvc.WriteLogTags
                |> Observable.ofTask
                |> Observable.subscribe (
                    function
                    | Ok _ -> ()
                    | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
                )
                |> hook.AddDispose

        let saveTags newTags =
            transact (fun _ ->
                newTags
                |> Map.toList
                |> List.map snd
                |> logsSvc.WriteLogTags
                |> Observable.ofTask
                |> Observable.subscribe (
                    function
                    | Error WriteDataError.DataIsChanged ->
                        reloadTags ()
                        snackbar.Add("Tags is changed outsize of the app, will reload it", Severity.Warning) |> ignore
                    | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
                    | Ok _ -> reloadTags ()
                )
                |> hook.AddDispose
                changedTags.Value <- Map.empty
                removedTags.Value <- []
            )


        let allTags =
            adaptive {
                let! tagsMap = tagsMap
                let! changedTags = changedTags
                let! removedTags = removedTags

                return
                    changedTags
                    |> Map.fold (fun s k v -> Map.add k v s) tagsMap
                    |> Map.filter (fun x _ -> Seq.contains x removedTags |> not)
                    |> Map.toList
                    |> List.sortBy fst
                    |> Map.ofList
            }

        let filteredTags =
            adaptive {
                let! allTags = allTags
                let! filter = filter

                return
                    allTags
                    |> Map.filter (fun x _ -> String.IsNullOrEmpty filter || x.ToLower().Contains(filter.ToLower()))
            }


        adaptiview () {
            let! i18n = store.UseI18n()

            MudDialog'() {
                DisableSidePadding true
                TitleContent [
                    adaptiview () {
                        let! _ = filter
                        MudFocusTrap'() {
                            Disabled false
                            DefaultFocus DefaultFocus.FirstChild
                            childContent [
                                MudTextField'() {
                                    Label i18n.App.TagsSelector.Title
                                    Value' filter
                                    AutoFocus true
                                }
                            ]
                        }
                    }
                ]
                DialogContent [
                    MudContainer'() {
                        Styles [
                            style.width 400
                            style.maxHeight 500
                            style.height (length.perc 100)
                            style.overflowHidden
                            style.displayFlex
                            style.flexDirectionColumn
                        ]
                        childContent [
                            adaptiview () {
                                let! tags = filteredTags |> AVal.map (Map.toSeq >> Seq.map snd >> Seq.sortByDescending (fun x -> x.UsageCount))

                                div () {
                                    styles [
                                        style.height (length.perc 100)
                                        style.overflowXHidden
                                        style.overflowYAuto
                                        style.paddingRight 5
                                    ]
                                    childContent [
                                        for tag in tags do
                                            let color' = if String.IsNullOrEmpty tag.Color then defaultColor else tag.Color
                                            MudChipSet'() {
                                                Styles [
                                                    style.displayFlex
                                                    style.alignItemsBaseline
                                                ]
                                                onclick (fun _ ->
                                                    updateTagUsageCount tag.Name
                                                    onSelect tag
                                                )
                                                childContent [
                                                    MudChip'() {
                                                        Size Size.Small
                                                        Variant Variant.Outlined
                                                        Styles [
                                                            style.backgroundColor color'
                                                            style.color "white"
                                                        ]
                                                        CloseIcon Icons.Filled.Close
                                                        OnClose(fun _ -> removedTags.Publish(List.append [ tag.Name ]))
                                                        childContent tag.Name
                                                    }
                                                    div () { styles [ style.flex 1 ] }
                                                    colorPicker color' (fun x -> changedTags.Publish(Map.add tag.Name { tag with Color = x }))
                                                ]
                                            }
                                    ]
                                }
                            }
                            spaceV4
                            adaptiview () {
                                let! editingTag' = editingTag

                                match editingTag' with
                                | None ->
                                    MudButton'() {
                                        StartIcon Icons.Filled.Add
                                        OnClick(fun _ -> { Name = ""; Color = defaultColor; UsageCount = 0 } |> Some |> editingTag.Publish)
                                        FullWidth true
                                        Variant Variant.Outlined
                                        Color Color.Primary
                                        childContent i18n.App.Common.Add
                                    }
                                | Some tag ->
                                    div () {
                                        styles [
                                            style.displayFlex
                                            style.alignItemsFlexEnd
                                            style.flexDirectionRow
                                            style.alignContentStretch
                                        ]
                                        childContent [
                                            MudTextField'() {
                                                Value tag.Name
                                                ValueChanged(fun x -> { tag with Name = x } |> Some |> editingTag.Publish)
                                                FullWidth true
                                                AutoFocus true
                                                Styles [ style.color tag.Color ]
                                            }
                                            spaceH2
                                            colorPicker tag.Color (fun x -> { tag with Color = x } |> Some |> editingTag.Publish)
                                            spaceH3
                                            MudIconButton'() {
                                                Icon Icons.Filled.Save
                                                Size Size.Medium
                                                Disabled(String.IsNullOrEmpty tag.Name || String.IsNullOrEmpty tag.Color)
                                                OnClick(fun _ ->
                                                    editingTag.Publish None
                                                    saveTags (Map.add tag.Name tag tagsMap.Value)
                                                )
                                                Styles [
                                                    style.padding (length.px 0, length.px 0, length.px 4, length.px 0)
                                                ]
                                            }
                                            spaceH1
                                            MudIconButton'() {
                                                Icon Icons.Filled.Cancel
                                                Size Size.Medium
                                                OnClick(fun _ -> editingTag.Publish None)
                                                Styles [
                                                    style.padding (length.px 0, length.px 0, length.px 4, length.px 0)
                                                ]
                                            }
                                        ]
                                    }
                            }
                            spaceV3
                        ]
                    }
                ]
                DialogActions [
                    MudButton'() {
                        OnClick(fun _ -> onClose ())
                        childContent i18n.App.Common.Close
                    }
                    adaptiview () {
                        let! changedTags = changedTags
                        let! removedTags = removedTags

                        if changedTags.Count > 0 || removedTags.Length > 0 then
                            MudButton'() {
                                Variant Variant.Filled
                                Color Color.Primary
                                OnClick(fun _ -> allTags |> AVal.force |> saveTags)
                                childContent i18n.App.Common.Save
                            }
                        else
                            html.none
                    }
                ]
            }
        }
