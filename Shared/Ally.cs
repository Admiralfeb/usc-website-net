using System.ComponentModel.DataAnnotations;

namespace UnitedSystemsCooperative.Web.Shared;

public class Ally : DbItem
{
    [Required] public string Name { get; set; }
}