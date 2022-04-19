using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitedSystemsCooperative.Web.Server.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AllyController : ControllerBase
{
    private IDatabaseService _db;
    public AllyController(IDatabaseService dbService)
    {
        _db = dbService;
    }
    
    [HttpPost]
    public async Task<bool> CreateAlly([FromBody] Ally ally)
    {
        throw new NotImplementedException();
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<Ally[]> GetAllies()
    {
        var results = await _db.GetItemsAsync<Ally>("ally", "name", SortOrder.Ascending);
        return results;
    }

    [HttpPost("update/{id}")]
    public async Task<bool> UpdateAlly(string id, [FromBody] Ally ally)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}")]
    public async Task<bool> DeleteAlly(string id)
    {
        throw new NotImplementedException();
    }
}