using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitedSystemsCooperative.Web.Server.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Server.Controllers;

/// <summary>
/// Handles database actions for Ship Builds
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BuildController : ControllerBase
{
    private const string DbCollectionName = "builds";
    private IDatabaseService _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbService"></param>
    public BuildController(IDatabaseService dbService)
    {
        _db = dbService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    public async Task<IActionResult> CreateBuild([FromBody] ShipBuild build)
    {
        throw new NotImplementedException();
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBuilds()
    {
        var results = await _db.GetItemsAsync<ShipBuild>(DbCollectionName, null, null);

        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBuildById(string id)
    {
        throw new NotImplementedException();
    }

    [HttpPost("update/{id}")]
    public async Task<IActionResult> UpdateBuild(string id, [FromBody] ShipBuild build)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteBuild(string id)
    {
        throw new NotImplementedException();
    }
}