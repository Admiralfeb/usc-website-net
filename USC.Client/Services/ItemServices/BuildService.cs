using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services.ItemServices;

public class BuildService : IItemService<ShipBuild>
{
    private readonly HttpClient _http;
    
    public BuildService(HttpClient http)
    {
        _http = http;
    }

    public async Task AddItem(ShipBuild item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ShipBuild> GetFromStore()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ShipBuild>> GetFromServer()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateItem(ShipBuild item)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteItem(string itemId)
    {
        throw new NotImplementedException();
    }
}