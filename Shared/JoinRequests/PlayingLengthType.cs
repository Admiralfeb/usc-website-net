using System.ComponentModel;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequests;

public enum PlayingLengthType
{
    Unknown,
    [Description("Less than a Month")] LessThanMonth,
    [Description("More than a Month")] MoreThanMonth,
    [Description("More than 6 Months")] MoreThan6Months,
    [Description("More than a Year")] MoreThanYear,
}