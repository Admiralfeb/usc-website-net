using AngleSharp.Dom;
using Bunit;
using UnitedSystemsCooperative.Web.Client.Pages;
using Xunit;

namespace UnitedSystemsCooperative.Web.Client.Test.Pages;

public class MassacresTest : TestContext
{
    [Fact]
    public void MassacresShouldRender()
    {
        var cut = RenderComponent<Massacres>();

        Assert.Equal("USC Massacre Mission Tracker", cut.Find("h2").Text());
    }
}