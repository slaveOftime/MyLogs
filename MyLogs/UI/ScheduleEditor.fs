[<AutoOpen>]
module MyLogs.UI.ScheduleEditor

open System
open FSharp.Control.Reactive
open Feliz
open Fun.Result
open Fun.Blazor
open MudBlazor
open MyLogs.Core

open type Styles


let scheduleEditor (date: DateTime) (schedule: Schedule) isDisabled onChanged =
    html.inject
    <| fun (hook: IComponentHook, store: IShareStore) ->
        adaptiview () {
            let! i18n = store.UseI18n()
            let! bgColor = store.UsePreferredBackground()

            div () {
                styles [
                    yield! lineStyles ()
                    yield! blurStyles (Utilities.MudColor(bgColor).SetAlpha(0.3).ToString(), 20)
                    style.boxShadow $"0 0 10px {Utilities.MudColor(bgColor).SetAlpha(0.6).ChangeLightness(0.3).ToString()}"
                    style.borderRadius radius
                ]
                childContent [
                    MudCheckBox'() {
                        Color(
                            match schedule with
                            | Schedule.Anytime -> Color.Success
                            | _ -> Color.Default
                        )
                        Checked(
                            match schedule with
                            | Schedule.Anytime -> true
                            | _ -> false
                        )
                        CheckedChanged(
                            function
                            | true -> Schedule.Anytime |> onChanged
                            | _ -> ()
                        )
                        Disabled isDisabled
                        childContent i18n.App.Schedule.Anytime
                    }
                    spaceH2
                    MudCheckBox'() {
                        Color(
                            match schedule with
                            | Schedule.Alarm _ -> Color.Success
                            | _ -> Color.Default
                        )
                        Checked(
                            match schedule with
                            | Schedule.Alarm _ -> true
                            | _ -> false
                        )
                        CheckedChanged(
                            function
                            | true -> Schedule.Alarm(TimeOnly.FromDateTime date) |> onChanged
                            | _ -> ()
                        )
                        Disabled isDisabled
                        childContent i18n.App.Schedule.Alarm
                    }
                    spaceH2
                    MudCheckBox'() {
                        Color(
                            match schedule with
                            | Schedule.Range _ -> Color.Success
                            | _ -> Color.Default
                        )
                        Checked(
                            match schedule with
                            | Schedule.Range _ -> true
                            | _ -> false
                        )
                        CheckedChanged(
                            function
                            | true -> Schedule.Range(TimeOnly.FromDateTime date, TimeOnly.FromDateTime(date).AddMinutes(30)) |> onChanged
                            | _ -> ()
                        )
                        Disabled isDisabled
                        childContent i18n.App.Schedule.Range
                    }
                ]
            }
            spaceV1
            div () {
                styles [
                    style.padding (length.px 0, length.px 15)
                ]
                childContent [
                    match schedule with
                    | Schedule.Anytime -> html.none
                    | Schedule.Alarm x ->
                        MudTimePicker'() {
                            Label i18n.App.LogDialog.AlarmOnTime
                            AmPm true
                            Time(x.ToTimeSpan())
                            TimeChanged(
                                Option.ofNullable
                                >> Option.map TimeOnly.FromTimeSpan
                                >> Option.defaultWith (fun _ -> TimeOnly.FromDateTime(DateTime.Now))
                                >> Schedule.Alarm
                                >> onChanged
                            )
                            Disabled isDisabled
                            PickerVariant PickerVariant.Dialog
                        }
                    | Schedule.Range (s, e) ->
                        div () {
                            styles (lineStyles ())
                            childContent [
                                MudTimePicker'() {
                                    Label i18n.App.LogDialog.StartTime
                                    AmPm true
                                    Time(s.ToTimeSpan())
                                    TimeChanged(
                                        Option.ofNullable
                                        >> Option.map TimeOnly.FromTimeSpan
                                        >> Option.defaultWith (fun _ -> TimeOnly.FromDateTime(DateTime.Now))
                                        >> fun s -> Schedule.Range(s, e)
                                        >> onChanged
                                    )
                                    Disabled isDisabled
                                    PickerVariant PickerVariant.Dialog
                                }
                                spaceH4
                                MudIcon'() { Icon Icons.Filled.ArrowForward }
                                spaceH4
                                MudTimePicker'() {
                                    Label i18n.App.LogDialog.EndTime
                                    AmPm true
                                    Time(e.ToTimeSpan())
                                    TimeChanged(
                                        Option.ofNullable
                                        >> Option.map TimeOnly.FromTimeSpan
                                        >> Option.defaultWith (fun _ -> TimeOnly.FromDateTime(DateTime.Now))
                                        >> fun e -> Schedule.Range(s, e)
                                        >> onChanged
                                    )
                                    Disabled isDisabled
                                    PickerVariant PickerVariant.Dialog
                                }
                            ]
                        }
                ]
            }
        }
