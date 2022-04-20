using System.Net.Http.Json;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class AllyService : BaseItemService
{
    private const string ApiPath = "/api/ally";

    public AllyService(ApiService api, StateService state) : base(api, state)
    {
    }

    public override IEnumerable<Ally> GetFromStore()
    {
        return State.Allies;
    }

    public override async Task<IEnumerable<Ally>> GetFromServer()
    {
        var client = Api.GetHttpClient(false);
        var allies = await client.GetFromJsonAsync<Ally[]>(ApiPath);
        if (allies == null)
            throw new Exception("Allies not found");
        return allies;
    }
}