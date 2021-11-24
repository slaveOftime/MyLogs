namespace MyLogs.UI

open MudBlazor


[<RequireQualifiedAccess>]
type ViewType =
    | Week
    | Day


[<RequireQualifiedAccess>]
type Status =
    | Information of string
    | Warning of string
    | Error of string


type Theme =
    | Dark of MudTheme
    | Light of MudTheme


type Filter = {
    Tags: string list
} with
    static member DefaultValue = { Tags = [] }


type WindowSize =
    | ExtraSmall
    | Small
    | Medium
    | Large
    | ExtraLarge
    | ExtraLarge2
