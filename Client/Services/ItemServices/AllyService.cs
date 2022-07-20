using System.Net.Http.Json;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class AllyService : BaseItemService, IItemService<Ally>
{
    private const string ApiPath = "/api/ally";
    
    private IEnumerable<Ally>? _allies;

    private IEnumerable<Ally> Allies
    {
        get => _allies ?? new List<Ally>();
        set => _allies = value;
    }

    public AllyService(ApiService api, StateService state) : base(api, state)
    {
    }

    public async Task AddItem(Ally item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ally> GetFromStore()
    {
        Console.WriteLine("Get Allies from store");
        return Allies;
    }

    public async Task<IEnumerable<Ally>> GetFromServer()
    {
        var client = Api.GetHttpClient(false);
        var allies = await client.GetFromJsonAsync<Ally[]>(ApiPath);
        Allies = allies ?? throw new Exception("Allies not found");
        return allies;
    }

    public async Task UpdateItem(Ally item)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteItem(string itemId)
    {
        throw new NotImplementedException();
    }
}