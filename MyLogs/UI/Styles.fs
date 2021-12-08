[<AutoOpen>]
module MyLogs.UI.Styles

open Fun.Result
open Fun.Blazor
open MudBlazor


let css (str: string) =
    html.raw
        $"""
<style>
{str}
</style>
"""


let radius = 10

let isExtraSmall x = x < 600
let isSmall x = x >= 600 && x < 960
let isMedium x = x >= 960 && x < 1280
let isLarge x = x >= 1280 && x < 1920
let isExtraLarge x = x >= 1920 && x < 2560
let isExtraLarge2 x = x > 2560


let getWindowSize width =
    match width with
    | LessThan 360 -> ExtraSmall
    | BetweenEqual 360 720 -> Small
    | BetweenEqual 720 1280 -> Medium
    | BetweenEqual 1280 1920 -> Large
    | BetweenEqual 1920 2560 -> ExtraLarge
    | _ -> ExtraLarge2


let mudStylesOverride bgColor =
    css
        $"""
        * {{
            text-shadow: inherit;
        }}
        .mud-dialog {{
            background-color: {Utilities.MudColor(bgColor).SetAlpha(0.6).ChangeLightness(0.1).ToString()};
            backdrop-filter: blur(50px);
            box-shadow: 10px 20px 15px rgb(0 0 0 / 20%%);
            border: 1px solid {Utilities.MudColor(bgColor).SetAlpha(0.7).ChangeLightness(0.15).ToString()};
        }}
        .mud-paper {{
            background-color: {Utilities.MudColor(bgColor).SetAlpha(0.95).ChangeLightness(0.1).ToString()};
            backdrop-filter: blur(20px);
            box-shadow: 10px 20px 15px rgb(0 0 0 / 20%%);
            border: 1px solid {Utilities.MudColor(bgColor).SetAlpha(0.95).ChangeLightness(0.15).ToString()};
        }}
        .mud-popover.mud-popover-open {{
            overflow-y: hidden;
        }}
        .mud-dialog-fullscreen > div:nth-child(2) {{
            display: flex;
            height: 100%%;
            flex-direction: column;
            overflow: hidden;
        }}
        .mud-dialog-fullscreen > .mud-dialog-content {{
            height: 100%%;
            overflow: hidden;
        }}
        textarea {{
            border: 0px;
            outline: none;
            border-radius: 0px;
        }}
        textarea:focus {{
            outline: none;
        }}
    """


type Styles =

    static member shadowStyles(?bgColor: string) =
        let bgColor = defaultArg bgColor "rgba(0, 0, 0, 0.2)"
        [ style.boxShadow $"10px 20px 15px {bgColor}" ]


    static member blurStyles(bgColor: string, ?blur: int) =
        let blur = defaultArg blur 10
        [
            style.backgroundColor bgColor
            style.custom ("-webkit-backdrop-filter", $"blur({blur}px)")
            style.custom ("backdrop-filter", $"blur({blur}px)")
        ]


    static member lineStyles() =
        [
            style.displayFlex
            style.alignItemsCenter
            style.flexDirectionRow
            style.alignContentStretch
        ]
