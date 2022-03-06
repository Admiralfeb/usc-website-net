namespace UnitedSystemsCooperative.Web.Shared;

public class FleetCarrier
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
    public string Purpose { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}