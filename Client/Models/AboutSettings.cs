using UnitedSystemsCooperative.Web.Client.Modules.About;

namespace UnitedSystemsCooperative.Web.Client.Models;

public class AboutSettings
{
    public const string SettingsName = "app-data:about";

    public RulesSettings Rules { get; set; }
    public AboutLayoutButtonInfo[] AboutItems { get; set; }
}

public class RulesSettings
{
    public const string SettingsName = "Rules";

    public string[] Discord { get; set; }
    public string[] Member { get; set; }
}