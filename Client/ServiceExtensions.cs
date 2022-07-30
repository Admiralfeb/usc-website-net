using System.Collections.Immutable;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Client.Models;
using UnitedSystemsCooperative.Web.Client.Services;
using UnitedSystemsCooperative.Web.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace UnitedSystemsCooperative.Web.Client;

public static class ServiceExtensions
{
    public static IServiceCollection AddConfigs(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LinkOptions>(configuration.GetSection(LinkOptions.SettingsName));
        services.Configure<AboutSettings>(configuration.GetSection(AboutSettings.SettingsName));


        return services;
    }

    public static IServiceCollection AddHttpClients(this IServiceCollection services, string baseAddress)
    {
        services.AddHttpClient(Constants.DefaultHttpClientName,
                client => client.BaseAddress = new Uri(baseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
        services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>());

        services.AddHttpClient(Constants.NoAuthHttpClientName,
            client => client.BaseAddress = new Uri(baseAddress));

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMsalAuthentication(options =>
        {
            configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
            options.ProviderOptions.DefaultAccessTokenScopes.Add(
                "https://unitedsystemscooperative.onmicrosoft.com/aa9ec6f0-b9d9-43cb-a1a1-8cf39fa159ad/Api.Access");
        });

        services.AddSingleton<ApiService>();
        services.AddSingleton<StateService>();
        services.AddSingleton<IItemService<Ally>, AllyService>();
        services.AddSingleton<IItemService<ShipBuild>, BuildService>();
        services.AddSingleton<IItemService<FleetCarrier>, FleetCarrierService>();
        services.AddSingleton<IItemService<FactionSystem>, SystemService>();

        return services;
    }
}