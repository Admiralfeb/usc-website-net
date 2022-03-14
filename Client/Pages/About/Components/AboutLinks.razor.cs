using UnitedSystemsCooperative.Web.Client.Models;

namespace UnitedSystemsCooperative.Web.Client.Pages.About.Components;

public partial class AboutLinks
{
    private AboutLayoutButtonInfo[]? _buttons;

    protected override void OnInitialized()
    {
        _buttons = _configuration.GetSection(AboutLayoutButtonInfo.SettingName).Get<AboutLayoutButtonInfo[]>();
        var uscLinks = _configuration.GetSection(UscLink.SettingName).Get<UscLink[]>();
        _buttons = _buttons.Select(x =>
        {
            if (!x.Link.Contains('{')) return x;
            var replacement = uscLinks.First(y => string.Equals(y.Replace, x.Link, StringComparison.CurrentCultureIgnoreCase));
            x.Link = replacement.Link;
            return x;
        }).ToArray();
    }
}