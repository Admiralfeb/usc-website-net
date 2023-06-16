using System.ComponentModel;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequests;

public enum RegionType
{
    Unknown,
    [Description("North/Central America")] N_CAmerica,
    [Description("South America")] SAmerica,
    [Description("Europe/Africa")] Europe_Africa,
    [Description("Asia")] Asia,
    [Description("Asia/Pacific")] Asia_Pacific,
}