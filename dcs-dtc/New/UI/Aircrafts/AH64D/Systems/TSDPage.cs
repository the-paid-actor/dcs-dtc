using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.AH64D.Systems;

public partial class TSDPage : AircraftSystemPage
{
    public TSDPage(AH64DPage parent) : base(parent, nameof(parent.Configuration.TSD))
    {
        InitializeComponent();

        var tsd = parent.Configuration.TSD;

        cboMapType.Items.AddRange(Enum.GetValues(typeof(MapType)).Cast<object>().ToArray());
        cboMapType.SelectedItem = tsd.MapType;
        cboMapType.SelectedIndexChanged += (s, e) =>
        {
            tsd.MapType = (MapType)cboMapType.SelectedItem;
        };

        cboMapOrientation.Items.AddRange(Enum.GetValues(typeof(MapOrientation)).Cast<object>().ToArray());
        cboMapOrientation.SelectedItem = tsd.MapOrientation;
        cboMapOrientation.SelectedIndexChanged += (s, e) =>
        {
            tsd.MapOrientation = (MapOrientation)cboMapOrientation.SelectedItem;
        };

        cboMapElevationColorBand.Items.AddRange(Enum.GetValues(typeof(ColorBand)).Cast<object>().ToArray());
        cboMapElevationColorBand.SelectedItem = tsd.MapElevationColorBand;
        cboMapElevationColorBand.SelectedIndexChanged += (s, e) =>
        {
            tsd.MapElevationColorBand = (ColorBand)cboMapElevationColorBand.SelectedItem;
        };

        chkShowPresentPosition.Checked = tsd.ShowPresentPosition;
        chkShowPresentPosition.CheckedChanged += (s, e) =>
        {
            tsd.ShowPresentPosition = chkShowPresentPosition.Checked;
            this.SavePreset();
        };

        chkShowCentered.Checked = tsd.ShowCentered;
        chkShowCentered.CheckedChanged += (s, e) =>
        {
            tsd.ShowCentered = chkShowCentered.Checked;
            this.SavePreset();
        };

        chkMapShowGrid.Checked = tsd.MapShowGrid;
        chkMapShowGrid.CheckedChanged += (s, e) =>
        {
            tsd.MapShowGrid = chkMapShowGrid.Checked;
            this.SavePreset();
        };

        chkMapElevationGray.Checked = tsd.MapElevationGray;
        chkMapElevationGray.CheckedChanged += (s, e) =>
        {
            tsd.MapElevationGray = chkMapElevationGray.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowWptData.Checked = tsd.NavPhaseShowWptData;
        chkNavPhaseShowWptData.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowWptData = chkNavPhaseShowWptData.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowInactiveZones.Checked = tsd.NavPhaseShowInactiveZones;
        chkNavPhaseShowInactiveZones.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowInactiveZones = chkNavPhaseShowInactiveZones.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowObstacles.Checked = tsd.NavPhaseShowObstacles;
        chkNavPhaseShowObstacles.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowObstacles = chkNavPhaseShowObstacles.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowOtherStationCursor.Checked = tsd.NavPhaseShowOtherStationCursor;
        chkNavPhaseShowOtherStationCursor.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowOtherStationCursor = chkNavPhaseShowOtherStationCursor.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowCursorInfo.Checked = tsd.NavPhaseShowCursorInfo;
        chkNavPhaseShowCursorInfo.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowCursorInfo = chkNavPhaseShowCursorInfo.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowHSI.Checked = tsd.NavPhaseShowHSI;
        chkNavPhaseShowHSI.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowHSI = chkNavPhaseShowHSI.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowEndurance.Checked = tsd.NavPhaseShowEndurance;
        chkNavPhaseShowEndurance.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowEndurance = chkNavPhaseShowEndurance.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowWind.Checked = tsd.NavPhaseShowWind;
        chkNavPhaseShowWind.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowWind = chkNavPhaseShowWind.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowControlMeasures.Checked = tsd.NavPhaseShowControlMeasures;
        chkNavPhaseShowControlMeasures.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowControlMeasures = chkNavPhaseShowControlMeasures.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowFriendlyUnits.Checked = tsd.NavPhaseShowFriendlyUnits;
        chkNavPhaseShowFriendlyUnits.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowFriendlyUnits = chkNavPhaseShowFriendlyUnits.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowEnemyUnits.Checked = tsd.NavPhaseShowEnemyUnits;
        chkNavPhaseShowEnemyUnits.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowEnemyUnits = chkNavPhaseShowEnemyUnits.Checked;
            this.SavePreset();
        };

        chkNavPhaseShowTargets.Checked = tsd.NavPhaseShowTargets;
        chkNavPhaseShowTargets.CheckedChanged += (s, e) =>
        {
            tsd.NavPhaseShowTargets = chkNavPhaseShowTargets.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowCurrentRoute.Checked = tsd.AttkPhaseShowCurrentRoute;
        chkAttkPhaseShowCurrentRoute.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowCurrentRoute = chkAttkPhaseShowCurrentRoute.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowInactiveZones.Checked = tsd.AttkPhaseShowInactiveZones;
        chkAttkPhaseShowInactiveZones.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowInactiveZones = chkAttkPhaseShowInactiveZones.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowObstacles.Checked = tsd.AttkPhaseShowObstacles;
        chkAttkPhaseShowObstacles.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowObstacles = chkAttkPhaseShowObstacles.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowOtherStationCursor.Checked = tsd.AttkPhaseShowOtherStationCursor;
        chkAttkPhaseShowOtherStationCursor.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowOtherStationCursor = chkAttkPhaseShowOtherStationCursor.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowCursorInfo.Checked = tsd.AttkPhaseShowCursorInfo;
        chkAttkPhaseShowCursorInfo.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowCursorInfo = chkAttkPhaseShowCursorInfo.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowHSI.Checked = tsd.AttkPhaseShowHSI;
        chkAttkPhaseShowHSI.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowHSI = chkAttkPhaseShowHSI.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowEndurance.Checked = tsd.AttkPhaseShowEndurance;
        chkAttkPhaseShowEndurance.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowEndurance = chkAttkPhaseShowEndurance.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowWind.Checked = tsd.AttkPhaseShowWind;
        chkAttkPhaseShowWind.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowWind = chkAttkPhaseShowWind.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowControlMeasures.Checked = tsd.AttkPhaseShowControlMeasures;
        chkAttkPhaseShowControlMeasures.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowControlMeasures = chkAttkPhaseShowControlMeasures.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowFriendlyUnits.Checked = tsd.AttkPhaseShowFriendlyUnits;
        chkAttkPhaseShowFriendlyUnits.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowFriendlyUnits = chkAttkPhaseShowFriendlyUnits.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowEnemyUnits.Checked = tsd.AttkPhaseShowEnemyUnits;
        chkAttkPhaseShowEnemyUnits.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowEnemyUnits = chkAttkPhaseShowEnemyUnits.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowTargets.Checked = tsd.AttkPhaseShowTargets;
        chkAttkPhaseShowTargets.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowTargets = chkAttkPhaseShowTargets.Checked;
            this.SavePreset();
        };

        chkAttkPhaseShowShot.Checked = tsd.AttkPhaseShowShot;
        chkAttkPhaseShowShot.CheckedChanged += (s, e) =>
        {
            tsd.AttkPhaseShowShot = chkAttkPhaseShowShot.Checked;
            this.SavePreset();
        };

        chkShowASEThreats.Checked = tsd.ShowASEThreats;
        chkShowASEThreats.CheckedChanged += (s, e) =>
        {
            tsd.ShowASEThreats = chkShowASEThreats.Checked;
            this.SavePreset();
        };

        chkShowThreatRings.Checked = tsd.ShowThreatRings;
        chkShowThreatRings.CheckedChanged += (s, e) =>
        {
            tsd.ShowThreatRings = chkShowThreatRings.Checked;
            this.SavePreset();
        };
    }

    public override string GetPageTitle()
    {
        return "TSD";
    }
}
