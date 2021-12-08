module MyLogs.Core.LogPatterns

open System
open System.Text
open System.Text.RegularExpressions
open MyLogs.Core.ParseLogs
open MyLogs.Core.EncodeLogs
open System.Globalization


let private formateTime (x: TimeOnly) = x.ToString("HH:mm:ss")
let private formateDateTimeOffset (x: DateTimeOffset) = x.ToString(CultureInfo.InvariantCulture)


type PartternLang =
    | EN
    | ZH


let patterns =
    Map.ofList [
        EN,
        {|
            Parse =
                {
                    ParsePattern.Head = Regex "# \[MyLogs\]([\s\S]*)"
                    DetailMarkdown = Regex "## Detail"
                    DetailTodo = Regex "## Detail Todo"
                    Tags = Regex "- Tags:"
                    Schedule = Regex "- Schedule:"
                    Created = Regex "- Created:"
                    Updated = Regex "- Updated:"
                    Splitters = [| ','; ';' |]
                    FinishedTodo = Regex "\[x\]([\s\S]*)"
                    StatusDone = Regex "- Status: Done"
                }
            Encode =
                {
                    EncodePattern.Head = fun x -> sprintf "# [MyLogs]%s" (if String.IsNullOrEmpty x then "" else " " + x)
                    Tags = String.concat "," >> sprintf "- Tags: %s"
                    Schedule =
                        function
                        | Schedule.Alarm x -> $"- Schedule: {formateTime x}"
                        | Schedule.Range (s, e) -> $"- Schedule: {formateTime s} - {formateTime e}"
                        | Schedule.Anytime -> ""
                    StatusDone = "- Status: Done"
                    Created = formateDateTimeOffset >> sprintf "- Created: %s"
                    Updated = formateDateTimeOffset >> sprintf "- Updated: %s"
                    Detail =
                        function
                        | Detail.Markdown x -> $"## Detail{Environment.NewLine}{x}"
                        | Detail.Todo ls ->
                            let sb = StringBuilder()
                            sb.AppendLine("## Detail Todo") |> ignore
                            for item in ls do
                                sb.AppendLine((if item.IsDone then "[x] " else "") + item.Content) |> ignore
                            sb.ToString()
                }
        |}
        ZH,
        {|
            Parse =
                {
                    ParsePattern.Head = Regex "# \[我的日志\]([\s\S]*)"
                    DetailMarkdown = Regex "## 详情"
                    DetailTodo = Regex "## 详情 待办"
                    Tags = Regex "- 标签："
                    Schedule = Regex "- 行程："
                    Created = Regex "- 创建："
                    Updated = Regex "- 更新："
                    Splitters = [| '，'; ','; '、'; '；'; ';' |]
                    FinishedTodo = Regex "\[x\]([\s\S]*)"
                    StatusDone = Regex "- 状态：完成"
                }
            Encode =
                {
                    EncodePattern.Head = fun x -> sprintf "# [我的日志]%s" (if String.IsNullOrEmpty x then "" else " " + x)
                    Tags = String.concat "," >> sprintf "- 标签：%s"
                    Schedule =
                        function
                        | Schedule.Alarm x -> $"- 行程：{formateTime x}"
                        | Schedule.Range (s, e) -> $"- 行程：{formateTime s} - {formateTime e}"
                        | Schedule.Anytime -> ""
                    StatusDone = "- 状态：完成"
                    Created = formateDateTimeOffset >> sprintf "- 创建：%s"
                    Updated = formateDateTimeOffset >> sprintf "- 更新：%s"
                    Detail =
                        function
                        | Detail.Markdown x -> $"## 详情{Environment.NewLine}{x}"
                        | Detail.Todo ls ->
                            let sb = StringBuilder()
                            sb.AppendLine("## 详情 待办") |> ignore
                            for item in ls do
                                sb.AppendLine((if item.IsDone then "[x] " else "") + item.Content) |> ignore
                            sb.ToString()
                }
        |}
    ]


let currentPatternLang =
    match CultureInfo.CurrentUICulture.TwoLetterISOLanguageName with
    | "zh" -> ZH
    | _ -> EN


let currentEncodePattern =
    patterns |> Map.find currentPatternLang |> fun x -> x.Encode


let allParsePatterns =
    let headPattern = patterns |> Map.find currentPatternLang
    let restPatterns =
        patterns |> Map.remove currentPatternLang |> Map.toList |> List.map (fun (_, x) -> x.Parse)
    headPattern.Parse :: restPatterns
