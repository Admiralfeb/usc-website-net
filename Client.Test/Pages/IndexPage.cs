using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using UnitedSystemsCooperative.Web.Client.Pages;
using Xunit;

namespace UnitedSystemsCooperative.Web.Client.Test.Pages;

public class IndexPageTests : TestContext
{
    [Fact]
    public void NavigatesToHome()
    {
        var cut = RenderComponent<Index>();

        var navMan = Services.GetRequiredService<FakeNavigationManager>();
        Assert.Equal("http://localhost/home", navMan.Uri);
    }
}