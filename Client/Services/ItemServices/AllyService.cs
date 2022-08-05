using System.Net.Http.Json;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class AllyService : BaseItemService, IItemService<Ally>
{
    private const string ApiPath = "/api/ally";

    private IEnumerable<Ally> _allies = Enumerable.Empty<Ally>();

    private readonly ILogger<AllyService> _logger;

    public AllyService(ApiService api, ILogger<AllyService> logger): base(api) => _logger = logger;

    public async Task AddItem(Ally item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ally> GetFromStore()
    {
        _logger.LogInformation("Get Allies from store");
        return _allies;
    }

    public async Task<IEnumerable<Ally>> GetFromServer()
    {
        var client = Api.GetHttpClient(false);
        var allies = await client.GetFromJsonAsync<Ally[]>(ApiPath);
        _allies = allies ?? throw new Exception("Allies not found");
        return _allies;
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