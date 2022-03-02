using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Xunit;
using UnitedSystemsCooperative.Web.Client;

namespace UnitedSystemsCooperative.Web.E2ETest;

public class HomePage : PageTest
{
    public HomePage()
    {
        
    }
    [Fact(Skip = "Will fail without test server")]
    public async Task Load()
    {
        await Page.GotoAsync("http://localhost:5000");
        
    }
}