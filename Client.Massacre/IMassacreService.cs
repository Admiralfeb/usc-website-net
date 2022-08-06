using UnitedSystemsCooperative.Web.Client.Modules.Massacre.Models;

namespace UnitedSystemsCooperative.Web.Client.Massacre;

public interface IMassacreService
{
    public List<MassacreTracker> Trackers { get; }
    public string SelectedTab { get; }

    public void SetSelectedTab(string newTab);
    public Task AddTracker(string system);
    public void UpdateTracker(string system, MassacreTracker updatedTracker);
    public void DeleteTracker(MassacreTracker tracker);
}