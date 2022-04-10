using System.ComponentModel.DataAnnotations;

namespace UnitedSystemsCooperative.Web.Shared;

public class FactionSystem
{
    public string Id { get; set; }
    [Required] public string Name { get; set; }
    public bool IsControlled { get; set; } = false;
}