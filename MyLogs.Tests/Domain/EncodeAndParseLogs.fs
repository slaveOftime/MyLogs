module Mylogs.Tests.Domain.EncodeAndParseLogs

open System
open Xunit
open FsUnit.Xunit.Typed
open MyLogs.Core
open MyLogs.Core.EncodeLogs
open MyLogs.Core.ParseLogs
open MyLogs.Core.LogPatterns



let logs = [
    {
        Log.Id = Guid.Empty
        Title = "Foo"
        Detail = Detail.Markdown """
Want to make some difference.
```fsharp
printfn "Great 😎"
```
"""
        CreatedTime = DateTimeOffset.Now.ToString() |> DateTimeOffset.Parse
        UpdatedTime = Some (DateTimeOffset.Now.AddDays(1).ToString() |> DateTimeOffset.Parse)
        Tags = [ "WinTool"; "CITI" ]
        Schedule = Schedule.Anytime
        Status = Status.Created
    }
    {
        Log.Id = Guid.Empty
        Title = "Foo2"
        Detail = Detail.Todo [
            { Content = "Detail test 1"; IsDone = true }
            { Content = "Detail test 2"; IsDone = false }
        ]
        CreatedTime = DateTimeOffset.Now.AddDays(1).ToString() |> DateTimeOffset.Parse
        UpdatedTime = Some (DateTimeOffset.Now.AddDays(2).ToString() |> DateTimeOffset.Parse)
        Tags = [ "WinTool" ]
        Schedule = Schedule.Anytime
        Status = Status.Created
    }
    for i in 3..10 do
        {
            Log.Id = Guid.Empty
            Title = $"Foo{i}"
            Detail = Detail.Markdown "asdasd"
            CreatedTime = DateTimeOffset.Now.AddDays(float(i + 1)).ToString() |> DateTimeOffset.Parse
            UpdatedTime = Some (DateTimeOffset.Now.AddDays(float(i + 2)).ToString() |> DateTimeOffset.Parse)
            Tags = [ "WinTool" ]
            Schedule = Schedule.Anytime
            Status = Status.Created
        }
    {
        Log.Id = Guid.Empty
        Title = "Foo11"
        Detail = Detail.Markdown "Alarm test"
        CreatedTime = DateTimeOffset.Now.AddDays(1).ToString() |> DateTimeOffset.Parse
        UpdatedTime = Some (DateTimeOffset.Now.AddDays(2).ToString() |> DateTimeOffset.Parse)
        Tags = [ "WinTool" ]
        Schedule = Schedule.Alarm (TimeOnly.FromDateTime(DateTime.Now.AddDays(1)))
        Status = Status.Created
    }
    {
        Log.Id = Guid.Empty
        Title = "Foo12"
        Detail = Detail.Todo [
            { Content = "Detail test 3"; IsDone = true }
            { Content = "Detail test 4"; IsDone = false }
        ]
        CreatedTime = DateTimeOffset.Now.AddDays(1).ToString() |> DateTimeOffset.Parse
        UpdatedTime = Some (DateTimeOffset.Now.AddDays(2).ToString() |> DateTimeOffset.Parse)
        Tags = [ "WinTool" ]
        Schedule = Schedule.Range (
            TimeOnly.FromDateTime(DateTime.Now.AddDays(1)),
            TimeOnly.FromDateTime(DateTime.Now.AddDays(1)).AddMinutes(30)
        )
        Status = Status.Done
    }
    {
        Log.Id = Guid.Empty
        Title = ""
        Detail = Detail.Markdown ""
        CreatedTime = DateTimeOffset.Now.ToString() |> DateTimeOffset.Parse
        UpdatedTime = Some (DateTimeOffset.Now.AddDays(1).ToString() |> DateTimeOffset.Parse)
        Tags = []
        Schedule = Schedule.Anytime
        Status = Status.Created
    }
    {
        Log.Id = Guid.Empty
        Title = ""
        Detail = Detail.Todo [ { Content = ""; IsDone = true } ]
        CreatedTime = DateTimeOffset.Now.ToString() |> DateTimeOffset.Parse
        UpdatedTime = Some (DateTimeOffset.Now.AddDays(1).ToString() |> DateTimeOffset.Parse)
        Tags = []
        Schedule = Schedule.Anytime
        Status = Status.Created
    }
    Log.DefaultValue()
]



[<Theory>]
[<InlineData 0>]
[<InlineData 1>]
[<InlineData 2>]
[<InlineData 10>]
let ``Encode and parse logs should works`` (count: int) =
    let logs = logs |> List.take count
    let readPatterns = patterns |> Map.toList |> List.map (fun (_, x) -> x.Parse)
    for KeyValue(_, pattern) in patterns do
        encodeLogs pattern.Encode logs
        |> fun x -> x.Split "\r\n"
        |> parseLogs readPatterns
        |> should equal logs
