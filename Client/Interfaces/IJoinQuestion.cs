using Microsoft.AspNetCore.Components;
using UnitedSystemsCooperative.Web.Shared.JoinRequests;

namespace UnitedSystemsCooperative.Web.Client.Interfaces;

public interface IJoinQuestion<TItem> where TItem : JoinRequestBase
{
    [Parameter] TItem? model { get; set; }
}