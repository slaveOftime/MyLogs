[<AutoOpen>]
module MyLogs.UI.Toolbar

open System
open FSharp.Control.Reactive
open FSharp.Data.Adaptive
open Feliz
open Fun.Result
open Fun.Blazor
open MudBlazor
open MyLogs.Core
open MyLogs.Services
open type Styles


let private header = html.inject <| fun (store: IShareStore) ->
    adaptiview(){
        let! theme = store.UseThemeValue()
        img(){
            src "_content/MyLogs/assets/mylogs.png"
            styles [ style.marginLeft 5; style.height 25 ]
        }
        h1(){
            childContent "My Logs"
            styles [
                style.fontSize 14; style.fontWeight 500; style.userSelectNone
                style.marginLeft 5; style.whiteSpaceNowrap
                style.color (string theme.Palette.TextSecondary)
            ]
        }
    }


let private statusBar = html.inject <| fun (store: IShareStore) ->
    adaptiview(){
        let! theme = store.UseThemeValue()
        let! statuses = store.UseStatuses()

        div(){
            styles [
                style.fontSize 12; style.color (string theme.Palette.InfoLighten); style.textAlignCenter
                style.overflowHidden; style.whiteSpaceNowrap; style.width (length.percent 100)
            ]
            childContent (
                if statuses.Length > 0 then statuses.Head
                else ""
            )
        }
    }


let private closeBtn = html.inject <| fun (platformSvc: IPlatformService) ->
    MudIconButton'(){
        Size Size.Small
        Icon Icons.Filled.Close
        Color Color.Error
        OnClick (fun _ -> platformSvc.Close())
    }


let private gotoTodayButton = html.inject <| fun (settingsSvc: ISettingsService, store: IShareStore, hook: IComponentHook) ->
    adaptiview(){
        let! i18n = store.UseI18n()
        let! startTime = store.UseStartTime()
        let! firstDayOfWeek = settingsSvc.Settings |> AVal.map (fun x -> x.FirstDayOfWeek)
        let! viewType = store.UseViewType()

        let isToday =
            match viewType with
            | ViewType.Day -> startTime = DateOnly.FromDateTime DateTime.Now
            | ViewType.Week -> startTime = getMonday().AddDays(int firstDayOfWeek - 1)

        MudButton'(){
            Size Size.Small
            OnClick (fun _ -> store.GoToToday settingsSvc)
            Variant (if isToday then Variant.Filled else Variant.Text)
            Color (if isToday then Color.Primary else Color.Default)
            Styles [ style.custom ("zoom", "0.8") ]
            childContent i18n.App.GotoToday
        }
    }


let private nextOrPrevButtons = html.inject <| fun (store: IShareStore) ->
    MudButtonGroup'(){
        Size Size.Small
        Variant Variant.Outlined
        preventDefault "onclick" true
        childContent [
            MudIconButton'(){
                Size Size.Small
                Icon Icons.Filled.ArrowBackIos
                OnClick(fun _ -> store.GotoNextOrPreviousDays false)
            }
            MudIconButton'(){
                Size Size.Small
                Icon Icons.Filled.ArrowForwardIos
                OnClick(fun _ -> store.GotoNextOrPreviousDays true)
            }
        ]
    }


let private filterBar isAvtivate = html.inject <| fun (store: IShareStore) ->
    adaptiview(){
        let! i18n = store.UseI18n()
        let! filter', setFilter = store.UseFilter().WithSetter()
        let hasFilter = filter'.Tags.Length > 0
        
        match isAvtivate, hasFilter with
        | false, false -> html.none
        | false, true ->
            div(){
                styles [ yield! lineStyles(); style.opacity 0.5 ]
                childContent [
                    for tag in filter'.Tags do
                        div(){
                            styles [ style.backgroundColor (store.GetTagColor tag); style.height 10; style.width 40 ]
                        }
                ]
            }
        | true, _ ->
            spaceH2
            div(){
                styles [ yield! lineStyles(); style.custom ("zoom", "0.8") ]
                childContent [
                    newTagChip i18n.App.FilterByTags (fun tag -> setFilter {
                        filter' with Tags = filter'.Tags@[tag] |> List.distinct
                    })
                    spaceH2
                    for index, tag in List.indexed filter'.Tags do
                        tagChip false tag 
                            (fun _ -> setFilter {
                                filter' with Tags = filter'.Tags |> List.removeAt index
                            })
                            (fun newTag -> setFilter {
                                filter' with Tags = filter'.Tags |> List.updateAt index newTag |> List.distinct
                            })
                ]
            }
            spaceH4
    }


