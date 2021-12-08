module Mylogs.Tests.Domain.Patterns

open Xunit
open FsUnit.Xunit.Typed
open MyLogs.Core.LogPatterns


[<Fact>]
let ``All parttern langs should be covered`` () =
    let expected =
        FSharp.Reflection.FSharpType.GetUnionCases(typeof<PartternLang>).Length

    patterns |> Map.keys |> Seq.distinct |> Seq.length |> should equal expected
