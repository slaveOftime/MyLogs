[<AutoOpen>]
module MyLogs.UI.App

open System
open FSharp.Data.Adaptive
open Fun.Result
open Fun.Blazor
open MudBlazor
open BrowserInterop.Extensions
open Microsoft.JSInterop
open MyLogs.Core
open MyLogs.Services



let private listenToSizeChange (jsRuntime: IJSRuntime, store: IShareStore) =
    task {
        let! window = jsRuntime.Window()
        store.UseInnerWidth().Publish window.InnerWidth

        window.OnResize(fun () ->
            task {
                let! window = jsRuntime.Window()
                store.UseInnerWidth().Publish window.InnerWidth
                store.UseWindowSize().Publish(getWindowSize window.InnerWidth)
            }
            |> ignore
            System.Threading.Tasks.ValueTask.CompletedTask
        )
        |> ignore
    }
    |> ignore


let private applySettings
    (store: IShareStore, settingsSvc: ISettingsService, platformSvc: IPlatformService, logsSvc: ILogsService)
    (settings: Settings)
    =
    let bgColor = store.UsePreferredBackground()
    let filter = store.UseFilter()
    let theme = store.UseTheme()

    if bgColor.Value <> settings.BackgroundColor then
        bgColor.Publish settings.BackgroundColor

    if filter.Value.Tags <> settings.TagsFilter then
        filter.Publish(fun f -> { f with Tags = settings.TagsFilter })

    match settings.Theme, theme.Value with
    | Theme.Light, Dark _ -> store.SwitchTheme()
    | Theme.Dark, Light _ -> store.SwitchTheme()
    | _ -> ()

    platformSvc.SwitchAutoStart settings.AutoStart |> ignore
    platformSvc.SwitchBackgroundBlur settings.EnableBakcgroundBlur |> ignore
    logsSvc.LoadLogTags() |> ignore
    store.ChangeI18n settings.Lang


let private setViewType (store: IShareStore) windowSize =
    let viewType = store.UseViewType()
    if windowSize = ExtraSmall || windowSize = Small then
        viewType.Publish ViewType.Day
    else
        viewType.Publish ViewType.Week


let app =
    html.inject (fun (hook: IComponentHook,
                      store: IShareStore,
                      logsSvc: ILogsService,
                      platformSvc: IPlatformService,
                      settingsSvc: ISettingsService,
                      sp: IServiceProvider) ->
        let isActive = store.UseIsActive()
        let windowSize = store.UseWindowSize()
        let isLoading = cval true


        hook.OnFirstAfterRender.Add(fun () ->
            // Syncronous set all init datas to avoid UI flash
            applySettings (sp.GetMultipleServices()) (settingsSvc.GetSettings())

            let width, _ = platformSvc.GetSize()
            let size = getWindowSize (int width)
            store.UseInnerWidth().Publish(int width)
            windowSize.Publish size
            setViewType (sp.GetMultipleServices()) size
            store.GoToToday settingsSvc

            hook.AddDisposes [
                logsSvc.Tags.AddCallback(fun x -> x.Tags |> List.map (fun x -> x.Name, x) |> Map.ofList |> store.UseTagsMap().Publish)

                settingsSvc.Settings.AddLazyCallback(applySettings (sp.GetMultipleServices()))

                platformSvc.Activated.Subscribe(fun _ -> isActive.Publish true)
                platformSvc.Deactivated.Subscribe(fun _ ->
                    isActive.Publish false
                    platformSvc.HideWindowController()
                )

                windowSize.AddLazyCallback(setViewType (sp.GetMultipleServices()))
            ]

            listenToSizeChange (sp.GetMultipleServices())

            logsSvc.LoadLogTags() |> ignore
            isLoading.Publish false
        )


        adaptiview () {
            let! isLoading = isLoading

            if isLoading then
                MudThemeProvider'.create ()
                MudProgressLinear'() {
                    Size Size.Small
                    Color Color.Success
                    Indeterminate true
                }
            else
                let! theme = store.UseThemeValue()
                let! bgColor = store.UsePreferredBackground()
                let! isActive = isActive
                let! windowSize = windowSize

                div {
                    style'' {
                        displayFlex
                        flexDirectionColumn
                        alignItemsStretch
                        height "100%"
                        overflowHidden
                        blurStyles bgColor
                    }
                    MudThemeProvider'() { Theme theme }
                    MudDialogProvider'() { DisableBackdropClick true }
                    MudSnackbarProvider'.create ()
                    mudStylesOverride bgColor

                    topToolbar
                    logsCanvas
                    if isActive && (windowSize = ExtraSmall || windowSize = Small) then
                        bottomToolbar
                }
        }
    )
