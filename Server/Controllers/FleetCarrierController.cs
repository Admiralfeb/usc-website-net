using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitedSystemsCooperative.Web.Server.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Server.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class FleetCarrierController : ControllerBase
{
    private const string DBCollectionName = "fleetcarriers";
    private IDatabaseService _db;

    public FleetCarrierController(IDatabaseService dbService)
    {
        _db = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFleetCarrier([FromBody] FleetCarrier carrier)
    {
        throw new NotImplementedException();
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetFleetCarriers()
    {
        var results = await _db.GetItemsAsync<FleetCarrier>(DBCollectionName, "name", SortOrder.Ascending);
        return Ok(results);
    }

    [HttpPost("update/{id}")]
    public async Task<IActionResult> UpdateFleetCarrier(string id, [FromBody] FleetCarrier carrier)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFleetCarrier(string id)
    {
        throw new NotImplementedException();
    }
}