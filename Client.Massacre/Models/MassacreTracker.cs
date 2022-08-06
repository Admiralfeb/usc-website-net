namespace UnitedSystemsCooperative.Web.Client.Modules.Massacre.Models;

public class MassacreTracker
{
    public bool IsCurrent;
    public string HazRezSystem { get; set; } = string.Empty;
    public IEnumerable<SystemInfo> SystemsIn10Ly { get; set; } = Enumerable.Empty<SystemInfo>();
    public IEnumerable<FactionsWithMissions> FactionsWithMissions { get; set; }
}

public class SystemInfo
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<FactionInfo> Factions { get; set; } = Enumerable.Empty<FactionInfo>();
    public IEnumerable<StationInfo> Stations { get; set; } = Enumerable.Empty<StationInfo>();
}

public class FactionInfo
{
    public string Name { get; set; } = string.Empty;
    public long Id { get; set; }
    public double Influence { get; set; }
    public bool IsRemoved { get; set; }
}

public class StationInfo
{
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Distance { get; set; }
}

public class FactionsWithMissions
{
    public string Name { get; set; }
    public long Id { get; set; }
    public bool IsRemoved { get; set; }
    public string Reputation { get; set; }
    public IEnumerable<FactionMission>? Missions { get; set; }
}

public class FactionMission
{
    public DateTime TimeStamp { get; set; }
    public int KillsForMission { get; set; }
    public int KillsCompleted { get; set; }
}