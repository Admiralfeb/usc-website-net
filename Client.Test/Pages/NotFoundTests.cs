using AngleSharp.Dom;
using Bunit;
using UnitedSystemsCooperative.Web.Client.Shared;
using Xunit;

namespace UnitedSystemsCooperative.Web.Client.Test.Pages;

public class NotFoundTests : TestContext
{
    [Fact(Skip = "Need to update test")]
    public void ShouldRender()
    {
        var cut = RenderComponent<NotFoundComponent>();

        Assert.Equal("NotFound", cut.Find("h3").Text());
    }
}