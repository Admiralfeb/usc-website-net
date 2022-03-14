using Microsoft.AspNetCore.Components;
using UnitedSystemsCooperative.Web.Client.Models;

namespace UnitedSystemsCooperative.Web.Client.Layouts.Components;

public partial class Navbar
{
    [Parameter]
    public Type? PageType { get; set; }

    private NavItem[]? NavItems { get; set; }

    protected override void OnInitialized()
    {
        NavItems = _configuration.GetSection("NavItems").Get<NavItem[]>();

        base.OnInitialized();
    }
}