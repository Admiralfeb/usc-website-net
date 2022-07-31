using UnitedSystemsCooperative.Web.Client.Interfaces;

namespace UnitedSystemsCooperative.Web.Client.Models.Options;

public class LinkOptions
{
    public const string SettingsName = "app-data:links";

    public NavItem[] NavItems { get; set; }
    public UscLink[] UscLinks { get; set; }
}

public class NavItem
{
    public string To { get; set; }
    public string Text { get; set; }
}

public class UscLink : ILink
{
    public string Title { get; set; } = string.Empty;
    public string Replace { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}