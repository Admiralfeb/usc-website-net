namespace UnitedSystemsCooperative.Web.Client.Shared.Services;

public abstract class BaseItemService
{
    protected readonly ApiService Api;

    protected BaseItemService(ApiService api) => Api = api;
}