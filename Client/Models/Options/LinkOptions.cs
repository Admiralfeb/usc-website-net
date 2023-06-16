using UnitedSystemsCooperative.Web.Client.Interfaces;

namespace UnitedSystemsCooperative.Web.Client.Models.Options;

public class LinkOptions
{
    public const string SettingsName = "app-data:links";

    public NavItem[] NavItems { get; set; } = Array.Empty<NavItem>();
    public UscLink[] UscLinks { get; set; } = Array.Empty<UscLink>();
}

public class NavItem
{
    public string To { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}

public class UscLink : ILink
{
    public string Title { get; set; } = string.Empty;
    public string Replace { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}