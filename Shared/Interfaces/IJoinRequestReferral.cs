using System.ComponentModel.DataAnnotations;
using UnitedSystemsCooperative.Web.Shared.JoinRequests;

namespace UnitedSystemsCooperative.Web.Shared.Interfaces;

public interface IJoinRequestReferral
{
    [Required]
    [Range(typeof(ReferralType), nameof(ReferralType.USI), nameof(ReferralType.Other),
        ErrorMessage = "Please select an option")]
    public ReferralType Referral { get; set; }

    public string? ReferralDescribe { get; set; }
}