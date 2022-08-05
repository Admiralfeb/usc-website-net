namespace UnitedSystemsCooperative.Web.Client.Services;

public abstract class BaseItemService
{
    protected readonly ApiService Api;

    protected BaseItemService(ApiService api) => Api = api;
}