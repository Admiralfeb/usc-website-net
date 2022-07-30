namespace UnitedSystemsCooperative.Web.Client.Models;

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