[<AutoOpen>]
module MyLogs.UI.Dialogs

open Fun.Blazor
open MudBlazor
open Microsoft.AspNetCore.Components


type FunDialogProps = {
    Close: unit -> unit
    Options: DialogOptions
}


type FunDialog() =
    inherit FunBlazorComponent()
    
    [<CascadingParameter>]
    member val MudDialogInstance = Unchecked.defaultof<MudDialogInstance> with get, set

    [<Parameter>]
    member val RenderFn = Unchecked.defaultof<FunDialogProps -> Bolero.Node> with get, set

    member this.CloseDialog() = 
        this.InvokeAsync(fun _ -> this.MudDialogInstance.Close())
        |> ignore


    override this.Render() =
        this.RenderFn {
            Close = this.CloseDialog
            Options = this.MudDialogInstance.Options
        }


type IDialogService with
    member this.Show (title, render: FunDialogProps -> Bolero.Node, ?options) =
        let options = options |> Option.defaultWith (fun _ -> DialogOptions())
        let parameters = DialogParameters()
        parameters.Add("RenderFn", render)
        this.Show<FunDialog>(title, parameters, options)

    member this.Show (title, render: FunDialogProps -> Bolero.Node) =
        this.Show(title, render, DialogOptions()) |> ignore

    member this.Show (render: FunDialogProps -> Bolero.Node) =
        this.Show("", render, DialogOptions()) |> ignore
    
    member this.Show (options, render: FunDialogProps -> Bolero.Node) =
        this.Show("", render, options) |> ignore
