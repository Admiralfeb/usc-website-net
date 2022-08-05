using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Client.Services;
using UnitedSystemsCooperative.Web.Shared;
using UnitedSystemsCooperative.Web.Client.Models.Options;

namespace UnitedSystemsCooperative.Web.Client;

public static class ServiceExtensions
{
    public static void AddConfigs(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LinkOptions>(configuration.GetSection(LinkOptions.SettingsName));
        services.Configure<AboutOptions>(configuration.GetSection(AboutOptions.SettingsName));
    }

    public static void AddHttpClients(this IServiceCollection services, string baseAddress)
    {
        services.AddHttpClient(Constants.NoAuthHttpClientName,
            client => client.BaseAddress = new Uri(baseAddress));
        
        services.AddHttpClient(Constants.DefaultHttpClientName,
                client => client.BaseAddress = new Uri(baseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
        
        // services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>());
    }

    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMsalAuthentication(options =>
        {
            configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
            options.ProviderOptions.DefaultAccessTokenScopes.Add(
                "https://unitedsystemscooperative.onmicrosoft.com/aa9ec6f0-b9d9-43cb-a1a1-8cf39fa159ad/Api.Access");
        });
        
        services.AddSingleton<UrlService>();

        services.AddScoped<ApiService>();
        services.AddScoped<IItemService<Ally>, AllyService>();
        services.AddScoped<IItemService<ShipBuild>, BuildService>();
        services.AddScoped<IItemService<FleetCarrier>, FleetCarrierService>();
        services.AddScoped<IItemService<FactionSystem>, SystemService>();
    }
}