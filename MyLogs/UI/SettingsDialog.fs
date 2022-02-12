[<AutoOpen>]
module MyLogs.UI.SettingsDialog

open System
open System.IO
open FSharp.Data.Adaptive
open FSharp.Control.Reactive
open Fun.Blazor
open MudBlazor
open MyLogs.Core
open MyLogs.Services


let settingsDialog =
    html.inject (fun (hook: IComponentHook,
                      store: IShareStore,
                      settingsSvc: ISettingsService,
                      platformSvc: IPlatformService,
                      snackbar: ISnackbar,
                      dialog: IDialogService) ->
        let isLoading = cval false

        let settingsForm =
            hook
                .UseAdaptiveForm<Settings, string>(Settings.DefaultValue())
                .AddValidators((fun x -> x.LocalFolder), false, [ fun _ v -> if Directory.Exists v then [] else [ "Directory is not valid" ] ])

        let saveSettings close =
            isLoading.Publish true
            settingsSvc.SaveSettings(true, (fun _ -> settingsForm.GetValue()))
            |> Observable.ofTask
            |> Observable.subscribe (
                function
                | Error e ->
                    snackbar.Add(e, Severity.Error) |> ignore
                    isLoading.Publish false
                | Ok _ ->
                    isLoading.Publish false
                    close ()
            )
            |> hook.AddDispose


        hook.OnFirstAfterRender.Add <| fun _ -> settingsSvc.GetSettings() |> settingsForm.SetValue


        adaptiview () {
            let! i18n = store.UseI18n()
            let! windowSize = store.UseWindowSize()

            let dialogOptions = DialogOptions(FullScreen = (windowSize = ExtraSmall || windowSize = Small))

            let dialogBody (props: FunDialogProps) =
                MudDialog'() {
                    DisableSidePadding true
                    DialogContent [
                        MudContainer'() {
                            style'' {
                                overflowYAuto
                                if not (windowSize = ExtraSmall || windowSize = Small) then
                                    width 400
                                    maxHeight 500
                            }
                            adaptiview () {
                                let! (localPath, setLocalPath), errors = settingsForm.UseFieldWithErrors(fun x -> x.LocalFolder)
                                MudTextField'() {
                                    Label i18n.App.Settings.LocalFolder
                                    Value localPath
                                    ValueChanged setLocalPath
                                    Adornment Adornment.End
                                    AdornmentIcon Icons.Filled.FolderOpen
                                    OnAdornmentClick(fun _ ->
                                        let path = platformSvc.SelectFolder()
                                        if String.IsNullOrEmpty path |> not then setLocalPath path
                                    )
                                    Disabled(isIOS || isAndroid)
                                    Error(not errors.IsEmpty)
                                }
                            }
                            spaceV2
                            adaptiview () {
                                let! lang' = settingsForm.UseField(fun x -> x.Lang)
                                MudSelect'() {
                                    Label i18n.App.Settings.Language
                                    Value' lang'
                                    MudSelectItem'() {
                                        Value Lang.EN
                                        "English"
                                    }
                                    MudSelectItem'() {
                                        Value Lang.ZH
                                        "中文"
                                    }
                                }
                            }
                            spaceV2
                            adaptiview () {
                                let! firstDayOfWeek = settingsForm.UseField(fun x -> x.FirstDayOfWeek)
                                MudSelect'() {
                                    Label i18n.App.Settings.FirstDayOfWeek
                                    Value' firstDayOfWeek
                                    fragment {
                                        for day in Enum.GetValues<DayOfWeek>() do
                                            MudSelectItem'() {
                                                Value day
                                                formatWeekDay i18n day
                                            }
                                    }
                                }
                            }
                            spaceV2
                            adaptiview () {
                                let! theme = settingsForm.UseField(fun x -> x.Theme)
                                MudSelect'() {
                                    Label i18n.App.Settings.Theme
                                    Value' theme
                                    MudSelectItem'() { Value Theme.Light }
                                    MudSelectItem'() { Value Theme.Dark }
                                }
                            }
                            spaceV2
                            adaptiview () {
                                let! backgroundColor, setBgColor = settingsForm.UseField(fun x -> x.BackgroundColor)
                                MudColorPicker'() {
                                    Value(Utilities.MudColor backgroundColor)
                                    ValueChanged(string >> setBgColor)
                                    PickerVariant PickerVariant.Dialog
                                    Label i18n.App.Settings.BackgrounColor
                                }
                            }
                            spaceV2
                            div {
                                style'' { marginLeft -15 }
                                adaptiview () {
                                    let! enableHideHeaderTags = settingsForm.UseField(fun x -> x.EnableHideHeaderTags)
                                    MudCheckBox'() {
                                        Label i18n.App.Settings.EnableHideHeaderTags
                                        Checked' enableHideHeaderTags
                                    }
                                }
                                spaceV2
                                adaptiview () {
                                    let! enableHideTimeline = settingsForm.UseField(fun x -> x.EnableHideTimeline)
                                    MudCheckBox'() {
                                        Label i18n.App.Settings.EnableHideTimeline
                                        Checked' enableHideTimeline
                                    }
                                }
                                spaceV2
                                if not (isIOS || isAndroid) then
                                    adaptiview () {
                                        let! autoStart = settingsForm.UseField(fun x -> x.AutoStart)
                                        MudCheckBox'() {
                                            Label i18n.App.Settings.AutoStart
                                            Checked' autoStart
                                        }
                                    }
                                    spaceV2
                                    adaptiview () {
                                        let! alwaysClickable = settingsForm.UseField(fun x -> x.AlwaysClickable)
                                        MudCheckBox'() {
                                            Label i18n.App.Settings.AlwaysClickable
                                            Checked' alwaysClickable
                                        }
                                    }
                                    spaceV2
                                    adaptiview () {
                                        let! enableAlwaysOnBottom = settingsForm.UseField(fun x -> x.EnableAlwaysOnBottom)
                                        MudCheckBox'() {
                                            Label i18n.App.Settings.EnableAlwaysOnBottom
                                            Checked' enableAlwaysOnBottom
                                        }
                                    }
                                    spaceV2
                                    adaptiview () {
                                        let! enableBakcgroundBlur = settingsForm.UseField(fun x -> x.EnableBakcgroundBlur)
                                        MudCheckBox'() {
                                            Label i18n.App.Settings.EnableBackgroundBlur
                                            Checked' enableBakcgroundBlur
                                        }
                                        MudAlert'() {
                                            style'' { marginLeft 45 }
                                            Severity Severity.Warning
                                            i18n.App.Settings.EnableBackgroundBlurTip
                                        }
                                    }
                            }
                            spaceV2
                            adaptiview () {
                                let! isLoading = isLoading
                                if isLoading then
                                    MudOverlay'() {
                                        Visible true
                                        MudProgressCircular'.create ()
                                    }
                            }
                        }
                    ]
                    DialogActions [
                        MudButton'() {
                            Size Size.Small
                            OnClick(ignore >> props.Close)
                            i18n.App.Common.Close
                        }
                        adaptiview () {
                            let! errors = settingsForm.UseErrors()
                            MudButton'() {
                                Size Size.Small
                                Variant Variant.Filled
                                Color Color.Primary
                                OnClick(fun _ -> saveSettings props.Close)
                                Disabled(not errors.IsEmpty)
                                i18n.App.Common.Save
                            }
                        }
                    ]
                }

            MudIconButton'() {
                Icon Icons.Filled.Settings
                Size Size.Small
                OnClick(fun _ -> dialog.Show(i18n.App.Settings.Title, dialogBody, dialogOptions) |> ignore)
            }
        }
    )
