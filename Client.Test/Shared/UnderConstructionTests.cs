using AngleSharp.Dom;
using Bunit;
using UnitedSystemsCooperative.Web.Client.Shared;
using Xunit;

namespace UnitedSystemsCooperative.Web.Client.Test.Shared;

public class UnderConstructionTests : TestContext
{
    [Theory]
    [InlineData("Herro")]
    [InlineData("Hah!")]
    public void TitleShouldRender(string title)
    {
        var cut = RenderComponent<UnderConstruction>(parameters =>
            parameters.Add(p => p.Title, title));

        Assert.Equal(title, cut.Find("h2").Text());
    }

    [Fact]
    public void TitleShouldBeEmpty()
    {
        var cut = RenderComponent<UnderConstruction>();

        Assert.Equal(0, cut.FindAll("h2").Count);
    }
}