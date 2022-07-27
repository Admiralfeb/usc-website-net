using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using UnitedSystemsCooperative.Web.Client;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Client.Services;
using UnitedSystemsCooperative.Web.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


await AddConfigurations(builder);
AddServices(builder);


await builder.Build().RunAsync();

static async Task AddConfigurations(WebAssemblyHostBuilder builder)
{
    var http = new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)};
    builder.Services.AddScoped(sp => http);
    var configs = builder.Configuration.GetValue("app-data");

    if (configs == null)
    {
        throw new Exception("Failed to get configs. App will not function correctly.");
    }

    foreach (var config in configs)
    {
        await using var configStream = await http.GetStreamAsync($"app-data/{config}.json");
        builder.Configuration.AddJsonStream(configStream);
    }
}

static void AddServices(WebAssemblyHostBuilder builder)
{
    builder.Services.AddHttpClient(Constants.DefaultHttpClientName,
            client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
        .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
    builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
        .CreateClient(Constants.DefaultHttpClientName));

    builder.Services.AddHttpClient(Constants.NoAuthHttpClientName,
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

    builder.Services.AddMsalAuthentication(options =>
    {
        builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
        options.ProviderOptions.DefaultAccessTokenScopes.Add(
            "https://unitedsystemscooperative.onmicrosoft.com/aa9ec6f0-b9d9-43cb-a1a1-8cf39fa159ad/Api.Access");
    });

    builder.Services.AddSingleton<ApiService>();
    builder.Services.AddSingleton<StateService>();
    builder.Services.AddSingleton<IItemService<Ally>, AllyService>();
    builder.Services.AddSingleton<IItemService<ShipBuild>, BuildService>();
    builder.Services.AddSingleton<IItemService<FleetCarrier>, FleetCarrierService>();
    builder.Services.AddSingleton<IItemService<FactionSystem>, SystemService>();
}

public partial class Program
{
}