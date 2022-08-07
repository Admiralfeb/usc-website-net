using UnitedSystemsCooperative.Web.Client.Shared.Interfaces;

namespace UnitedSystemsCooperative.Web.Client.About;

public class AboutLayoutButtonInfo : ILink
{
    public string Title { get; set; } = string.Empty;
    public bool Local { get; set; }
    public string Link { get; set; } = string.Empty;
}