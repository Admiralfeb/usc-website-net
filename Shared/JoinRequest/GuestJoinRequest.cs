using System.ComponentModel.DataAnnotations;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequest;

public class GuestJoinRequest : JoinRequestBase
{
    [Required]
    public ReferralType? Referral { get; set; }
    public string? ReferralDescribe { get; set; }
}