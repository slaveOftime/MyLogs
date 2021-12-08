namespace MyLogs.Services

open System
open System.IO
open FSharp.Data.Adaptive
open Fun.Result
open Fun.Blazor
open MyLogs.Core


type SettingsService(windowSVC: IPlatformService) =
    let appSettingsPath =
        Environment.GetFolderPath Environment.SpecialFolder.LocalApplicationData
    let appSettingsFile = Path.Combine(appSettingsPath, "app.config")
    let detaultSettings =
        { Settings.DefaultValue() with
            LocalFolder = windowSVC.DefaultDataDir
        }

    let settings =
        cval (
            try
                File.ReadAllText appSettingsFile |> fromJson<Settings>
            with
                | _ -> detaultSettings
        )

    let saveToFile (x: Settings) =
        try
            File.WriteAllText(appSettingsFile, toJson x)
            TaskResult.retn ()
        with
            | ex -> TaskResult.ofError ex.Message


    do
        if Directory.Exists appSettingsPath |> not then
            Directory.CreateDirectory appSettingsPath |> ignore


    interface ISettingsService with
        member _.Settings = settings :> aval<_>

        member _.GetSettings() = settings.Value

        member _.SaveSettings(shouldNotify, fn) =
            taskResult {
                let settings' = settings.Value

                let s = fn settings'
                do! saveToFile s
                if shouldNotify then settings.Publish s
            }
