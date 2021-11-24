namespace rec BlazorStyled.DslInternals

open Bolero.Html
open Fun.Blazor
open Microsoft.AspNetCore.Components.DslInternals
open Microsoft.AspNetCore.Components.Web.DslInternals
open BlazorStyled.DslInternals


type StyledBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit FunBlazorContextWithAttrs<'FunBlazorGeneric>()
    new (x: string) as this = StyledBuilder<'FunBlazorGeneric>() then Bolero.Html.attr.fragment "ChildContent" (x |> html.text |> html.toBolero) |> BoleroAttr |> this.AddProp |> ignore
    new (x: IFunBlazorNode list) as this = StyledBuilder<'FunBlazorGeneric>() then Bolero.Html.attr.fragment "ChildContent" (x |> html.fragment |> html.toBolero) |> BoleroAttr |> this.AddProp |> ignore
    static member create (x: string) = StyledBuilder<'FunBlazorGeneric>(x) :> IFunBlazorNode
    static member create (x: IFunBlazorNode list) = StyledBuilder<'FunBlazorGeneric>(x) :> IFunBlazorNode
    [<CustomOperation("Id")>] member this.Id (_: FunBlazorContext<'FunBlazorGeneric>, x: System.String) = "Id" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("Priority")>] member this.Priority (_: FunBlazorContext<'FunBlazorGeneric>, x: System.Nullable<System.Int32>) = "Priority" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("Classname")>] member this.Classname (_: FunBlazorContext<'FunBlazorGeneric>, x: System.String) = "Classname" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("MediaQuery")>] member this.MediaQuery (_: FunBlazorContext<'FunBlazorGeneric>, x: BlazorStyled.MediaQueries) = "MediaQuery" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("IsKeyframes")>] member this.IsKeyframes (_: FunBlazorContext<'FunBlazorGeneric>, x: System.Boolean) = "IsKeyframes" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("PseudoClass")>] member this.PseudoClass (_: FunBlazorContext<'FunBlazorGeneric>, x: BlazorStyled.PseudoClasses) = "PseudoClass" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("ClassnameChanged")>] member this.ClassnameChanged (_: FunBlazorContext<'FunBlazorGeneric>, fn) = (Bolero.Html.attr.callback<System.String> "ClassnameChanged" (fun e -> fn e)) |> BoleroAttr |> this.AddProp
    [<CustomOperation("GlobalStyle")>] member this.GlobalStyle (_: FunBlazorContext<'FunBlazorGeneric>, x: System.String) = "GlobalStyle" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("ComposeAttributes")>] member this.ComposeAttributes (_: FunBlazorContext<'FunBlazorGeneric>, x: System.Collections.Generic.IReadOnlyDictionary<System.String, System.Object>) = "ComposeAttributes" => x |> BoleroAttr |> this.AddProp
                

type StyledGoogleFontBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit FunBlazorContext<'FunBlazorGeneric>()
    static member create () = StyledGoogleFontBuilder<'FunBlazorGeneric>() :> IFunBlazorNode
    [<CustomOperation("Id")>] member this.Id (_: FunBlazorContext<'FunBlazorGeneric>, x: System.String) = "Id" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("Priority")>] member this.Priority (_: FunBlazorContext<'FunBlazorGeneric>, x: System.Nullable<System.Int32>) = "Priority" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("Name")>] member this.Name (_: FunBlazorContext<'FunBlazorGeneric>, x: System.String) = "Name" => x |> BoleroAttr |> this.AddProp
    [<CustomOperation("Styles")>] member this.Styles (_: FunBlazorContext<'FunBlazorGeneric>, x: System.String) = "Styles" => x |> BoleroAttr |> this.AddProp
                

type _importsBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit FunBlazorContext<'FunBlazorGeneric>()
    static member create () = _importsBuilder<'FunBlazorGeneric>() :> IFunBlazorNode

                
            

// =======================================================================================================================

namespace BlazorStyled

[<AutoOpen>]
module DslCE =

    open BlazorStyled.DslInternals

    type Styled' = StyledBuilder<BlazorStyled.Styled>
    type StyledGoogleFont' = StyledGoogleFontBuilder<BlazorStyled.StyledGoogleFont>
    type _imports' = _importsBuilder<BlazorStyled._imports>
            