let private viewTypeSwitcher = html.inject <| fun (store: IShareStore) ->
    adaptiview(){
        let! i18n = store.UseI18n()
        let! viewType, setViewType = store.UseViewType().WithSetter()

        MudButtonGroup'(){
            Size Size.Small
            Variant Variant.Text
            childContent [
                MudButton'(){
                    Size Size.Small
                    OnClick (fun _ -> setViewType ViewType.Week)
                    Color (match viewType with ViewType.Week -> Color.Primary | _ -> Color.Default)
                    childContent i18n.App.ViewType.Week
                }
                MudButton'(){
                    Size Size.Small
                    OnClick (fun _ -> setViewType ViewType.Day)
                    Color (match viewType with ViewType.Day -> Color.Primary | _ -> Color.Default)
                    childContent i18n.App.ViewType.Day
                }
            ]
        }
    }


let bottomToolbar = html.inject <| fun (settingsSvc: ISettingsService, store: IShareStore, hook: IComponentHook) ->
    let startTime = store.UseStartTime()

    hook.AddDisposes [
        settingsSvc.Settings.AddLazyCallback (fun _ -> DateTime.Now |> DateOnly.FromDateTime |> startTime.Publish)
    ]

    adaptiview(){
        let! bgColor = store.UsePreferredBackground() |> AVal.map Utilities.MudColor
        let! startTime' = startTime
     
        div(){
            styles [
                style.flexShrink 0; style.padding(length.px 10, length.px 15)
                yield! lineStyles()
                yield! blurStyles (bgColor.SetAlpha(bgColor.APercentage + 0.2).ChangeLightness(0.15).ToString())
            ]
            childContent [
                MudDatePicker'(){
                    PickerVariant PickerVariant.Inline
                    Date (startTime'.ToDateTime(TimeOnly()))
                    DateChanged (Option.ofNullable >> Option.iter (DateOnly.FromDateTime >> startTime.Publish))
                    Styles [ style.marginTop -5; style.width 140 ]
                    Elevation 10
                }
                spaceHF
                nextOrPrevButtons
            ]
        }
    }


let topToolbar = html.inject <| fun (window: IPlatformService, hook: IComponentHook, store: IShareStore, settingsSvc: ISettingsService, snackbar: ISnackbar) ->
    let windowIsActive = store.UseIsActive()

    let filter = store.UseFilter()
    let statuses = store.UseStatuses()

    let isAvtivate = cval windowIsActive.Value


    hook.AddDisposes [
        TimeSpan.FromSeconds 5
        |> Observable.interval
        |> Observable.subscribe (fun _ ->
            if statuses.Value.Length > 0 then
                statuses.Publish (List.removeAt 0))

        filter.AddLazyCallback (fun (f: Filter) ->
            settingsSvc.SaveSettings (false, fun s -> { s with TagsFilter = f.Tags })
            |> TaskResult.mapError (fun e -> snackbar.Add(e, Severity.Error) |> ignore)
            |> ignore
        )

        windowIsActive.AddLazyCallback (function
            | false -> isAvtivate.Publish false
            | _ -> ()
        )

        isAvtivate.AddLazyCallback (function
            | true -> window.ShowWindowController()
            | _ -> ()
        )
    ]


    adaptiview(){
        let! bgColor = store.UsePreferredBackground()
        let! windowSize = store.UseWindowSize()
        let! isAvtivate' = isAvtivate

        let bgAlpha = Utilities.MudColor(bgColor).APercentage

        div(){
            styles [
                style.displayFlex; style.alignItemsCenter; style.justifyContentSpaceBetween; style.flexShrink 0
                style.overflowYHidden; style.overflowXAuto; style.cursorPointer
                if isAvtivate' then
                    style.height 40
                    yield! blurStyles (Utilities.MudColor(bgColor).SetAlpha(bgAlpha + 0.2).ChangeLightness(0.15).ToString())
                else
                    style.height 5
                    yield! blurStyles (Utilities.MudColor(bgColor).SetAlpha(0.30).ToString())
            ]
            onclick (fun _ -> isAvtivate.Publish true)
            childContent [
                if not (windowSize = ExtraSmall || windowSize = Small) then
                    if isAvtivate' then header
                    spaceH4
                    statusBar
                    spaceH4
                filterBar isAvtivate'
                if windowSize = ExtraSmall || windowSize = Small then
                    spaceHF
                if isAvtivate' then
                    if not (windowSize = ExtraSmall || windowSize = Small) then
                        gotoTodayButton
                        spaceH2
                        viewTypeSwitcher
                    spaceH2
                    settingsDialog
                    spaceH2
                    if not (windowSize = ExtraSmall || windowSize = Small) then
                        closeBtn
                        spaceH2
                        nextOrPrevButtons
                        spaceH2
            ]
        }
    }
