using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using UnitedSystemsCooperative.Web.Server;
using UnitedSystemsCooperative.Web.Server.Interfaces;
using UnitedSystemsCooperative.Web.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDatabaseService, CosmosDbService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
    {
        c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
        c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidAudience = builder.Configuration["Auth0:Audience"],
            ValidIssuer = builder.Configuration["Auth0:Domain"]
        };
    });

#if DEBUG
builder.Configuration.AddJsonFile("appsettings.local.json");
var azureIdentity = new AzureIdentityConfig();
builder.Configuration.Bind("AzureIdentity", azureIdentity);
Environment.SetEnvironmentVariable("AZURE_TENANT_ID", azureIdentity.TenantId);
Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", azureIdentity.ClientId);
Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", azureIdentity.ClientSecret);
#endif

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseSwaggerUI();

app.Run();
