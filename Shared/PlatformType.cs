using System.ComponentModel;

namespace UnitedSystemsCooperative.Web.Shared;

public enum PlatformType
{
    [Description("PC")]
    PC,
    [Description("Xbox")]
    Xbox,
    [Description("PlayStation")]
    PS,
    Unknown
}