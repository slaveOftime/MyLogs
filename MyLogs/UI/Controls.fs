[<AutoOpen>]
module MyLogs.UI.Controls

open System
open Fun.Blazor
open Markdig


let private spaceH (x: int) =
    div {
        style'' {
            width x
            flexShrink 0
            displayInlineBlock
        }
    }

let private spaceV (x: int) =
    div {
        style'' {
            height x
            flexShrink 0
        }
    }

let spaceH1 = spaceH 3
let spaceH2 = spaceH 6
let spaceH3 = spaceH 10
let spaceH4 = spaceH 18

let spaceHF = div { style'' { width "100%" } }

let spaceV1 = spaceV 3
let spaceV2 = spaceV 6
let spaceV3 = spaceV 10
let spaceV4 = spaceV 18


let markdown (markdown: string) =
    html.inject (fun () ->
        let checkedStr =
            """<li class="task-list-item task-list-item-checked"><input type="checkbox" onclick="return false;" class="task-list-item-checkbox" checked="">"""
        let unCheckedStr =
            """<li class="task-list-item"><input type="checkbox" disabled class="task-list-item-checkbox">"""

        let processChecked (html: string) =
            html.Replace("<li>[x]", checkedStr).Replace("<li>[]", unCheckedStr).Replace("<li>[ ]", unCheckedStr)

        let processLink (html: string) =
            html.Replace("<a href=", "<a target=\"_blank\" href=")

        div {
            style'' { fontSize "0.85rem" }
            article {
                classes [ "markdown-body" ]
                markdown |> Markdown.Parse |> Markdown.ToHtml |> processChecked |> processLink |> html.raw
            }
            script { src "https://cdnjs.cloudflare.com/ajax/libs/prism/1.23.0/components/prism-core.min.js" }
            script { src "https://cdnjs.cloudflare.com/ajax/libs/prism/1.23.0/plugins/autoloader/prism-autoloader.min.js" }
        }
    )


let formatWeekDay (i18n: I18N) =
    function
    | DayOfWeek.Monday -> i18n.App.WeekDay.Monday
    | DayOfWeek.Tuesday -> i18n.App.WeekDay.Tuesday
    | DayOfWeek.Wednesday -> i18n.App.WeekDay.Wednesday
    | DayOfWeek.Thursday -> i18n.App.WeekDay.Thursday
    | DayOfWeek.Friday -> i18n.App.WeekDay.Friday
    | DayOfWeek.Saturday -> i18n.App.WeekDay.Saturday
    | DayOfWeek.Sunday -> i18n.App.WeekDay.Sunday
    | _ -> "---"
