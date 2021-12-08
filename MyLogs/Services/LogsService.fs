namespace MyLogs.Services

open System
open System.IO
open FSharp.Data.Adaptive
open FSharp.Control.Reactive
open Fun.Blazor
open Fun.Result
open MyLogs.Core


[<AutoOpen>]
module Utils =
    type Settings with

        member this.GetLogsFile(date: DateOnly) =
            let myLogsFolder = Path.Combine(this.LocalFolder, "MyLogs")

            if Directory.Exists myLogsFolder |> not then
                Directory.CreateDirectory myLogsFolder |> ignore

            Path.Combine(myLogsFolder, date.ToString("yyyy-MM-dd") + ".md")


        member this.GetLogsOfTodayFile() =
            if Directory.Exists this.LocalFolder |> not then
                Directory.CreateDirectory this.LocalFolder |> ignore

            Path.Combine(this.LocalFolder, "logs-of-today.md")


        member this.GetLogTagsFile() =
            if Directory.Exists this.LocalFolder |> not then
                Directory.CreateDirectory this.LocalFolder |> ignore

            Path.Combine(this.LocalFolder, "tags.config")


        member this.GetLogDetailCacheFile() =
            Path.Combine(this.LocalFolder, "editing-log-detail.cache")



type LogsService(settingsSvc: ISettingsService) as this =
    let logs = cval<Map<DateOnly, Logs>> (Map.empty)
    let tags = cval<Tags> (Tags.DefaultValue)


    let readLogs logsFile =
        File.ReadLines logsFile
        |> ParseLogs.parseLogs LogPatterns.allParsePatterns
        |> List.map (fun x -> { x with Id = Guid.NewGuid() })

    let writeLogs file (logs: Logs) =
        let logsFileInfo = FileInfo file
        if logsFileInfo.LastWriteTime <= logs.LastModifiedTime then
            let logsString = EncodeLogs.encodeLogs LogPatterns.currentEncodePattern logs.Logs
            File.WriteAllText(file, logsString)
            TaskResult.ofSuccess ()
        else
            TaskResult.ofError DataIsChanged

    let appendLog file log =
        let logsString = EncodeLogs.encodeLogs LogPatterns.currentEncodePattern [ log ]
        if File.Exists file then
            File.AppendAllText(file, logsString)
        else
            File.WriteAllText(file, logsString)

    let reloadAfterWriteFor date =
        (this :> ILogsService).LoadLogs date |> TaskResult.mapError WriteDataError.FailedToRead


    do
        TimeSpan.FromSeconds 10
        |> Observable.interval
        |> Observable.add (fun _ ->
            taskResult {
                let settings = settingsSvc.GetSettings()

                for KeyValue (date, logs) in logs.Value do
                    let logsFile = settings.GetLogsFile date
                    let logsFileInfo = FileInfo logsFile
                    if logsFileInfo.LastWriteTime > logs.LastModifiedTime then
                        do! (this :> ILogsService).LoadLogs date

                let tagsFile = settings.GetLogTagsFile()
                let tagsFileInfo = FileInfo tagsFile
                if tagsFileInfo.LastWriteTime > tags.Value.LastModifiedTime then
                    do! (this :> ILogsService).LoadLogTags()

            }
            |> ignore
        )


    interface ILogsService with
        member _.Logs = logs
        member _.Tags = tags


        member _.ClearLogsCache() = logs.Publish Map.empty


        member _.LoadLogs date =
            taskResult {
                let settings = settingsSvc.GetSettings()

                let logFile = settings.GetLogsFile date
                let logFileInfo = FileInfo logFile

                if logFileInfo.Exists then
                    logs.Publish(
                        Map.add
                            date
                            {
                                LastModifiedTime = logFileInfo.LastWriteTime
                                Logs = readLogs logFile
                            }
                    )

                else
                    logs.Publish(Map.add date { LastModifiedTime = DateTime.Now; Logs = [] })
            }


        member _.CreateLog(date, log) =
            taskResult {
                let settings = settingsSvc.GetSettings()

                let logsFile = settings.GetLogsFile date
                match logs.Value |> Map.tryFind date with
                | None -> appendLog logsFile log
                | Some logs -> do! writeLogs logsFile { logs with Logs = log :: logs.Logs }

                do! reloadAfterWriteFor date
            }


        member _.ModifyLog(date, log, isDelete) =
            taskResult {
                let log =
                    { log with
                        UpdatedTime = Some DateTimeOffset.Now
                        Status =
                            match log.Detail with
                            | Detail.Markdown _ -> log.Status
                            | Detail.Todo ls ->
                                if ls |> Seq.exists (fun x -> not x.IsDone) |> not then
                                    Status.Done
                                else
                                    Status.Created
                    }

                let settings = settingsSvc.GetSettings()

                let modifyLogAt index (logs: Logs) =
                    { logs with
                        Logs =
                            if isDelete then
                                logs.Logs |> List.removeAt index
                            else
                                logs.Logs |> List.removeAt index |> List.insertAt index log
                    }

                match Map.tryFind date logs.Value with
                | None -> ()
                | Some logs ->
                    let logsFile = settings.GetLogsFile date
                    match logs.Logs |> List.tryFindIndex (fun x -> x.Id = log.Id) with
                    | None -> ()
                    | Some index ->
                        do! modifyLogAt index logs |> writeLogs logsFile
                        do! reloadAfterWriteFor date
            }


        member _.MarkLogAsDone(date, log) =
            taskResult {
                let settings = settingsSvc.GetSettings()

                let newLog =
                    { log with
                        Status = Status.Done
                        Detail =
                            match log.Detail with
                            | Detail.Markdown _ -> log.Detail
                            | Detail.Todo ls -> ls |> List.map (fun x -> { x with IsDone = true }) |> Detail.Todo
                    }

                match logs.Value |> Map.tryFind date with
                | None -> ()
                | Some logs ->
                    let newLogs =
                        { logs with
                            Logs = logs.Logs |> List.filter (fun x -> x.Id <> log.Id) |> fun ls -> ls @ [ newLog ]
                        }

                    do! writeLogs (settings.GetLogsFile date) newLogs
                    do! reloadAfterWriteFor date
            }


        member _.OrderLog(sourceDate, sourceLog, targetDate, targetLog) =
            taskResult {
                let settings = settingsSvc.GetSettings()

                do!
                    option {
                        let! sourceLogs = logs.Value |> Map.tryFind sourceDate
                        let! targetLogs = logs.Value |> Map.tryFind targetDate

                        let! sourceIndex = sourceLogs.Logs |> List.tryFindIndex (fun x -> x.Id = sourceLog.Id)
                        let! targetIndex = targetLogs.Logs |> List.tryFindIndex (fun x -> x.Id = targetLog.Id)

                        let targetLogsFile = settings.GetLogsFile targetDate
                        let sourceLogsFile = settings.GetLogsFile sourceDate

                        let newTargetLogs =
                            { targetLogs with
                                Logs = targetLogs.Logs |> List.insertAt targetIndex sourceLog
                            }

                        return
                            taskResult {
                                if sourceDate <> targetDate then
                                    let newSourceLogs =
                                        { sourceLogs with
                                            Logs = sourceLogs.Logs |> List.removeAt sourceIndex
                                        }
                                    do! writeLogs targetLogsFile newTargetLogs
                                    do! writeLogs sourceLogsFile newSourceLogs
                                    do! reloadAfterWriteFor targetDate
                                    do! reloadAfterWriteFor sourceDate
                                else
                                    let newTargetLogs =
                                        { newTargetLogs with
                                            Logs =
                                                newTargetLogs.Logs
                                                |> List.removeAt (if sourceIndex > targetIndex then sourceIndex + 1 else sourceIndex)
                                        }
                                    do! writeLogs targetLogsFile newTargetLogs
                                    do! reloadAfterWriteFor targetDate
                            }
                    }
                    |> Option.defaultWith (fun _ -> TaskResult.ofSuccess ())
            }


        member _.LoadLogTags() =
            taskResult {
                let settings = settingsSvc.GetSettings()

                let tagsFile = settings.GetLogTagsFile()
                let tagsFileInfo = FileInfo tagsFile

                let! tags' =
                    if File.Exists tagsFile then
                        try
                            TaskResult.retn
                                {
                                    LastModifiedTime = tagsFileInfo.LastWriteTime
                                    Tags = File.ReadAllText tagsFile |> fromJson<Tag list>
                                }
                        with
                            | ex -> TaskResult.ofError ex.Message
                    else
                        TaskResult.retn { LastModifiedTime = DateTime.Now; Tags = [] }

                tags.Publish tags'
            }


        member _.WriteLogTags tags' =
            taskResult {
                let settings = settingsSvc.GetSettings()

                let tagsFile = settings.GetLogTagsFile()
                let tagsFileInfo = FileInfo tagsFile

                if tagsFileInfo.LastWriteTime <= tags.Value.LastModifiedTime then
                    let tagsStr = toJson tags'
                    File.WriteAllText(tagsFile, tagsStr)
                    do! (this :> ILogsService).LoadLogTags() |> TaskResult.mapError WriteDataError.FailedToRead

                else
                    do! TaskResult.ofError DataIsChanged
            }


        member _.ReadLogDetailCache() =
            task {
                let cacheFile = settingsSvc.GetSettings().GetLogDetailCacheFile()
                return
                    if File.Exists cacheFile then
                        try
                            File.ReadAllText cacheFile |> fromJson<Detail> |> Some
                        with
                            | _ -> None
                    else
                        None
            }

        member _.WriteLogDetailCache detail =
            task {
                let cacheFile = settingsSvc.GetSettings().GetLogDetailCacheFile()
                try
                    match detail with
                    | None -> File.WriteAllText(cacheFile, "")
                    | Some detail ->
                        let content = toJson detail
                        File.WriteAllText(cacheFile, content)
                with
                    | _ -> ()
            }
