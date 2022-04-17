using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AllyController : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<bool> CreateAlly([FromBody] Ally ally)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<List<Ally[]>> GetAllies()
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost("update/{id}")]
    public async Task<bool> UpdateAlly(string id, [FromBody] Ally ally)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpDelete("delete/{id}")]
    public async Task<bool> DeleteAlly(string id)
    {
        throw new NotImplementedException();
    }
}