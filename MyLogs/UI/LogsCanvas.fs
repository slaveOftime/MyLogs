[<AutoOpen>]
module MyLogs.UI.LogsCanvas

open Feliz
open Fun.Blazor


let logsCanvas = html.inject <| fun (store: IShareStore) ->
    adaptiview(){
        let! viewType = store.UseViewType()
        let! windowSize = store.UseWindowSize()

        div(){
            styles [ style.height (length.percent 100); style.overflowHidden ]
            childContent [
                if windowSize = ExtraSmall && windowSize = Small then
                    logsDaysView 1
                else
                    match viewType with
                    | ViewType.Day -> logsDaysView 1
                    | ViewType.Week -> logsDaysView 7
            ]
        }
    }
