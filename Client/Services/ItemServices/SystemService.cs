using System.Net.Http.Json;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class SystemService : BaseItemService, IItemService<FactionSystem>
{
    private const string ApiPath = "/api/system";

    private IEnumerable<FactionSystem>? _factionSystems;

    private IEnumerable<FactionSystem> FactionSystems
    {
        get => _factionSystems ?? new List<FactionSystem>();
        set => _factionSystems = value;
    }

    public SystemService(ApiService api) : base(api)
    {
    }

    public async Task AddItem(FactionSystem item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FactionSystem> GetFromStore()
    {
        Console.WriteLine("Get Faction Systems from store");
        return FactionSystems;
    }

    public async Task<IEnumerable<FactionSystem>> GetFromServer()
    {
        var client = Api.GetHttpClient(false);
        var systems = await client.GetFromJsonAsync<FactionSystem[]>(ApiPath);
        FactionSystems = systems ?? throw new Exception("Faction systems not found");
        return FactionSystems;
    }

    public async Task UpdateItem(FactionSystem item)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteItem(string itemId)
    {
        throw new NotImplementedException();
    }
}