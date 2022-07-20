using System.ComponentModel.DataAnnotations;

namespace UnitedSystemsCooperative.Web.Shared;

public class FactionSystem : DbItem
{
    [Required] public string Name { get; set; }
    public bool IsControlled { get; set; } = false;
}