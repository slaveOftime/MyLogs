[<AutoOpen>]
module MyLogs.UI.Tags

open FSharp.Data.Adaptive
open Fun.Blazor
open MudBlazor
open MyLogs.Core


let tagChip isDisabled (tag: string) onDelete onReplace =
    html.inject (fun (store: IShareStore, dialog: IDialogService) ->
        adaptiview () {
            let! i18n = store.UseI18n()
            let! tags = store.UseTagsMap()

            let bgColor =
                match tags |> Map.tryFind tag with
                | Some t -> t.Color
                | None -> "transparent"

            if isDisabled then
                MudChip'() {
                    style'' { backgroundColor bgColor }
                    childContent tag
                }
            else
                MudChip'() {
                    style'' { backgroundColor bgColor }
                    CloseIcon Icons.Filled.Close
                    OnClose(fun _ -> onDelete tag)
                    OnClick(fun _ ->
                        dialog.Show(
                            i18n.App.TagsSelector.ChangeTag,
                            fun d ->
                                tagsSelector
                                    d.Close
                                    (fun x ->
                                        d.Close()
                                        onReplace x.Name
                                    )
                        )
                    )
                    Size Size.Small
                    childContent tag
                }
        }
    )


let newTagChip (titleStr: string) onSelected =
    html.inject (fun (dialog: IDialogService, store: IShareStore) ->
        adaptiview () {
            let! i18n = store.UseI18n()

            MudButton'() {
                style'' {
                    displayInlineBlock
                    whiteSpaceNowrap
                }
                Variant Variant.Outlined
                Size Size.Small
                OnClick(fun _ ->
                    dialog.Show(
                        i18n.App.TagsSelector.SelectATag,
                        fun d ->
                            tagsSelector
                                d.Close
                                (fun x ->
                                    onSelected x.Name
                                    d.Close()
                                )
                    )
                )
                titleStr
            }
        }
    )
