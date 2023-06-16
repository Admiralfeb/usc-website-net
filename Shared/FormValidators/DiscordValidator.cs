using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UnitedSystemsCooperative.Web.Shared.FormValidators;

public class DiscordValidator : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        Regex regex = new Regex(@"^.+[0-9]{4}$");

        return regex.IsMatch(value.ToString())
            ? ValidationResult.Success
            : new ValidationResult("This must be in {username}#0000 format", new[] {validationContext.MemberName ?? string.Empty});
    }
}