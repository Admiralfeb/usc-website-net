using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UnitedSystemsCooperative.Web.Server.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly IDatabaseService _db;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(IDatabaseService dbService, UserManager<IdentityUser> userManager)
    {
        _db = dbService;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        // TODO: Check USC database here before checking UserManager...


        var user = await _userManager.FindByEmailAsync(model.Email);
        var returnUrl = HttpContext?.Request.Query.FirstOrDefault(r => r.Key == "returnUrl");

        if (user is null)
        {
            return Unauthorized();
        }

        var token = await _userManager.GenerateUserTokenAsync(user, "Default", "passwordless-auth");
        var url = Url.ActionLink(action: "", controller: "LoginRedirect", values: new
        {
            Token = token,
            Email = model.Email,
            returnUrl = returnUrl?.Value
        }, protocol: Request.Scheme);
        // TODO: Send email with token.
        return Ok();
    }
}