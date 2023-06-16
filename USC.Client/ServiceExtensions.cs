using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Client.Services;
using UnitedSystemsCooperative.Web.Shared;
using UnitedSystemsCooperative.Web.Client.Models.Options;
using UnitedSystemsCooperative.Web.Client.Services.ItemServices;

namespace UnitedSystemsCooperative.Web.Client;

public static class ServiceExtensions
{
    public static void AddConfigs(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LinkOptions>(configuration.GetSection(LinkOptions.SettingsName));
        services.Configure<AboutOptions>(configuration.GetSection(AboutOptions.SettingsName));
        services.Configure<InformationOptions>(configuration.GetSection(InformationOptions.SettingsName));
    }

    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<UrlService>();
        
        services.AddScoped<IItemService<Ally>, AllyService>();
        services.AddScoped<IItemService<ShipBuild>, BuildService>();
        services.AddScoped<IItemService<FleetCarrier>, FleetCarrierService>();
        services.AddScoped<IItemService<FactionSystem>, SystemService>();
    }
}