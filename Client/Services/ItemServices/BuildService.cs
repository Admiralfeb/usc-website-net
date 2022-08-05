using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class BuildService : BaseItemService, IItemService<ShipBuild>
{
    public BuildService(ApiService api) : base(api)
    {
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