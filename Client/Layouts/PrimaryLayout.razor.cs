using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace UnitedSystemsCooperative.Web.Client.Layouts;

public partial class PrimaryLayout
{
    public Type PageType { get; set; }
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    MudTheme _uscTheme = UscTheme.Theme;

    protected override void OnParametersSet()
    {
        PageType = (Body.Target as RouteView)?.RouteData.PageType;
        base.OnParametersSet();
    }
}