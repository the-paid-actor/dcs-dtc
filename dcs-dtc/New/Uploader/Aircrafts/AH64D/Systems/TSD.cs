using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.AH64D;

public partial class AH64DUploader
{
    private void BuildTSD(bool pilot)
    {
        if (!config.Upload.TSD)
        {
            return;
        }

        Device display = pilot ? MFD_PLT_RIGHT : MFD_CPG_RIGHT;

        Cmd(display.GetCommand("TSD"));
        ToggleButton(display, config.TSD.ShowPresentPosition, "PB4_13_b", "T4");
        ToggleButton(display, config.TSD.ShowCentered, "PB9_21_b", "R3");

        Cmd(display.GetCommand("B4"));
        IfNot(LabelEqual(display, "PB23_15", GetMapType(config.TSD.MapType)), display.GetCommand("L2"), display.GetCommand(GetMapTypeButton(config.TSD.MapType)));
        IfNot(LabelEqual(display, "PB11_7", GetMapOrientation(config.TSD.MapOrientation)), display.GetCommand("R5"), display.GetCommand(GetMapOrientationButton(config.TSD.MapOrientation)));
        ToggleButton(display, config.TSD.MapShowGrid, "PB5_23_b", "T5");
        IfNot(LabelEqual(display, "PB21_31", GetMapColorBand(config.TSD.MapElevationColorBand)), display.GetCommand("L4"), display.GetCommand(GetMapColorBandButton(config.TSD.MapElevationColorBand)));
        if (config.TSD.MapType == MapType.Elevation)
            ToggleButton(display, config.TSD.MapElevationGray, "PB4_21_b", "T4");
        Cmd(display.GetCommand("B4"));

        Cmd(display.GetCommand("T3"));
        If(LabelEqual(display, "PB17_21", "ATK"), display.GetCommand("B2"));
        ToggleButton(display, config.TSD.NavPhaseShowWptData, "PB23_9_b", "L2");
        ToggleButton(display, config.TSD.NavPhaseShowInactiveZones, "PB22_13_b", "L3");
        ToggleButton(display, config.TSD.NavPhaseShowObstacles, "PB21_29_b", "L4");
        ToggleButton(display, config.TSD.NavPhaseShowOtherStationCursor, "PB20_15_b", "L5");
        ToggleButton(display, config.TSD.NavPhaseShowCursorInfo, "PB19_17_b", "L6");

        ToggleButton(display, config.TSD.NavPhaseShowHSI, "PB10_23_b", "R4");
        ToggleButton(display, config.TSD.NavPhaseShowEndurance, "PB11_25_b", "R5");
        ToggleButton(display, config.TSD.NavPhaseShowWind, "PB12_27_b", "R6");

        Cmd(display.GetCommand("T6"));
        ToggleButton(display, config.TSD.NavPhaseShowControlMeasures, "PB23_11_b", "L2");
        ToggleButton(display, config.TSD.NavPhaseShowFriendlyUnits, "PB22_13_b", "L3");
        ToggleButton(display, config.TSD.NavPhaseShowEnemyUnits, "PB21_15_b", "L4");
        ToggleButton(display, config.TSD.NavPhaseShowTargets, "PB20_17_b", "L5");
        Cmd(display.GetCommand("T6"));

        If(LabelEqual(display, "PB17_21", "NAV"), display.GetCommand("B2"));

        ToggleButton(display, config.TSD.AttkPhaseShowCurrentRoute, "PB23_11_b", "L2");
        ToggleButton(display, config.TSD.AttkPhaseShowInactiveZones, "PB22_13_b", "L3");
        ToggleButton(display, config.TSD.AttkPhaseShowObstacles, "PB21_31_b", "L4");
        ToggleButton(display, config.TSD.AttkPhaseShowOtherStationCursor, "PB20_15_b", "L5");
        ToggleButton(display, config.TSD.AttkPhaseShowCursorInfo, "PB19_17_b", "L6");

        ToggleButton(display, config.TSD.AttkPhaseShowHSI, "PB10_23_b", "R4");
        ToggleButton(display, config.TSD.AttkPhaseShowEndurance, "PB11_25_b", "R5");
        ToggleButton(display, config.TSD.AttkPhaseShowWind, "PB12_27_b", "R6");

        Cmd(display.GetCommand("T6"));
        ToggleButton(display, config.TSD.AttkPhaseShowControlMeasures, "PB23_11_b", "L2");
        ToggleButton(display, config.TSD.AttkPhaseShowFriendlyUnits, "PB22_13_b", "L3");
        ToggleButton(display, config.TSD.AttkPhaseShowEnemyUnits, "PB21_15_b", "L4");
        ToggleButton(display, config.TSD.AttkPhaseShowTargets, "PB20_17_b", "L5");
        ToggleButton(display, config.TSD.AttkPhaseShowShot, "PB9_23_b", "R3");
        Cmd(display.GetCommand("T6"));

        Cmd(display.GetCommand("T5"));
        ToggleButton(display, config.TSD.ShowASEThreats, "PB23_15_b", "L2");
        ToggleButton(display, config.TSD.ShowThreatRings, "PB11_43_b", "R5");
        Cmd(display.GetCommand("T5"));

        Cmd(display.GetCommand("T3"));
        Cmd(display.GetCommand("B2"));
    }

    private string GetMapColorBand(ColorBand colorBand)
    {
        switch (colorBand)
        {
            case ColorBand.Aircraft: return "A/C";
            case ColorBand.Elevation: return "ELEV";
            case ColorBand.None: return "NONE";
            default: throw new NotImplementedException();
        }
    }

    private string GetMapColorBandButton(ColorBand colorBand)
    {
        switch (colorBand)
        {
            case ColorBand.Aircraft: return "L3";
            case ColorBand.Elevation: return "L4";
            case ColorBand.None: return "L5";
            default: throw new NotImplementedException();
        }
    }

    private string GetMapOrientation(MapOrientation mapOrientation)
    {
        switch (mapOrientation)
        {
            case MapOrientation.HeadingUp: return "HDG-UP";
            case MapOrientation.TrackUp: return "TRK-UP";
            case MapOrientation.NorthUp: return "N-UP";
            default: throw new NotImplementedException();
        }
    }

    private string GetMapOrientationButton(MapOrientation mapOrientation)
    {
        switch (mapOrientation)
        {
            case MapOrientation.HeadingUp: return "R4";
            case MapOrientation.TrackUp: return "R5";
            case MapOrientation.NorthUp: return "R6";
            default: throw new NotImplementedException();
        }
    }

    private string GetMapType(MapType mapType)
    {
        switch (mapType)
        {
            case MapType.Elevation: return "DIG";
            case MapType.Chart: return "CHART";
            case MapType.Satellite: return "SAT";
            case MapType.Stick: return "STICK";
            default: throw new NotImplementedException();
        }
    }

    private string GetMapTypeButton(MapType mapType)
    {
        switch (mapType)
        {
            case MapType.Elevation: return "L2";
            case MapType.Chart: return "L3";
            case MapType.Satellite: return "L4";
            case MapType.Stick: return "L5";
            default: throw new NotImplementedException();
        }
    }

    private void ToggleButton(Device display, bool condition, string label, string command)
    {
        if (condition)
        {
            IfNot(LabelEqual(display, label, ""), display.GetCommand(command));
        }
        else
        {
            If(LabelEqual(display, label, ""), display.GetCommand(command));
        }
    }

    private Condition LabelEqual(Device display, string label, string value)
    {
        return new Condition($"LabelEqual('{display.Name}', '{label}', '{value}')");
    }
}