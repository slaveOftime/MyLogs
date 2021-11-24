module MyLogs.Core.ParseLogs

open System
open System.Text
open System.Text.RegularExpressions
open System.Collections.Generic
open Fun.Result


type ParsePattern = {
    Head: Regex
    DetailMarkdown: Regex
    DetailTodo: Regex
    Tags: Regex
    Schedule: Regex
    Created: Regex
    Updated: Regex
    Splitters: char[]
    FinishedTodo: Regex
    StatusDone: Regex
}


let parseLogs (patterns: ParsePattern list) (logLines: string seq) =
    let logs = List()

    let mutable log = Option<Log>.None
    let mutable logPattern = None
    let mutable detail = Option<Detail>.None
    let mutable detailStringBuilder = Option<StringBuilder>.None

    let tryAppendLog () =
        log |> Option.iter (fun log' ->
            logs.Add {
                log' with
                    Detail =
                        match detail with
                        | None -> Detail.Markdown ""
                        | Some (Detail.Todo x) -> Detail.Todo x
                        | Some (Detail.Markdown _) ->
                            let detail = detailStringBuilder |> Option.map (fun sb -> sb.ToString()) |> Option.defaultValue ""
                            let ternimator = Environment.NewLine
                            let length = ternimator.Length * 3
                            Detail.Markdown(
                                if detail.Length > length && detail.Substring(detail.Length - length) = ternimator + ternimator + ternimator then
                                    detail.Remove(detail.Length - length)
                                else
                                    detail
                            )
            }
            log <- None
            detail <- None
            detailStringBuilder <- None
        )

    let changeLog fn = log |> Option.iter (fun l -> log <- Some(fn l))
    let changeLogSchedule s = changeLog (fun l -> { l with Schedule = s })

    let (|Header|_|) line =
        patterns
        |> Seq.tryPick (fun pattern ->
            let result = pattern.Head.Match line
            if result.Success then Some (pattern, result.Groups[1].Value.Trim())
            else None
        )

    for line in logLines do
        match logPattern, line, detail with
        | _, Header (pattern, title), _ ->
            tryAppendLog()
            log <- Some { Log.DefaultValue with Title = title }
            logPattern <- Some pattern

        | Some _, _, Some (Detail.Markdown _) when detailStringBuilder.IsSome ->
            detailStringBuilder.Value.AppendLine line |> ignore

        
        | Some _, _, Some (Detail.Markdown _) ->
            detailStringBuilder <- Some(StringBuilder())
            detailStringBuilder.Value.AppendLine line |> ignore

        | Some pattern, _, Some (Detail.Todo ls) ->
            match line with
            | RegPattern pattern.FinishedTodo (result, _) ->
                detail <- ls@[ { Content = result.Groups[1].Value.Trim(); IsDone = true } ] |> Detail.Todo |> Some
            | SafeString line ->
                detail <- ls@[ { Content = line.Trim(); IsDone = false } ] |> Detail.Todo |> Some
            | _ ->
                ()

        | Some pattern, _, _ ->
            match line with
            | RegPattern pattern.Tags (_, result) ->
                changeLog (fun log -> {
                    log with
                        Tags =
                            result.Split(pattern.Splitters)
                            |> Seq.map (fun x -> x.Trim())
                            |> Seq.filter (String.IsNullOrEmpty >> not)
                            |> Seq.toList
                })

            | RegPattern pattern.Schedule (_, result) ->
                if result.Contains "-" then
                    let splits = result.Split "-" |> Seq.map (fun x -> x.Trim()) |> Seq.filter (String.IsNullOrEmpty >> not) |> Seq.toList
                    match splits[0], splits[1] with
                    | TimeOnly startTime, TimeOnly endTime -> changeLogSchedule (Schedule.Range (startTime, endTime))
                    | _ -> ()
                else
                    match result with
                    | TimeOnly time -> changeLogSchedule (Schedule.Alarm time)
                    | _ -> ()
            
            | RegPattern pattern.StatusDone _ ->
                changeLog (fun log -> { log with Status = Status.Done })

            | RegPattern pattern.Created (_, DateTimeOffset x) -> changeLog (fun l -> { l with CreatedTime = x })

            | RegPattern pattern.Updated (_, DateTimeOffset x) -> changeLog (fun l -> { l with UpdatedTime = Some x })

            | RegPattern pattern.DetailTodo _ ->
                detail <- Some (Detail.Todo [])

            // This should be the last line for detail
            | RegPattern pattern.DetailMarkdown _ ->
                detail <- Some (Detail.Markdown "")
                detailStringBuilder <- Some (StringBuilder())

            | _ -> ()

        | None, _, _ ->
            ()

    tryAppendLog()

    logs |> Seq.toList
