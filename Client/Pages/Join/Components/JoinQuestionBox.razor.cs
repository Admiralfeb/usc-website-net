using Microsoft.AspNetCore.Components;

namespace UnitedSystemsCooperative.Web.Client.Pages.Join.Components;

public partial class JoinQuestionBox
{
    [Parameter]
    public string Question { get; set; } = string.Empty;

    [Parameter]
    public string ErrorMessage { get; set; } = string.Empty;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}