using System.ComponentModel.DataAnnotations;
using UnitedSystemsCooperative.Web.Shared.Interfaces;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequests;

public class GuestJoinRequest : JoinRequestBase, IJoinRequestReferral
{
    [Required]
    [Range(typeof(ReferralType), nameof(ReferralType.USI), nameof(ReferralType.Other),
        ErrorMessage = "Please select an option")]
    public ReferralType Referral { get; set; } = ReferralType.Unknown;

    public string? ReferralDescribe { get; set; }
}