using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class FleetCarrierService : BaseItemService, IItemService<FleetCarrier>
{
    private const string ApiPath = "/api/fleetcarrier";

    public FleetCarrierService(ApiService api, StateService state) : base(api, state)
    {
    }

    public async Task AddItem(FleetCarrier item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FleetCarrier> GetFromStore()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FleetCarrier>> GetFromServer()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateItem(FleetCarrier item)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteItem(string itemId)
    {
        throw new NotImplementedException();
    }
}