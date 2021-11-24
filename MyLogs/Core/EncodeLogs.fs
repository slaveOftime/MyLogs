module MyLogs.Core.EncodeLogs

open System
open System.Text


type EncodePattern = {
    Head: string -> string
    Detail: Detail -> string
    Tags: string list -> string 
    Schedule: Schedule -> string
    StatusDone: string
    Created: DateTimeOffset -> string
    Updated: DateTimeOffset -> string
}


type StringBuilder with
    member this.AppendLineIf (condition, line: unit -> string) = 
        if condition then this.AppendLine (line())
        else this


let encodeLogs (patterns: EncodePattern) (logs: Log list) =
    let logsString = StringBuilder()

    for i, log in logs |> List.indexed do
        let schedule = patterns.Schedule log.Schedule
        logsString
            .AppendLine(patterns.Head log.Title)
            .AppendLineIf(log.Tags.Length > 0, fun _ -> patterns.Tags log.Tags)
            .AppendLineIf(String.IsNullOrEmpty schedule |> not, fun _ -> schedule)
            .AppendLineIf(log.Status = Status.Done, fun _ -> patterns.StatusDone)
            .AppendLine(patterns.Created log.CreatedTime)
            .AppendLineIf(log.UpdatedTime.IsSome, fun _ -> patterns.Updated log.UpdatedTime.Value)
            .Append(patterns.Detail log.Detail) |> ignore

        if i < logs.Length - 1 then
            logsString.AppendLine().AppendLine().AppendLine() |> ignore
        else
            logsString.AppendLine().AppendLine() |> ignore

    logsString.ToString()
