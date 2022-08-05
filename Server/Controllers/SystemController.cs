using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitedSystemsCooperative.Web.Server.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Server.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SystemController : ControllerBase
{
    private const string DbCollectionName = "systems";
    private IDatabaseService _db;

    public SystemController(IDatabaseService dbService)
    {
        _db = dbService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateSystem([FromBody] FactionSystem system)
    {
        throw new NotImplementedException();
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSystems()
    {
        var results = await _db.GetItemsAsync<Ally>(DbCollectionName, "name", SortOrder.Ascending);

        return Ok(results);
    }

    [HttpPost("update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSystem(string id, [FromBody] FactionSystem system)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSystem(string id)
    {
        throw new NotImplementedException();
    }
}