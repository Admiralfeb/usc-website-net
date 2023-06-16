using UnitedSystemsCooperative.Web.Client.Interfaces;

namespace UnitedSystemsCooperative.Web.Client.Modules.About;

public class AboutLayoutButtonInfo : ILink
{
    public string Title { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public bool Local { get; set; }
    public string Link { get; set; } = string.Empty;
}