[<AutoOpen>]
module MyLogs.UI.Stores

open System
open System.IO
open FSharp.Data.Adaptive
open Fun.Blazor
open MyLogs.Core
open MyLogs.Services
open MudBlazor


[<Literal>]
let I18NTemplate = __SOURCE_DIRECTORY__ + "/i18n-en.json"

type I18N = Fun.I18n.Provider.I18nProvider<I18NTemplate, false>

let private i18nPath lang =
    try
        let assembly = Reflection.Assembly.GetExecutingAssembly()
        use stream =
            assembly.GetManifestResourceStream($"MyLogs.UI.i18n-{lang.ToString().ToLower()}.json")
        use reader = new StreamReader(stream)
        reader.ReadToEnd()
    with
        | ex -> "{}"

let private detaultI18n = I18N(i18nPath Lang.EN)


let private lightTheme () =
    MudTheme(
        Palette =
            Palette(
                Primary = "#679550",
                PrimaryDarken = "#4d6f3c",
                PrimaryLighten = "#e9fbdd",
                PrimaryContrastText = "rgba(255,255,255,0.80)",
                Black = "#272c34"
            )
    )
    |> Light

let private darkTheme () =
    MudTheme(
        Palette =
            Palette(
                Primary = "#679550",
                PrimaryDarken = "#4d6f3c",
                PrimaryLighten = "#e9fbdd",
                PrimaryContrastText = "rgba(255,255,255,0.80)",
                Black = "#27272f",
                Background = "#32333d",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                DrawerBackground = "#27272f",
                DrawerText = "rgba(255,255,255,0.60)",
                DrawerIcon = "rgba(255,255,255,0.60)",
                AppbarBackground = "#27272f",
                AppbarText = "rgba(255,255,255,0.70)",
                TextPrimary = "rgba(255,255,255,0.80)",
                TextSecondary = "rgba(255,255,255,0.60)",
                ActionDefault = "rgba(255,255,255,0.80)",
                ActionDisabled = "rgba(255,255,255,0.26)",
                ActionDisabledBackground = "rgba(255,255,255,0.12)",
                Divider = "rgba(255,255,255,0.12)",
                DividerLight = "rgba(255,255,255,0.06)",
                TableLines = "rgba(255,255,255,0.12)",
                LinesDefault = "rgba(255,255,255,0.12)",
                LinesInputs = "rgba(255,255,255,0.3)",
                TextDisabled = "rgba(255,255,255,0.2)"
            )
    )
    |> Dark


type IShareStore with

    member this.Theme = this.CreateCVal("theme", darkTheme ())

    member this.ThemeValue =
        this.Theme
        |> AVal.map (
            function
            | Light x
            | Dark x -> x
        )

    member this.IsDark =
        this.Theme
        |> AVal.map (
            function
            | Light _ -> false
            | Dark _ -> true
        )

    member this.SwitchTheme() =
        this.Theme.Publish(
            function
            | Light _ -> darkTheme ()
            | Dark _ -> lightTheme ()
        )


    member this.IsActive = this.CreateCVal("isactive", true)
    member this.PreferredBackground = this.CreateCVal("preferred-background", "#061f153f")
    member this.ViewType = this.CreateCVal("view-type", ViewType.Week)

    member this.Statuses = this.CreateCVal("status", List<string>.Empty)

    member this.TagsMap = this.CreateCVal("tags-map", Map.empty<string, Tag>)

    member this.GetTagColor tag =
        this.TagsMap.Value
        |> Map.tryFind tag
        |> Option.map (fun x -> x.Color)
        |> Option.defaultWith (fun _ -> this.ThemeValue |> AVal.force |> fun t -> t.Palette.Success.ToString())

    member this.Filter = this.CreateCVal("filter", Filter.DefaultValue)

    member this.InnerWidth = this.CreateCVal("inner-width", 0)
    member this.WindowSize = this.CreateCVal("window-size", Small)


    member this.I18n = this.CreateCVal("i18n", detaultI18n)

    member this.ChangeI18n(lang: Lang) =
        let i18n = this.I18n
        i18n.Publish(Fun.I18n.Provider.Utils.createI18nWith detaultI18n (i18nPath lang))


    member this.FirstDayOfWeek = this.CreateCVal("first-day-of-week", DayOfWeek.Monday)

    member this.StartTime = this.CreateCVal("start-time", getMonday ())

    member this.GoToToday() =
        let viewType = this.ViewType
        let startTime = this.StartTime

        match viewType.Value with
        | ViewType.Week ->
            let firstDay = int this.FirstDayOfWeek.Value
            getMonday().AddDays(firstDay - 1) |> startTime.Publish
        | ViewType.Day -> DateTime.Now |> DateOnly.FromDateTime |> startTime.Publish

    member this.GotoNextOrPreviousDays isForward =
        let flag = if isForward then 1 else -1
        let startTime = this.StartTime
        match this.ViewType.Value with
        | ViewType.Week -> startTime.Publish(fun s -> s.AddDays(7 * flag))
        | ViewType.Day -> startTime.Publish(fun s -> s.AddDays(1 * flag))
