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
        store.InnerWidth.Publish window.InnerWidth

        window.OnResize(fun () ->
            task {
                let! window = jsRuntime.Window()
                store.InnerWidth.Publish window.InnerWidth
                store.WindowSize.Publish(getWindowSize window.InnerWidth)
            }
            |> ignore
            System.Threading.Tasks.ValueTask.CompletedTask
        )
        |> ignore
    }
    |> ignore


let private applySettings
    (store: IShareStore, platformSvc: IPlatformService, logsSvc: ILogsService)
    (settings: Settings)
    =
    transact (fun () ->
        let bgColor = store.PreferredBackground
        let filter = store.Filter
        let theme = store.Theme

        if bgColor.Value <> settings.BackgroundColor then
            bgColor.Value <- settings.BackgroundColor

        if filter.Value.Tags <> settings.TagsFilter then
            filter.Value <- { filter.Value with Tags = settings.TagsFilter }

        match settings.Theme, theme.Value with
        | Theme.Light, Dark _ -> store.SwitchTheme()
        | Theme.Dark, Light _ -> store.SwitchTheme()
        | _ -> ()

        platformSvc.SwitchAutoStart settings.AutoStart |> ignore
        platformSvc.SwitchBackgroundBlur settings.EnableBakcgroundBlur |> ignore
        logsSvc.LoadLogTags() |> ignore
        store.ChangeI18n settings.Lang
        store.FirstDayOfWeek.Value <- settings.FirstDayOfWeek
    )
    store.GoToToday()



let private setViewType (store: IShareStore) windowSize =
    let viewType = store.ViewType
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
        let isActive = store.IsActive
        let windowSize = store.WindowSize
        let isLoading = cval true


        hook.OnFirstAfterRender.Add(fun () ->
            // Syncronous set all init datas to avoid UI flash
            applySettings (sp.GetMultipleServices()) (settingsSvc.GetSettings())

            let width, _ = platformSvc.GetSize()
            let size = getWindowSize (int width)
            store.InnerWidth.Publish(int width)
            windowSize.Publish size
            setViewType (sp.GetMultipleServices()) size
            store.GoToToday()

            hook.AddDisposes [
                logsSvc.Tags.AddCallback(fun x -> x.Tags |> List.map (fun x -> x.Name, x) |> Map.ofList |> store.TagsMap.Publish)

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
                let! theme = store.ThemeValue
                let! bgColor = store.PreferredBackground
                let! isActive = isActive
                let! windowSize = windowSize

                div {
                    style'' {
                        displayFlex
                        flexDirectionColumn
                        alignItemsStretch
                        height "100%"
                        overflowHidden
                        blurStyles bgColor 10
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
