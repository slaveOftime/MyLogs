[<AutoOpen>]
module MyLogs.UI.Controls

open System
open Feliz
open Fun.Blazor
open Markdig;


let private spaceH (x: int) =
    div(){
        styles [ style.width x; style.flexShrink 0; style.displayInlineBlock ]
    }

let private spaceV (x: int) =
    div(){
        styles [ style.height x; style.flexShrink 0 ]
    }

let spaceH1 = spaceH 3
let spaceH2 = spaceH 6
let spaceH3 = spaceH 10
let spaceH4 = spaceH 18

let spaceHF =
    div(){
        styles [ style.width (length.percent 100) ]
    }

let spaceV1 = spaceV 3
let spaceV2 = spaceV 6
let spaceV3 = spaceV 10
let spaceV4 = spaceV 18


let markdown (markdown: string) = html.inject <| fun () ->
    let checkedStr   = """<li class="task-list-item task-list-item-checked"><input type="checkbox" onclick="return false;" class="task-list-item-checkbox" checked="">"""
    let unCheckedStr = """<li class="task-list-item"><input type="checkbox" disabled class="task-list-item-checkbox">"""
    
    let processChecked (html: string) =
        html
            .Replace("<li>[x]", checkedStr)
            .Replace("<li>[]", unCheckedStr)
            .Replace("<li>[ ]", unCheckedStr)

    let processLink (html: string) =
        html.Replace("<a href=", "<a target=\"_blank\" href=")

    div(){
        styles [ style.fontSize (length.rem 0.85) ]
        childContent [
            article(){
                classes [ "markdown-body" ]
                childContent [
                    markdown |> Markdown.Parse |> Markdown.ToHtml |> processChecked |> processLink |> html.raw
                ]
            }
            html.script "https://cdnjs.cloudflare.com/ajax/libs/prism/1.23.0/components/prism-core.min.js"
            html.script "https://cdnjs.cloudflare.com/ajax/libs/prism/1.23.0/plugins/autoloader/prism-autoloader.min.js"
        ]
    }


let formatWeekDay (i18n: I18N) = function
    | DayOfWeek.Monday -> i18n.App.WeekDay.Monday
    | DayOfWeek.Tuesday -> i18n.App.WeekDay.Tuesday
    | DayOfWeek.Wednesday -> i18n.App.WeekDay.Wednesday
    | DayOfWeek.Thursday -> i18n.App.WeekDay.Thursday
    | DayOfWeek.Friday -> i18n.App.WeekDay.Friday
    | DayOfWeek.Saturday -> i18n.App.WeekDay.Saturday
    | DayOfWeek.Sunday -> i18n.App.WeekDay.Sunday
    | _ -> "---"
