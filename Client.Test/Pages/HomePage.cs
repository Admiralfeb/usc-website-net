using AngleSharp.Dom;
using Bunit;
using UnitedSystemsCooperative.Web.Client.Pages;
using Xunit;

namespace UnitedSystemsCooperative.Web.Client.Test.Pages;

public class HomePageTests
{
    [Fact]
    public void RendersLatinText()
    {
        using var ctx = new TestContext();
        var cut = ctx.RenderComponent<Home>();
        
        Assert.Equal("Ad astra per aspera".ToUpper(), cut.Find(".latin-text").Text());
    }
}