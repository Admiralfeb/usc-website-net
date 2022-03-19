using AngleSharp.Dom;
using Bunit;
using UnitedSystemsCooperative.Web.Client.Pages;
using Xunit;

namespace UnitedSystemsCooperative.Web.Client.Test.Pages;

public class NotFoundTests : TestContext
{
    [Fact]
    public void ShouldRender()
    {
        var cut = RenderComponent<NotFound>();

        Assert.Equal("NotFound", cut.Find("h3").Text());
    }
}