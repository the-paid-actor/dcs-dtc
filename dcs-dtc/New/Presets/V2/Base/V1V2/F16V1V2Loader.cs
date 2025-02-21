using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;
using Newtonsoft.Json;
using System.Dynamic;
using System.Globalization;
using F16ConfigurationV1 = DTC.New.Presets.V1.Aircrafts.F16.F16Configuration;
using F16ConfigurationV2 = DTC.New.Presets.V2.Aircrafts.F16.F16Configuration;

namespace DTC.New.Presets.V2.Base.V1V2;

internal class F16V1V2Loader
{
    public static F16ConfigurationV2 GetV2(string json)
    {
        var v1 = JsonConvert.DeserializeObject<F16ConfigurationV1>(json);
        var v2 = new F16ConfigurationV2();

        CopyUpload(v1, v2);
        CopyWaypoints(v1, v2);
        CopyRadios(v1, v2);
        CopyCMS(v1, v2);
        CopyMFDs(v1, v2);
        CopyHARM(v1, v2);
        CopyHTS(v1, v2);
        CopyMisc(v1, v2);

        Cleanup(v2, json);

        return v2;
    }

    private static void Cleanup(F16ConfigurationV2 v2, string json)
    {
        var originalCfg = JsonConvert.DeserializeObject<ExpandoObject>(json);
        var anyNull = false;

        if (!Util.HasProperty(originalCfg, "Waypoints")) { v2.Waypoints = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "Radios")) { v2.Radios = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "CMS")) { v2.CMS = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "MFD")) { v2.MFD = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "HARM")) { v2.HARM = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "HTS")) { v2.HTS = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "Misc")) { v2.Misc = null; anyNull = true; }

        if (anyNull)
        {
            v2.Datalink = null;
            v2.WaypointsCapture = null;
            v2.Upload = null;
        }
    }

    private static void CopyMisc(F16ConfigurationV1 v1, F16ConfigurationV2 v2)
    {
        if (v1.Misc == null) return;

        v2.Misc.Bingo = v1.Misc.Bingo;
        v2.Misc.BingoToBeUpdated = v1.Misc.BingoToBeUpdated;
        v2.Misc.BullseyeToBeUpdated = v1.Misc.BullseyeToBeUpdated;
        v2.Misc.BullseyeWP = v1.Misc.BullseyeWP;
        v2.Misc.CARAALOW = v1.Misc.CARAALOW;
        v2.Misc.CARAALOWToBeUpdated = v1.Misc.CARAALOWToBeUpdated;
        v2.Misc.MSLFloor = v1.Misc.MSLFloor;
        v2.Misc.MSLFloorToBeUpdated = v1.Misc.MSLFloorToBeUpdated;
        v2.Misc.LaserSettingsToBeUpdated = v1.Misc.LaserSettingsToBeUpdated;
        v2.Misc.TGPCode = v1.Misc.TGPCode;
        v2.Misc.LSTCode = v1.Misc.LSTCode;
        v2.Misc.LaserStartTime = v1.Misc.LaserStartTime;
        v2.Misc.TACANChannel = v1.Misc.TACANChannel;
        v2.Misc.TACANBand = (TACANBands)v1.Misc.TACANBand;
        v2.Misc.TACANToBeUpdated = v1.Misc.TACANToBeUpdated;
        v2.Misc.ILSFrequency = v1.Misc.ILSFrequency;
        v2.Misc.ILSCourse = v1.Misc.ILSCourse;
        v2.Misc.ILSToBeUpdated = v1.Misc.ILSToBeUpdated;
    }

    private static void CopyHTS(F16ConfigurationV1 v1, F16ConfigurationV2 v2)
    {
        if (v1.HTS == null) return;

        v2.HTS.ManualEmitters = v1.HTS.ManualEmitters;
        v2.HTS.ManualEmittersToBeUpdated = v1.HTS.ManualEmittersToBeUpdated;
        v2.HTS.EnabledClasses = v1.HTS.EnabledClasses;
        v2.HTS.ManualTableEnabledToBeUpdated = v1.HTS.ManualTableEnabledToBeUpdated;
        v2.HTS.ManualTableEnabled = v1.HTS.ManualTableEnabled;
    }

    private static void CopyHARM(F16ConfigurationV1 v1, F16ConfigurationV2 v2)
    {
        if (v1.HARM == null) return;

        for (var i = 0; i < v1.HARM.Tables.Length; i++)
        {
            var tableV1 = v1.HARM.Tables[i];
            var tableV2 = v2.HARM.Tables[i];
            tableV2.ToBeUpdated = tableV1.ToBeUpdated;
            tableV2.TableNumber = tableV1.TableNumber;
            tableV2.Emitters = tableV1.Emitters;
        }
    }

    private static void CopyMFDs(F16ConfigurationV1 v1, F16ConfigurationV2 v2)
    {
        if (v1.MFD == null) return;

        for (var i = 0; i < v1.MFD.Configurations.Length; i++)
        {
            var cfgV1 = v1.MFD.Configurations[i];
            var cfgV2 = v2.MFD.Configurations[i];
            cfgV2.Mode = (Mode)cfgV1.Mode;
            cfgV2.ToBeUpdated = cfgV1.ToBeUpdated;
            cfgV2.LeftMFD.SelectedPage = cfgV1.LeftMFD.SelectedPage;
            cfgV2.LeftMFD.Page1 = (Page)cfgV1.LeftMFD.Page1;
            cfgV2.LeftMFD.Page2 = (Page)cfgV1.LeftMFD.Page2;
            cfgV2.LeftMFD.Page3 = (Page)cfgV1.LeftMFD.Page3;
        }
    }

    private static void CopyRadios(F16ConfigurationV1 v1, F16ConfigurationV2 v2)
    {
        if (v1.Radios == null) return;

        CopyRadio(v1.Radios.COM1, v2.Radios.Radio1);
        CopyRadio(v1.Radios.COM2, v2.Radios.Radio2);
    }

    private static void CopyCMS(F16ConfigurationV1 v1, F16ConfigurationV2 v2)
    {
        if (v1.CMS == null) return;

        v2.CMS.ChaffBingo = v1.CMS.ChaffBingo;
        v2.CMS.FlareBingo = v1.CMS.FlareBingo;

        for (var i = 0; i < v1.CMS.Programs.Length; i++)
        {
            var program = v1.CMS.Programs[i];
            if (program.ToBeUpdated)
            {
                v2.CMS.Programs[i].Number = program.Number;
                v2.CMS.Programs[i].FlareBurstQty = program.FlareBurstQty;
                v2.CMS.Programs[i].FlareBurstInterval = program.FlareBurstInterval;
                v2.CMS.Programs[i].FlareSalvoQty = program.FlareSalvoQty;
                v2.CMS.Programs[i].FlareSalvoInterval = program.FlareSalvoInterval;
                v2.CMS.Programs[i].ChaffBurstQty = program.ChaffBurstQty;
                v2.CMS.Programs[i].ChaffBurstInterval = program.ChaffBurstInterval;
                v2.CMS.Programs[i].ChaffSalvoQty = program.ChaffSalvoQty;
                v2.CMS.Programs[i].ChaffSalvoInterval = program.ChaffSalvoInterval;
                v2.CMS.Programs[i].ToBeUpdated = program.ToBeUpdated;
            }
        }
    }

    private static void CopyWaypoints(F16ConfigurationV1 v1, F16ConfigurationV2 v2)
    {
        if (v1.Waypoints == null) return;

        v2.Waypoints.Waypoints.AddRange(v1.Waypoints.Waypoints.Select(CopyWaypoint));
    }

    private static void CopyUpload(F16ConfigurationV1 v1, F16ConfigurationV2 v2)
    {
        if (v1.Waypoints != null) v2.Upload.Waypoints = v1.Waypoints.EnableUpload;
        if (v1.CMS != null) v2.Upload.CMS = v1.CMS.EnableUpload;
        if (v1.Radios != null) v2.Upload.Radios = v1.Radios.EnableUpload;
        if (v1.MFD != null) v2.Upload.MFDs = v1.MFD.EnableUpload;
        if (v1.Misc != null) v2.Upload.Misc = v1.Misc.EnableUpload;

        var harmUpload = false;
        var htsUpload = false;
        if (v1.HARM != null) harmUpload = v1.HARM.EnableUpload;
        if (v1.HARM != null) htsUpload = v1.HTS.EnableUpload;
        v2.Upload.HARMHTS = harmUpload || htsUpload;
    }

    private static void CopyRadio(V1.Aircrafts.F16.Radio radioV1, Radio radioV2)
    {
        for (var i = 0; i < radioV1.Channels.Length; i++)
        {
            var channel = radioV1.Channels[i];
            radioV2.AddPreset(new RadioPreset(channel.Channel) { Frequency = channel.Frequency.ToString("#.00", CultureInfo.InvariantCulture) });
        }

        if (radioV1.SelectedChannel != null)
        {
            radioV2.SelectedPreset = radioV1.SelectedChannel.Channel.ToString();
            radioV2.Mode = RadioMode.Preset;
        }
    }

    private static Waypoint CopyWaypoint(V1.Aircrafts.F16.Waypoint w)
    {
        var wpt = new Waypoint()
        {
            Sequence = w.Sequence,
            Name = w.Name,
            Latitude = w.Latitude,
            Longitude = w.Longitude,
            Elevation = w.Elevation,
            TimeOverSteerpoint = w.TimeOverSteerpoint == "00:00:00" ? null : w.TimeOverSteerpoint,
            UseOA = w.UseOA,
            UseVIP = w.UseVIP,
            UseVRP = w.UseVRP
        };

        wpt.OffsetAimpoint1 = CopyOffset(w.OffsetAimpoint1);
        wpt.OffsetAimpoint2 = CopyOffset(w.OffsetAimpoint2);
        wpt.VIPtoTGT = CopyOffset(w.VIPtoTGT);
        wpt.VIPtoPUP = CopyOffset(w.VIPtoPUP);
        wpt.TGTtoVRP = CopyOffset(w.TGTtoVRP);
        wpt.TGTtoPUP = CopyOffset(w.TGTtoPUP);

        return wpt;
    }

    private static Offset? CopyOffset(V1.Aircrafts.F16.Offset offset)
    {
        if (offset != null)
        {
            return new Offset()
            {
                Bearing = offset.Bearing,
                Elevation = offset.Elevation,
                Range = offset.Range
            };
        }
        return null;
    }
}