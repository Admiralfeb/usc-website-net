using UnitedSystemsCooperative.Web.Shared;

namespace UnitedSystemsCooperative.Web.Client.Services;

public class StateService
{
    private IEnumerable<Ally>? _allies;

    public IEnumerable<Ally> Allies
    {
        get => _allies ?? new List<Ally>();
        set => _allies = value;
    }
}