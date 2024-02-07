
namespace DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

public enum MapType
{
    Chart,
    Elevation,
    Satellite,
    Stick
}

public enum ColorBand
{
    None,
    Aircraft,
    Elevation
}

public enum MapOrientation
{
    HeadingUp,
    TrackUp,
    NorthUp
}

public class TSDSystem
{
    public bool ShowPresentPosition { get; set; }
    public bool ShowCentered { get; set; }
    public MapType MapType { get; set; }
    public MapOrientation MapOrientation { get; set; }
    public bool MapShowGrid { get; set; }
    public ColorBand MapElevationColorBand { get; set; }
    public bool MapElevationGray { get; set; }
    public bool NavPhaseShowWptData { get; set; }
    public bool NavPhaseShowInactiveZones { get; set; }
    public bool NavPhaseShowObstacles { get; set; }
    public bool NavPhaseShowOtherStationCursor { get; set; }
    public bool NavPhaseShowCursorInfo { get; set; }
    public bool NavPhaseShowHSI { get; set; }
    public bool NavPhaseShowEndurance { get; set; }
    public bool NavPhaseShowWind { get; set; }
    public bool NavPhaseShowControlMeasures { get; set; }
    public bool NavPhaseShowFriendlyUnits { get; set; }
    public bool NavPhaseShowEnemyUnits { get; set; }
    public bool NavPhaseShowTargets { get; set; }
    public bool AttkPhaseShowCurrentRoute { get; set; }
    public bool AttkPhaseShowInactiveZones { get; set; }
    public bool AttkPhaseShowObstacles { get; set; }
    public bool AttkPhaseShowOtherStationCursor { get; set; }
    public bool AttkPhaseShowCursorInfo { get; set; }
    public bool AttkPhaseShowHSI { get; set; }
    public bool AttkPhaseShowEndurance { get; set; }
    public bool AttkPhaseShowWind { get; set; }
    public bool AttkPhaseShowControlMeasures { get; set; }
    public bool AttkPhaseShowFriendlyUnits { get; set; }
    public bool AttkPhaseShowEnemyUnits { get; set; }
    public bool AttkPhaseShowTargets { get; set; }
    public bool AttkPhaseShowShot { get; set; }
    public bool ShowASEThreats { get; set; }
    public bool ShowThreatRings { get; set; }
}
