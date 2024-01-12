using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;
using Newtonsoft.Json;
using System.Dynamic;
using F15EConfigurationV1 = DTC.New.Presets.V1.Aircrafts.F15E.F15EConfiguration;
using F15EConfigurationV2 = DTC.New.Presets.V2.Aircrafts.F15E.F15EConfiguration;

namespace DTC.New.Presets.V2.Base.V1V2;

internal class F15EV1V2Loader
{
    public static F15EConfigurationV2 GetV2(string json)
    {
        var v1 = JsonConvert.DeserializeObject<F15EConfigurationV1>(json);
        var v2 = new F15EConfigurationV2();

        CopyUpload(v1, v2);
        CopyWaypoints(v1, v2);
        CopyRadios(v1, v2);
        CopyDisplays(v1, v2);
        CopyMisc(v1, v2);

        Cleanup(v2, json);

        return v2;
    }

    private static void Cleanup(F15EConfigurationV2 v2, string json)
    {
        var originalCfg = JsonConvert.DeserializeObject<ExpandoObject>(json);
        var anyNull = false;

        if (!Util.HasProperty(originalCfg, "Waypoints"))
        {
            v2.RouteA = null;
            v2.RouteB = null;
            v2.RouteC = null;
            anyNull = true;
        }

        if (!Util.HasProperty(originalCfg, "Radios")) { v2.Radios = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "Displays")) { v2.Displays = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "Misc")) { v2.Misc = null; anyNull = true; }

        if (anyNull)
        {
            v2.SmartWeapons = null;
            v2.WaypointsCapture = null;
            v2.Upload = null;
        }
    }

    private static void CopyRadios(F15EConfigurationV1 v1, F15EConfigurationV2 v2)
    {
        if (v1.Radios == null) return;

        CopyRadio(v1.Radios.Radio1, v2.Radios.Radio1);
        CopyRadio(v1.Radios.Radio2, v2.Radios.Radio2);
    }

    private static void CopyMisc(F15EConfigurationV1 v1, F15EConfigurationV2 v2)
    {
        if (v1.Misc == null) return;

        v2.Misc.Bingo = v1.Misc.Bingo;
        v2.Misc.BingoToBeUpdated = v1.Misc.BingoToBeUpdated;
        v2.Misc.CARAALOW = v1.Misc.CARAALOW;
        v2.Misc.CARAALOWToBeUpdated = v1.Misc.CARAALOWToBeUpdated;
        v2.Misc.TACANChannel = v1.Misc.TACANChannel;
        v2.Misc.TACANBand = (TACANBands)v1.Misc.TACANBand;
        v2.Misc.TACANToBeUpdated = v1.Misc.TACANToBeUpdated;
        v2.Misc.ILSFrequency = v1.Misc.ILSFrequency;
        v2.Misc.ILSToBeUpdated = v1.Misc.ILSToBeUpdated;
    }

    private static void CopyDisplays(F15EConfigurationV1 v1, F15EConfigurationV2 v2)
    {
        if (v1.Displays == null) return;

        CopyDisplay(v1.Displays.Pilot.LeftMPD, v2.Displays.Pilot.LeftMPD);
        CopyDisplay(v1.Displays.Pilot.RightMPD, v2.Displays.Pilot.RightMPD);
        CopyDisplay(v1.Displays.Pilot.MPCD, v2.Displays.Pilot.MPCD);
        CopyDisplay(v1.Displays.WSO.LeftMPCD, v2.Displays.WSO.LeftMPCD);
        CopyDisplay(v1.Displays.WSO.LeftMPD, v2.Displays.WSO.LeftMPD);
        CopyDisplay(v1.Displays.WSO.RightMPD, v2.Displays.WSO.RightMPD);
        CopyDisplay(v1.Displays.WSO.RightMPCD, v2.Displays.WSO.RightMPCD);
    }

    private static void CopyWaypoints(F15EConfigurationV1 v1, F15EConfigurationV2 v2)
    {
        if (v1.Waypoints == null) return;

        v2.RouteA.Waypoints.AddRange(v1.Waypoints.Waypoints.Select((w) => new Waypoint()
        {
            Sequence = w.Sequence,
            Name = w.Name,
            Latitude = w.Latitude,
            Longitude = w.Longitude,
            Elevation = w.Elevation,
            Target = w.Target
        }));
    }

    private static void CopyUpload(F15EConfigurationV1 v1, F15EConfigurationV2 v2)
    {
        if (v1.Waypoints != null) v2.Upload.RouteA = v1.Waypoints.EnableUpload;
        if (v1.Radios != null) v2.Upload.Radios = v1.Radios.EnableUpload;
        if (v1.Displays != null) v2.Upload.Displays = v1.Displays.EnableUpload;
        if (v1.Misc != null) v2.Upload.Misc = v1.Misc.EnableUpload;
    }

    private static void CopyDisplay(V1.Aircrafts.F15E.DisplayConfig dispV1, DisplayConfig dispV2)
    {
        dispV2.FirstDisplay = (Display)dispV1.FirstDisplay;
        dispV2.SecondDisplay = (Display)dispV1.SecondDisplay;
        dispV2.ThirdDisplay = (Display)dispV1.ThirdDisplay;
        dispV2.FirstDisplayMode = (DisplayMode)dispV1.FirstDisplayMode;
        dispV2.SecondDisplayMode = (DisplayMode)dispV1.SecondDisplayMode;
        dispV2.ThirdDisplayMode = (DisplayMode)dispV1.ThirdDisplayMode;
    }

    private static void CopyRadio(V1.Aircrafts.F15E.Radio radioV1, Radio radioV2)
    {
        for (var i = 0; i < radioV1.Frequencies.Length; i++)
        {
            var freq = radioV1.Frequencies[i];
            if (string.IsNullOrEmpty(freq)) continue;
            radioV2.AddPreset(new RadioPreset(i) { Frequency = freq });
        }

        radioV2.SelectedFrequency = radioV1.SelectedFrequency;
        radioV2.SelectedPreset = radioV1.SelectedPreset;
        radioV2.EnableGuard = radioV1.EnableGuard;
        radioV2.Mode = (RadioMode)(int)radioV1.Mode;
    }
}
