using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using UnitedSystemsCooperative.Web.Shared.JoinRequests;

namespace UnitedSystemsCooperative.Web.Client.Pages.Join;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class JoinFormAmbassador
{
    private EditContext? _editContext;
    private AmbassadorJoinRequest model = new();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(model);
    }

    private void OnValidSubmit(EditContext context)
    {
        Console.WriteLine(JsonSerializer.Serialize(context.Model));
        StateHasChanged();
    }
}