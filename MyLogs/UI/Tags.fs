[<AutoOpen>]
module MyLogs.UI.Tags

open FSharp.Data.Adaptive
open Fun.Blazor
open MudBlazor
open MyLogs.Core


let tagChip isDisabled (tag: string) onDelete onReplace =
    html.inject
    <| fun (store: IShareStore, dialog: IDialogService) ->
        adaptiview () {
            let! i18n = store.UseI18n()
            let! tags = store.UseTagsMap()

            let styles' =
                [
                    match tags |> Map.tryFind tag with
                    | None -> ()
                    | Some t -> style.backgroundColor t.Color
                ]

            if isDisabled then
                MudChip'() {
                    Styles styles'
                    childContent tag
                }
            else
                MudChip'() {
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
                    Styles styles'
                    Size Size.Small
                    childContent tag
                }
        }


let newTagChip (title': string) onSelected =
    html.inject
    <| fun (dialog: IDialogService, store: IShareStore) ->
        adaptiview () {
            let! i18n = store.UseI18n()

            MudButton'() {
                Variant Variant.Outlined
                Size Size.Small
                Styles [
                    style.displayInlineBlock
                    style.whiteSpaceNowrap
                ]
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
                childContent title'
            }
        }
