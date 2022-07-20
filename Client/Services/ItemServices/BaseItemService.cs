namespace UnitedSystemsCooperative.Web.Client.Services;

public abstract class BaseItemService
{
    protected readonly ApiService Api;
    protected readonly StateService State;

    protected BaseItemService(ApiService api, StateService state)
    {
        Api = api;
        State = state;
    }
}