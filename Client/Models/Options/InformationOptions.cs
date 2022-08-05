namespace UnitedSystemsCooperative.Web.Client.Models.Options;

public class InformationOptions
{
    public const string SettingsName = "app-data:information";

    public Infographic[] Infographics = Array.Empty<Infographic>();
}

public class Infographic
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public int Width { get; set; }
    public int Height { get; set; }
}