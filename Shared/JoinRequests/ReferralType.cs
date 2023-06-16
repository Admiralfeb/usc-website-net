using System.ComponentModel;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequests;

public enum ReferralType
{
    Unknown,

    [Description("Previous Squadron (USI)")]
    USI,
    [Description("Player Referral")] Player,
    [Description("Discord")] Discord,
    [Description("Forums")] Forums,
    [Description("Facebook")] FB,
    [Description("Website")] Website,
    [Description("In Game")] InGame,
    [Description("Inara")] Inara,
    [Description("Reddit")] Reddit,

    [Description("Other - please explain")]
    Other,
}