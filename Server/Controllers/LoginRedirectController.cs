using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class LoginRedirectController : ControllerBase
{
    private readonly IConfiguration _iconfiguration;
    private readonly UserManager<IdentityUser> _userManager;

    public LoginRedirectController(UserManager<IdentityUser> userManager, IConfiguration iconfiguration)
    {
        _userManager = userManager;
        _iconfiguration = iconfiguration;
    }

    [HttpGet]
    public async Task<IActionResult> Login(string token, string email, string returnUrl)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var isValid = await _userManager.VerifyUserTokenAsync(user, "Default", "passwordless-auth", token);
        if (isValid)
        {
            await _userManager.UpdateSecurityStampAsync(user);
            await HttpContext.SignInAsync(
                IdentityConstants.ApplicationScheme,
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        new List<Claim>
                        {
                            new Claim("sub", user.Id)
                        },
                        IdentityConstants.ApplicationScheme
                    )
                )
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var jwToken = tokenHandler.CreateToken(tokenDescriptor);

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return new OkObjectResult(new Tokens {Token = tokenHandler.WriteToken(jwToken)});
            }

            return new RedirectResult($"~{returnUrl}");
        }

        return Unauthorized();
    }
}