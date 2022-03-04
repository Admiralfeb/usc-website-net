using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Xunit;
using UnitedSystemsCooperative.Web.Client;

namespace UnitedSystemsCooperative.Web.E2ETest;

public class HomePage : IClassFixture<DevServerFixture>
{
    private readonly DevServerFixture _server;
    public HomePage(DevServerFixture server)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("testsettings.json")
            .AddJsonFile("testsettings.local.json", true)
            .Build();
        
        var root = Path.Combine(AppContext.BaseDirectory, "../../../../");
        var location = Path.GetFullPath(Path.Combine(root, config["contentRoot"]));

        _server = server;
        _server.ContentRoot = location;
    }
    [Fact]
    public async Task Load()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        var page = await browser.NewPageAsync();
        await page.GotoAsync(_server.RootUri.AbsoluteUri);
        var latinText = await page.WaitForSelectorAsync(".latin-text");
        Assert.Equal("Ad astra per aspera".ToUpper(), await latinText.TextContentAsync());
    }
}