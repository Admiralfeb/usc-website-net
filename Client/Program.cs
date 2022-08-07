using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using UnitedSystemsCooperative.Web.Client;
using UnitedSystemsCooperative.Web.Client.Interfaces;
using UnitedSystemsCooperative.Web.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Services
    .AddHttpClients(builder.HostEnvironment.BaseAddress)
    .AddConfigs(builder.Configuration);

builder.Services.AddServices(builder.Configuration);

await builder.Build().RunAsync();

public partial class Program
{
}