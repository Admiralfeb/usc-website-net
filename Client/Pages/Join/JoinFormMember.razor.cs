using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using UnitedSystemsCooperative.Web.Shared.JoinRequests;

namespace UnitedSystemsCooperative.Web.Client.Pages.Join;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class JoinFormMember
{
    private EditContext? _editContext;
    private string _referralQuestion = string.Empty;
    private MemberJoinRequest model = new();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(model);
        _editContext.OnFieldChanged += OnFieldChange;
    }

    private void OnFieldChange(object? sender, FieldChangedEventArgs e)
    {
        if (e.FieldIdentifier.FieldName != nameof(model.Referral)) return;
        _referralQuestion = model.Referral switch
        {
            ReferralType.Player => "Which player referred you?",
            ReferralType.Other => "Please explain",
            _ => string.Empty
        };
    }

    private void OnValidSubmit(EditContext context)
    {
        Console.WriteLine(JsonSerializer.Serialize(context.Model));
        StateHasChanged();
    }
}