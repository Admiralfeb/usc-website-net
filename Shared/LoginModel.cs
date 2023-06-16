using System.ComponentModel.DataAnnotations;

namespace UnitedSystemsCooperative.Web.Shared;

public class LoginModel
{
    public string? UserName { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }
}