[<AutoOpen>]
module MyLogs.UI.MoveLogToDateDialog

open System
open FSharp.Data.Adaptive
open FSharp.Control.Reactive
open Fun.Blazor
open MudBlazor
open Fun.Result
open MyLogs.Core
open MyLogs.Services


let moveLogToDateDialog (currentDate, log: Log) onClose onDone =
    html.inject (fun (store: IShareStore, logsSvc: ILogsService, snackbar: ISnackbar, hook: IComponentHook) ->
        let targetDate = cval None

        let move () =
            match targetDate.Value with
            | Some targetDate when targetDate <> currentDate ->
                taskResult {
                    do! logsSvc.CreateLog(targetDate, log)
                    do! logsSvc.ModifyLog(currentDate, log, true)
                }
                |> Observable.ofTask
                |> Observable.subscribe (
                    function
                    | Ok _ ->
                        logsSvc.LoadLogs currentDate |> ignore
                        logsSvc.LoadLogs targetDate |> ignore
                        onDone ()
                    | Error e -> snackbar.Add(string e, Severity.Error) |> ignore
                )
                |> hook.AddDispose
            | _ -> ()

        adaptiview () {
            let! i18n = store.I18n
            let! targetDate' = targetDate

            MudDialog'() {
                DialogContent [
                    MudDatePicker'() {
                        Date(targetDate' |> Option.map (fun x -> x.ToString("yyyy/MM/dd") |> DateTime.Parse) |> Option.toNullable)
                        DateChanged(Option.ofNullable >> Option.map DateOnly.FromDateTime >> targetDate.Publish)
                        Label "Pick a date"
                        PickerVariant PickerVariant.Dialog
                    }
                ]
                DialogActions [
                    MudButton'() {
                        OnClick(ignore >> onClose)
                        i18n.App.Common.Close
                    }
                    match targetDate' with
                    | Some t when t <> currentDate ->
                        MudButton'() {
                            Color Color.Primary
                            Variant Variant.Filled
                            OnClick(ignore >> move)
                            i18n.App.MoveLogToDate
                        }
                    | _ -> html.none
                ]
            }
        }
    )
