[<AutoOpen>]
module Utils

open System
open System.Text
open System.Text.Json
open System.Text.Json.Serialization
open System.Text.RegularExpressions


let private options =
    let op = JsonSerializerOptions()
    op.Converters.Add(JsonFSharpConverter())
    op


let toJson value = JsonSerializer.Serialize(value, options)
let fromJson<'T> (str: string) = JsonSerializer.Deserialize<'T>(str, options)


let getMonday () =
    if DateTime.Now.DayOfWeek = DayOfWeek.Sunday then
        DateTime.Now.AddDays(-6.)
    else
        DateTime.Now.AddDays(1. - float DateTime.Now.DayOfWeek)
    |> DateOnly.FromDateTime


let (|RegPattern|_|) (reg: Regex) (str: string) =
    let result = reg.Match str
    if result.Success then Some (result, str.Substring(result.Value.Length).Trim())
    else None


let (|RegPatterns|_|) (regs: Regex list) (str: string) =
    regs
    |> Seq.tryPick (fun reg ->
        let result = reg.Match str
        if result.Success then Some (result, str.Substring(result.Value.Length).Trim())
        else None
    )


let (|TimeOnly|_|) (str: string) =
    match TimeOnly.TryParse str with
    | true, x -> Some x
    | _ -> None


let (|DateTimeOffset|_|) (str: string) =
    match DateTimeOffset.TryParse str with
    | true, x -> Some x
    | _ -> None



let trim length (x: string) = if x.Length > length then x.Substring(0, length) else x


let trimLines length (x: string) =
    let ls = x.Split Environment.NewLine
    if ls |> Seq.filter (String.IsNullOrEmpty >> not) |> Seq.length > length then
        let mutable count = 0
        ls
        |> Seq.takeWhile (fun x ->
            if String.IsNullOrEmpty x |> not then
                count <- count + 1
            count <= length)
        |> Seq.fold
            (fun (s: StringBuilder) x -> s.AppendLine(x))
            (StringBuilder())
        |> fun x -> x.AppendLine().AppendLine("...")
        |> string
    else
        x


let isIOS =
    #if __IOS__
    true
    #else
    false
    #endif


let isAndroid =
    #if __ANDROID__
    true
    #else
    false
    #endif
