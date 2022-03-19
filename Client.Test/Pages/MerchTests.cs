using AngleSharp.Dom;
using Bunit;
using UnitedSystemsCooperative.Web.Client.Pages;
using Xunit;

namespace UnitedSystemsCooperative.Web.Client.Test.Pages;

public class MerchTests : TestContext
{
    [Fact]
    public void ShouldRender()
    {
        var cut = RenderComponent<Merch>();

        Assert.Equal("USC Merch", cut.Find("h2").Text());
    }
}