using System.Net.Http.Json;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services.ItemServices;

public class SystemService : IItemService<FactionSystem>
{
    private const string ApiPath = "/api/system";
    private readonly HttpClient _http;

    private IEnumerable<FactionSystem>? _factionSystems;

    private IEnumerable<FactionSystem> FactionSystems
    {
        get => _factionSystems ?? new List<FactionSystem>();
        set => _factionSystems = value;
    }

    public SystemService(HttpClient http)
    {
        _http = http;
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
        var systems = await _http.GetFromJsonAsync<FactionSystem[]>(ApiPath);
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