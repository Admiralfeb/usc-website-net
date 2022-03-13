using Microsoft.AspNetCore.Components;

namespace UnitedSystemsCooperative.Web.Client.Pages;

public partial class Index
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    protected override void OnInitialized()
    {
        _navigationManager.NavigateTo("/home");
    }
}