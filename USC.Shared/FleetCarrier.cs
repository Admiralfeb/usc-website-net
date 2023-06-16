using System.ComponentModel.DataAnnotations;
using UnitedSystemsCooperative.Web.Shared.FormValidators;

namespace UnitedSystemsCooperative.Web.Shared;

public class FleetCarrier : DbItem
{
    [Required] [FleetCarrierValidator] public override string Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Owner { get; set; }

    public string OwnerId { get; set; }
    public string Purpose { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}