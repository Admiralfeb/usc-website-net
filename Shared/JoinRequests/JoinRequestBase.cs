using System.ComponentModel.DataAnnotations;
using UnitedSystemsCooperative.Web.Shared.FormValidators;

namespace UnitedSystemsCooperative.Web.Shared.JoinRequests;

public abstract class JoinRequestBase
{
    public string? Id { get; set; }
    public DateTime? TimeStamp { get; set; }
    [Required] public string? CmdrName { get; set; }

    [Required] [DiscordValidator] public string? DiscordName { get; set; }

    [Required, EnumDataType(typeof(PlatformType))]
    [Range(typeof(PlatformType), nameof(PlatformType.PC), nameof(PlatformType.PS),
        ErrorMessage = "Please select an option.")]
    public PlatformType Platform { get; set; } = PlatformType.Unknown;

    [Required, EnumDataType(typeof(RegionType))]
    [Range(typeof(RegionType), nameof(RegionType.N_CAmerica), nameof(RegionType.Asia_Pacific),
        ErrorMessage = "Please select an option.")]
    public RegionType Region { get; set; } = RegionType.Unknown;

    [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept our rules to continue.")]
    public bool AcceptsRules { get; set; }
}