namespace MyLogs.Core

open System
open System.Globalization


[<RequireQualifiedAccess>]
type Schedule =
    | Anytime
    | Alarm of TimeOnly
    | Range of startTime: TimeOnly * endTime: TimeOnly

[<RequireQualifiedAccess>]
type Status =
    | Created
    | Done

type TodoItem = { Content: string; IsDone: bool }

[<RequireQualifiedAccess>]
type Detail =
    | Markdown of string
    | Todo of TodoItem list

type Log =
    {
        Id: Guid
        Title: string
        Detail: Detail
        Tags: string list
        CreatedTime: DateTimeOffset
        UpdatedTime: DateTimeOffset option
        Schedule: Schedule
        Status: Status
    }

    static member DefaultValue() =
        {
            Id = Guid.Empty
            Title = ""
            Detail = Detail.Markdown ""
            Tags = []
            CreatedTime = DateTimeOffset.Now
            UpdatedTime = None
            Schedule = Schedule.Anytime
            Status = Status.Created
        }


type Logs =
    {
        LastModifiedTime: DateTime
        Logs: Log list
    }

    static member DefaultValue = { LastModifiedTime = DateTime.Now; Logs = [] }


type Tag = { Name: string; Color: string; UsageCount: int64 }

type Tags =
    {
        LastModifiedTime: DateTime
        Tags: Tag list
    }

    static member DefaultValue = { LastModifiedTime = DateTime.Now; Tags = [] }


[<RequireQualifiedAccess>]
type Theme =
    | Auto
    | Dark
    | Light


[<RequireQualifiedAccess>]
type Lang =
    | EN
    | ZH


type Settings =
    {
        Theme: Theme
        LocalFolder: string
        FirstDayOfWeek: DayOfWeek
        AutoStart: bool
        AlwaysClickable: bool
        EnableBakcgroundBlur: bool
        EnableHideHeaderTags: bool
        EnableHideTimeline: bool
        EnableAlwaysOnBottom: bool
        BackgroundColor: string
        TagsFilter: string list
        Lang: Lang
    }

    static member DefaultValue() =
        {
            Theme = Theme.Dark
            LocalFolder = ""
            FirstDayOfWeek = DayOfWeek.Monday
            AutoStart = false
            AlwaysClickable = true
            EnableBakcgroundBlur = false
            EnableHideHeaderTags = true
            EnableHideTimeline = true
            EnableAlwaysOnBottom = false
            BackgroundColor = "#49154c73"
            TagsFilter = []
            Lang =
                match CultureInfo.CurrentUICulture.TwoLetterISOLanguageName with
                | "zh" -> Lang.ZH
                | _ -> Lang.EN
        }
