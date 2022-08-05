using System.Net.Http.Json;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class FleetCarrierService : BaseItemService, IItemService<FleetCarrier>
{
    private const string ApiPath = "/api/fleetcarrier";
    
    private IEnumerable<FleetCarrier>? _fleetCarriers;
    public IEnumerable<FleetCarrier> FleetCarriers
    {
        get => _fleetCarriers ?? new List<FleetCarrier>();
        set => _fleetCarriers = value;
    }

    public FleetCarrierService(ApiService api) : base(api)
    {
    }

    public async Task AddItem(FleetCarrier item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FleetCarrier> GetFromStore()
    {
        Console.WriteLine("Get Fleet Carriers from store");
        return FleetCarriers;
    }

    public async Task<IEnumerable<FleetCarrier>> GetFromServer()
    {
        var client = Api.GetHttpClient(false);
        var carriers = await client.GetFromJsonAsync<FleetCarrier[]>(ApiPath);
        FleetCarriers = carriers ?? throw new Exception("Carriers not found");
        return carriers;
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