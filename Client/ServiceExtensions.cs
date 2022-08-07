using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using UnitedSystemsCooperative.Web.Client.About;
using UnitedSystemsCooperative.Web.Client.Massacre;
using UnitedSystemsCooperative.Web.Shared;
using UnitedSystemsCooperative.Web.Client.Models.Options;
using UnitedSystemsCooperative.Web.Client.Shared;
using UnitedSystemsCooperative.Web.Client.Shared.Interfaces;
using UnitedSystemsCooperative.Web.Client.Shared.Models;
using UnitedSystemsCooperative.Web.Client.Shared.Services;

namespace UnitedSystemsCooperative.Web.Client;

public static class ServiceExtensions
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services, string baseAddress)
    {
        services.AddHttpClient(Constants.NoAuthHttpClientName,
            client => client.BaseAddress = new Uri(baseAddress));

        services.AddHttpClient(Constants.DefaultHttpClientName,
                client => client.BaseAddress = new Uri(baseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        return services;
    }

    public static async Task AddConfigs(
        this IServiceCollection services,
        WebAssemblyHostConfiguration configuration)
    {
        services.Configure<LinkOptions>(configuration.GetSection(LinkOptions.SettingsName));

        var http = services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>()
            .CreateClient(Constants.NoAuthHttpClientName);

        await using var aboutStream = await http.GetStreamAsync("_content/Client.About/data.json");
        configuration.AddJsonStream(aboutStream);
        services.Configure<AboutOptions>(configuration.GetSection(AboutOptions.SettingsName));

        // await using var informationStream = await http.GetStreamAsync("_content/Client.Information/data.json");
        // services.Configure<InformationOptions>(configuration.GetSection(InformationOptions.SettingsName));
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
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

        // External Services
        services.AddScoped<IMassacreService, MassacreService>();

        return services;
    }
}