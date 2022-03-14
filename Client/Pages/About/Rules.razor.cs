using UnitedSystemsCooperative.Web.Client.Models;

namespace UnitedSystemsCooperative.Web.Client.Pages.About;

public partial class Rules
{
    private string[]? _discordRules;
    private string[]? _memberRules;

    protected override void OnInitialized()
    {
        var rules = _configuration.GetSection(RulesSettings.SettingsName).Get<RulesSettings>();
        _discordRules = rules.Discord;
        _memberRules = rules.Member;
        base.OnInitialized();
    }
}