using System.ComponentModel.DataAnnotations;
using UnitedSystemsCooperative.Web.Shared.Interfaces;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequests;

public class MemberJoinRequest : JoinRequestBase, IJoinRequestReferral
{
    [Required, EnumDataType(typeof(PlayingLengthType))]
    [Range(typeof(PlayingLengthType), nameof(PlayingLengthType.LessThanMonth), nameof(PlayingLengthType.MoreThanYear),
        ErrorMessage = "Please select an option.")]
    public PlayingLengthType PlayingLength { get; set; } = PlayingLengthType.Unknown;

    [Required]
    [Range(typeof(ReferralType), nameof(ReferralType.USI), nameof(ReferralType.Other),
        ErrorMessage = "Please select an option")]
    public ReferralType Referral { get; set; } = ReferralType.Unknown;

    public string? ReferralDescribe { get; set; }
}