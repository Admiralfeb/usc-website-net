using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class SystemService : BaseItemService, IItemService<FactionSystem>
{
    private const string ApiPath = "/api/system";

    public SystemService(ApiService api, StateService state) : base(api, state)
    {
    }

    public async Task AddItem(FactionSystem item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FactionSystem> GetFromStore()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FactionSystem>> GetFromServer()
    {
        throw new NotImplementedException();
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