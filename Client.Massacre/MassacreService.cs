using UnitedSystemsCooperative.Web.Client.Modules.Massacre.Models;

namespace UnitedSystemsCooperative.Web.Client.Massacre;

public class MassacreService : IMassacreService
{
    public MassacreService()
    {
    }

    public List<MassacreTracker> Trackers { get; private set; } = new();
    public string SelectedTab { get; private set; } = string.Empty;

    public void SetSelectedTab(string newTab)
    {
        throw new NotImplementedException();
    }

    public Task AddTracker(string system)
    {
        throw new NotImplementedException();
    }

    public void UpdateTracker(string system, MassacreTracker updatedTracker)
    {
        throw new NotImplementedException();
    }

    public void DeleteTracker(MassacreTracker tracker)
    {
        throw new NotImplementedException();
    }
}