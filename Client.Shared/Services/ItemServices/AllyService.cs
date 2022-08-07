using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using UnitedSystemsCooperative.Web.Client.Shared.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Shared.Services;

public class AllyService : BaseItemService, IItemService<Ally>
{
    private const string ApiPath = "/api/ally";

    private readonly ILogger<AllyService> _logger;

    private IEnumerable<Ally> _allies = Enumerable.Empty<Ally>();

    public AllyService(ApiService api, ILogger<AllyService> logger) : base(api) => _logger = logger;

    public async Task AddItem(Ally item)
    {
        _logger.LogDebug("Add Ally: {@Item}", item);
        throw new NotImplementedException();
    }

    public IEnumerable<Ally> GetFromStore()
    {
        _logger.LogDebug("Get Allies from store");
        return _allies;
    }

    public async Task<IEnumerable<Ally>> GetFromServer()
    {
        _logger.LogDebug("Get Allies from server");
        var client = Api.GetHttpClient(false);
        var allies = await client.GetFromJsonAsync<Ally[]>(ApiPath);

        if (allies == null)
        {
            _logger.LogError("Allies not found");
            throw new Exception("Allies not found");
        }

        _allies = allies;
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