using UnitedSystemsCooperative.Web.Client.Massacre;

namespace UnitedSystemsCooperative.Web.Client.LazyServices;

public class MassacreServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MassacreServiceFactory(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    public IMassacreService Create()
    {
        return new MassacreService();
    }
}