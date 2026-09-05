using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.UI.Base.Systems;

public interface IWaypointEditCustomPanel
{
    bool GenericCoordinateInputEnabled => true;
    void SetCoordinateInputEnabledCallback(Action<bool> callback) { }
    void SetTimeOverSteerpointEnabledCallback(Action<bool> callback) { }
    Control GetControl();
    void LoadWaypoint(IWaypoint wpt);
    bool Validate(out string? message);
    void Save(IWaypoint wpt);
}