using System.ComponentModel.DataAnnotations;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequest;

public class MemberJoinRequest : JoinRequestBase
{
    [Required]
    public PlayingLength? PlayingLength { get; set; }
    [Required]
    public ReferralType? Referral { get; set; }
    public string? ReferralDescribe { get; set; }
    
    
}