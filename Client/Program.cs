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

builder.Services.AddHttpClient("UnitedSystemsCooperative.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("UnitedSystemsCooperative.ServerAPI"));

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://unitedsystemscooperative.onmicrosoft.com/aa9ec6f0-b9d9-43cb-a1a1-8cf39fa159ad/Api.Access");
});

AddServices(builder.Services, builder.Configuration);

await builder.Build().RunAsync();


static void AddServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddSingleton<ApiService>();
    services.AddSingleton<StateService>();
    services.AddSingleton<IItemService<Ally>, AllyService>();
    services.AddSingleton<IItemService<ShipBuild>, BuildService>();
    services.AddSingleton<IItemService<FleetCarrier>, FleetCarrierService>();
    services.AddSingleton<IItemService<FactionSystem>, SystemService>();
}

public partial class Program
{
}