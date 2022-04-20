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

AddHttpClients(builder.Services, builder.HostEnvironment.BaseAddress);

AddServices(builder.Services, builder.Configuration);

await builder.Build().RunAsync();

static void AddHttpClients(IServiceCollection services, string baseAddress)
{
    services.AddHttpClient(Constants.DefaultHttpClientName,
            client => client.BaseAddress = new Uri(baseAddress))
        .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
    services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
        .CreateClient(Constants.DefaultHttpClientName));

    services.AddHttpClient(Constants.NoAuthHttpClientName,
        client => client.BaseAddress = new Uri(baseAddress));
}

static void AddServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddSingleton<ApiService>();
    services.AddSingleton<StateService>();
    services.AddSingleton<IItemService<Ally>, AllyService>();
    services.AddSingleton<IItemService<ShipBuild>, BuildService>();
    services.AddSingleton<IItemService<FleetCarrier>, FleetCarrierService>();
    services.AddSingleton<IItemService<FactionSystem>, SystemService>();

    services.AddOidcAuthentication(options =>
    {
        configuration.Bind("Auth0", options.ProviderOptions);
        options.ProviderOptions.ResponseType = "code";
        options.ProviderOptions.AdditionalProviderParameters.Add("audience", configuration["Auth0:Audience"]);
    });
}

public partial class Program
{
}