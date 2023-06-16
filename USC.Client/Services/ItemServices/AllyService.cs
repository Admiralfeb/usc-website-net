using System.Net.Http.Json;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services.ItemServices;

public class AllyService : IItemService<Ally>
{
    private const string ApiPath = "/api/ally";

    private readonly HttpClient _http;
    private readonly ILogger<AllyService> _logger;

    private IEnumerable<Ally> _allies = Enumerable.Empty<Ally>();

    public AllyService(HttpClient http, ILogger<AllyService> logger)
    {
        _http = http;
        _logger = logger;
    }

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
        var allies = await _http.GetFromJsonAsync<Ally[]>(ApiPath);

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