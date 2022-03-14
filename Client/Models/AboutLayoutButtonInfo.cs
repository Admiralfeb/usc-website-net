namespace UnitedSystemsCooperative.Web.Client.Models;

public class AboutLayoutButtonInfo
{
    public const string SettingName = "AboutItems";
    public string Title { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public bool Local { get; set; }
    public string Link { get; set; } = string.Empty;
}