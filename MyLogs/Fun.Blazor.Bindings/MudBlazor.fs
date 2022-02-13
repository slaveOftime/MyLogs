namespace rec MudBlazor.DslInternals

open FSharp.Data.Adaptive
open Fun.Blazor
open Fun.Blazor.Operators
open MudBlazor.DslInternals


type MudComponentBaseBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudComponentBaseBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Classes")>] member inline _.Classes ([<InlineIfLambda>] render: AttrRenderFragment, x: string list) = render ==> html.classes x
    [<CustomOperation("Styles")>] member inline _.Styles ([<InlineIfLambda>] render: AttrRenderFragment, x: (string * string) list) = render ==> html.styles x
    [<CustomOperation("Tag")>] member inline _.Tag ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("Tag" => x)
    [<CustomOperation("UserAttributes")>] member inline _.UserAttributes ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.Dictionary<System.String, System.Object>) = render ==> ("UserAttributes" => x)
                

type MudBaseButtonBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudBaseButtonBuilder<'FunBlazorGeneric>())
    [<CustomOperation("HtmlTag")>] member inline _.HtmlTag ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HtmlTag" => x)
    [<CustomOperation("ButtonType")>] member inline _.ButtonType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ButtonType) = render ==> ("ButtonType" => x)
    [<CustomOperation("Link")>] member inline _.Link ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Link" => x)
    [<CustomOperation("Target")>] member inline _.Target ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Target" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("DisableElevation")>] member inline _.DisableElevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableElevation" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Command")>] member inline _.Command ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Windows.Input.ICommand) = render ==> ("Command" => x)
    [<CustomOperation("CommandParameter")>] member inline _.CommandParameter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("CommandParameter" => x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
                

type MudButtonBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseButtonBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudButtonBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudButtonBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("StartIcon")>] member inline _.StartIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("StartIcon" => x)
    [<CustomOperation("EndIcon")>] member inline _.EndIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("EndIcon" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("IconClass")>] member inline _.IconClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("IconClass" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("FullWidth")>] member inline _.FullWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FullWidth" => x)
                

type MudFabBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseButtonBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudFabBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("StartIcon")>] member inline _.StartIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("StartIcon" => x)
    [<CustomOperation("EndIcon")>] member inline _.EndIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("EndIcon" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("IconSize")>] member inline _.IconSize ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("IconSize" => x)
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Label" => x)
                

type MudIconButtonBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseButtonBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudIconButtonBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudIconButtonBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Edge")>] member inline _.Edge ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Edge) = render ==> ("Edge" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
                

type MudFileUploaderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseButtonBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudFileUploaderBuilder<'FunBlazorGeneric>())

                

type MudDrawerContainerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudDrawerContainerBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudDrawerContainerBuilder<'FunBlazorGeneric>(){ yield! x }

                

type MudLayoutBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudDrawerContainerBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudLayoutBuilder<'FunBlazorGeneric>())

                

type MudBaseSelectItemBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudBaseSelectItemBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudBaseSelectItemBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Href")>] member inline _.Href ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Href" => x)
    [<CustomOperation("ForceLoad")>] member inline _.ForceLoad ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ForceLoad" => x)
    [<CustomOperation("CommandParameter")>] member inline _.CommandParameter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("CommandParameter" => x)
    [<CustomOperation("Command")>] member inline _.Command ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Windows.Input.ICommand) = render ==> ("Command" => x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
                

type MudNavLinkBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseSelectItemBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudNavLinkBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("Match")>] member inline _.Match ([<InlineIfLambda>] render: AttrRenderFragment, x: Microsoft.AspNetCore.Components.Routing.NavLinkMatch) = render ==> ("Match" => x)
    [<CustomOperation("Target")>] member inline _.Target ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Target" => x)
                

type MudSelectItemBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseSelectItemBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudSelectItemBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Value" => x)
                

type MudTableBaseBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudTableBaseBuilder<'FunBlazorGeneric>())
    [<CustomOperation("IsEditRowSwitchingBlocked")>] member inline _.IsEditRowSwitchingBlocked ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsEditRowSwitchingBlocked" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("Outlined")>] member inline _.Outlined ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Outlined" => x)
    [<CustomOperation("Bordered")>] member inline _.Bordered ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Bordered" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("Hover")>] member inline _.Hover ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Hover" => x)
    [<CustomOperation("Striped")>] member inline _.Striped ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Striped" => x)
    [<CustomOperation("Breakpoint")>] member inline _.Breakpoint ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Breakpoint) = render ==> ("Breakpoint" => x)
    [<CustomOperation("FixedHeader")>] member inline _.FixedHeader ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FixedHeader" => x)
    [<CustomOperation("FixedFooter")>] member inline _.FixedFooter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FixedFooter" => x)
    [<CustomOperation("Height")>] member inline _.Height ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Height" => x)
    [<CustomOperation("SortLabel")>] member inline _.SortLabel ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SortLabel" => x)
    [<CustomOperation("AllowUnsorted")>] member inline _.AllowUnsorted ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AllowUnsorted" => x)
    [<CustomOperation("RowsPerPage")>] member inline _.RowsPerPage ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("RowsPerPage" => x)
    [<CustomOperation("RowsPerPage'")>] member inline _.RowsPerPage' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Int32>) = render ==> html.bind("RowsPerPage", value)
    [<CustomOperation("RowsPerPage'")>] member inline _.RowsPerPage' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Int32>) = render ==> html.bind("RowsPerPage", value)
    [<CustomOperation("RowsPerPage'")>] member inline _.RowsPerPage' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Int32 * (System.Int32 -> unit)) = render ==> html.bind("RowsPerPage", valueFn)
    [<CustomOperation("RowsPerPageChanged")>] member inline _.RowsPerPageChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Int32>("RowsPerPageChanged", fn)
    [<CustomOperation("CurrentPage")>] member inline _.CurrentPage ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("CurrentPage" => x)
    [<CustomOperation("MultiSelection")>] member inline _.MultiSelection ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("MultiSelection" => x)
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ToolBarContent", fragment)
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ToolBarContent", fragment { yield! fragments })
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ToolBarContent", html.text x)
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ToolBarContent", html.text x)
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ToolBarContent", html.text x)
    [<CustomOperation("Loading")>] member inline _.Loading ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Loading" => x)
    [<CustomOperation("LoadingProgressColor")>] member inline _.LoadingProgressColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("LoadingProgressColor" => x)
    [<CustomOperation("HeaderContent")>] member inline _.HeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("HeaderContent", fragment)
    [<CustomOperation("HeaderContent")>] member inline _.HeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("HeaderContent", fragment { yield! fragments })
    [<CustomOperation("HeaderContent")>] member inline _.HeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("HeaderContent", html.text x)
    [<CustomOperation("HeaderContent")>] member inline _.HeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("HeaderContent", html.text x)
    [<CustomOperation("HeaderContent")>] member inline _.HeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("HeaderContent", html.text x)
    [<CustomOperation("CustomHeader")>] member inline _.CustomHeader ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("CustomHeader" => x)
    [<CustomOperation("HeaderClass")>] member inline _.HeaderClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderClass" => x)
    [<CustomOperation("FooterContent")>] member inline _.FooterContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("FooterContent", fragment)
    [<CustomOperation("FooterContent")>] member inline _.FooterContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("FooterContent", fragment { yield! fragments })
    [<CustomOperation("FooterContent")>] member inline _.FooterContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("FooterContent", html.text x)
    [<CustomOperation("FooterContent")>] member inline _.FooterContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("FooterContent", html.text x)
    [<CustomOperation("FooterContent")>] member inline _.FooterContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("FooterContent", html.text x)
    [<CustomOperation("CustomFooter")>] member inline _.CustomFooter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("CustomFooter" => x)
    [<CustomOperation("FooterClass")>] member inline _.FooterClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterClass" => x)
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ColGroup", fragment)
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ColGroup", fragment { yield! fragments })
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ColGroup", html.text x)
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ColGroup", html.text x)
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ColGroup", html.text x)
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("PagerContent", fragment)
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("PagerContent", fragment { yield! fragments })
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("PagerContent", html.text x)
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("PagerContent", html.text x)
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("PagerContent", html.text x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("OnCommitEditClick")>] member inline _.OnCommitEditClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnCommitEditClick", fn)
    [<CustomOperation("OnCancelEditClick")>] member inline _.OnCancelEditClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnCancelEditClick", fn)
    [<CustomOperation("OnPreviewEditClick")>] member inline _.OnPreviewEditClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Object>("OnPreviewEditClick", fn)
    [<CustomOperation("CommitEditCommand")>] member inline _.CommitEditCommand ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Windows.Input.ICommand) = render ==> ("CommitEditCommand" => x)
    [<CustomOperation("CommitEditCommandParameter")>] member inline _.CommitEditCommandParameter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("CommitEditCommandParameter" => x)
    [<CustomOperation("CommitEditTooltip")>] member inline _.CommitEditTooltip ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CommitEditTooltip" => x)
    [<CustomOperation("CancelEditTooltip")>] member inline _.CancelEditTooltip ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CancelEditTooltip" => x)
    [<CustomOperation("CommitEditIcon")>] member inline _.CommitEditIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CommitEditIcon" => x)
    [<CustomOperation("CancelEditIcon")>] member inline _.CancelEditIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CancelEditIcon" => x)
    [<CustomOperation("CanCancelEdit")>] member inline _.CanCancelEdit ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("CanCancelEdit" => x)
    [<CustomOperation("RowEditPreview")>] member inline _.RowEditPreview ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("RowEditPreview" => (System.Action<System.Object>fn))
    [<CustomOperation("RowEditCommit")>] member inline _.RowEditCommit ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("RowEditCommit" => (System.Action<System.Object>fn))
    [<CustomOperation("RowEditCancel")>] member inline _.RowEditCancel ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("RowEditCancel" => (System.Action<System.Object>fn))
    [<CustomOperation("TotalItems")>] member inline _.TotalItems ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("TotalItems" => x)
    [<CustomOperation("RowClass")>] member inline _.RowClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RowClass" => x)
    [<CustomOperation("RowStyle")>] member inline _.RowStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RowStyle" => x)
    [<CustomOperation("Virtualize")>] member inline _.Virtualize ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Virtualize" => x)
                

type MudTableBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudTableBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudTableBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("RowTemplate")>] member inline _.RowTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("RowTemplate", fn)
    [<CustomOperation("ChildRowContent")>] member inline _.ChildRowContent ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("ChildRowContent", fn)
    [<CustomOperation("RowEditingTemplate")>] member inline _.RowEditingTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("RowEditingTemplate", fn)
    [<CustomOperation("Columns")>] member inline _.Columns ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("Columns", fn)
    [<CustomOperation("QuickColumns")>] member inline _.QuickColumns ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("QuickColumns" => x)
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("NoRecordsContent", fragment)
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("NoRecordsContent", fragment { yield! fragments })
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("NoRecordsContent", html.text x)
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("NoRecordsContent", html.text x)
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("NoRecordsContent", html.text x)
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("LoadingContent", fragment)
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("LoadingContent", fragment { yield! fragments })
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("LoadingContent", html.text x)
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("LoadingContent", html.text x)
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("LoadingContent", html.text x)
    [<CustomOperation("HorizontalScrollbar")>] member inline _.HorizontalScrollbar ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HorizontalScrollbar" => x)
    [<CustomOperation("Items")>] member inline _.Items ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.IEnumerable<'T>) = render ==> ("Items" => x)
    [<CustomOperation("Filter")>] member inline _.Filter ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("Filter" => (System.Func<'T, System.Boolean>fn))
    [<CustomOperation("OnRowClick")>] member inline _.OnRowClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.TableRowClickEventArgs<'T>>("OnRowClick", fn)
    [<CustomOperation("RowClassFunc")>] member inline _.RowClassFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("RowClassFunc" => (System.Func<'T, System.Int32, System.String>fn))
    [<CustomOperation("RowStyleFunc")>] member inline _.RowStyleFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("RowStyleFunc" => (System.Func<'T, System.Int32, System.String>fn))
    [<CustomOperation("SelectedItem")>] member inline _.SelectedItem ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("SelectedItem" => x)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("SelectedItem", value)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("SelectedItem", value)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("SelectedItem", valueFn)
    [<CustomOperation("SelectedItemChanged")>] member inline _.SelectedItemChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("SelectedItemChanged", fn)
    [<CustomOperation("SelectedItems")>] member inline _.SelectedItems ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.HashSet<'T>) = render ==> ("SelectedItems" => x)
    [<CustomOperation("SelectedItems'")>] member inline _.SelectedItems' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Collections.Generic.HashSet<'T>>) = render ==> html.bind("SelectedItems", value)
    [<CustomOperation("SelectedItems'")>] member inline _.SelectedItems' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Collections.Generic.HashSet<'T>>) = render ==> html.bind("SelectedItems", value)
    [<CustomOperation("SelectedItems'")>] member inline _.SelectedItems' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Collections.Generic.HashSet<'T> * (System.Collections.Generic.HashSet<'T> -> unit)) = render ==> html.bind("SelectedItems", valueFn)
    [<CustomOperation("SelectedItemsChanged")>] member inline _.SelectedItemsChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Collections.Generic.HashSet<'T>>("SelectedItemsChanged", fn)
    [<CustomOperation("GroupBy")>] member inline _.GroupBy ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TableGroupDefinition<'T>) = render ==> ("GroupBy" => x)
    [<CustomOperation("GroupHeaderTemplate")>] member inline _.GroupHeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: MudBlazor.TableGroupData<System.Object, 'T> -> NodeRenderFragment) = render ==> html.renderFragment("GroupHeaderTemplate", fn)
    [<CustomOperation("GroupHeaderClass")>] member inline _.GroupHeaderClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("GroupHeaderClass" => x)
    [<CustomOperation("GroupHeaderStyle")>] member inline _.GroupHeaderStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("GroupHeaderStyle" => x)
    [<CustomOperation("GroupFooterClass")>] member inline _.GroupFooterClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("GroupFooterClass" => x)
    [<CustomOperation("GroupFooterStyle")>] member inline _.GroupFooterStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("GroupFooterStyle" => x)
    [<CustomOperation("GroupFooterTemplate")>] member inline _.GroupFooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: MudBlazor.TableGroupData<System.Object, 'T> -> NodeRenderFragment) = render ==> html.renderFragment("GroupFooterTemplate", fn)
    [<CustomOperation("ServerData")>] member inline _.ServerData ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("ServerData" => (System.Func<MudBlazor.TableState, System.Threading.Tasks.Task<MudBlazor.TableData<'T>>>fn))
                

type MudTabsBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTabsBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTabsBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("KeepPanelsAlive")>] member inline _.KeepPanelsAlive ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("KeepPanelsAlive" => x)
    [<CustomOperation("Rounded")>] member inline _.Rounded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Rounded" => x)
    [<CustomOperation("Border")>] member inline _.Border ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Border" => x)
    [<CustomOperation("Outlined")>] member inline _.Outlined ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Outlined" => x)
    [<CustomOperation("Centered")>] member inline _.Centered ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Centered" => x)
    [<CustomOperation("HideSlider")>] member inline _.HideSlider ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideSlider" => x)
    [<CustomOperation("PrevIcon")>] member inline _.PrevIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PrevIcon" => x)
    [<CustomOperation("NextIcon")>] member inline _.NextIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NextIcon" => x)
    [<CustomOperation("AlwaysShowScrollButtons")>] member inline _.AlwaysShowScrollButtons ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AlwaysShowScrollButtons" => x)
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("MaxHeight" => x)
    [<CustomOperation("Position")>] member inline _.Position ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Position) = render ==> ("Position" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("SliderColor")>] member inline _.SliderColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("SliderColor" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("ScrollIconColor")>] member inline _.ScrollIconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("ScrollIconColor" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("ApplyEffectsToContainer")>] member inline _.ApplyEffectsToContainer ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ApplyEffectsToContainer" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("DisableSliderAnimation")>] member inline _.DisableSliderAnimation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableSliderAnimation" => x)
    [<CustomOperation("PrePanelContent")>] member inline _.PrePanelContent ([<InlineIfLambda>] render: AttrRenderFragment, fn: MudBlazor.MudTabPanel -> NodeRenderFragment) = render ==> html.renderFragment("PrePanelContent", fn)
    [<CustomOperation("TabPanelClass")>] member inline _.TabPanelClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("TabPanelClass" => x)
    [<CustomOperation("PanelClass")>] member inline _.PanelClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PanelClass" => x)
    [<CustomOperation("ActivePanelIndex")>] member inline _.ActivePanelIndex ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("ActivePanelIndex" => x)
    [<CustomOperation("ActivePanelIndex'")>] member inline _.ActivePanelIndex' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Int32>) = render ==> html.bind("ActivePanelIndex", value)
    [<CustomOperation("ActivePanelIndex'")>] member inline _.ActivePanelIndex' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Int32>) = render ==> html.bind("ActivePanelIndex", value)
    [<CustomOperation("ActivePanelIndex'")>] member inline _.ActivePanelIndex' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Int32 * (System.Int32 -> unit)) = render ==> html.bind("ActivePanelIndex", valueFn)
    [<CustomOperation("ActivePanelIndexChanged")>] member inline _.ActivePanelIndexChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Int32>("ActivePanelIndexChanged", fn)
    [<CustomOperation("Header")>] member inline _.Header ([<InlineIfLambda>] render: AttrRenderFragment, fn: MudBlazor.MudTabs -> NodeRenderFragment) = render ==> html.renderFragment("Header", fn)
    [<CustomOperation("HeaderPosition")>] member inline _.HeaderPosition ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TabHeaderPosition) = render ==> ("HeaderPosition" => x)
    [<CustomOperation("TabPanelHeader")>] member inline _.TabPanelHeader ([<InlineIfLambda>] render: AttrRenderFragment, fn: MudBlazor.MudTabPanel -> NodeRenderFragment) = render ==> html.renderFragment("TabPanelHeader", fn)
    [<CustomOperation("TabPanelHeaderPosition")>] member inline _.TabPanelHeaderPosition ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TabHeaderPosition) = render ==> ("TabPanelHeaderPosition" => x)
                

type MudDynamicTabsBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudTabsBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDynamicTabsBuilder<'FunBlazorGeneric>())
    [<CustomOperation("AddTabIcon")>] member inline _.AddTabIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AddTabIcon" => x)
    [<CustomOperation("CloseTabIcon")>] member inline _.CloseTabIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseTabIcon" => x)
    [<CustomOperation("AddTab")>] member inline _.AddTab ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback("AddTab", fn)
    [<CustomOperation("AddTab")>] member inline _.AddTab ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callbackTask("AddTab", fn)
    [<CustomOperation("CloseTab")>] member inline _.CloseTab ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.MudTabPanel>("CloseTab", fn)
    [<CustomOperation("AddIconClass")>] member inline _.AddIconClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AddIconClass" => x)
    [<CustomOperation("AddIconStyle")>] member inline _.AddIconStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AddIconStyle" => x)
    [<CustomOperation("CloseIconClass")>] member inline _.CloseIconClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIconClass" => x)
    [<CustomOperation("CloseIconStyle")>] member inline _.CloseIconStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIconStyle" => x)
    [<CustomOperation("AddIconToolTip")>] member inline _.AddIconToolTip ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AddIconToolTip" => x)
    [<CustomOperation("CloseIconToolTip")>] member inline _.CloseIconToolTip ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIconToolTip" => x)
                

type MudChartBaseBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudChartBaseBuilder<'FunBlazorGeneric>())
    [<CustomOperation("InputData")>] member inline _.InputData ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double[]) = render ==> ("InputData" => x)
    [<CustomOperation("InputLabels")>] member inline _.InputLabels ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String[]) = render ==> ("InputLabels" => x)
    [<CustomOperation("XAxisLabels")>] member inline _.XAxisLabels ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String[]) = render ==> ("XAxisLabels" => x)
    [<CustomOperation("ChartSeries")>] member inline _.ChartSeries ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.List<MudBlazor.ChartSeries>) = render ==> ("ChartSeries" => x)
    [<CustomOperation("ChartOptions")>] member inline _.ChartOptions ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ChartOptions) = render ==> ("ChartOptions" => x)
    [<CustomOperation("CustomGraphics")>] member inline _.CustomGraphics ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("CustomGraphics", fragment)
    [<CustomOperation("CustomGraphics")>] member inline _.CustomGraphics ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("CustomGraphics", fragment { yield! fragments })
    [<CustomOperation("CustomGraphics")>] member inline _.CustomGraphics ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("CustomGraphics", html.text x)
    [<CustomOperation("CustomGraphics")>] member inline _.CustomGraphics ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("CustomGraphics", html.text x)
    [<CustomOperation("CustomGraphics")>] member inline _.CustomGraphics ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("CustomGraphics", html.text x)
    [<CustomOperation("ChartType")>] member inline _.ChartType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ChartType) = render ==> ("ChartType" => x)
    [<CustomOperation("Width")>] member inline _.Width ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Width" => x)
    [<CustomOperation("Height")>] member inline _.Height ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Height" => x)
    [<CustomOperation("LegendPosition")>] member inline _.LegendPosition ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Position) = render ==> ("LegendPosition" => x)
    [<CustomOperation("SelectedIndex")>] member inline _.SelectedIndex ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("SelectedIndex" => x)
    [<CustomOperation("SelectedIndex'")>] member inline _.SelectedIndex' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Int32>) = render ==> html.bind("SelectedIndex", value)
    [<CustomOperation("SelectedIndex'")>] member inline _.SelectedIndex' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Int32>) = render ==> html.bind("SelectedIndex", value)
    [<CustomOperation("SelectedIndex'")>] member inline _.SelectedIndex' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Int32 * (System.Int32 -> unit)) = render ==> html.bind("SelectedIndex", valueFn)
    [<CustomOperation("SelectedIndexChanged")>] member inline _.SelectedIndexChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Int32>("SelectedIndexChanged", fn)
                

type MudChartBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudChartBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudChartBuilder<'FunBlazorGeneric>())

                
            
namespace rec MudBlazor.DslInternals.Charts

open FSharp.Data.Adaptive
open Fun.Blazor
open Fun.Blazor.Operators
open MudBlazor.DslInternals


type BarBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudChartBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(BarBuilder<'FunBlazorGeneric>())

                

type DonutBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudChartBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(DonutBuilder<'FunBlazorGeneric>())

                

type LineBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudChartBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(LineBuilder<'FunBlazorGeneric>())

                

type PieBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudChartBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(PieBuilder<'FunBlazorGeneric>())

                

type LegendBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudChartBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(LegendBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Data")>] member inline _.Data ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.List<MudBlazor.Charts.SVG.Models.SvgLegend>) = render ==> ("Data" => x)
                
            
namespace rec MudBlazor.DslInternals

open FSharp.Data.Adaptive
open Fun.Blazor
open Fun.Blazor.Operators
open MudBlazor.DslInternals


type MudBaseItemsControlBuilder<'FunBlazorGeneric, 'TChildComponent when 'TChildComponent :> MudBlazor.MudComponentBase and 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudBaseItemsControlBuilder<'FunBlazorGeneric, 'TChildComponent>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudBaseItemsControlBuilder<'FunBlazorGeneric, 'TChildComponent>(){ yield! x }
    [<CustomOperation("SelectedIndex")>] member inline _.SelectedIndex ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("SelectedIndex" => x)
    [<CustomOperation("SelectedIndex'")>] member inline _.SelectedIndex' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Int32>) = render ==> html.bind("SelectedIndex", value)
    [<CustomOperation("SelectedIndex'")>] member inline _.SelectedIndex' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Int32>) = render ==> html.bind("SelectedIndex", value)
    [<CustomOperation("SelectedIndex'")>] member inline _.SelectedIndex' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Int32 * (System.Int32 -> unit)) = render ==> html.bind("SelectedIndex", valueFn)
    [<CustomOperation("SelectedIndexChanged")>] member inline _.SelectedIndexChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Int32>("SelectedIndexChanged", fn)
                

type MudBaseBindableItemsControlBuilder<'FunBlazorGeneric, 'TChildComponent, 'TData when 'TChildComponent :> MudBlazor.MudComponentBase and 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseItemsControlBuilder<'FunBlazorGeneric, 'TChildComponent>()
    static member inline create () = html.fromBuilder(MudBaseBindableItemsControlBuilder<'FunBlazorGeneric, 'TChildComponent, 'TData>())
    [<CustomOperation("ItemsSource")>] member inline _.ItemsSource ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.IEnumerable<'TData>) = render ==> ("ItemsSource" => x)
    [<CustomOperation("ItemTemplate")>] member inline _.ItemTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'TData -> NodeRenderFragment) = render ==> html.renderFragment("ItemTemplate", fn)
                

type MudCarouselBuilder<'FunBlazorGeneric, 'TData when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseBindableItemsControlBuilder<'FunBlazorGeneric, MudBlazor.MudCarouselItem, 'TData>()
    static member inline create () = html.fromBuilder(MudCarouselBuilder<'FunBlazorGeneric, 'TData>())
    [<CustomOperation("ShowArrows")>] member inline _.ShowArrows ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowArrows" => x)
    [<CustomOperation("ArrowsPosition")>] member inline _.ArrowsPosition ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Position) = render ==> ("ArrowsPosition" => x)
    [<CustomOperation("ShowBullets")>] member inline _.ShowBullets ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowBullets" => x)
    [<CustomOperation("BulletsPosition")>] member inline _.BulletsPosition ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Position) = render ==> ("BulletsPosition" => x)
    [<CustomOperation("BulletsColor")>] member inline _.BulletsColor ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<MudBlazor.Color>) = render ==> ("BulletsColor" => x)
    [<CustomOperation("ShowDelimiters")>] member inline _.ShowDelimiters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowDelimiters" => x)
    [<CustomOperation("DelimitersColor")>] member inline _.DelimitersColor ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<MudBlazor.Color>) = render ==> ("DelimitersColor" => x)
    [<CustomOperation("AutoCycle")>] member inline _.AutoCycle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AutoCycle" => x)
    [<CustomOperation("AutoCycleTime")>] member inline _.AutoCycleTime ([<InlineIfLambda>] render: AttrRenderFragment, x: System.TimeSpan) = render ==> ("AutoCycleTime" => x)
    [<CustomOperation("NavigationButtonsClass")>] member inline _.NavigationButtonsClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NavigationButtonsClass" => x)
    [<CustomOperation("BulletsClass")>] member inline _.BulletsClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("BulletsClass" => x)
    [<CustomOperation("DelimitersClass")>] member inline _.DelimitersClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("DelimitersClass" => x)
    [<CustomOperation("PreviousIcon")>] member inline _.PreviousIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PreviousIcon" => x)
    [<CustomOperation("CheckedIcon")>] member inline _.CheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CheckedIcon" => x)
    [<CustomOperation("UncheckedIcon")>] member inline _.UncheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("UncheckedIcon" => x)
    [<CustomOperation("NextIcon")>] member inline _.NextIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NextIcon" => x)
    [<CustomOperation("NextButtonTemplate")>] member inline _.NextButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("NextButtonTemplate", fragment)
    [<CustomOperation("NextButtonTemplate")>] member inline _.NextButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("NextButtonTemplate", fragment { yield! fragments })
    [<CustomOperation("NextButtonTemplate")>] member inline _.NextButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("NextButtonTemplate", html.text x)
    [<CustomOperation("NextButtonTemplate")>] member inline _.NextButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("NextButtonTemplate", html.text x)
    [<CustomOperation("NextButtonTemplate")>] member inline _.NextButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("NextButtonTemplate", html.text x)
    [<CustomOperation("PreviousButtonTemplate")>] member inline _.PreviousButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("PreviousButtonTemplate", fragment)
    [<CustomOperation("PreviousButtonTemplate")>] member inline _.PreviousButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("PreviousButtonTemplate", fragment { yield! fragments })
    [<CustomOperation("PreviousButtonTemplate")>] member inline _.PreviousButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("PreviousButtonTemplate", html.text x)
    [<CustomOperation("PreviousButtonTemplate")>] member inline _.PreviousButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("PreviousButtonTemplate", html.text x)
    [<CustomOperation("PreviousButtonTemplate")>] member inline _.PreviousButtonTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("PreviousButtonTemplate", html.text x)
    [<CustomOperation("BulletTemplate")>] member inline _.BulletTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: System.Boolean -> NodeRenderFragment) = render ==> html.renderFragment("BulletTemplate", fn)
    [<CustomOperation("DelimiterTemplate")>] member inline _.DelimiterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: System.Boolean -> NodeRenderFragment) = render ==> html.renderFragment("DelimiterTemplate", fn)
                

type MudTimelineBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseItemsControlBuilder<'FunBlazorGeneric, MudBlazor.MudTimelineItem>()
    static member inline create () = html.fromBuilder(MudTimelineBuilder<'FunBlazorGeneric>())
    [<CustomOperation("TimelineOrientation")>] member inline _.TimelineOrientation ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TimelineOrientation) = render ==> ("TimelineOrientation" => x)
    [<CustomOperation("TimelinePosition")>] member inline _.TimelinePosition ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TimelinePosition) = render ==> ("TimelinePosition" => x)
    [<CustomOperation("TimelineAlign")>] member inline _.TimelineAlign ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TimelineAlign) = render ==> ("TimelineAlign" => x)
    [<CustomOperation("Reverse")>] member inline _.Reverse ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Reverse" => x)
    [<CustomOperation("DisableModifiers")>] member inline _.DisableModifiers ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableModifiers" => x)
                

type MudFormComponentBuilder<'FunBlazorGeneric, 'T, 'U when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudFormComponentBuilder<'FunBlazorGeneric, 'T, 'U>())
    [<CustomOperation("Required")>] member inline _.Required ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Required" => x)
    [<CustomOperation("RequiredError")>] member inline _.RequiredError ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RequiredError" => x)
    [<CustomOperation("ErrorText")>] member inline _.ErrorText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ErrorText" => x)
    [<CustomOperation("Error")>] member inline _.Error ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Error" => x)
    [<CustomOperation("Converter")>] member inline _.Converter ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Converter<'T, 'U>) = render ==> ("Converter" => x)
    [<CustomOperation("Culture")>] member inline _.Culture ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Globalization.CultureInfo) = render ==> ("Culture" => x)
    [<CustomOperation("Validation")>] member inline _.Validation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("Validation" => x)
    [<CustomOperation("For'")>] member inline _.For' ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Linq.Expressions.Expression<System.Func<'T>>) = render ==> ("For" => x)
                

type MudBaseInputBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudFormComponentBuilder<'FunBlazorGeneric, 'T, System.String>()
    static member inline create () = html.fromBuilder(MudBaseInputBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("FullWidth")>] member inline _.FullWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FullWidth" => x)
    [<CustomOperation("Immediate")>] member inline _.Immediate ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Immediate" => x)
    [<CustomOperation("DisableUnderLine")>] member inline _.DisableUnderLine ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableUnderLine" => x)
    [<CustomOperation("HelperText")>] member inline _.HelperText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HelperText" => x)
    [<CustomOperation("HelperTextOnFocus")>] member inline _.HelperTextOnFocus ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HelperTextOnFocus" => x)
    [<CustomOperation("AdornmentIcon")>] member inline _.AdornmentIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AdornmentIcon" => x)
    [<CustomOperation("AdornmentText")>] member inline _.AdornmentText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AdornmentText" => x)
    [<CustomOperation("Adornment")>] member inline _.Adornment ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Adornment) = render ==> ("Adornment" => x)
    [<CustomOperation("AdornmentColor")>] member inline _.AdornmentColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("AdornmentColor" => x)
    [<CustomOperation("IconSize")>] member inline _.IconSize ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("IconSize" => x)
    [<CustomOperation("OnAdornmentClick")>] member inline _.OnAdornmentClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnAdornmentClick", fn)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Margin")>] member inline _.Margin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Margin) = render ==> ("Margin" => x)
    [<CustomOperation("Placeholder")>] member inline _.Placeholder ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Placeholder" => x)
    [<CustomOperation("Counter")>] member inline _.Counter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("Counter" => x)
    [<CustomOperation("MaxLength")>] member inline _.MaxLength ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("MaxLength" => x)
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Label" => x)
    [<CustomOperation("AutoFocus")>] member inline _.AutoFocus ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AutoFocus" => x)
    [<CustomOperation("Lines")>] member inline _.Lines ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Lines" => x)
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("Text'")>] member inline _.Text' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.String>) = render ==> html.bind("Text", value)
    [<CustomOperation("Text'")>] member inline _.Text' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.String>) = render ==> html.bind("Text", value)
    [<CustomOperation("Text'")>] member inline _.Text' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.String * (System.String -> unit)) = render ==> html.bind("Text", valueFn)
    [<CustomOperation("TextUpdateSuppression")>] member inline _.TextUpdateSuppression ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("TextUpdateSuppression" => x)
    [<CustomOperation("InputMode")>] member inline _.InputMode ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.InputMode) = render ==> ("InputMode" => x)
    [<CustomOperation("Pattern")>] member inline _.Pattern ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Pattern" => x)
    [<CustomOperation("TextChanged")>] member inline _.TextChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.String>("TextChanged", fn)
    [<CustomOperation("OnBlur")>] member inline _.OnBlur ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.FocusEventArgs>("OnBlur", fn)
    [<CustomOperation("OnInternalInputChanged")>] member inline _.OnInternalInputChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.ChangeEventArgs>("OnInternalInputChanged", fn)
    [<CustomOperation("OnKeyDown")>] member inline _.OnKeyDown ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>("OnKeyDown", fn)
    [<CustomOperation("KeyDownPreventDefault")>] member inline _.KeyDownPreventDefault ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("KeyDownPreventDefault" => x)
    [<CustomOperation("OnKeyPress")>] member inline _.OnKeyPress ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>("OnKeyPress", fn)
    [<CustomOperation("KeyPressPreventDefault")>] member inline _.KeyPressPreventDefault ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("KeyPressPreventDefault" => x)
    [<CustomOperation("OnKeyUp")>] member inline _.OnKeyUp ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>("OnKeyUp", fn)
    [<CustomOperation("KeyUpPreventDefault")>] member inline _.KeyUpPreventDefault ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("KeyUpPreventDefault" => x)
    [<CustomOperation("ValueChanged")>] member inline _.ValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("ValueChanged", fn)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Value" => x)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("Value", valueFn)
    [<CustomOperation("Format")>] member inline _.Format ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Format" => x)
                

type MudAutocompleteBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseInputBuilder<'FunBlazorGeneric, 'T>()
    static member inline create () = html.fromBuilder(MudAutocompleteBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("PopoverClass")>] member inline _.PopoverClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PopoverClass" => x)
    [<CustomOperation("AnchorOrigin")>] member inline _.AnchorOrigin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("AnchorOrigin" => x)
    [<CustomOperation("TransformOrigin")>] member inline _.TransformOrigin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("TransformOrigin" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("OpenIcon")>] member inline _.OpenIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("OpenIcon" => x)
    [<CustomOperation("CloseIcon")>] member inline _.CloseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIcon" => x)
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("MaxHeight" => x)
    [<CustomOperation("ToStringFunc")>] member inline _.ToStringFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("ToStringFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("SearchFunc")>] member inline _.SearchFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("SearchFunc" => (System.Func<System.String, System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<'T>>>fn))
    [<CustomOperation("MaxItems")>] member inline _.MaxItems ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("MaxItems" => x)
    [<CustomOperation("MinCharacters")>] member inline _.MinCharacters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("MinCharacters" => x)
    [<CustomOperation("ResetValueOnEmptyText")>] member inline _.ResetValueOnEmptyText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ResetValueOnEmptyText" => x)
    [<CustomOperation("DebounceInterval")>] member inline _.DebounceInterval ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("DebounceInterval" => x)
    [<CustomOperation("ItemTemplate")>] member inline _.ItemTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("ItemTemplate", fn)
    [<CustomOperation("ItemSelectedTemplate")>] member inline _.ItemSelectedTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("ItemSelectedTemplate", fn)
    [<CustomOperation("ItemDisabledTemplate")>] member inline _.ItemDisabledTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("ItemDisabledTemplate", fn)
    [<CustomOperation("CoerceText")>] member inline _.CoerceText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("CoerceText" => x)
    [<CustomOperation("CoerceValue")>] member inline _.CoerceValue ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("CoerceValue" => x)
    [<CustomOperation("ItemDisabledFunc")>] member inline _.ItemDisabledFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("ItemDisabledFunc" => (System.Func<'T, System.Boolean>fn))
    [<CustomOperation("IsOpenChanged")>] member inline _.IsOpenChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsOpenChanged", fn)
    [<CustomOperation("SelectValueOnTab")>] member inline _.SelectValueOnTab ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("SelectValueOnTab" => x)
    [<CustomOperation("Clearable")>] member inline _.Clearable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Clearable" => x)
    [<CustomOperation("OnClearButtonClick")>] member inline _.OnClearButtonClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClearButtonClick", fn)
                

type MudDebouncedInputBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseInputBuilder<'FunBlazorGeneric, 'T>()
    static member inline create () = html.fromBuilder(MudDebouncedInputBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("DebounceInterval")>] member inline _.DebounceInterval ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("DebounceInterval" => x)
    [<CustomOperation("OnDebounceIntervalElapsed")>] member inline _.OnDebounceIntervalElapsed ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.String>("OnDebounceIntervalElapsed", fn)
                

type MudNumericFieldBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudDebouncedInputBuilder<'FunBlazorGeneric, 'T>()
    static member inline create () = html.fromBuilder(MudNumericFieldBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("Clearable")>] member inline _.Clearable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Clearable" => x)
    [<CustomOperation("InvertMouseWheel")>] member inline _.InvertMouseWheel ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("InvertMouseWheel" => x)
    [<CustomOperation("Min")>] member inline _.Min ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Min" => x)
    [<CustomOperation("Max")>] member inline _.Max ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Max" => x)
    [<CustomOperation("Step")>] member inline _.Step ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Step" => x)
    [<CustomOperation("HideSpinButtons")>] member inline _.HideSpinButtons ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideSpinButtons" => x)
    [<CustomOperation("InputMode")>] member inline _.InputMode ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.InputMode) = render ==> ("InputMode" => x)
    [<CustomOperation("Pattern")>] member inline _.Pattern ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Pattern" => x)
                

type MudTextFieldBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudDebouncedInputBuilder<'FunBlazorGeneric, 'T>()
    static member inline create () = html.fromBuilder(MudTextFieldBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("InputType")>] member inline _.InputType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.InputType) = render ==> ("InputType" => x)
    [<CustomOperation("Clearable")>] member inline _.Clearable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Clearable" => x)
    [<CustomOperation("OnClearButtonClick")>] member inline _.OnClearButtonClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClearButtonClick", fn)
                

type MudInputBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseInputBuilder<'FunBlazorGeneric, 'T>()
    static member inline create (x: string) = MudInputBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudInputBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("InputType")>] member inline _.InputType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.InputType) = render ==> ("InputType" => x)
    [<CustomOperation("OnIncrement")>] member inline _.OnIncrement ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback("OnIncrement", fn)
    [<CustomOperation("OnIncrement")>] member inline _.OnIncrement ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callbackTask("OnIncrement", fn)
    [<CustomOperation("OnDecrement")>] member inline _.OnDecrement ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback("OnDecrement", fn)
    [<CustomOperation("OnDecrement")>] member inline _.OnDecrement ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callbackTask("OnDecrement", fn)
    [<CustomOperation("HideSpinButtons")>] member inline _.HideSpinButtons ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideSpinButtons" => x)
    [<CustomOperation("Clearable")>] member inline _.Clearable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Clearable" => x)
    [<CustomOperation("OnClearButtonClick")>] member inline _.OnClearButtonClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClearButtonClick", fn)
    [<CustomOperation("OnMouseWheel")>] member inline _.OnMouseWheel ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.WheelEventArgs>("OnMouseWheel", fn)
    [<CustomOperation("ClearIcon")>] member inline _.ClearIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ClearIcon" => x)
    [<CustomOperation("NumericUpIcon")>] member inline _.NumericUpIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NumericUpIcon" => x)
    [<CustomOperation("NumericDownIcon")>] member inline _.NumericDownIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NumericDownIcon" => x)
                

type MudInputStringBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudInputBuilder<'FunBlazorGeneric, System.String>()
    static member inline create () = html.fromBuilder(MudInputStringBuilder<'FunBlazorGeneric>())

                

type MudRangeInputBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseInputBuilder<'FunBlazorGeneric, MudBlazor.Range<'T>>()
    static member inline create (x: string) = MudRangeInputBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudRangeInputBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("InputType")>] member inline _.InputType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.InputType) = render ==> ("InputType" => x)
    [<CustomOperation("PlaceholderStart")>] member inline _.PlaceholderStart ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PlaceholderStart" => x)
    [<CustomOperation("PlaceholderEnd")>] member inline _.PlaceholderEnd ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PlaceholderEnd" => x)
    [<CustomOperation("SeparatorIcon")>] member inline _.SeparatorIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SeparatorIcon" => x)
                

type MudSelectBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseInputBuilder<'FunBlazorGeneric, 'T>()
    static member inline create (x: string) = MudSelectBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudSelectBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("PopoverClass")>] member inline _.PopoverClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PopoverClass" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("OpenIcon")>] member inline _.OpenIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("OpenIcon" => x)
    [<CustomOperation("CloseIcon")>] member inline _.CloseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIcon" => x)
    [<CustomOperation("SelectAll")>] member inline _.SelectAll ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("SelectAll" => x)
    [<CustomOperation("SelectAllText")>] member inline _.SelectAllText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SelectAllText" => x)
    [<CustomOperation("SelectedValuesChanged")>] member inline _.SelectedValuesChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Collections.Generic.IEnumerable<'T>>("SelectedValuesChanged", fn)
    [<CustomOperation("MultiSelectionTextFunc")>] member inline _.MultiSelectionTextFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("MultiSelectionTextFunc" => (System.Func<System.Collections.Generic.List<System.String>, System.String>fn))
    [<CustomOperation("Delimiter")>] member inline _.Delimiter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Delimiter" => x)
    [<CustomOperation("SelectedValues")>] member inline _.SelectedValues ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.IEnumerable<'T>) = render ==> ("SelectedValues" => x)
    [<CustomOperation("SelectedValues'")>] member inline _.SelectedValues' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Collections.Generic.IEnumerable<'T>>) = render ==> html.bind("SelectedValues", value)
    [<CustomOperation("SelectedValues'")>] member inline _.SelectedValues' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Collections.Generic.IEnumerable<'T>>) = render ==> html.bind("SelectedValues", value)
    [<CustomOperation("SelectedValues'")>] member inline _.SelectedValues' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Collections.Generic.IEnumerable<'T> * (System.Collections.Generic.IEnumerable<'T> -> unit)) = render ==> html.bind("SelectedValues", valueFn)
    [<CustomOperation("Comparer")>] member inline _.Comparer ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.IEqualityComparer<'T>) = render ==> ("Comparer" => x)
    [<CustomOperation("ToStringFunc")>] member inline _.ToStringFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("ToStringFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("MultiSelection")>] member inline _.MultiSelection ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("MultiSelection" => x)
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("MaxHeight" => x)
    [<CustomOperation("AnchorOrigin")>] member inline _.AnchorOrigin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("AnchorOrigin" => x)
    [<CustomOperation("TransformOrigin")>] member inline _.TransformOrigin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("TransformOrigin" => x)
    [<CustomOperation("Strict")>] member inline _.Strict ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Strict" => x)
    [<CustomOperation("Clearable")>] member inline _.Clearable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Clearable" => x)
    [<CustomOperation("LockScroll")>] member inline _.LockScroll ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("LockScroll" => x)
    [<CustomOperation("OnClearButtonClick")>] member inline _.OnClearButtonClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClearButtonClick", fn)
    [<CustomOperation("CheckedIcon")>] member inline _.CheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CheckedIcon" => x)
    [<CustomOperation("UncheckedIcon")>] member inline _.UncheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("UncheckedIcon" => x)
    [<CustomOperation("IndeterminateIcon")>] member inline _.IndeterminateIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("IndeterminateIcon" => x)
                

type MudBooleanInputBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudFormComponentBuilder<'FunBlazorGeneric, 'T, System.Nullable<System.Boolean>>()
    static member inline create () = html.fromBuilder(MudBooleanInputBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("Checked")>] member inline _.Checked ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Checked" => x)
    [<CustomOperation("Checked'")>] member inline _.Checked' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("Checked", value)
    [<CustomOperation("Checked'")>] member inline _.Checked' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("Checked", value)
    [<CustomOperation("Checked'")>] member inline _.Checked' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("Checked", valueFn)
    [<CustomOperation("StopClickPropagation")>] member inline _.StopClickPropagation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("StopClickPropagation" => x)
    [<CustomOperation("CheckedChanged")>] member inline _.CheckedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("CheckedChanged", fn)
                

type MudCheckBoxBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBooleanInputBuilder<'FunBlazorGeneric, 'T>()
    static member inline create (x: string) = MudCheckBoxBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudCheckBoxBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Label" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("CheckedIcon")>] member inline _.CheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CheckedIcon" => x)
    [<CustomOperation("UncheckedIcon")>] member inline _.UncheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("UncheckedIcon" => x)
    [<CustomOperation("IndeterminateIcon")>] member inline _.IndeterminateIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("IndeterminateIcon" => x)
    [<CustomOperation("TriState")>] member inline _.TriState ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("TriState" => x)
                

type MudSwitchBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBooleanInputBuilder<'FunBlazorGeneric, 'T>()
    static member inline create (x: string) = MudSwitchBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudSwitchBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Label" => x)
    [<CustomOperation("ThumbIcon")>] member inline _.ThumbIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ThumbIcon" => x)
    [<CustomOperation("ThumbIconColor")>] member inline _.ThumbIconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("ThumbIconColor" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
                

type MudPickerBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudFormComponentBuilder<'FunBlazorGeneric, 'T, System.String>()
    static member inline create () = html.fromBuilder(MudPickerBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("AdornmentColor")>] member inline _.AdornmentColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("AdornmentColor" => x)
    [<CustomOperation("AdornmentIcon")>] member inline _.AdornmentIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AdornmentIcon" => x)
    [<CustomOperation("Placeholder")>] member inline _.Placeholder ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Placeholder" => x)
    [<CustomOperation("PickerOpened")>] member inline _.PickerOpened ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback("PickerOpened", fn)
    [<CustomOperation("PickerOpened")>] member inline _.PickerOpened ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callbackTask("PickerOpened", fn)
    [<CustomOperation("PickerClosed")>] member inline _.PickerClosed ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback("PickerClosed", fn)
    [<CustomOperation("PickerClosed")>] member inline _.PickerClosed ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callbackTask("PickerClosed", fn)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("Rounded")>] member inline _.Rounded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Rounded" => x)
    [<CustomOperation("HelperText")>] member inline _.HelperText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HelperText" => x)
    [<CustomOperation("HelperTextOnFocus")>] member inline _.HelperTextOnFocus ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HelperTextOnFocus" => x)
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Label" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("Editable")>] member inline _.Editable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Editable" => x)
    [<CustomOperation("DisableToolbar")>] member inline _.DisableToolbar ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableToolbar" => x)
    [<CustomOperation("ToolBarClass")>] member inline _.ToolBarClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ToolBarClass" => x)
    [<CustomOperation("PickerVariant")>] member inline _.PickerVariant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.PickerVariant) = render ==> ("PickerVariant" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Adornment")>] member inline _.Adornment ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Adornment) = render ==> ("Adornment" => x)
    [<CustomOperation("Orientation")>] member inline _.Orientation ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Orientation) = render ==> ("Orientation" => x)
    [<CustomOperation("IconSize")>] member inline _.IconSize ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("IconSize" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("AllowKeyboardInput")>] member inline _.AllowKeyboardInput ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AllowKeyboardInput" => x)
    [<CustomOperation("TextChanged")>] member inline _.TextChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.String>("TextChanged", fn)
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("Text'")>] member inline _.Text' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.String>) = render ==> html.bind("Text", value)
    [<CustomOperation("Text'")>] member inline _.Text' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.String>) = render ==> html.bind("Text", value)
    [<CustomOperation("Text'")>] member inline _.Text' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.String * (System.String -> unit)) = render ==> html.bind("Text", valueFn)
    [<CustomOperation("ClassActions")>] member inline _.ClassActions ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ClassActions" => x)
    [<CustomOperation("PickerActions")>] member inline _.PickerActions ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("PickerActions", fragment)
    [<CustomOperation("PickerActions")>] member inline _.PickerActions ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("PickerActions", fragment { yield! fragments })
    [<CustomOperation("PickerActions")>] member inline _.PickerActions ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("PickerActions", html.text x)
    [<CustomOperation("PickerActions")>] member inline _.PickerActions ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("PickerActions", html.text x)
    [<CustomOperation("PickerActions")>] member inline _.PickerActions ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("PickerActions", html.text x)
    [<CustomOperation("Margin")>] member inline _.Margin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Margin) = render ==> ("Margin" => x)
                

type MudBaseDatePickerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudPickerBuilder<'FunBlazorGeneric, System.Nullable<System.DateTime>>()
    static member inline create () = html.fromBuilder(MudBaseDatePickerBuilder<'FunBlazorGeneric>())
    [<CustomOperation("MaxDate")>] member inline _.MaxDate ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.DateTime>) = render ==> ("MaxDate" => x)
    [<CustomOperation("MinDate")>] member inline _.MinDate ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.DateTime>) = render ==> ("MinDate" => x)
    [<CustomOperation("OpenTo")>] member inline _.OpenTo ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.OpenTo) = render ==> ("OpenTo" => x)
    [<CustomOperation("DateFormat")>] member inline _.DateFormat ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("DateFormat" => x)
    [<CustomOperation("FirstDayOfWeek")>] member inline _.FirstDayOfWeek ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.DayOfWeek>) = render ==> ("FirstDayOfWeek" => x)
    [<CustomOperation("PickerMonth")>] member inline _.PickerMonth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.DateTime>) = render ==> ("PickerMonth" => x)
    [<CustomOperation("PickerMonth'")>] member inline _.PickerMonth' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Nullable<System.DateTime>>) = render ==> html.bind("PickerMonth", value)
    [<CustomOperation("PickerMonth'")>] member inline _.PickerMonth' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Nullable<System.DateTime>>) = render ==> html.bind("PickerMonth", value)
    [<CustomOperation("PickerMonth'")>] member inline _.PickerMonth' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Nullable<System.DateTime> * (System.Nullable<System.DateTime> -> unit)) = render ==> html.bind("PickerMonth", valueFn)
    [<CustomOperation("PickerMonthChanged")>] member inline _.PickerMonthChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Nullable<System.DateTime>>("PickerMonthChanged", fn)
    [<CustomOperation("ClosingDelay")>] member inline _.ClosingDelay ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("ClosingDelay" => x)
    [<CustomOperation("DisplayMonths")>] member inline _.DisplayMonths ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("DisplayMonths" => x)
    [<CustomOperation("MaxMonthColumns")>] member inline _.MaxMonthColumns ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("MaxMonthColumns" => x)
    [<CustomOperation("StartMonth")>] member inline _.StartMonth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.DateTime>) = render ==> ("StartMonth" => x)
    [<CustomOperation("ShowWeekNumbers")>] member inline _.ShowWeekNumbers ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowWeekNumbers" => x)
    [<CustomOperation("TitleDateFormat")>] member inline _.TitleDateFormat ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("TitleDateFormat" => x)
    [<CustomOperation("IsDateDisabledFunc")>] member inline _.IsDateDisabledFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("IsDateDisabledFunc" => (System.Func<System.DateTime, System.Boolean>fn))
    [<CustomOperation("PreviousIcon")>] member inline _.PreviousIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PreviousIcon" => x)
    [<CustomOperation("NextIcon")>] member inline _.NextIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NextIcon" => x)
    [<CustomOperation("FixYear")>] member inline _.FixYear ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("FixYear" => x)
    [<CustomOperation("FixMonth")>] member inline _.FixMonth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("FixMonth" => x)
    [<CustomOperation("FixDay")>] member inline _.FixDay ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("FixDay" => x)
                

type MudDatePickerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseDatePickerBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDatePickerBuilder<'FunBlazorGeneric>())
    [<CustomOperation("DateChanged")>] member inline _.DateChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Nullable<System.DateTime>>("DateChanged", fn)
    [<CustomOperation("Date")>] member inline _.Date ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.DateTime>) = render ==> ("Date" => x)
    [<CustomOperation("Date'")>] member inline _.Date' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Nullable<System.DateTime>>) = render ==> html.bind("Date", value)
    [<CustomOperation("Date'")>] member inline _.Date' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Nullable<System.DateTime>>) = render ==> html.bind("Date", value)
    [<CustomOperation("Date'")>] member inline _.Date' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Nullable<System.DateTime> * (System.Nullable<System.DateTime> -> unit)) = render ==> html.bind("Date", valueFn)
    [<CustomOperation("AutoClose")>] member inline _.AutoClose ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AutoClose" => x)
                

type MudDateRangePickerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseDatePickerBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDateRangePickerBuilder<'FunBlazorGeneric>())
    [<CustomOperation("DateRangeChanged")>] member inline _.DateRangeChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.DateRange>("DateRangeChanged", fn)
    [<CustomOperation("DateRange")>] member inline _.DateRange ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.DateRange) = render ==> ("DateRange" => x)
    [<CustomOperation("DateRange'")>] member inline _.DateRange' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<MudBlazor.DateRange>) = render ==> html.bind("DateRange", value)
    [<CustomOperation("DateRange'")>] member inline _.DateRange' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<MudBlazor.DateRange>) = render ==> html.bind("DateRange", value)
    [<CustomOperation("DateRange'")>] member inline _.DateRange' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: MudBlazor.DateRange * (MudBlazor.DateRange -> unit)) = render ==> html.bind("DateRange", valueFn)
                

type MudColorPickerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudPickerBuilder<'FunBlazorGeneric, MudBlazor.Utilities.MudColor>()
    static member inline create () = html.fromBuilder(MudColorPickerBuilder<'FunBlazorGeneric>())
    [<CustomOperation("DisableAlpha")>] member inline _.DisableAlpha ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableAlpha" => x)
    [<CustomOperation("DisableColorField")>] member inline _.DisableColorField ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableColorField" => x)
    [<CustomOperation("DisableModeSwitch")>] member inline _.DisableModeSwitch ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableModeSwitch" => x)
    [<CustomOperation("DisableInputs")>] member inline _.DisableInputs ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableInputs" => x)
    [<CustomOperation("DisableSliders")>] member inline _.DisableSliders ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableSliders" => x)
    [<CustomOperation("DisablePreview")>] member inline _.DisablePreview ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisablePreview" => x)
    [<CustomOperation("ColorPickerMode")>] member inline _.ColorPickerMode ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ColorPickerMode) = render ==> ("ColorPickerMode" => x)
    [<CustomOperation("ColorPickerView")>] member inline _.ColorPickerView ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ColorPickerView) = render ==> ("ColorPickerView" => x)
    [<CustomOperation("UpdateBindingIfOnlyHSLChanged")>] member inline _.UpdateBindingIfOnlyHSLChanged ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("UpdateBindingIfOnlyHSLChanged" => x)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Utilities.MudColor) = render ==> ("Value" => x)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<MudBlazor.Utilities.MudColor>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<MudBlazor.Utilities.MudColor>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: MudBlazor.Utilities.MudColor * (MudBlazor.Utilities.MudColor -> unit)) = render ==> html.bind("Value", valueFn)
    [<CustomOperation("ValueChanged")>] member inline _.ValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.Utilities.MudColor>("ValueChanged", fn)
    [<CustomOperation("Palette")>] member inline _.Palette ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.IEnumerable<MudBlazor.Utilities.MudColor>) = render ==> ("Palette" => x)
    [<CustomOperation("DisableDragEffect")>] member inline _.DisableDragEffect ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableDragEffect" => x)
    [<CustomOperation("CloseIcon")>] member inline _.CloseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIcon" => x)
    [<CustomOperation("SpectrumIcon")>] member inline _.SpectrumIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SpectrumIcon" => x)
    [<CustomOperation("GridIcon")>] member inline _.GridIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("GridIcon" => x)
    [<CustomOperation("PaletteIcon")>] member inline _.PaletteIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PaletteIcon" => x)
    [<CustomOperation("ImportExportIcon")>] member inline _.ImportExportIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ImportExportIcon" => x)
                

type MudTimePickerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudPickerBuilder<'FunBlazorGeneric, System.Nullable<System.TimeSpan>>()
    static member inline create () = html.fromBuilder(MudTimePickerBuilder<'FunBlazorGeneric>())
    [<CustomOperation("OpenTo")>] member inline _.OpenTo ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.OpenTo) = render ==> ("OpenTo" => x)
    [<CustomOperation("TimeEditMode")>] member inline _.TimeEditMode ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TimeEditMode) = render ==> ("TimeEditMode" => x)
    [<CustomOperation("ClosingDelay")>] member inline _.ClosingDelay ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("ClosingDelay" => x)
    [<CustomOperation("AutoClose")>] member inline _.AutoClose ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AutoClose" => x)
    [<CustomOperation("AmPm")>] member inline _.AmPm ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AmPm" => x)
    [<CustomOperation("TimeFormat")>] member inline _.TimeFormat ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("TimeFormat" => x)
    [<CustomOperation("Time")>] member inline _.Time ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.TimeSpan>) = render ==> ("Time" => x)
    [<CustomOperation("Time'")>] member inline _.Time' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Nullable<System.TimeSpan>>) = render ==> html.bind("Time", value)
    [<CustomOperation("Time'")>] member inline _.Time' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Nullable<System.TimeSpan>>) = render ==> html.bind("Time", value)
    [<CustomOperation("Time'")>] member inline _.Time' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Nullable<System.TimeSpan> * (System.Nullable<System.TimeSpan> -> unit)) = render ==> html.bind("Time", valueFn)
    [<CustomOperation("TimeChanged")>] member inline _.TimeChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Nullable<System.TimeSpan>>("TimeChanged", fn)
                

type MudRadioGroupBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudFormComponentBuilder<'FunBlazorGeneric, 'T, 'T>()
    static member inline create (x: string) = MudRadioGroupBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudRadioGroupBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("Name")>] member inline _.Name ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Name" => x)
    [<CustomOperation("SelectedOption")>] member inline _.SelectedOption ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("SelectedOption" => x)
    [<CustomOperation("SelectedOption'")>] member inline _.SelectedOption' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("SelectedOption", value)
    [<CustomOperation("SelectedOption'")>] member inline _.SelectedOption' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("SelectedOption", value)
    [<CustomOperation("SelectedOption'")>] member inline _.SelectedOption' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("SelectedOption", valueFn)
    [<CustomOperation("SelectedOptionChanged")>] member inline _.SelectedOptionChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("SelectedOptionChanged", fn)
                

type MudAlertBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudAlertBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudAlertBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("ContentAlignment")>] member inline _.ContentAlignment ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.HorizontalAlignment) = render ==> ("ContentAlignment" => x)
    [<CustomOperation("CloseIconClicked")>] member inline _.CloseIconClicked ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.MudAlert>("CloseIconClicked", fn)
    [<CustomOperation("CloseIcon")>] member inline _.CloseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIcon" => x)
    [<CustomOperation("ShowCloseIcon")>] member inline _.ShowCloseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowCloseIcon" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("NoIcon")>] member inline _.NoIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("NoIcon" => x)
    [<CustomOperation("Severity")>] member inline _.Severity ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Severity) = render ==> ("Severity" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
                

type MudAppBarBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudAppBarBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudAppBarBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Bottom")>] member inline _.Bottom ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Bottom" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("DisableGutters")>] member inline _.DisableGutters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableGutters" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Fixed")>] member inline _.Fixed ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Fixed" => x)
    [<CustomOperation("ToolBarClass")>] member inline _.ToolBarClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ToolBarClass" => x)
                

type MudAvatarBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudAvatarBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudAvatarBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("Rounded")>] member inline _.Rounded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Rounded" => x)
    [<CustomOperation("Image")>] member inline _.Image ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Image" => x)
    [<CustomOperation("Alt")>] member inline _.Alt ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Alt" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
                

type MudAvatarGroupBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudAvatarGroupBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudAvatarGroupBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Spacing")>] member inline _.Spacing ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Spacing" => x)
    [<CustomOperation("Outlined")>] member inline _.Outlined ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Outlined" => x)
    [<CustomOperation("OutlineColor")>] member inline _.OutlineColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("OutlineColor" => x)
    [<CustomOperation("MaxElevation")>] member inline _.MaxElevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("MaxElevation" => x)
    [<CustomOperation("MaxSquare")>] member inline _.MaxSquare ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("MaxSquare" => x)
    [<CustomOperation("MaxRounded")>] member inline _.MaxRounded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("MaxRounded" => x)
    [<CustomOperation("MaxColor")>] member inline _.MaxColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("MaxColor" => x)
    [<CustomOperation("MaxSize")>] member inline _.MaxSize ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("MaxSize" => x)
    [<CustomOperation("MaxVariant")>] member inline _.MaxVariant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("MaxVariant" => x)
    [<CustomOperation("Max")>] member inline _.Max ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Max" => x)
    [<CustomOperation("MaxAvatarClass")>] member inline _.MaxAvatarClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("MaxAvatarClass" => x)
                

type MudBadgeBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudBadgeBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudBadgeBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Origin")>] member inline _.Origin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("Origin" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Visible")>] member inline _.Visible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Visible" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Dot")>] member inline _.Dot ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dot" => x)
    [<CustomOperation("Overlap")>] member inline _.Overlap ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Overlap" => x)
    [<CustomOperation("Bordered")>] member inline _.Bordered ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Bordered" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("Max")>] member inline _.Max ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Max" => x)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("Content" => x)
    [<CustomOperation("BadgeClass")>] member inline _.BadgeClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("BadgeClass" => x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
                

type MudBreadcrumbsBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudBreadcrumbsBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Items")>] member inline _.Items ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.List<MudBlazor.BreadcrumbItem>) = render ==> ("Items" => x)
    [<CustomOperation("Separator")>] member inline _.Separator ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Separator" => x)
    [<CustomOperation("SeparatorTemplate")>] member inline _.SeparatorTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("SeparatorTemplate", fragment)
    [<CustomOperation("SeparatorTemplate")>] member inline _.SeparatorTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("SeparatorTemplate", fragment { yield! fragments })
    [<CustomOperation("SeparatorTemplate")>] member inline _.SeparatorTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("SeparatorTemplate", html.text x)
    [<CustomOperation("SeparatorTemplate")>] member inline _.SeparatorTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("SeparatorTemplate", html.text x)
    [<CustomOperation("SeparatorTemplate")>] member inline _.SeparatorTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("SeparatorTemplate", html.text x)
    [<CustomOperation("ItemTemplate")>] member inline _.ItemTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: MudBlazor.BreadcrumbItem -> NodeRenderFragment) = render ==> html.renderFragment("ItemTemplate", fn)
    [<CustomOperation("MaxItems")>] member inline _.MaxItems ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Byte>) = render ==> ("MaxItems" => x)
    [<CustomOperation("ExpanderIcon")>] member inline _.ExpanderIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ExpanderIcon" => x)
                

type MudBreakpointProviderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudBreakpointProviderBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudBreakpointProviderBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("OnBreakpointChanged")>] member inline _.OnBreakpointChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.Breakpoint>("OnBreakpointChanged", fn)
                

type MudButtonGroupBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudButtonGroupBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudButtonGroupBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("OverrideStyles")>] member inline _.OverrideStyles ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("OverrideStyles" => x)
    [<CustomOperation("VerticalAlign")>] member inline _.VerticalAlign ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("VerticalAlign" => x)
    [<CustomOperation("DisableElevation")>] member inline _.DisableElevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableElevation" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
                

type MudToggleIconButtonBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudToggleIconButtonBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Toggled")>] member inline _.Toggled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Toggled" => x)
    [<CustomOperation("Toggled'")>] member inline _.Toggled' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Toggled", value)
    [<CustomOperation("Toggled'")>] member inline _.Toggled' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Toggled", value)
    [<CustomOperation("Toggled'")>] member inline _.Toggled' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Toggled", valueFn)
    [<CustomOperation("ToggledChanged")>] member inline _.ToggledChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("ToggledChanged", fn)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("ToggledIcon")>] member inline _.ToggledIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ToggledIcon" => x)
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("ToggledTitle")>] member inline _.ToggledTitle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ToggledTitle" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("ToggledColor")>] member inline _.ToggledColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("ToggledColor" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("ToggledSize")>] member inline _.ToggledSize ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("ToggledSize" => x)
    [<CustomOperation("Edge")>] member inline _.Edge ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Edge) = render ==> ("Edge" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
                

type MudCardBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudCardBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudCardBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("Outlined")>] member inline _.Outlined ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Outlined" => x)
                

type MudCardActionsBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudCardActionsBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudCardActionsBuilder<'FunBlazorGeneric>(){ yield! x }

                

type MudCardContentBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudCardContentBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudCardContentBuilder<'FunBlazorGeneric>(){ yield! x }

                

type MudCardHeaderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudCardHeaderBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudCardHeaderBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("CardHeaderAvatar")>] member inline _.CardHeaderAvatar ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("CardHeaderAvatar", fragment)
    [<CustomOperation("CardHeaderAvatar")>] member inline _.CardHeaderAvatar ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("CardHeaderAvatar", fragment { yield! fragments })
    [<CustomOperation("CardHeaderAvatar")>] member inline _.CardHeaderAvatar ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("CardHeaderAvatar", html.text x)
    [<CustomOperation("CardHeaderAvatar")>] member inline _.CardHeaderAvatar ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("CardHeaderAvatar", html.text x)
    [<CustomOperation("CardHeaderAvatar")>] member inline _.CardHeaderAvatar ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("CardHeaderAvatar", html.text x)
    [<CustomOperation("CardHeaderContent")>] member inline _.CardHeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("CardHeaderContent", fragment)
    [<CustomOperation("CardHeaderContent")>] member inline _.CardHeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("CardHeaderContent", fragment { yield! fragments })
    [<CustomOperation("CardHeaderContent")>] member inline _.CardHeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("CardHeaderContent", html.text x)
    [<CustomOperation("CardHeaderContent")>] member inline _.CardHeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("CardHeaderContent", html.text x)
    [<CustomOperation("CardHeaderContent")>] member inline _.CardHeaderContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("CardHeaderContent", html.text x)
    [<CustomOperation("CardHeaderActions")>] member inline _.CardHeaderActions ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("CardHeaderActions", fragment)
    [<CustomOperation("CardHeaderActions")>] member inline _.CardHeaderActions ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("CardHeaderActions", fragment { yield! fragments })
    [<CustomOperation("CardHeaderActions")>] member inline _.CardHeaderActions ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("CardHeaderActions", html.text x)
    [<CustomOperation("CardHeaderActions")>] member inline _.CardHeaderActions ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("CardHeaderActions", html.text x)
    [<CustomOperation("CardHeaderActions")>] member inline _.CardHeaderActions ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("CardHeaderActions", html.text x)
                

type MudCardMediaBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudCardMediaBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("Image")>] member inline _.Image ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Image" => x)
    [<CustomOperation("Height")>] member inline _.Height ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Height" => x)
                

type MudCarouselItemBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudCarouselItemBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudCarouselItemBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Transition")>] member inline _.Transition ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Transition) = render ==> ("Transition" => x)
    [<CustomOperation("CustomTransitionEnter")>] member inline _.CustomTransitionEnter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CustomTransitionEnter" => x)
    [<CustomOperation("CustomTransitionExit")>] member inline _.CustomTransitionExit ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CustomTransitionExit" => x)
                

type MudChipSetBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudChipSetBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudChipSetBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("MultiSelection")>] member inline _.MultiSelection ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("MultiSelection" => x)
    [<CustomOperation("Mandatory")>] member inline _.Mandatory ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Mandatory" => x)
    [<CustomOperation("AllClosable")>] member inline _.AllClosable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AllClosable" => x)
    [<CustomOperation("Filter")>] member inline _.Filter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Filter" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("SelectedChip")>] member inline _.SelectedChip ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.MudChip) = render ==> ("SelectedChip" => x)
    [<CustomOperation("SelectedChip'")>] member inline _.SelectedChip' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<MudBlazor.MudChip>) = render ==> html.bind("SelectedChip", value)
    [<CustomOperation("SelectedChip'")>] member inline _.SelectedChip' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<MudBlazor.MudChip>) = render ==> html.bind("SelectedChip", value)
    [<CustomOperation("SelectedChip'")>] member inline _.SelectedChip' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: MudBlazor.MudChip * (MudBlazor.MudChip -> unit)) = render ==> html.bind("SelectedChip", valueFn)
    [<CustomOperation("SelectedChipChanged")>] member inline _.SelectedChipChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.MudChip>("SelectedChipChanged", fn)
    [<CustomOperation("SelectedChips")>] member inline _.SelectedChips ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.MudChip[]) = render ==> ("SelectedChips" => x)
    [<CustomOperation("SelectedChips'")>] member inline _.SelectedChips' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<MudBlazor.MudChip[]>) = render ==> html.bind("SelectedChips", value)
    [<CustomOperation("SelectedChips'")>] member inline _.SelectedChips' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<MudBlazor.MudChip[]>) = render ==> html.bind("SelectedChips", value)
    [<CustomOperation("SelectedChips'")>] member inline _.SelectedChips' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: MudBlazor.MudChip[] * (MudBlazor.MudChip[] -> unit)) = render ==> html.bind("SelectedChips", valueFn)
    [<CustomOperation("Comparer")>] member inline _.Comparer ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.IEqualityComparer<System.Object>) = render ==> ("Comparer" => x)
    [<CustomOperation("SelectedChipsChanged")>] member inline _.SelectedChipsChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.MudChip[]>("SelectedChipsChanged", fn)
    [<CustomOperation("SelectedValues")>] member inline _.SelectedValues ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.ICollection<System.Object>) = render ==> ("SelectedValues" => x)
    [<CustomOperation("SelectedValues'")>] member inline _.SelectedValues' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Collections.Generic.ICollection<System.Object>>) = render ==> html.bind("SelectedValues", value)
    [<CustomOperation("SelectedValues'")>] member inline _.SelectedValues' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Collections.Generic.ICollection<System.Object>>) = render ==> html.bind("SelectedValues", value)
    [<CustomOperation("SelectedValues'")>] member inline _.SelectedValues' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Collections.Generic.ICollection<System.Object> * (System.Collections.Generic.ICollection<System.Object> -> unit)) = render ==> html.bind("SelectedValues", valueFn)
    [<CustomOperation("SelectedValuesChanged")>] member inline _.SelectedValuesChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Collections.Generic.ICollection<System.Object>>("SelectedValuesChanged", fn)
    [<CustomOperation("OnClose")>] member inline _.OnClose ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.MudChip>("OnClose", fn)
                

type MudChipBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudChipBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudChipBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("SelectedColor")>] member inline _.SelectedColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("SelectedColor" => x)
    [<CustomOperation("Avatar")>] member inline _.Avatar ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Avatar" => x)
    [<CustomOperation("AvatarClass")>] member inline _.AvatarClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AvatarClass" => x)
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Label" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("CheckedIcon")>] member inline _.CheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CheckedIcon" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("CloseIcon")>] member inline _.CloseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIcon" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Link")>] member inline _.Link ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Link" => x)
    [<CustomOperation("Target")>] member inline _.Target ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Target" => x)
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("Value" => x)
    [<CustomOperation("ForceLoad")>] member inline _.ForceLoad ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ForceLoad" => x)
    [<CustomOperation("Default")>] member inline _.Default ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("Default" => x)
    [<CustomOperation("Command")>] member inline _.Command ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Windows.Input.ICommand) = render ==> ("Command" => x)
    [<CustomOperation("CommandParameter")>] member inline _.CommandParameter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("CommandParameter" => x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
    [<CustomOperation("OnClose")>] member inline _.OnClose ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.MudChip>("OnClose", fn)
                

type MudCollapseBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudCollapseBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudCollapseBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Expanded")>] member inline _.Expanded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Expanded" => x)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Expanded", valueFn)
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("MaxHeight" => x)
    [<CustomOperation("OnAnimationEnd")>] member inline _.OnAnimationEnd ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback("OnAnimationEnd", fn)
    [<CustomOperation("OnAnimationEnd")>] member inline _.OnAnimationEnd ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callbackTask("OnAnimationEnd", fn)
    [<CustomOperation("ExpandedChanged")>] member inline _.ExpandedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("ExpandedChanged", fn)
                

type CellBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(CellBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("Item")>] member inline _.Item ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Item" => x)
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("Field")>] member inline _.Field ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Field" => x)
    [<CustomOperation("CellTemplate")>] member inline _.CellTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("CellTemplate", fn)
    [<CustomOperation("EditTemplate")>] member inline _.EditTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("EditTemplate", fn)
    [<CustomOperation("ColumnType")>] member inline _.ColumnType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ColumnType) = render ==> ("ColumnType" => x)
    [<CustomOperation("IsEditable")>] member inline _.IsEditable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsEditable" => x)
    [<CustomOperation("CellClass")>] member inline _.CellClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CellClass" => x)
    [<CustomOperation("CellStyle")>] member inline _.CellStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CellStyle" => x)
    [<CustomOperation("CellClassFunc")>] member inline _.CellClassFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("CellClassFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("CellStyleFunc")>] member inline _.CellStyleFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("CellStyleFunc" => (System.Func<'T, System.String>fn))
                

type ColumnBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = ColumnBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = ColumnBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Value" => x)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("Value", valueFn)
    [<CustomOperation("ValueChanged")>] member inline _.ValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("ValueChanged", fn)
    [<CustomOperation("Visible")>] member inline _.Visible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Visible" => x)
    [<CustomOperation("Field")>] member inline _.Field ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Field" => x)
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("HideSmall")>] member inline _.HideSmall ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideSmall" => x)
    [<CustomOperation("FooterColSpan")>] member inline _.FooterColSpan ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("FooterColSpan" => x)
    [<CustomOperation("HeaderColSpan")>] member inline _.HeaderColSpan ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("HeaderColSpan" => x)
    [<CustomOperation("Type")>] member inline _.Type ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ColumnType) = render ==> ("Type" => x)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("HeaderTemplate", fragment)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("HeaderTemplate", fragment { yield! fragments })
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("HeaderTemplate", html.text x)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("HeaderTemplate", html.text x)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("HeaderTemplate", html.text x)
    [<CustomOperation("CellTemplate")>] member inline _.CellTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("CellTemplate", fn)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("FooterTemplate", fragment)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("FooterTemplate", fragment { yield! fragments })
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("FooterTemplate", html.text x)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("FooterTemplate", html.text x)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("FooterTemplate", html.text x)
    [<CustomOperation("HeaderClass")>] member inline _.HeaderClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderClass" => x)
    [<CustomOperation("HeaderClassFunc")>] member inline _.HeaderClassFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("HeaderClassFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("HeaderStyle")>] member inline _.HeaderStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderStyle" => x)
    [<CustomOperation("HeaderStyleFunc")>] member inline _.HeaderStyleFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("HeaderStyleFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("Sortable")>] member inline _.Sortable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("Sortable" => x)
    [<CustomOperation("Filterable")>] member inline _.Filterable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("Filterable" => x)
    [<CustomOperation("ShowColumnOptions")>] member inline _.ShowColumnOptions ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("ShowColumnOptions" => x)
    [<CustomOperation("SortBy")>] member inline _.SortBy ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("SortBy" => (System.Func<'T, System.Object>fn))
    [<CustomOperation("InitialDirection")>] member inline _.InitialDirection ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.SortDirection) = render ==> ("InitialDirection" => x)
    [<CustomOperation("SortIcon")>] member inline _.SortIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SortIcon" => x)
    [<CustomOperation("CellClass")>] member inline _.CellClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CellClass" => x)
    [<CustomOperation("CellClassFunc")>] member inline _.CellClassFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("CellClassFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("CellStyle")>] member inline _.CellStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CellStyle" => x)
    [<CustomOperation("CellStyleFunc")>] member inline _.CellStyleFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("CellStyleFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("IsEditable")>] member inline _.IsEditable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("IsEditable" => x)
    [<CustomOperation("EditTemplate")>] member inline _.EditTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("EditTemplate", fn)
    [<CustomOperation("FooterClass")>] member inline _.FooterClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterClass" => x)
    [<CustomOperation("FooterClassFunc")>] member inline _.FooterClassFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("FooterClassFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("FooterStyle")>] member inline _.FooterStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterStyle" => x)
    [<CustomOperation("FooterStyleFunc")>] member inline _.FooterStyleFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("FooterStyleFunc" => (System.Func<'T, System.String>fn))
    [<CustomOperation("EnableFooterSelection")>] member inline _.EnableFooterSelection ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("EnableFooterSelection" => x)
                

type FooterCellBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = FooterCellBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = FooterCellBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("ColSpan")>] member inline _.ColSpan ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("ColSpan" => x)
    [<CustomOperation("ColumnType")>] member inline _.ColumnType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ColumnType) = render ==> ("ColumnType" => x)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("FooterTemplate", fragment)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("FooterTemplate", fragment { yield! fragments })
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("FooterTemplate", html.text x)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("FooterTemplate", html.text x)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("FooterTemplate", html.text x)
    [<CustomOperation("FooterClass")>] member inline _.FooterClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterClass" => x)
    [<CustomOperation("FooterStyle")>] member inline _.FooterStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterStyle" => x)
                

type HeaderCellBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = HeaderCellBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = HeaderCellBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("Field")>] member inline _.Field ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Field" => x)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("HeaderTemplate", fragment)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("HeaderTemplate", fragment { yield! fragments })
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("HeaderTemplate", html.text x)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("HeaderTemplate", html.text x)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("HeaderTemplate", html.text x)
    [<CustomOperation("ColSpan")>] member inline _.ColSpan ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("ColSpan" => x)
    [<CustomOperation("ColumnType")>] member inline _.ColumnType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ColumnType) = render ==> ("ColumnType" => x)
    [<CustomOperation("SortBy")>] member inline _.SortBy ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("SortBy" => (System.Func<'T, System.Object>fn))
    [<CustomOperation("SortIcon")>] member inline _.SortIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SortIcon" => x)
    [<CustomOperation("InitialDirection")>] member inline _.InitialDirection ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.SortDirection) = render ==> ("InitialDirection" => x)
    [<CustomOperation("Sortable")>] member inline _.Sortable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("Sortable" => x)
    [<CustomOperation("Filterable")>] member inline _.Filterable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("Filterable" => x)
    [<CustomOperation("ShowColumnOptions")>] member inline _.ShowColumnOptions ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("ShowColumnOptions" => x)
    [<CustomOperation("HeaderClass")>] member inline _.HeaderClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderClass" => x)
    [<CustomOperation("HeaderStyle")>] member inline _.HeaderStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderStyle" => x)
                

type MudDataGridBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDataGridBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("SelectedItemChanged")>] member inline _.SelectedItemChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("SelectedItemChanged", fn)
    [<CustomOperation("SelectedItemsChanged")>] member inline _.SelectedItemsChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Collections.Generic.HashSet<'T>>("SelectedItemsChanged", fn)
    [<CustomOperation("RowClick")>] member inline _.RowClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.DataGridRowClickEventArgs<'T>>("RowClick", fn)
    [<CustomOperation("StartedEditingItem")>] member inline _.StartedEditingItem ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("StartedEditingItem", fn)
    [<CustomOperation("EditingItemCancelled")>] member inline _.EditingItemCancelled ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("EditingItemCancelled", fn)
    [<CustomOperation("StartedCommittingItemChanges")>] member inline _.StartedCommittingItemChanges ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("StartedCommittingItemChanges", fn)
    [<CustomOperation("Sortable")>] member inline _.Sortable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Sortable" => x)
    [<CustomOperation("Filterable")>] member inline _.Filterable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Filterable" => x)
    [<CustomOperation("ShowColumnOptions")>] member inline _.ShowColumnOptions ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowColumnOptions" => x)
    [<CustomOperation("Breakpoint")>] member inline _.Breakpoint ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Breakpoint) = render ==> ("Breakpoint" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("Outlined")>] member inline _.Outlined ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Outlined" => x)
    [<CustomOperation("Bordered")>] member inline _.Bordered ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Bordered" => x)
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ColGroup", fragment)
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ColGroup", fragment { yield! fragments })
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ColGroup", html.text x)
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ColGroup", html.text x)
    [<CustomOperation("ColGroup")>] member inline _.ColGroup ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ColGroup", html.text x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("Hover")>] member inline _.Hover ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Hover" => x)
    [<CustomOperation("Striped")>] member inline _.Striped ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Striped" => x)
    [<CustomOperation("FixedHeader")>] member inline _.FixedHeader ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FixedHeader" => x)
    [<CustomOperation("FixedFooter")>] member inline _.FixedFooter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FixedFooter" => x)
    [<CustomOperation("FilterDefinitions")>] member inline _.FilterDefinitions ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.List<MudBlazor.FilterDefinition<'T>>) = render ==> ("FilterDefinitions" => x)
    [<CustomOperation("Virtualize")>] member inline _.Virtualize ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Virtualize" => x)
    [<CustomOperation("RowClass")>] member inline _.RowClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RowClass" => x)
    [<CustomOperation("RowStyle")>] member inline _.RowStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RowStyle" => x)
    [<CustomOperation("RowClassFunc")>] member inline _.RowClassFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("RowClassFunc" => (System.Func<'T, System.Int32, System.String>fn))
    [<CustomOperation("RowStyleFunc")>] member inline _.RowStyleFunc ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("RowStyleFunc" => (System.Func<'T, System.Int32, System.String>fn))
    [<CustomOperation("MultiSelection")>] member inline _.MultiSelection ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("MultiSelection" => x)
    [<CustomOperation("EditMode")>] member inline _.EditMode ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<MudBlazor.DataGridEditMode>) = render ==> ("EditMode" => x)
    [<CustomOperation("Items")>] member inline _.Items ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.IEnumerable<'T>) = render ==> ("Items" => x)
    [<CustomOperation("Loading")>] member inline _.Loading ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Loading" => x)
    [<CustomOperation("CanCancelEdit")>] member inline _.CanCancelEdit ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("CanCancelEdit" => x)
    [<CustomOperation("LoadingProgressColor")>] member inline _.LoadingProgressColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("LoadingProgressColor" => x)
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ToolBarContent", fragment)
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ToolBarContent", fragment { yield! fragments })
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ToolBarContent", html.text x)
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ToolBarContent", html.text x)
    [<CustomOperation("ToolBarContent")>] member inline _.ToolBarContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ToolBarContent", html.text x)
    [<CustomOperation("HorizontalScrollbar")>] member inline _.HorizontalScrollbar ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HorizontalScrollbar" => x)
    [<CustomOperation("HeaderClass")>] member inline _.HeaderClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderClass" => x)
    [<CustomOperation("Height")>] member inline _.Height ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Height" => x)
    [<CustomOperation("FooterClass")>] member inline _.FooterClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterClass" => x)
    [<CustomOperation("QuickFilter")>] member inline _.QuickFilter ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("QuickFilter" => (System.Func<'T, System.Boolean>fn))
    [<CustomOperation("Header")>] member inline _.Header ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("Header", fragment)
    [<CustomOperation("Header")>] member inline _.Header ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("Header", fragment { yield! fragments })
    [<CustomOperation("Header")>] member inline _.Header ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("Header", html.text x)
    [<CustomOperation("Header")>] member inline _.Header ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("Header", html.text x)
    [<CustomOperation("Header")>] member inline _.Header ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("Header", html.text x)
    [<CustomOperation("Columns")>] member inline _.Columns ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("Columns", fragment)
    [<CustomOperation("Columns")>] member inline _.Columns ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("Columns", fragment { yield! fragments })
    [<CustomOperation("Columns")>] member inline _.Columns ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("Columns", html.text x)
    [<CustomOperation("Columns")>] member inline _.Columns ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("Columns", html.text x)
    [<CustomOperation("Columns")>] member inline _.Columns ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("Columns", html.text x)
    [<CustomOperation("Footer")>] member inline _.Footer ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("Footer", fragment)
    [<CustomOperation("Footer")>] member inline _.Footer ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("Footer", fragment { yield! fragments })
    [<CustomOperation("Footer")>] member inline _.Footer ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("Footer", html.text x)
    [<CustomOperation("Footer")>] member inline _.Footer ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("Footer", html.text x)
    [<CustomOperation("Footer")>] member inline _.Footer ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("Footer", html.text x)
    [<CustomOperation("ChildRowContent")>] member inline _.ChildRowContent ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("ChildRowContent", fn)
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("NoRecordsContent", fragment)
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("NoRecordsContent", fragment { yield! fragments })
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("NoRecordsContent", html.text x)
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("NoRecordsContent", html.text x)
    [<CustomOperation("NoRecordsContent")>] member inline _.NoRecordsContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("NoRecordsContent", html.text x)
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("LoadingContent", fragment)
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("LoadingContent", fragment { yield! fragments })
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("LoadingContent", html.text x)
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("LoadingContent", html.text x)
    [<CustomOperation("LoadingContent")>] member inline _.LoadingContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("LoadingContent", html.text x)
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("PagerContent", fragment)
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("PagerContent", fragment { yield! fragments })
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("PagerContent", html.text x)
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("PagerContent", html.text x)
    [<CustomOperation("PagerContent")>] member inline _.PagerContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("PagerContent", html.text x)
    [<CustomOperation("ServerData")>] member inline _.ServerData ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("ServerData" => (System.Func<MudBlazor.GridState<'T>, System.Threading.Tasks.Task<MudBlazor.GridData<'T>>>fn))
    [<CustomOperation("RowsPerPage")>] member inline _.RowsPerPage ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("RowsPerPage" => x)
    [<CustomOperation("CurrentPage")>] member inline _.CurrentPage ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("CurrentPage" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("SelectedItems")>] member inline _.SelectedItems ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.HashSet<'T>) = render ==> ("SelectedItems" => x)
    [<CustomOperation("SelectedItems'")>] member inline _.SelectedItems' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Collections.Generic.HashSet<'T>>) = render ==> html.bind("SelectedItems", value)
    [<CustomOperation("SelectedItems'")>] member inline _.SelectedItems' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Collections.Generic.HashSet<'T>>) = render ==> html.bind("SelectedItems", value)
    [<CustomOperation("SelectedItems'")>] member inline _.SelectedItems' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Collections.Generic.HashSet<'T> * (System.Collections.Generic.HashSet<'T> -> unit)) = render ==> html.bind("SelectedItems", valueFn)
    [<CustomOperation("SelectedItem")>] member inline _.SelectedItem ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("SelectedItem" => x)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("SelectedItem", value)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("SelectedItem", value)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("SelectedItem", valueFn)
                

type MudDataGridPagerBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDataGridPagerBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("DisableRowsPerPage")>] member inline _.DisableRowsPerPage ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRowsPerPage" => x)
    [<CustomOperation("PageSizeOptions")>] member inline _.PageSizeOptions ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32[]) = render ==> ("PageSizeOptions" => x)
    [<CustomOperation("InfoFormat")>] member inline _.InfoFormat ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("InfoFormat" => x)
    [<CustomOperation("RowsPerPageString")>] member inline _.RowsPerPageString ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RowsPerPageString" => x)
                

type RowBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = RowBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = RowBuilder<'FunBlazorGeneric>(){ yield! x }

                

type MudDialogBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDialogBuilder<'FunBlazorGeneric>())
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("TitleContent", fragment)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("TitleContent", fragment { yield! fragments })
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("DialogContent")>] member inline _.DialogContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("DialogContent", fragment)
    [<CustomOperation("DialogContent")>] member inline _.DialogContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("DialogContent", fragment { yield! fragments })
    [<CustomOperation("DialogContent")>] member inline _.DialogContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("DialogContent", html.text x)
    [<CustomOperation("DialogContent")>] member inline _.DialogContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("DialogContent", html.text x)
    [<CustomOperation("DialogContent")>] member inline _.DialogContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("DialogContent", html.text x)
    [<CustomOperation("DialogActions")>] member inline _.DialogActions ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("DialogActions", fragment)
    [<CustomOperation("DialogActions")>] member inline _.DialogActions ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("DialogActions", fragment { yield! fragments })
    [<CustomOperation("DialogActions")>] member inline _.DialogActions ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("DialogActions", html.text x)
    [<CustomOperation("DialogActions")>] member inline _.DialogActions ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("DialogActions", html.text x)
    [<CustomOperation("DialogActions")>] member inline _.DialogActions ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("DialogActions", html.text x)
    [<CustomOperation("Options")>] member inline _.Options ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.DialogOptions) = render ==> ("Options" => x)
    [<CustomOperation("DisableSidePadding")>] member inline _.DisableSidePadding ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableSidePadding" => x)
    [<CustomOperation("ClassContent")>] member inline _.ClassContent ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ClassContent" => x)
    [<CustomOperation("ClassActions")>] member inline _.ClassActions ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ClassActions" => x)
    [<CustomOperation("ContentStyle")>] member inline _.ContentStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ContentStyle" => x)
    [<CustomOperation("IsVisible")>] member inline _.IsVisible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsVisible" => x)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsVisible", value)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsVisible", value)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsVisible", valueFn)
    [<CustomOperation("IsVisibleChanged")>] member inline _.IsVisibleChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsVisibleChanged", fn)
                

type MudDialogInstanceBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDialogInstanceBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Options")>] member inline _.Options ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.DialogOptions) = render ==> ("Options" => x)
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("TitleContent", fragment)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("TitleContent", fragment { yield! fragments })
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("Content", fragment)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("Content", fragment { yield! fragments })
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("Content", html.text x)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("Content", html.text x)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("Content", html.text x)
    [<CustomOperation("Id")>] member inline _.Id ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Guid) = render ==> ("Id" => x)
    [<CustomOperation("CloseIcon")>] member inline _.CloseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIcon" => x)
                

type MudDrawerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudDrawerBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudDrawerBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Fixed")>] member inline _.Fixed ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Fixed" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Anchor")>] member inline _.Anchor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Anchor) = render ==> ("Anchor" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.DrawerVariant) = render ==> ("Variant" => x)
    [<CustomOperation("DisableOverlay")>] member inline _.DisableOverlay ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableOverlay" => x)
    [<CustomOperation("PreserveOpenState")>] member inline _.PreserveOpenState ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("PreserveOpenState" => x)
    [<CustomOperation("OpenMiniOnHover")>] member inline _.OpenMiniOnHover ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("OpenMiniOnHover" => x)
    [<CustomOperation("Breakpoint")>] member inline _.Breakpoint ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Breakpoint) = render ==> ("Breakpoint" => x)
    [<CustomOperation("Open")>] member inline _.Open ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Open" => x)
    [<CustomOperation("Open'")>] member inline _.Open' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Open", value)
    [<CustomOperation("Open'")>] member inline _.Open' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Open", value)
    [<CustomOperation("Open'")>] member inline _.Open' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Open", valueFn)
    [<CustomOperation("OpenChanged")>] member inline _.OpenChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("OpenChanged", fn)
    [<CustomOperation("Width")>] member inline _.Width ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Width" => x)
    [<CustomOperation("MiniWidth")>] member inline _.MiniWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("MiniWidth" => x)
    [<CustomOperation("Height")>] member inline _.Height ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Height" => x)
    [<CustomOperation("ClipMode")>] member inline _.ClipMode ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.DrawerClipMode) = render ==> ("ClipMode" => x)
                

type MudElementBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudElementBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudElementBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("HtmlTag")>] member inline _.HtmlTag ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HtmlTag" => x)
    [<CustomOperation("Ref")>] member inline _.Ref ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<Microsoft.AspNetCore.Components.ElementReference>) = render ==> ("Ref" => x)
    [<CustomOperation("Ref'")>] member inline _.Ref' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Nullable<Microsoft.AspNetCore.Components.ElementReference>>) = render ==> html.bind("Ref", value)
    [<CustomOperation("Ref'")>] member inline _.Ref' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Nullable<Microsoft.AspNetCore.Components.ElementReference>>) = render ==> html.bind("Ref", value)
    [<CustomOperation("Ref'")>] member inline _.Ref' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Nullable<Microsoft.AspNetCore.Components.ElementReference> * (System.Nullable<Microsoft.AspNetCore.Components.ElementReference> -> unit)) = render ==> html.bind("Ref", valueFn)
    [<CustomOperation("RefChanged")>] member inline _.RefChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.ElementReference>("RefChanged", fn)
                

type MudExpansionPanelBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudExpansionPanelBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudExpansionPanelBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("MaxHeight" => x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("TitleContent", fragment)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("TitleContent", fragment { yield! fragments })
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("HideIcon")>] member inline _.HideIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideIcon" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("DisableGutters")>] member inline _.DisableGutters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableGutters" => x)
    [<CustomOperation("IsExpandedChanged")>] member inline _.IsExpandedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsExpandedChanged", fn)
    [<CustomOperation("IsExpanded")>] member inline _.IsExpanded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsExpanded" => x)
    [<CustomOperation("IsExpanded'")>] member inline _.IsExpanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsExpanded", value)
    [<CustomOperation("IsExpanded'")>] member inline _.IsExpanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsExpanded", value)
    [<CustomOperation("IsExpanded'")>] member inline _.IsExpanded' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsExpanded", valueFn)
    [<CustomOperation("IsInitiallyExpanded")>] member inline _.IsInitiallyExpanded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsInitiallyExpanded" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
                

type MudExpansionPanelsBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudExpansionPanelsBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudExpansionPanelsBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("MultiExpansion")>] member inline _.MultiExpansion ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("MultiExpansion" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("DisableGutters")>] member inline _.DisableGutters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableGutters" => x)
    [<CustomOperation("DisableBorders")>] member inline _.DisableBorders ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableBorders" => x)
                

type MudFieldBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudFieldBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudFieldBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Margin")>] member inline _.Margin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Margin) = render ==> ("Margin" => x)
    [<CustomOperation("Error")>] member inline _.Error ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Error" => x)
    [<CustomOperation("ErrorText")>] member inline _.ErrorText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ErrorText" => x)
    [<CustomOperation("HelperText")>] member inline _.HelperText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HelperText" => x)
    [<CustomOperation("FullWidth")>] member inline _.FullWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FullWidth" => x)
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Label" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("AdornmentIcon")>] member inline _.AdornmentIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AdornmentIcon" => x)
    [<CustomOperation("AdornmentText")>] member inline _.AdornmentText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AdornmentText" => x)
    [<CustomOperation("Adornment")>] member inline _.Adornment ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Adornment) = render ==> ("Adornment" => x)
    [<CustomOperation("AdornmentColor")>] member inline _.AdornmentColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("AdornmentColor" => x)
    [<CustomOperation("IconSize")>] member inline _.IconSize ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("IconSize" => x)
    [<CustomOperation("OnAdornmentClick")>] member inline _.OnAdornmentClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnAdornmentClick", fn)
    [<CustomOperation("InnerPadding")>] member inline _.InnerPadding ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("InnerPadding" => x)
    [<CustomOperation("DisableUnderLine")>] member inline _.DisableUnderLine ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableUnderLine" => x)
                

type MudFocusTrapBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudFocusTrapBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudFocusTrapBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("DefaultFocus")>] member inline _.DefaultFocus ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.DefaultFocus) = render ==> ("DefaultFocus" => x)
                

type MudFormBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudFormBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudFormBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("IsValid")>] member inline _.IsValid ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsValid" => x)
    [<CustomOperation("IsValid'")>] member inline _.IsValid' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsValid", value)
    [<CustomOperation("IsValid'")>] member inline _.IsValid' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsValid", value)
    [<CustomOperation("IsValid'")>] member inline _.IsValid' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsValid", valueFn)
    [<CustomOperation("IsTouched")>] member inline _.IsTouched ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsTouched" => x)
    [<CustomOperation("IsTouched'")>] member inline _.IsTouched' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsTouched", value)
    [<CustomOperation("IsTouched'")>] member inline _.IsTouched' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsTouched", value)
    [<CustomOperation("IsTouched'")>] member inline _.IsTouched' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsTouched", valueFn)
    [<CustomOperation("ValidationDelay")>] member inline _.ValidationDelay ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("ValidationDelay" => x)
    [<CustomOperation("SuppressRenderingOnValidation")>] member inline _.SuppressRenderingOnValidation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("SuppressRenderingOnValidation" => x)
    [<CustomOperation("SuppressImplicitSubmission")>] member inline _.SuppressImplicitSubmission ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("SuppressImplicitSubmission" => x)
    [<CustomOperation("IsValidChanged")>] member inline _.IsValidChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsValidChanged", fn)
    [<CustomOperation("IsTouchedChanged")>] member inline _.IsTouchedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsTouchedChanged", fn)
    [<CustomOperation("Errors")>] member inline _.Errors ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String[]) = render ==> ("Errors" => x)
    [<CustomOperation("Errors'")>] member inline _.Errors' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.String[]>) = render ==> html.bind("Errors", value)
    [<CustomOperation("Errors'")>] member inline _.Errors' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.String[]>) = render ==> html.bind("Errors", value)
    [<CustomOperation("Errors'")>] member inline _.Errors' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.String[] * (System.String[] -> unit)) = render ==> html.bind("Errors", valueFn)
    [<CustomOperation("ErrorsChanged")>] member inline _.ErrorsChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.String[]>("ErrorsChanged", fn)
    [<CustomOperation("Model")>] member inline _.Model ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("Model" => x)
                

type MudHiddenBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudHiddenBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudHiddenBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Breakpoint")>] member inline _.Breakpoint ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Breakpoint) = render ==> ("Breakpoint" => x)
    [<CustomOperation("Invert")>] member inline _.Invert ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Invert" => x)
    [<CustomOperation("IsHidden")>] member inline _.IsHidden ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsHidden" => x)
    [<CustomOperation("IsHidden'")>] member inline _.IsHidden' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsHidden", value)
    [<CustomOperation("IsHidden'")>] member inline _.IsHidden' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsHidden", value)
    [<CustomOperation("IsHidden'")>] member inline _.IsHidden' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsHidden", valueFn)
    [<CustomOperation("IsHiddenChanged")>] member inline _.IsHiddenChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsHiddenChanged", fn)
                

type MudIconBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudIconBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudIconBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("ViewBox")>] member inline _.ViewBox ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ViewBox" => x)
                

type MudInputControlBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudInputControlBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudInputControlBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("InputContent")>] member inline _.InputContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("InputContent", fragment)
    [<CustomOperation("InputContent")>] member inline _.InputContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("InputContent", fragment { yield! fragments })
    [<CustomOperation("InputContent")>] member inline _.InputContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("InputContent", html.text x)
    [<CustomOperation("InputContent")>] member inline _.InputContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("InputContent", html.text x)
    [<CustomOperation("InputContent")>] member inline _.InputContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("InputContent", html.text x)
    [<CustomOperation("Margin")>] member inline _.Margin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Margin) = render ==> ("Margin" => x)
    [<CustomOperation("Required")>] member inline _.Required ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Required" => x)
    [<CustomOperation("Error")>] member inline _.Error ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Error" => x)
    [<CustomOperation("ErrorText")>] member inline _.ErrorText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ErrorText" => x)
    [<CustomOperation("HelperText")>] member inline _.HelperText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HelperText" => x)
    [<CustomOperation("HelperTextOnFocus")>] member inline _.HelperTextOnFocus ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HelperTextOnFocus" => x)
    [<CustomOperation("CounterText")>] member inline _.CounterText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CounterText" => x)
    [<CustomOperation("FullWidth")>] member inline _.FullWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FullWidth" => x)
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Label" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
                

type MudInputLabelBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudInputLabelBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudInputLabelBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("Error")>] member inline _.Error ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Error" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Margin")>] member inline _.Margin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Margin) = render ==> ("Margin" => x)
                

type MudLinkBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudLinkBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudLinkBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Typo")>] member inline _.Typo ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Typo) = render ==> ("Typo" => x)
    [<CustomOperation("Underline")>] member inline _.Underline ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Underline) = render ==> ("Underline" => x)
    [<CustomOperation("Href")>] member inline _.Href ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Href" => x)
    [<CustomOperation("Target")>] member inline _.Target ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Target" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
                

type MudListBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudListBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudListBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Clickable")>] member inline _.Clickable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Clickable" => x)
    [<CustomOperation("DisablePadding")>] member inline _.DisablePadding ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisablePadding" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("DisableGutters")>] member inline _.DisableGutters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableGutters" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("SelectedItem")>] member inline _.SelectedItem ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.MudListItem) = render ==> ("SelectedItem" => x)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<MudBlazor.MudListItem>) = render ==> html.bind("SelectedItem", value)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<MudBlazor.MudListItem>) = render ==> html.bind("SelectedItem", value)
    [<CustomOperation("SelectedItem'")>] member inline _.SelectedItem' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: MudBlazor.MudListItem * (MudBlazor.MudListItem -> unit)) = render ==> html.bind("SelectedItem", valueFn)
    [<CustomOperation("SelectedItemChanged")>] member inline _.SelectedItemChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.MudListItem>("SelectedItemChanged", fn)
    [<CustomOperation("SelectedValue")>] member inline _.SelectedValue ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("SelectedValue" => x)
    [<CustomOperation("SelectedValue'")>] member inline _.SelectedValue' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Object>) = render ==> html.bind("SelectedValue", value)
    [<CustomOperation("SelectedValue'")>] member inline _.SelectedValue' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Object>) = render ==> html.bind("SelectedValue", value)
    [<CustomOperation("SelectedValue'")>] member inline _.SelectedValue' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Object * (System.Object -> unit)) = render ==> html.bind("SelectedValue", valueFn)
    [<CustomOperation("SelectedValueChanged")>] member inline _.SelectedValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Object>("SelectedValueChanged", fn)
                

type MudListItemBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudListItemBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudListItemBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("Value" => x)
    [<CustomOperation("Avatar")>] member inline _.Avatar ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Avatar" => x)
    [<CustomOperation("Href")>] member inline _.Href ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Href" => x)
    [<CustomOperation("ForceLoad")>] member inline _.ForceLoad ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ForceLoad" => x)
    [<CustomOperation("AvatarClass")>] member inline _.AvatarClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("AvatarClass" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("IconSize")>] member inline _.IconSize ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("IconSize" => x)
    [<CustomOperation("AdornmentColor")>] member inline _.AdornmentColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("AdornmentColor" => x)
    [<CustomOperation("ExpandLessIcon")>] member inline _.ExpandLessIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ExpandLessIcon" => x)
    [<CustomOperation("ExpandMoreIcon")>] member inline _.ExpandMoreIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ExpandMoreIcon" => x)
    [<CustomOperation("Inset")>] member inline _.Inset ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Inset" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("DisableGutters")>] member inline _.DisableGutters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableGutters" => x)
    [<CustomOperation("Expanded")>] member inline _.Expanded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Expanded" => x)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Expanded", valueFn)
    [<CustomOperation("ExpandedChanged")>] member inline _.ExpandedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("ExpandedChanged", fn)
    [<CustomOperation("InitiallyExpanded")>] member inline _.InitiallyExpanded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("InitiallyExpanded" => x)
    [<CustomOperation("CommandParameter")>] member inline _.CommandParameter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("CommandParameter" => x)
    [<CustomOperation("Command")>] member inline _.Command ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Windows.Input.ICommand) = render ==> ("Command" => x)
    [<CustomOperation("NestedList")>] member inline _.NestedList ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("NestedList", fragment)
    [<CustomOperation("NestedList")>] member inline _.NestedList ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("NestedList", fragment { yield! fragments })
    [<CustomOperation("NestedList")>] member inline _.NestedList ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("NestedList", html.text x)
    [<CustomOperation("NestedList")>] member inline _.NestedList ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("NestedList", html.text x)
    [<CustomOperation("NestedList")>] member inline _.NestedList ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("NestedList", html.text x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
                

type MudListSubheaderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudListSubheaderBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudListSubheaderBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("DisableGutters")>] member inline _.DisableGutters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableGutters" => x)
    [<CustomOperation("Inset")>] member inline _.Inset ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Inset" => x)
                

type MudMenuBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudMenuBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudMenuBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Label")>] member inline _.Label ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Label" => x)
    [<CustomOperation("ListClass")>] member inline _.ListClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ListClass" => x)
    [<CustomOperation("PopoverClass")>] member inline _.PopoverClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("PopoverClass" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("StartIcon")>] member inline _.StartIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("StartIcon" => x)
    [<CustomOperation("EndIcon")>] member inline _.EndIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("EndIcon" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("FullWidth")>] member inline _.FullWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FullWidth" => x)
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("MaxHeight" => x)
    [<CustomOperation("PositionAtCursor")>] member inline _.PositionAtCursor ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("PositionAtCursor" => x)
    [<CustomOperation("ActivatorContent")>] member inline _.ActivatorContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ActivatorContent", fragment)
    [<CustomOperation("ActivatorContent")>] member inline _.ActivatorContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ActivatorContent", fragment { yield! fragments })
    [<CustomOperation("ActivatorContent")>] member inline _.ActivatorContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ActivatorContent", html.text x)
    [<CustomOperation("ActivatorContent")>] member inline _.ActivatorContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ActivatorContent", html.text x)
    [<CustomOperation("ActivatorContent")>] member inline _.ActivatorContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ActivatorContent", html.text x)
    [<CustomOperation("ActivationEvent")>] member inline _.ActivationEvent ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.MouseEvent) = render ==> ("ActivationEvent" => x)
    [<CustomOperation("AnchorOrigin")>] member inline _.AnchorOrigin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("AnchorOrigin" => x)
    [<CustomOperation("TransformOrigin")>] member inline _.TransformOrigin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("TransformOrigin" => x)
    [<CustomOperation("LockScroll")>] member inline _.LockScroll ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("LockScroll" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("DisableElevation")>] member inline _.DisableElevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableElevation" => x)
                

type MudMenuItemBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudMenuItemBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudMenuItemBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("Link")>] member inline _.Link ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Link" => x)
    [<CustomOperation("Target")>] member inline _.Target ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Target" => x)
    [<CustomOperation("ForceLoad")>] member inline _.ForceLoad ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ForceLoad" => x)
    [<CustomOperation("Command")>] member inline _.Command ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Windows.Input.ICommand) = render ==> ("Command" => x)
    [<CustomOperation("CommandParameter")>] member inline _.CommandParameter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("CommandParameter" => x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
                

type MudMessageBoxBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudMessageBoxBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("TitleContent", fragment)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("TitleContent", fragment { yield! fragments })
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("TitleContent")>] member inline _.TitleContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("TitleContent", html.text x)
    [<CustomOperation("Message")>] member inline _.Message ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Message" => x)
    [<CustomOperation("MessageContent")>] member inline _.MessageContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("MessageContent", fragment)
    [<CustomOperation("MessageContent")>] member inline _.MessageContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("MessageContent", fragment { yield! fragments })
    [<CustomOperation("MessageContent")>] member inline _.MessageContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("MessageContent", html.text x)
    [<CustomOperation("MessageContent")>] member inline _.MessageContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("MessageContent", html.text x)
    [<CustomOperation("MessageContent")>] member inline _.MessageContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("MessageContent", html.text x)
    [<CustomOperation("CancelText")>] member inline _.CancelText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CancelText" => x)
    [<CustomOperation("CancelButton")>] member inline _.CancelButton ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("CancelButton", fragment)
    [<CustomOperation("CancelButton")>] member inline _.CancelButton ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("CancelButton", fragment { yield! fragments })
    [<CustomOperation("CancelButton")>] member inline _.CancelButton ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("CancelButton", html.text x)
    [<CustomOperation("CancelButton")>] member inline _.CancelButton ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("CancelButton", html.text x)
    [<CustomOperation("CancelButton")>] member inline _.CancelButton ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("CancelButton", html.text x)
    [<CustomOperation("NoText")>] member inline _.NoText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NoText" => x)
    [<CustomOperation("NoButton")>] member inline _.NoButton ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("NoButton", fragment)
    [<CustomOperation("NoButton")>] member inline _.NoButton ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("NoButton", fragment { yield! fragments })
    [<CustomOperation("NoButton")>] member inline _.NoButton ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("NoButton", html.text x)
    [<CustomOperation("NoButton")>] member inline _.NoButton ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("NoButton", html.text x)
    [<CustomOperation("NoButton")>] member inline _.NoButton ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("NoButton", html.text x)
    [<CustomOperation("YesText")>] member inline _.YesText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("YesText" => x)
    [<CustomOperation("YesButton")>] member inline _.YesButton ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("YesButton", fragment)
    [<CustomOperation("YesButton")>] member inline _.YesButton ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("YesButton", fragment { yield! fragments })
    [<CustomOperation("YesButton")>] member inline _.YesButton ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("YesButton", html.text x)
    [<CustomOperation("YesButton")>] member inline _.YesButton ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("YesButton", html.text x)
    [<CustomOperation("YesButton")>] member inline _.YesButton ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("YesButton", html.text x)
    [<CustomOperation("OnYes")>] member inline _.OnYes ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("OnYes", fn)
    [<CustomOperation("OnNo")>] member inline _.OnNo ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("OnNo", fn)
    [<CustomOperation("OnCancel")>] member inline _.OnCancel ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("OnCancel", fn)
    [<CustomOperation("IsVisible")>] member inline _.IsVisible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsVisible" => x)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsVisible", value)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsVisible", value)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsVisible", valueFn)
    [<CustomOperation("IsVisibleChanged")>] member inline _.IsVisibleChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsVisibleChanged", fn)
                

type MudNavGroupBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudNavGroupBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudNavGroupBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Title")>] member inline _.Title ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Title" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Expanded")>] member inline _.Expanded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Expanded" => x)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Expanded", valueFn)
    [<CustomOperation("ExpandedChanged")>] member inline _.ExpandedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("ExpandedChanged", fn)
    [<CustomOperation("HideExpandIcon")>] member inline _.HideExpandIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideExpandIcon" => x)
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("MaxHeight" => x)
    [<CustomOperation("ExpandIcon")>] member inline _.ExpandIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ExpandIcon" => x)
                

type MudNavMenuBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudNavMenuBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudNavMenuBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Bordered")>] member inline _.Bordered ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Bordered" => x)
    [<CustomOperation("Rounded")>] member inline _.Rounded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Rounded" => x)
    [<CustomOperation("Margin")>] member inline _.Margin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Margin) = render ==> ("Margin" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
                

type MudOverlayBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudOverlayBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudOverlayBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("VisibleChanged")>] member inline _.VisibleChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("VisibleChanged", fn)
    [<CustomOperation("Visible")>] member inline _.Visible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Visible" => x)
    [<CustomOperation("Visible'")>] member inline _.Visible' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Visible", value)
    [<CustomOperation("Visible'")>] member inline _.Visible' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Visible", value)
    [<CustomOperation("Visible'")>] member inline _.Visible' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Visible", valueFn)
    [<CustomOperation("AutoClose")>] member inline _.AutoClose ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AutoClose" => x)
    [<CustomOperation("LockScroll")>] member inline _.LockScroll ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("LockScroll" => x)
    [<CustomOperation("LockScrollClass")>] member inline _.LockScrollClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("LockScrollClass" => x)
    [<CustomOperation("DarkBackground")>] member inline _.DarkBackground ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DarkBackground" => x)
    [<CustomOperation("LightBackground")>] member inline _.LightBackground ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("LightBackground" => x)
    [<CustomOperation("Absolute")>] member inline _.Absolute ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Absolute" => x)
    [<CustomOperation("ZIndex")>] member inline _.ZIndex ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("ZIndex" => x)
    [<CustomOperation("CommandParameter")>] member inline _.CommandParameter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("CommandParameter" => x)
    [<CustomOperation("Command")>] member inline _.Command ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Windows.Input.ICommand) = render ==> ("Command" => x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
                

type MudPageContentNavigationBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudPageContentNavigationBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Headline")>] member inline _.Headline ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Headline" => x)
    [<CustomOperation("SectionClassSelector")>] member inline _.SectionClassSelector ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SectionClassSelector" => x)
    [<CustomOperation("ActivateFirstSectionAsDefault")>] member inline _.ActivateFirstSectionAsDefault ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ActivateFirstSectionAsDefault" => x)
                

type MudPaginationBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudPaginationBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Count")>] member inline _.Count ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Count" => x)
    [<CustomOperation("BoundaryCount")>] member inline _.BoundaryCount ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("BoundaryCount" => x)
    [<CustomOperation("MiddleCount")>] member inline _.MiddleCount ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("MiddleCount" => x)
    [<CustomOperation("Selected")>] member inline _.Selected ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Selected" => x)
    [<CustomOperation("Selected'")>] member inline _.Selected' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Int32>) = render ==> html.bind("Selected", value)
    [<CustomOperation("Selected'")>] member inline _.Selected' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Int32>) = render ==> html.bind("Selected", value)
    [<CustomOperation("Selected'")>] member inline _.Selected' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Int32 * (System.Int32 -> unit)) = render ==> html.bind("Selected", valueFn)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Rectangular")>] member inline _.Rectangular ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Rectangular" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("DisableElevation")>] member inline _.DisableElevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableElevation" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("ShowFirstButton")>] member inline _.ShowFirstButton ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowFirstButton" => x)
    [<CustomOperation("ShowLastButton")>] member inline _.ShowLastButton ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowLastButton" => x)
    [<CustomOperation("ShowPreviousButton")>] member inline _.ShowPreviousButton ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowPreviousButton" => x)
    [<CustomOperation("ShowNextButton")>] member inline _.ShowNextButton ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ShowNextButton" => x)
    [<CustomOperation("ControlButtonClicked")>] member inline _.ControlButtonClicked ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.Page>("ControlButtonClicked", fn)
    [<CustomOperation("SelectedChanged")>] member inline _.SelectedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Int32>("SelectedChanged", fn)
    [<CustomOperation("FirstIcon")>] member inline _.FirstIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FirstIcon" => x)
    [<CustomOperation("BeforeIcon")>] member inline _.BeforeIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("BeforeIcon" => x)
    [<CustomOperation("NextIcon")>] member inline _.NextIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NextIcon" => x)
    [<CustomOperation("LastIcon")>] member inline _.LastIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("LastIcon" => x)
                

type MudPopoverBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudPopoverBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudPopoverBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Int32>) = render ==> ("MaxHeight" => x)
    [<CustomOperation("Paper")>] member inline _.Paper ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Paper" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("Open")>] member inline _.Open ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Open" => x)
    [<CustomOperation("Fixed")>] member inline _.Fixed ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Fixed" => x)
    [<CustomOperation("Duration")>] member inline _.Duration ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Duration" => x)
    [<CustomOperation("Delay'")>] member inline _.Delay' ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Delay" => x)
    [<CustomOperation("AnchorOrigin")>] member inline _.AnchorOrigin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("AnchorOrigin" => x)
    [<CustomOperation("TransformOrigin")>] member inline _.TransformOrigin ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Origin) = render ==> ("TransformOrigin" => x)
    [<CustomOperation("OverflowBehavior")>] member inline _.OverflowBehavior ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.OverflowBehavior) = render ==> ("OverflowBehavior" => x)
    [<CustomOperation("RelativeWidth")>] member inline _.RelativeWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("RelativeWidth" => x)
                

type MudProgressCircularBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudProgressCircularBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Indeterminate")>] member inline _.Indeterminate ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Indeterminate" => x)
    [<CustomOperation("Min")>] member inline _.Min ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Min" => x)
    [<CustomOperation("Max")>] member inline _.Max ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Max" => x)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Value" => x)
    [<CustomOperation("StrokeWidth")>] member inline _.StrokeWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("StrokeWidth" => x)
                

type MudProgressLinearBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudProgressLinearBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudProgressLinearBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Indeterminate")>] member inline _.Indeterminate ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Indeterminate" => x)
    [<CustomOperation("Buffer")>] member inline _.Buffer ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Buffer" => x)
    [<CustomOperation("Rounded")>] member inline _.Rounded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Rounded" => x)
    [<CustomOperation("Striped")>] member inline _.Striped ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Striped" => x)
    [<CustomOperation("Vertical")>] member inline _.Vertical ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Vertical" => x)
    [<CustomOperation("Min")>] member inline _.Min ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Min" => x)
    [<CustomOperation("Max")>] member inline _.Max ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Max" => x)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Value" => x)
    [<CustomOperation("BufferValue")>] member inline _.BufferValue ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("BufferValue" => x)
                

type MudRadioBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudRadioBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudRadioBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Placement")>] member inline _.Placement ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Placement) = render ==> ("Placement" => x)
    [<CustomOperation("Option")>] member inline _.Option ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Option" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
                

type MudRatingBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudRatingBuilder<'FunBlazorGeneric>())
    [<CustomOperation("RatingItemsClass")>] member inline _.RatingItemsClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RatingItemsClass" => x)
    [<CustomOperation("RatingItemsStyle")>] member inline _.RatingItemsStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RatingItemsStyle" => x)
    [<CustomOperation("Name")>] member inline _.Name ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Name" => x)
    [<CustomOperation("MaxValue")>] member inline _.MaxValue ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("MaxValue" => x)
    [<CustomOperation("FullIcon")>] member inline _.FullIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FullIcon" => x)
    [<CustomOperation("EmptyIcon")>] member inline _.EmptyIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("EmptyIcon" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("SelectedValueChanged")>] member inline _.SelectedValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Int32>("SelectedValueChanged", fn)
    [<CustomOperation("SelectedValue")>] member inline _.SelectedValue ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("SelectedValue" => x)
    [<CustomOperation("SelectedValue'")>] member inline _.SelectedValue' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Int32>) = render ==> html.bind("SelectedValue", value)
    [<CustomOperation("SelectedValue'")>] member inline _.SelectedValue' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Int32>) = render ==> html.bind("SelectedValue", value)
    [<CustomOperation("SelectedValue'")>] member inline _.SelectedValue' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Int32 * (System.Int32 -> unit)) = render ==> html.bind("SelectedValue", valueFn)
    [<CustomOperation("HoveredValueChanged")>] member inline _.HoveredValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Nullable<System.Int32>>("HoveredValueChanged", fn)
                

type MudRatingItemBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudRatingItemBuilder<'FunBlazorGeneric>())
    [<CustomOperation("ItemValue")>] member inline _.ItemValue ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("ItemValue" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("DisableRipple")>] member inline _.DisableRipple ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableRipple" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("ItemClicked")>] member inline _.ItemClicked ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Int32>("ItemClicked", fn)
    [<CustomOperation("ItemHovered")>] member inline _.ItemHovered ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Nullable<System.Int32>>("ItemHovered", fn)
                

type MudRTLProviderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudRTLProviderBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudRTLProviderBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("RightToLeft")>] member inline _.RightToLeft ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("RightToLeft" => x)
                

type MudScrollToTopBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudScrollToTopBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudScrollToTopBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Selector")>] member inline _.Selector ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Selector" => x)
    [<CustomOperation("Visible")>] member inline _.Visible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Visible" => x)
    [<CustomOperation("VisibleCssClass")>] member inline _.VisibleCssClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("VisibleCssClass" => x)
    [<CustomOperation("HiddenCssClass")>] member inline _.HiddenCssClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HiddenCssClass" => x)
    [<CustomOperation("TopOffset")>] member inline _.TopOffset ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("TopOffset" => x)
    [<CustomOperation("ScrollBehavior")>] member inline _.ScrollBehavior ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.ScrollBehavior) = render ==> ("ScrollBehavior" => x)
    [<CustomOperation("OnScroll")>] member inline _.OnScroll ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.ScrollEventArgs>("OnScroll", fn)
                

type MudSkeletonBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudSkeletonBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Width")>] member inline _.Width ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Width" => x)
    [<CustomOperation("Height")>] member inline _.Height ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Height" => x)
    [<CustomOperation("SkeletonType")>] member inline _.SkeletonType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.SkeletonType) = render ==> ("SkeletonType" => x)
    [<CustomOperation("Animation")>] member inline _.Animation ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Animation) = render ==> ("Animation" => x)
                

type MudSliderBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudSliderBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudSliderBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("Min")>] member inline _.Min ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Min" => x)
    [<CustomOperation("Max")>] member inline _.Max ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Max" => x)
    [<CustomOperation("Step")>] member inline _.Step ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Step" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("Converter")>] member inline _.Converter ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Converter<'T>) = render ==> ("Converter" => x)
    [<CustomOperation("ValueChanged")>] member inline _.ValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("ValueChanged", fn)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Value" => x)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("Value", valueFn)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Immediate")>] member inline _.Immediate ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Immediate" => x)
                

type MudSnackbarElementBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudSnackbarElementBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Snackbar")>] member inline _.Snackbar ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Snackbar) = render ==> ("Snackbar" => x)
    [<CustomOperation("CloseIcon")>] member inline _.CloseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CloseIcon" => x)
                

type MudSnackbarProviderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudSnackbarProviderBuilder<'FunBlazorGeneric>())

                

type MudSwipeAreaBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudSwipeAreaBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudSwipeAreaBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("OnSwipe")>] member inline _.OnSwipe ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("OnSwipe" => (System.Action<MudBlazor.SwipeDirection>fn))
                

type MudSimpleTableBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudSimpleTableBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudSimpleTableBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Hover")>] member inline _.Hover ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Hover" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("Outlined")>] member inline _.Outlined ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Outlined" => x)
    [<CustomOperation("Bordered")>] member inline _.Bordered ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Bordered" => x)
    [<CustomOperation("Striped")>] member inline _.Striped ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Striped" => x)
    [<CustomOperation("FixedHeader")>] member inline _.FixedHeader ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FixedHeader" => x)
                

type MudTableGroupRowBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudTableGroupRowBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("GroupDefinition")>] member inline _.GroupDefinition ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TableGroupDefinition<'T>) = render ==> ("GroupDefinition" => x)
    [<CustomOperation("Items")>] member inline _.Items ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Linq.IGrouping<System.Object, 'T>) = render ==> ("Items" => x)
    [<CustomOperation("HeaderTemplate")>] member inline _.HeaderTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: MudBlazor.TableGroupData<System.Object, 'T> -> NodeRenderFragment) = render ==> html.renderFragment("HeaderTemplate", fn)
    [<CustomOperation("FooterTemplate")>] member inline _.FooterTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: MudBlazor.TableGroupData<System.Object, 'T> -> NodeRenderFragment) = render ==> html.renderFragment("FooterTemplate", fn)
    [<CustomOperation("IsCheckable")>] member inline _.IsCheckable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsCheckable" => x)
    [<CustomOperation("HeaderClass")>] member inline _.HeaderClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderClass" => x)
    [<CustomOperation("FooterClass")>] member inline _.FooterClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterClass" => x)
    [<CustomOperation("HeaderStyle")>] member inline _.HeaderStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderStyle" => x)
    [<CustomOperation("FooterStyle")>] member inline _.FooterStyle ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterStyle" => x)
    [<CustomOperation("ExpandIcon")>] member inline _.ExpandIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ExpandIcon" => x)
    [<CustomOperation("CollapseIcon")>] member inline _.CollapseIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CollapseIcon" => x)
    [<CustomOperation("OnRowClick")>] member inline _.OnRowClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnRowClick", fn)
                

type MudTablePagerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudTablePagerBuilder<'FunBlazorGeneric>())
    [<CustomOperation("HideRowsPerPage")>] member inline _.HideRowsPerPage ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideRowsPerPage" => x)
    [<CustomOperation("HidePageNumber")>] member inline _.HidePageNumber ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HidePageNumber" => x)
    [<CustomOperation("HidePagination")>] member inline _.HidePagination ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HidePagination" => x)
    [<CustomOperation("HorizontalAlignment")>] member inline _.HorizontalAlignment ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.HorizontalAlignment) = render ==> ("HorizontalAlignment" => x)
    [<CustomOperation("PageSizeOptions")>] member inline _.PageSizeOptions ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32[]) = render ==> ("PageSizeOptions" => x)
    [<CustomOperation("InfoFormat")>] member inline _.InfoFormat ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("InfoFormat" => x)
    [<CustomOperation("RowsPerPageString")>] member inline _.RowsPerPageString ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("RowsPerPageString" => x)
    [<CustomOperation("FirstIcon")>] member inline _.FirstIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FirstIcon" => x)
    [<CustomOperation("BeforeIcon")>] member inline _.BeforeIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("BeforeIcon" => x)
    [<CustomOperation("NextIcon")>] member inline _.NextIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("NextIcon" => x)
    [<CustomOperation("LastIcon")>] member inline _.LastIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("LastIcon" => x)
                

type MudTableSortLabelBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTableSortLabelBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTableSortLabelBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("InitialDirection")>] member inline _.InitialDirection ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.SortDirection) = render ==> ("InitialDirection" => x)
    [<CustomOperation("Enabled")>] member inline _.Enabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Enabled" => x)
    [<CustomOperation("SortIcon")>] member inline _.SortIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SortIcon" => x)
    [<CustomOperation("AppendIcon")>] member inline _.AppendIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("AppendIcon" => x)
    [<CustomOperation("SortDirection")>] member inline _.SortDirection ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.SortDirection) = render ==> ("SortDirection" => x)
    [<CustomOperation("SortDirection'")>] member inline _.SortDirection' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<MudBlazor.SortDirection>) = render ==> html.bind("SortDirection", value)
    [<CustomOperation("SortDirection'")>] member inline _.SortDirection' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<MudBlazor.SortDirection>) = render ==> html.bind("SortDirection", value)
    [<CustomOperation("SortDirection'")>] member inline _.SortDirection' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: MudBlazor.SortDirection * (MudBlazor.SortDirection -> unit)) = render ==> html.bind("SortDirection", valueFn)
    [<CustomOperation("SortDirectionChanged")>] member inline _.SortDirectionChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<MudBlazor.SortDirection>("SortDirectionChanged", fn)
    [<CustomOperation("SortBy")>] member inline _.SortBy ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("SortBy" => (System.Func<'T, System.Object>fn))
    [<CustomOperation("SortLabel")>] member inline _.SortLabel ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SortLabel" => x)
                

type MudTdBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTdBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTdBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("DataLabel")>] member inline _.DataLabel ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("DataLabel" => x)
    [<CustomOperation("HideSmall")>] member inline _.HideSmall ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideSmall" => x)
                

type MudTFootRowBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTFootRowBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTFootRowBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("IsCheckable")>] member inline _.IsCheckable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsCheckable" => x)
    [<CustomOperation("IgnoreCheckbox")>] member inline _.IgnoreCheckbox ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IgnoreCheckbox" => x)
    [<CustomOperation("IgnoreEditable")>] member inline _.IgnoreEditable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IgnoreEditable" => x)
    [<CustomOperation("IsExpandable")>] member inline _.IsExpandable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsExpandable" => x)
    [<CustomOperation("OnRowClick")>] member inline _.OnRowClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnRowClick", fn)
                

type MudThBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudThBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudThBuilder<'FunBlazorGeneric>(){ yield! x }

                

type MudTHeadRowBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTHeadRowBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTHeadRowBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("IsCheckable")>] member inline _.IsCheckable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsCheckable" => x)
    [<CustomOperation("IgnoreCheckbox")>] member inline _.IgnoreCheckbox ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IgnoreCheckbox" => x)
    [<CustomOperation("IgnoreEditable")>] member inline _.IgnoreEditable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IgnoreEditable" => x)
    [<CustomOperation("IsExpandable")>] member inline _.IsExpandable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsExpandable" => x)
    [<CustomOperation("OnRowClick")>] member inline _.OnRowClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnRowClick", fn)
                

type MudTrBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTrBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTrBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Item")>] member inline _.Item ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("Item" => x)
    [<CustomOperation("IsCheckable")>] member inline _.IsCheckable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsCheckable" => x)
    [<CustomOperation("IsEditable")>] member inline _.IsEditable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsEditable" => x)
    [<CustomOperation("IsEditing")>] member inline _.IsEditing ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsEditing" => x)
    [<CustomOperation("IsEditSwitchBlocked")>] member inline _.IsEditSwitchBlocked ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsEditSwitchBlocked" => x)
    [<CustomOperation("IsExpandable")>] member inline _.IsExpandable ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsExpandable" => x)
    [<CustomOperation("IsHeader")>] member inline _.IsHeader ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsHeader" => x)
    [<CustomOperation("IsFooter")>] member inline _.IsFooter ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsFooter" => x)
    [<CustomOperation("IsCheckedChanged")>] member inline _.IsCheckedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsCheckedChanged", fn)
    [<CustomOperation("IsChecked")>] member inline _.IsChecked ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsChecked" => x)
    [<CustomOperation("IsChecked'")>] member inline _.IsChecked' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsChecked", value)
    [<CustomOperation("IsChecked'")>] member inline _.IsChecked' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsChecked", value)
    [<CustomOperation("IsChecked'")>] member inline _.IsChecked' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsChecked", valueFn)
                

type MudTimelineItemBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTimelineItemBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTimelineItemBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("Variant")>] member inline _.Variant ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Variant) = render ==> ("Variant" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("TimelineAlign")>] member inline _.TimelineAlign ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.TimelineAlign) = render ==> ("TimelineAlign" => x)
    [<CustomOperation("HideDot")>] member inline _.HideDot ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("HideDot" => x)
    [<CustomOperation("ItemOpposite")>] member inline _.ItemOpposite ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ItemOpposite", fragment)
    [<CustomOperation("ItemOpposite")>] member inline _.ItemOpposite ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ItemOpposite", fragment { yield! fragments })
    [<CustomOperation("ItemOpposite")>] member inline _.ItemOpposite ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ItemOpposite", html.text x)
    [<CustomOperation("ItemOpposite")>] member inline _.ItemOpposite ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ItemOpposite", html.text x)
    [<CustomOperation("ItemOpposite")>] member inline _.ItemOpposite ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ItemOpposite", html.text x)
    [<CustomOperation("ItemContent")>] member inline _.ItemContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ItemContent", fragment)
    [<CustomOperation("ItemContent")>] member inline _.ItemContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ItemContent", fragment { yield! fragments })
    [<CustomOperation("ItemContent")>] member inline _.ItemContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ItemContent", html.text x)
    [<CustomOperation("ItemContent")>] member inline _.ItemContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ItemContent", html.text x)
    [<CustomOperation("ItemContent")>] member inline _.ItemContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ItemContent", html.text x)
    [<CustomOperation("ItemDot")>] member inline _.ItemDot ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ItemDot", fragment)
    [<CustomOperation("ItemDot")>] member inline _.ItemDot ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ItemDot", fragment { yield! fragments })
    [<CustomOperation("ItemDot")>] member inline _.ItemDot ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ItemDot", html.text x)
    [<CustomOperation("ItemDot")>] member inline _.ItemDot ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ItemDot", html.text x)
    [<CustomOperation("ItemDot")>] member inline _.ItemDot ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ItemDot", html.text x)
                

type MudTooltipBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTooltipBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTooltipBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("Arrow")>] member inline _.Arrow ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Arrow" => x)
    [<CustomOperation("Duration")>] member inline _.Duration ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Duration" => x)
    [<CustomOperation("Delay'")>] member inline _.Delay' ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Double) = render ==> ("Delay" => x)
    [<CustomOperation("Placement")>] member inline _.Placement ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Placement) = render ==> ("Placement" => x)
    [<CustomOperation("TooltipContent")>] member inline _.TooltipContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("TooltipContent", fragment)
    [<CustomOperation("TooltipContent")>] member inline _.TooltipContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("TooltipContent", fragment { yield! fragments })
    [<CustomOperation("TooltipContent")>] member inline _.TooltipContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("TooltipContent", html.text x)
    [<CustomOperation("TooltipContent")>] member inline _.TooltipContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("TooltipContent", html.text x)
    [<CustomOperation("TooltipContent")>] member inline _.TooltipContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("TooltipContent", html.text x)
    [<CustomOperation("Inline")>] member inline _.Inline ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Inline" => x)
    [<CustomOperation("IsVisible")>] member inline _.IsVisible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsVisible" => x)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsVisible", value)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsVisible", value)
    [<CustomOperation("IsVisible'")>] member inline _.IsVisible' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsVisible", valueFn)
    [<CustomOperation("IsVisibleChanged")>] member inline _.IsVisibleChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsVisibleChanged", fn)
                

type MudTreeViewBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTreeViewBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTreeViewBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("CheckBoxColor")>] member inline _.CheckBoxColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("CheckBoxColor" => x)
    [<CustomOperation("MultiSelection")>] member inline _.MultiSelection ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("MultiSelection" => x)
    [<CustomOperation("ExpandOnClick")>] member inline _.ExpandOnClick ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ExpandOnClick" => x)
    [<CustomOperation("Hover")>] member inline _.Hover ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Hover" => x)
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("Height")>] member inline _.Height ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Height" => x)
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("MaxHeight" => x)
    [<CustomOperation("Width")>] member inline _.Width ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Width" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("Items")>] member inline _.Items ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.HashSet<'T>) = render ==> ("Items" => x)
    [<CustomOperation("SelectedValueChanged")>] member inline _.SelectedValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("SelectedValueChanged", fn)
    [<CustomOperation("SelectedValuesChanged")>] member inline _.SelectedValuesChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Collections.Generic.HashSet<'T>>("SelectedValuesChanged", fn)
    [<CustomOperation("ItemTemplate")>] member inline _.ItemTemplate ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("ItemTemplate", fn)
    [<CustomOperation("ServerData")>] member inline _.ServerData ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("ServerData" => (System.Func<'T, System.Threading.Tasks.Task<System.Collections.Generic.HashSet<'T>>>fn))
                

type MudTreeViewItemBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTreeViewItemBuilder<'FunBlazorGeneric, 'T>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTreeViewItemBuilder<'FunBlazorGeneric, 'T>(){ yield! x }
    [<CustomOperation("CheckedIcon")>] member inline _.CheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("CheckedIcon" => x)
    [<CustomOperation("UncheckedIcon")>] member inline _.UncheckedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("UncheckedIcon" => x)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Value" => x)
    [<CustomOperation("Culture")>] member inline _.Culture ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Globalization.CultureInfo) = render ==> ("Culture" => x)
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("TextTypo")>] member inline _.TextTypo ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Typo) = render ==> ("TextTypo" => x)
    [<CustomOperation("TextClass")>] member inline _.TextClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("TextClass" => x)
    [<CustomOperation("EndText")>] member inline _.EndText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("EndText" => x)
    [<CustomOperation("EndTextTypo")>] member inline _.EndTextTypo ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Typo) = render ==> ("EndTextTypo" => x)
    [<CustomOperation("EndTextClass")>] member inline _.EndTextClass ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("EndTextClass" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("Content", fragment)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("Content", fragment { yield! fragments })
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("Content", html.text x)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("Content", html.text x)
    [<CustomOperation("Content")>] member inline _.Content ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("Content", html.text x)
    [<CustomOperation("Items")>] member inline _.Items ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.HashSet<'T>) = render ==> ("Items" => x)
    [<CustomOperation("Command")>] member inline _.Command ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Windows.Input.ICommand) = render ==> ("Command" => x)
    [<CustomOperation("Expanded")>] member inline _.Expanded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Expanded" => x)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Expanded", valueFn)
    [<CustomOperation("ExpandedChanged")>] member inline _.ExpandedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("ExpandedChanged", fn)
    [<CustomOperation("Activated")>] member inline _.Activated ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Activated" => x)
    [<CustomOperation("Activated'")>] member inline _.Activated' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Activated", value)
    [<CustomOperation("Activated'")>] member inline _.Activated' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Activated", value)
    [<CustomOperation("Activated'")>] member inline _.Activated' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Activated", valueFn)
    [<CustomOperation("Selected")>] member inline _.Selected ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Selected" => x)
    [<CustomOperation("Selected'")>] member inline _.Selected' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Selected", value)
    [<CustomOperation("Selected'")>] member inline _.Selected' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Selected", value)
    [<CustomOperation("Selected'")>] member inline _.Selected' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Selected", valueFn)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("IconColor")>] member inline _.IconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("IconColor" => x)
    [<CustomOperation("EndIcon")>] member inline _.EndIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("EndIcon" => x)
    [<CustomOperation("EndIconColor")>] member inline _.EndIconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("EndIconColor" => x)
    [<CustomOperation("ExpandedIcon")>] member inline _.ExpandedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ExpandedIcon" => x)
    [<CustomOperation("ExpandedIconColor")>] member inline _.ExpandedIconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("ExpandedIconColor" => x)
    [<CustomOperation("LoadingIcon")>] member inline _.LoadingIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("LoadingIcon" => x)
    [<CustomOperation("LoadingIconColor")>] member inline _.LoadingIconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("LoadingIconColor" => x)
    [<CustomOperation("ActivatedChanged")>] member inline _.ActivatedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("ActivatedChanged", fn)
    [<CustomOperation("SelectedChanged")>] member inline _.SelectedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("SelectedChanged", fn)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
                

type MudTextBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTextBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTextBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Typo")>] member inline _.Typo ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Typo) = render ==> ("Typo" => x)
    [<CustomOperation("Align")>] member inline _.Align ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Align) = render ==> ("Align" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("GutterBottom")>] member inline _.GutterBottom ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("GutterBottom" => x)
    [<CustomOperation("Inline")>] member inline _.Inline ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Inline" => x)
                

type MudContainerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudContainerBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudContainerBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Fixed")>] member inline _.Fixed ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Fixed" => x)
    [<CustomOperation("MaxWidth")>] member inline _.MaxWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.MaxWidth) = render ==> ("MaxWidth" => x)
                

type MudDividerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDividerBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Absolute")>] member inline _.Absolute ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Absolute" => x)
    [<CustomOperation("FlexItem")>] member inline _.FlexItem ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("FlexItem" => x)
    [<CustomOperation("Light")>] member inline _.Light ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Light" => x)
    [<CustomOperation("Vertical")>] member inline _.Vertical ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Vertical" => x)
    [<CustomOperation("DividerType")>] member inline _.DividerType ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.DividerType) = render ==> ("DividerType" => x)
                

type MudDrawerHeaderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudDrawerHeaderBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudDrawerHeaderBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("LinkToIndex")>] member inline _.LinkToIndex ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("LinkToIndex" => x)
                

type MudGridBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudGridBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudGridBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Spacing")>] member inline _.Spacing ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Spacing" => x)
    [<CustomOperation("Justify")>] member inline _.Justify ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Justify) = render ==> ("Justify" => x)
                

type MudItemBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudItemBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudItemBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("xs")>] member inline _.xs ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("xs" => x)
    [<CustomOperation("sm")>] member inline _.sm ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("sm" => x)
    [<CustomOperation("md")>] member inline _.md ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("md" => x)
    [<CustomOperation("lg")>] member inline _.lg ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("lg" => x)
    [<CustomOperation("xl")>] member inline _.xl ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("xl" => x)
    [<CustomOperation("xxl")>] member inline _.xxl ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("xxl" => x)
                

type MudHighlighterBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudHighlighterBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("HighlightedText")>] member inline _.HighlightedText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HighlightedText" => x)
    [<CustomOperation("CaseSensitive")>] member inline _.CaseSensitive ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("CaseSensitive" => x)
    [<CustomOperation("UntilNextBoundary")>] member inline _.UntilNextBoundary ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("UntilNextBoundary" => x)
                

type MudMainContentBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudMainContentBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudMainContentBuilder<'FunBlazorGeneric>(){ yield! x }

                

type MudPaperBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudPaperBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudPaperBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Elevation")>] member inline _.Elevation ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("Elevation" => x)
    [<CustomOperation("Square")>] member inline _.Square ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Square" => x)
    [<CustomOperation("Outlined")>] member inline _.Outlined ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Outlined" => x)
    [<CustomOperation("Height")>] member inline _.Height ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Height" => x)
    [<CustomOperation("Width")>] member inline _.Width ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Width" => x)
    [<CustomOperation("MaxHeight")>] member inline _.MaxHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("MaxHeight" => x)
    [<CustomOperation("MaxWidth")>] member inline _.MaxWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("MaxWidth" => x)
    [<CustomOperation("MinHeight")>] member inline _.MinHeight ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("MinHeight" => x)
    [<CustomOperation("MinWidth")>] member inline _.MinWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("MinWidth" => x)
                

type MudSparkLineBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudSparkLineBuilder<'FunBlazorGeneric>())
    [<CustomOperation("StrokeWidth")>] member inline _.StrokeWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Int32) = render ==> ("StrokeWidth" => x)
                

type MudTabPanelBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudTabPanelBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudTabPanelBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("Disabled")>] member inline _.Disabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Disabled" => x)
    [<CustomOperation("BadgeData")>] member inline _.BadgeData ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("BadgeData" => x)
    [<CustomOperation("BadgeDot")>] member inline _.BadgeDot ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("BadgeDot" => x)
    [<CustomOperation("BadgeColor")>] member inline _.BadgeColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("BadgeColor" => x)
    [<CustomOperation("ID")>] member inline _.ID ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("ID" => x)
    [<CustomOperation("OnClick")>] member inline _.OnClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("OnClick", fn)
    [<CustomOperation("ToolTip")>] member inline _.ToolTip ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ToolTip" => x)
                

type MudToolBarBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudComponentBaseBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudToolBarBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudToolBarBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Dense")>] member inline _.Dense ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Dense" => x)
    [<CustomOperation("DisableGutters")>] member inline _.DisableGutters ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableGutters" => x)
                

type MudBaseColumnBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudBaseColumnBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Visible")>] member inline _.Visible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Visible" => x)
    [<CustomOperation("HeaderText")>] member inline _.HeaderText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("HeaderText" => x)
                

type MudColumnBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseColumnBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudColumnBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Value" => x)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("Value", valueFn)
    [<CustomOperation("ValueChanged")>] member inline _.ValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("ValueChanged", fn)
    [<CustomOperation("FooterValue")>] member inline _.FooterValue ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("FooterValue" => x)
    [<CustomOperation("FooterText")>] member inline _.FooterText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterText" => x)
    [<CustomOperation("DataFormatString")>] member inline _.DataFormatString ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("DataFormatString" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
                

type MudSortableColumnBuilder<'FunBlazorGeneric, 'T, 'ModelType when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseColumnBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudSortableColumnBuilder<'FunBlazorGeneric, 'T, 'ModelType>())
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Value" => x)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<'T>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: 'T * ('T -> unit)) = render ==> html.bind("Value", valueFn)
    [<CustomOperation("ValueChanged")>] member inline _.ValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<'T>("ValueChanged", fn)
    [<CustomOperation("FooterValue")>] member inline _.FooterValue ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("FooterValue" => x)
    [<CustomOperation("FooterText")>] member inline _.FooterText ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("FooterText" => x)
    [<CustomOperation("DataFormatString")>] member inline _.DataFormatString ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("DataFormatString" => x)
    [<CustomOperation("ReadOnly")>] member inline _.ReadOnly ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("ReadOnly" => x)
    [<CustomOperation("SortLabel")>] member inline _.SortLabel ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("SortLabel" => x)
    [<CustomOperation("SortBy")>] member inline _.SortBy ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> ("SortBy" => (System.Func<'ModelType, System.Object>fn))
                

type MudAvatarColumnBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseColumnBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudAvatarColumnBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("Value" => x)
                

type MudTemplateColumnBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit MudBaseColumnBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudTemplateColumnBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("DataContext")>] member inline _.DataContext ([<InlineIfLambda>] render: AttrRenderFragment, x: 'T) = render ==> ("DataContext" => x)
    [<CustomOperation("Header")>] member inline _.Header ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("Header", fn)
    [<CustomOperation("Row")>] member inline _.Row ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("Row", fn)
    [<CustomOperation("Edit")>] member inline _.Edit ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("Edit", fn)
    [<CustomOperation("Footer")>] member inline _.Footer ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("Footer", fn)
                

type BaseMudThemeProviderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(BaseMudThemeProviderBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Theme")>] member inline _.Theme ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.MudTheme) = render ==> ("Theme" => x)
    [<CustomOperation("DefaultScrollbar")>] member inline _.DefaultScrollbar ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DefaultScrollbar" => x)
    [<CustomOperation("IsDarkMode")>] member inline _.IsDarkMode ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsDarkMode" => x)
    [<CustomOperation("IsDarkMode'")>] member inline _.IsDarkMode' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("IsDarkMode", value)
    [<CustomOperation("IsDarkMode'")>] member inline _.IsDarkMode' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("IsDarkMode", value)
    [<CustomOperation("IsDarkMode'")>] member inline _.IsDarkMode' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("IsDarkMode", valueFn)
    [<CustomOperation("IsDarkModeChanged")>] member inline _.IsDarkModeChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("IsDarkModeChanged", fn)
                

type MudThemeProviderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit BaseMudThemeProviderBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudThemeProviderBuilder<'FunBlazorGeneric>())

                

type FilterBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(FilterBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("Id")>] member inline _.Id ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Guid) = render ==> ("Id" => x)
    [<CustomOperation("Field")>] member inline _.Field ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Field" => x)
    [<CustomOperation("Field'")>] member inline _.Field' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.String>) = render ==> html.bind("Field", value)
    [<CustomOperation("Field'")>] member inline _.Field' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.String>) = render ==> html.bind("Field", value)
    [<CustomOperation("Field'")>] member inline _.Field' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.String * (System.String -> unit)) = render ==> html.bind("Field", valueFn)
    [<CustomOperation("Operator")>] member inline _.Operator ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Operator" => x)
    [<CustomOperation("Operator'")>] member inline _.Operator' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.String>) = render ==> html.bind("Operator", value)
    [<CustomOperation("Operator'")>] member inline _.Operator' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.String>) = render ==> html.bind("Operator", value)
    [<CustomOperation("Operator'")>] member inline _.Operator' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.String * (System.String -> unit)) = render ==> html.bind("Operator", valueFn)
    [<CustomOperation("Value")>] member inline _.Value ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Object) = render ==> ("Value" => x)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Object>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Object>) = render ==> html.bind("Value", value)
    [<CustomOperation("Value'")>] member inline _.Value' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Object * (System.Object -> unit)) = render ==> html.bind("Value", valueFn)
    [<CustomOperation("FieldChanged")>] member inline _.FieldChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.String>("FieldChanged", fn)
    [<CustomOperation("OperatorChanged")>] member inline _.OperatorChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.String>("OperatorChanged", fn)
    [<CustomOperation("ValueChanged")>] member inline _.ValueChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Object>("ValueChanged", fn)
                

type MudDialogProviderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudDialogProviderBuilder<'FunBlazorGeneric>())
    [<CustomOperation("NoHeader")>] member inline _.NoHeader ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("NoHeader" => x)
    [<CustomOperation("CloseButton")>] member inline _.CloseButton ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("CloseButton" => x)
    [<CustomOperation("DisableBackdropClick")>] member inline _.DisableBackdropClick ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("DisableBackdropClick" => x)
    [<CustomOperation("CloseOnEscapeKey")>] member inline _.CloseOnEscapeKey ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("CloseOnEscapeKey" => x)
    [<CustomOperation("FullWidth")>] member inline _.FullWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<System.Boolean>) = render ==> ("FullWidth" => x)
    [<CustomOperation("Position")>] member inline _.Position ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<MudBlazor.DialogPosition>) = render ==> ("Position" => x)
    [<CustomOperation("MaxWidth")>] member inline _.MaxWidth ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Nullable<MudBlazor.MaxWidth>) = render ==> ("MaxWidth" => x)
                

type MudPopoverProviderBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudPopoverProviderBuilder<'FunBlazorGeneric>())

                

type MudVirtualizeBuilder<'FunBlazorGeneric, 'T when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudVirtualizeBuilder<'FunBlazorGeneric, 'T>())
    [<CustomOperation("IsEnabled")>] member inline _.IsEnabled ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("IsEnabled" => x)
    [<CustomOperation("ChildContent")>] member inline _.ChildContent ([<InlineIfLambda>] render: AttrRenderFragment, fn: 'T -> NodeRenderFragment) = render ==> html.renderFragment("ChildContent", fn)
    [<CustomOperation("Items")>] member inline _.Items ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Collections.Generic.ICollection<'T>) = render ==> ("Items" => x)
                

type BreadcrumbLinkBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(BreadcrumbLinkBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Item")>] member inline _.Item ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.BreadcrumbItem) = render ==> ("Item" => x)
                

type BreadcrumbSeparatorBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(BreadcrumbSeparatorBuilder<'FunBlazorGeneric>())

                

type MudPickerContentBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudPickerContentBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudPickerContentBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Classes")>] member inline _.Classes ([<InlineIfLambda>] render: AttrRenderFragment, x: string list) = render ==> html.classes x
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ChildContent", fragment)
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ChildContent", fragment { yield! fragments })
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ChildContent", html.text x)
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ChildContent", html.text x)
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ChildContent", html.text x)
                

type MudPickerToolbarBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create (x: string) = MudPickerToolbarBuilder<'FunBlazorGeneric>(){ x }
    static member inline create (x: NodeRenderFragment seq) = MudPickerToolbarBuilder<'FunBlazorGeneric>(){ yield! x }
    [<CustomOperation("Classes")>] member inline _.Classes ([<InlineIfLambda>] render: AttrRenderFragment, x: string list) = render ==> html.classes x
    [<CustomOperation("Styles")>] member inline _.Styles ([<InlineIfLambda>] render: AttrRenderFragment, x: (string * string) list) = render ==> html.styles x
    [<CustomOperation("DisableToolbar")>] member inline _.DisableToolbar ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("DisableToolbar" => x)
    [<CustomOperation("Orientation")>] member inline _.Orientation ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Orientation) = render ==> ("Orientation" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, fragment) = render ==> html.renderFragment("ChildContent", fragment)
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, fragments) = render ==> html.renderFragment("ChildContent", fragment { yield! fragments })
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> html.renderFragment("ChildContent", html.text x)
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, x: int) = render ==> html.renderFragment("ChildContent", html.text x)
    [<CustomOperation("childContent")>] member inline _.childContent ([<InlineIfLambda>] render: AttrRenderFragment, x: float) = render ==> html.renderFragment("ChildContent", html.text x)
                

type MudSpacerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudSpacerBuilder<'FunBlazorGeneric>())

                

type MudTreeViewItemToggleButtonBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudTreeViewItemToggleButtonBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Visible")>] member inline _.Visible ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Visible" => x)
    [<CustomOperation("Expanded")>] member inline _.Expanded ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Expanded" => x)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: IStore<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, value: cval<System.Boolean>) = render ==> html.bind("Expanded", value)
    [<CustomOperation("Expanded'")>] member inline _.Expanded' ([<InlineIfLambda>] render: AttrRenderFragment, valueFn: System.Boolean * (System.Boolean -> unit)) = render ==> html.bind("Expanded", valueFn)
    [<CustomOperation("Loading")>] member inline _.Loading ([<InlineIfLambda>] render: AttrRenderFragment, x: System.Boolean) = render ==> ("Loading" => x)
    [<CustomOperation("ExpandedChanged")>] member inline _.ExpandedChanged ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<System.Boolean>("ExpandedChanged", fn)
    [<CustomOperation("LoadingIcon")>] member inline _.LoadingIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("LoadingIcon" => x)
    [<CustomOperation("LoadingIconColor")>] member inline _.LoadingIconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("LoadingIconColor" => x)
    [<CustomOperation("ExpandedIcon")>] member inline _.ExpandedIcon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("ExpandedIcon" => x)
    [<CustomOperation("ExpandedIconColor")>] member inline _.ExpandedIconColor ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("ExpandedIconColor" => x)
                

type _ImportsBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(_ImportsBuilder<'FunBlazorGeneric>())

                
            
namespace rec MudBlazor.DslInternals.Internal

open FSharp.Data.Adaptive
open Fun.Blazor
open Fun.Blazor.Operators
open MudBlazor.DslInternals


type MudInputAdornmentBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(MudInputAdornmentBuilder<'FunBlazorGeneric>())
    [<CustomOperation("Classes")>] member inline _.Classes ([<InlineIfLambda>] render: AttrRenderFragment, x: string list) = render ==> html.classes x
    [<CustomOperation("Text")>] member inline _.Text ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Text" => x)
    [<CustomOperation("Icon")>] member inline _.Icon ([<InlineIfLambda>] render: AttrRenderFragment, x: System.String) = render ==> ("Icon" => x)
    [<CustomOperation("Edge")>] member inline _.Edge ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Edge) = render ==> ("Edge" => x)
    [<CustomOperation("Size")>] member inline _.Size ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Size) = render ==> ("Size" => x)
    [<CustomOperation("Color")>] member inline _.Color ([<InlineIfLambda>] render: AttrRenderFragment, x: MudBlazor.Color) = render ==> ("Color" => x)
    [<CustomOperation("AdornmentClick")>] member inline _.AdornmentClick ([<InlineIfLambda>] render: AttrRenderFragment, fn) = render ==> html.callback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>("AdornmentClick", fn)
                
            
namespace rec MudBlazor.DslInternals.Charts

open FSharp.Data.Adaptive
open Fun.Blazor
open Fun.Blazor.Operators
open MudBlazor.DslInternals


type FiltersBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    static member inline create () = html.fromBuilder(FiltersBuilder<'FunBlazorGeneric>())

                
            

// =======================================================================================================================

namespace MudBlazor

[<AutoOpen>]
module DslCE =

    open MudBlazor.DslInternals

    type MudComponentBase'() = inherit MudComponentBaseBuilder<MudBlazor.MudComponentBase>()
    type MudBaseButton'() = inherit MudBaseButtonBuilder<MudBlazor.MudBaseButton>()
    type MudButton'() = inherit MudButtonBuilder<MudBlazor.MudButton>()
    type MudFab'() = inherit MudFabBuilder<MudBlazor.MudFab>()
    type MudIconButton'() = inherit MudIconButtonBuilder<MudBlazor.MudIconButton>()
    type MudFileUploader'() = inherit MudFileUploaderBuilder<MudBlazor.MudFileUploader>()
    type MudDrawerContainer'() = inherit MudDrawerContainerBuilder<MudBlazor.MudDrawerContainer>()
    type MudLayout'() = inherit MudLayoutBuilder<MudBlazor.MudLayout>()
    type MudBaseSelectItem'() = inherit MudBaseSelectItemBuilder<MudBlazor.MudBaseSelectItem>()
    type MudNavLink'() = inherit MudNavLinkBuilder<MudBlazor.MudNavLink>()
    type MudSelectItem'<'T>() = inherit MudSelectItemBuilder<MudBlazor.MudSelectItem<'T>, 'T>()
    type MudTableBase'() = inherit MudTableBaseBuilder<MudBlazor.MudTableBase>()
    type MudTable'<'T>() = inherit MudTableBuilder<MudBlazor.MudTable<'T>, 'T>()
    type MudTabs'() = inherit MudTabsBuilder<MudBlazor.MudTabs>()
    type MudDynamicTabs'() = inherit MudDynamicTabsBuilder<MudBlazor.MudDynamicTabs>()
    type MudChartBase'() = inherit MudChartBaseBuilder<MudBlazor.MudChartBase>()
    type MudChart'() = inherit MudChartBuilder<MudBlazor.MudChart>()
    type MudBaseItemsControl'<'TChildComponent when 'TChildComponent :> MudBlazor.MudComponentBase>() = inherit MudBaseItemsControlBuilder<MudBlazor.MudBaseItemsControl<'TChildComponent>, 'TChildComponent>()
    type MudBaseBindableItemsControl'<'TChildComponent, 'TData when 'TChildComponent :> MudBlazor.MudComponentBase>() = inherit MudBaseBindableItemsControlBuilder<MudBlazor.MudBaseBindableItemsControl<'TChildComponent, 'TData>, 'TChildComponent, 'TData>()
    type MudCarousel'<'TData>() = inherit MudCarouselBuilder<MudBlazor.MudCarousel<'TData>, 'TData>()
    type MudTimeline'() = inherit MudTimelineBuilder<MudBlazor.MudTimeline>()
    type MudFormComponent'<'T, 'U>() = inherit MudFormComponentBuilder<MudBlazor.MudFormComponent<'T, 'U>, 'T, 'U>()
    type MudBaseInput'<'T>() = inherit MudBaseInputBuilder<MudBlazor.MudBaseInput<'T>, 'T>()
    type MudAutocomplete'<'T>() = inherit MudAutocompleteBuilder<MudBlazor.MudAutocomplete<'T>, 'T>()
    type MudDebouncedInput'<'T>() = inherit MudDebouncedInputBuilder<MudBlazor.MudDebouncedInput<'T>, 'T>()
    type MudNumericField'<'T>() = inherit MudNumericFieldBuilder<MudBlazor.MudNumericField<'T>, 'T>()
    type MudTextField'<'T>() = inherit MudTextFieldBuilder<MudBlazor.MudTextField<'T>, 'T>()
    type MudInput'<'T>() = inherit MudInputBuilder<MudBlazor.MudInput<'T>, 'T>()
    type MudInputString'() = inherit MudInputStringBuilder<MudBlazor.MudInputString>()
    type MudRangeInput'<'T>() = inherit MudRangeInputBuilder<MudBlazor.MudRangeInput<'T>, 'T>()
    type MudSelect'<'T>() = inherit MudSelectBuilder<MudBlazor.MudSelect<'T>, 'T>()
    type MudBooleanInput'<'T>() = inherit MudBooleanInputBuilder<MudBlazor.MudBooleanInput<'T>, 'T>()
    type MudCheckBox'<'T>() = inherit MudCheckBoxBuilder<MudBlazor.MudCheckBox<'T>, 'T>()
    type MudSwitch'<'T>() = inherit MudSwitchBuilder<MudBlazor.MudSwitch<'T>, 'T>()
    type MudPicker'<'T>() = inherit MudPickerBuilder<MudBlazor.MudPicker<'T>, 'T>()
    type MudBaseDatePicker'() = inherit MudBaseDatePickerBuilder<MudBlazor.MudBaseDatePicker>()
    type MudDatePicker'() = inherit MudDatePickerBuilder<MudBlazor.MudDatePicker>()
    type MudDateRangePicker'() = inherit MudDateRangePickerBuilder<MudBlazor.MudDateRangePicker>()
    type MudColorPicker'() = inherit MudColorPickerBuilder<MudBlazor.MudColorPicker>()
    type MudTimePicker'() = inherit MudTimePickerBuilder<MudBlazor.MudTimePicker>()
    type MudRadioGroup'<'T>() = inherit MudRadioGroupBuilder<MudBlazor.MudRadioGroup<'T>, 'T>()
    type MudAlert'() = inherit MudAlertBuilder<MudBlazor.MudAlert>()
    type MudAppBar'() = inherit MudAppBarBuilder<MudBlazor.MudAppBar>()
    type MudAvatar'() = inherit MudAvatarBuilder<MudBlazor.MudAvatar>()
    type MudAvatarGroup'() = inherit MudAvatarGroupBuilder<MudBlazor.MudAvatarGroup>()
    type MudBadge'() = inherit MudBadgeBuilder<MudBlazor.MudBadge>()
    type MudBreadcrumbs'() = inherit MudBreadcrumbsBuilder<MudBlazor.MudBreadcrumbs>()
    type MudBreakpointProvider'() = inherit MudBreakpointProviderBuilder<MudBlazor.MudBreakpointProvider>()
    type MudButtonGroup'() = inherit MudButtonGroupBuilder<MudBlazor.MudButtonGroup>()
    type MudToggleIconButton'() = inherit MudToggleIconButtonBuilder<MudBlazor.MudToggleIconButton>()
    type MudCard'() = inherit MudCardBuilder<MudBlazor.MudCard>()
    type MudCardActions'() = inherit MudCardActionsBuilder<MudBlazor.MudCardActions>()
    type MudCardContent'() = inherit MudCardContentBuilder<MudBlazor.MudCardContent>()
    type MudCardHeader'() = inherit MudCardHeaderBuilder<MudBlazor.MudCardHeader>()
    type MudCardMedia'() = inherit MudCardMediaBuilder<MudBlazor.MudCardMedia>()
    type MudCarouselItem'() = inherit MudCarouselItemBuilder<MudBlazor.MudCarouselItem>()
    type MudChipSet'() = inherit MudChipSetBuilder<MudBlazor.MudChipSet>()
    type MudChip'() = inherit MudChipBuilder<MudBlazor.MudChip>()
    type MudCollapse'() = inherit MudCollapseBuilder<MudBlazor.MudCollapse>()
    type Cell'<'T>() = inherit CellBuilder<MudBlazor.Cell<'T>, 'T>()
    type Column'<'T>() = inherit ColumnBuilder<MudBlazor.Column<'T>, 'T>()
    type FooterCell'<'T>() = inherit FooterCellBuilder<MudBlazor.FooterCell<'T>, 'T>()
    type HeaderCell'<'T>() = inherit HeaderCellBuilder<MudBlazor.HeaderCell<'T>, 'T>()
    type MudDataGrid'<'T>() = inherit MudDataGridBuilder<MudBlazor.MudDataGrid<'T>, 'T>()
    type MudDataGridPager'<'T>() = inherit MudDataGridPagerBuilder<MudBlazor.MudDataGridPager<'T>, 'T>()
    type Row'() = inherit RowBuilder<MudBlazor.Row>()
    type MudDialog'() = inherit MudDialogBuilder<MudBlazor.MudDialog>()
    type MudDialogInstance'() = inherit MudDialogInstanceBuilder<MudBlazor.MudDialogInstance>()
    type MudDrawer'() = inherit MudDrawerBuilder<MudBlazor.MudDrawer>()
    type MudElement'() = inherit MudElementBuilder<MudBlazor.MudElement>()
    type MudExpansionPanel'() = inherit MudExpansionPanelBuilder<MudBlazor.MudExpansionPanel>()
    type MudExpansionPanels'() = inherit MudExpansionPanelsBuilder<MudBlazor.MudExpansionPanels>()
    type MudField'() = inherit MudFieldBuilder<MudBlazor.MudField>()
    type MudFocusTrap'() = inherit MudFocusTrapBuilder<MudBlazor.MudFocusTrap>()
    type MudForm'() = inherit MudFormBuilder<MudBlazor.MudForm>()
    type MudHidden'() = inherit MudHiddenBuilder<MudBlazor.MudHidden>()
    type MudIcon'() = inherit MudIconBuilder<MudBlazor.MudIcon>()
    type MudInputControl'() = inherit MudInputControlBuilder<MudBlazor.MudInputControl>()
    type MudInputLabel'() = inherit MudInputLabelBuilder<MudBlazor.MudInputLabel>()
    type MudLink'() = inherit MudLinkBuilder<MudBlazor.MudLink>()
    type MudList'() = inherit MudListBuilder<MudBlazor.MudList>()
    type MudListItem'() = inherit MudListItemBuilder<MudBlazor.MudListItem>()
    type MudListSubheader'() = inherit MudListSubheaderBuilder<MudBlazor.MudListSubheader>()
    type MudMenu'() = inherit MudMenuBuilder<MudBlazor.MudMenu>()
    type MudMenuItem'() = inherit MudMenuItemBuilder<MudBlazor.MudMenuItem>()
    type MudMessageBox'() = inherit MudMessageBoxBuilder<MudBlazor.MudMessageBox>()
    type MudNavGroup'() = inherit MudNavGroupBuilder<MudBlazor.MudNavGroup>()
    type MudNavMenu'() = inherit MudNavMenuBuilder<MudBlazor.MudNavMenu>()
    type MudOverlay'() = inherit MudOverlayBuilder<MudBlazor.MudOverlay>()
    type MudPageContentNavigation'() = inherit MudPageContentNavigationBuilder<MudBlazor.MudPageContentNavigation>()
    type MudPagination'() = inherit MudPaginationBuilder<MudBlazor.MudPagination>()
    type MudPopover'() = inherit MudPopoverBuilder<MudBlazor.MudPopover>()
    type MudProgressCircular'() = inherit MudProgressCircularBuilder<MudBlazor.MudProgressCircular>()
    type MudProgressLinear'() = inherit MudProgressLinearBuilder<MudBlazor.MudProgressLinear>()
    type MudRadio'<'T>() = inherit MudRadioBuilder<MudBlazor.MudRadio<'T>, 'T>()
    type MudRating'() = inherit MudRatingBuilder<MudBlazor.MudRating>()
    type MudRatingItem'() = inherit MudRatingItemBuilder<MudBlazor.MudRatingItem>()
    type MudRTLProvider'() = inherit MudRTLProviderBuilder<MudBlazor.MudRTLProvider>()
    type MudScrollToTop'() = inherit MudScrollToTopBuilder<MudBlazor.MudScrollToTop>()
    type MudSkeleton'() = inherit MudSkeletonBuilder<MudBlazor.MudSkeleton>()
    type MudSlider'<'T>() = inherit MudSliderBuilder<MudBlazor.MudSlider<'T>, 'T>()
    type MudSnackbarElement'() = inherit MudSnackbarElementBuilder<MudBlazor.MudSnackbarElement>()
    type MudSnackbarProvider'() = inherit MudSnackbarProviderBuilder<MudBlazor.MudSnackbarProvider>()
    type MudSwipeArea'() = inherit MudSwipeAreaBuilder<MudBlazor.MudSwipeArea>()
    type MudSimpleTable'() = inherit MudSimpleTableBuilder<MudBlazor.MudSimpleTable>()
    type MudTableGroupRow'<'T>() = inherit MudTableGroupRowBuilder<MudBlazor.MudTableGroupRow<'T>, 'T>()
    type MudTablePager'() = inherit MudTablePagerBuilder<MudBlazor.MudTablePager>()
    type MudTableSortLabel'<'T>() = inherit MudTableSortLabelBuilder<MudBlazor.MudTableSortLabel<'T>, 'T>()
    type MudTd'() = inherit MudTdBuilder<MudBlazor.MudTd>()
    type MudTFootRow'() = inherit MudTFootRowBuilder<MudBlazor.MudTFootRow>()
    type MudTh'() = inherit MudThBuilder<MudBlazor.MudTh>()
    type MudTHeadRow'() = inherit MudTHeadRowBuilder<MudBlazor.MudTHeadRow>()
    type MudTr'() = inherit MudTrBuilder<MudBlazor.MudTr>()
    type MudTimelineItem'() = inherit MudTimelineItemBuilder<MudBlazor.MudTimelineItem>()
    type MudTooltip'() = inherit MudTooltipBuilder<MudBlazor.MudTooltip>()
    type MudTreeView'<'T>() = inherit MudTreeViewBuilder<MudBlazor.MudTreeView<'T>, 'T>()
    type MudTreeViewItem'<'T>() = inherit MudTreeViewItemBuilder<MudBlazor.MudTreeViewItem<'T>, 'T>()
    type MudText'() = inherit MudTextBuilder<MudBlazor.MudText>()
    type MudContainer'() = inherit MudContainerBuilder<MudBlazor.MudContainer>()
    type MudDivider'() = inherit MudDividerBuilder<MudBlazor.MudDivider>()
    type MudDrawerHeader'() = inherit MudDrawerHeaderBuilder<MudBlazor.MudDrawerHeader>()
    type MudGrid'() = inherit MudGridBuilder<MudBlazor.MudGrid>()
    type MudItem'() = inherit MudItemBuilder<MudBlazor.MudItem>()
    type MudHighlighter'() = inherit MudHighlighterBuilder<MudBlazor.MudHighlighter>()
    type MudMainContent'() = inherit MudMainContentBuilder<MudBlazor.MudMainContent>()
    type MudPaper'() = inherit MudPaperBuilder<MudBlazor.MudPaper>()
    type MudSparkLine'() = inherit MudSparkLineBuilder<MudBlazor.MudSparkLine>()
    type MudTabPanel'() = inherit MudTabPanelBuilder<MudBlazor.MudTabPanel>()
    type MudToolBar'() = inherit MudToolBarBuilder<MudBlazor.MudToolBar>()
    type MudBaseColumn'() = inherit MudBaseColumnBuilder<MudBlazor.MudBaseColumn>()
    type MudColumn'<'T>() = inherit MudColumnBuilder<MudBlazor.MudColumn<'T>, 'T>()
    type MudSortableColumn'<'T, 'ModelType>() = inherit MudSortableColumnBuilder<MudBlazor.MudSortableColumn<'T, 'ModelType>, 'T, 'ModelType>()
    type MudAvatarColumn'<'T>() = inherit MudAvatarColumnBuilder<MudBlazor.MudAvatarColumn<'T>, 'T>()
    type MudTemplateColumn'<'T>() = inherit MudTemplateColumnBuilder<MudBlazor.MudTemplateColumn<'T>, 'T>()
    type BaseMudThemeProvider'() = inherit BaseMudThemeProviderBuilder<MudBlazor.BaseMudThemeProvider>()
    type MudThemeProvider'() = inherit MudThemeProviderBuilder<MudBlazor.MudThemeProvider>()
    type Filter'<'T>() = inherit FilterBuilder<MudBlazor.Filter<'T>, 'T>()
    type MudDialogProvider'() = inherit MudDialogProviderBuilder<MudBlazor.MudDialogProvider>()
    type MudPopoverProvider'() = inherit MudPopoverProviderBuilder<MudBlazor.MudPopoverProvider>()
    type MudVirtualize'<'T>() = inherit MudVirtualizeBuilder<MudBlazor.MudVirtualize<'T>, 'T>()
    type BreadcrumbLink'() = inherit BreadcrumbLinkBuilder<MudBlazor.BreadcrumbLink>()
    type BreadcrumbSeparator'() = inherit BreadcrumbSeparatorBuilder<MudBlazor.BreadcrumbSeparator>()
    type MudPickerContent'() = inherit MudPickerContentBuilder<MudBlazor.MudPickerContent>()
    type MudPickerToolbar'() = inherit MudPickerToolbarBuilder<MudBlazor.MudPickerToolbar>()
    type MudSpacer'() = inherit MudSpacerBuilder<MudBlazor.MudSpacer>()
    type MudTreeViewItemToggleButton'() = inherit MudTreeViewItemToggleButtonBuilder<MudBlazor.MudTreeViewItemToggleButton>()
    type _Imports'() = inherit _ImportsBuilder<MudBlazor._Imports>()
            
namespace MudBlazor.Charts

[<AutoOpen>]
module DslCE =

    open MudBlazor.DslInternals.Charts

    type Bar'() = inherit BarBuilder<MudBlazor.Charts.Bar>()
    type Donut'() = inherit DonutBuilder<MudBlazor.Charts.Donut>()
    type Line'() = inherit LineBuilder<MudBlazor.Charts.Line>()
    type Pie'() = inherit PieBuilder<MudBlazor.Charts.Pie>()
    type Legend'() = inherit LegendBuilder<MudBlazor.Charts.Legend>()
    type Filters'() = inherit FiltersBuilder<MudBlazor.Charts.Filters>()
            
namespace MudBlazor.Internal

[<AutoOpen>]
module DslCE =

    open MudBlazor.DslInternals.Internal

    type MudInputAdornment'() = inherit MudInputAdornmentBuilder<MudBlazor.Internal.MudInputAdornment>()
            