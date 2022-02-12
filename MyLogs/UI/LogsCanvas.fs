[<AutoOpen>]
module MyLogs.UI.LogsCanvas

open Fun.Blazor


let logsCanvas =
    html.inject (fun (store: IShareStore) ->
        adaptiview () {
            let! viewType = store.UseViewType()
            let! windowSize = store.UseWindowSize()

            div {
                style'' {
                    height "100%"
                    overflowHidden
                }
                if windowSize = ExtraSmall && windowSize = Small then
                    logsDaysView 1
                else
                    match viewType with
                    | ViewType.Day -> logsDaysView 1
                    | ViewType.Week -> logsDaysView 7
            }
        }
    )
