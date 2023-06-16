using MudBlazor;
using MudBlazor.Utilities;

namespace UnitedSystemsCooperative.Web.Client;

public static class UscTheme
{
    public static MudTheme Theme { get; } = new()
    {
        PaletteDark = new Palette()
        {
            Primary = new MudColor("#f07b05"),
            Secondary = new MudColor("#00b3f7"),
            TextPrimary = new MudColor("#f2f2f2"),
            TextSecondary = new MudColor("rgba(255, 255, 255, 0.7)"),
            ActionDefault = new MudColor("rgba(255, 255, 255, 0.7)"),
            Dark = new MudColor("#272727"),
            Surface = new MudColor("#272727")
        },
        Typography = new Typography()
        {
            Default = new Default()
            {
                FontFamily = new[] {"Roboto", "Helvetica", "Arial", "sans-serif"},
            }
        },
        
    };
}