using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitedSystemsCooperative.Web.Server.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Server.Controllers;

/// <summary>
/// Handles database actions for Allies
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AllyController : ControllerBase
{
    private const string DbCollectionName = "allies";
    private IDatabaseService _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbService"></param>
    public AllyController(IDatabaseService dbService)
    {
        _db = dbService;
    }

    /// <summary>
    /// Adds an ally to the database.
    /// </summary>
    /// <param name="ally">Ally to add</param>
    /// <returns>A newly created Ally</returns>
    /// <remarks>
    /// Sample Request:
    ///
    ///     POST /Ally
    ///     {
    ///         "name": "Ally's Name"
    ///     }
    /// </remarks>
    /// <exception cref="NotImplementedException">This Api is not yet implemented</exception>
    /// <response code="501">This is endpoint not yet implemented</response>
    // <response code="201">Returns the newly created ally</response>
    // <response code="400">If the item is null or the ally already exists</response>
    [HttpPost]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    public async Task<IActionResult> CreateAlly([FromBody] Ally ally)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the allies from the database.
    /// </summary>
    /// <returns>List of allies.</returns>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllies()
    {
        var results = await _db.GetItemsAsync<Ally>(DbCollectionName, "name", SortOrder.Ascending);

        return Ok(results);
    }

    [HttpPost("update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAlly(string id, [FromBody] Ally ally)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAlly(string id)
    {
        throw new NotImplementedException();
    }
}