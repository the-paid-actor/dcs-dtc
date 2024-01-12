using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;
using Newtonsoft.Json;
using System.Dynamic;
using System.Globalization;
using FA18ConfigurationV1 = DTC.New.Presets.V1.Aircrafts.FA18.FA18Configuration;
using FA18ConfigurationV2 = DTC.New.Presets.V2.Aircrafts.FA18.FA18Configuration;

namespace DTC.New.Presets.V2.Base.V1V2;

internal class FA18V1V2Loader
{
    public static FA18ConfigurationV2 GetV2(string json)
    {
        var v1 = JsonConvert.DeserializeObject<FA18ConfigurationV1>(json);
        var v2 = new FA18ConfigurationV2();

        CopyUpload(v1, v2);
        CopyWaypoints(v1, v2);
        CopySequences(v1, v2);
        CopyPreplanned(v1, v2);
        CopyRadios(v1, v2);
        CopyCMS(v1, v2);
        CopyMisc(v1, v2);

        Cleanup(v2, json);

        return v2;
    }

    private static void Cleanup(FA18ConfigurationV2 v2, string json)
    {
        var originalCfg = JsonConvert.DeserializeObject<ExpandoObject>(json);
        var anyNull = false;

        if (!Util.HasProperty(originalCfg, "Waypoints")) { v2.Waypoints = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "Sequences")) { v2.Sequences = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "PrePlanned")) { v2.PrePlanned = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "Radios")) { v2.Radios = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "CMS")) { v2.CMS = null; anyNull = true; }
        if (!Util.HasProperty(originalCfg, "Misc")) { v2.Misc = null; anyNull = true; }

        if (anyNull)
        {
            v2.FCR = null;
            v2.HMD = null;
            v2.WaypointsCapture = null;
            v2.Upload = null;
        }
    }

    private static void CopyMisc(FA18ConfigurationV1 v1, FA18ConfigurationV2 v2)
    {
        if (v1.Misc == null) return;

        v2.Misc.Bingo = v1.Misc.Bingo;
        v2.Misc.BingoToBeUpdated = v1.Misc.BingoToBeUpdated;
        v2.Misc.BullseyeToBeUpdated = v1.Misc.BullseyeToBeUpdated;
        v2.Misc.BullseyeWP = v1.Misc.BullseyeWP;
        v2.Misc.BaroWarn = v1.Misc.BaroWarn;
        v2.Misc.BaroToBeUpdated = v1.Misc.BaroToBeUpdated;
        v2.Misc.RadarWarn = v1.Misc.RadarWarn;
        v2.Misc.RadarToBeUpdated = v1.Misc.RadarToBeUpdated;
        v2.Misc.BlimTac = v1.Misc.BlimTac;
        v2.Misc.TACANChannel = v1.Misc.TACANChannel;
        v2.Misc.TACANBand = (TACANBands)v1.Misc.TACANBand;
        v2.Misc.TACANToBeUpdated = v1.Misc.TACANToBeUpdated;
        v2.Misc.ILSToBeUpdated = v1.Misc.ILSToBeUpdated;
        v2.Misc.ILSChannel = v1.Misc.ILSChannel;
        v2.Misc.HideMapOnHSI = v1.Misc.HideMapOnHSI;
    }

    private static void CopyCMS(FA18ConfigurationV1 v1, FA18ConfigurationV2 v2)
    {
        if (v1.CMS == null) return;

        for (var i = 0; i < v1.CMS.Programs.Length; i++)
        {
            var program = v1.CMS.Programs[i];
            if (program.ToBeUpdated)
            {
                v2.CMS.Programs[i].Number = program.Number;
                v2.CMS.Programs[i].FlareQty = program.FlareQty;
                v2.CMS.Programs[i].ChaffQty = program.ChaffQty;
                v2.CMS.Programs[i].Interval = program.Interval;
                v2.CMS.Programs[i].Repeat = program.Repeat;
                v2.CMS.Programs[i].ToBeUpdated = program.ToBeUpdated;
            }
        }
    }

    private static void CopyRadios(FA18ConfigurationV1 v1, FA18ConfigurationV2 v2)
    {
        if (v1.Radios == null) return;

        CopyRadio(v1.Radios.COM1, v2.Radios.Radio1);
        CopyRadio(v1.Radios.COM2, v2.Radios.Radio2);
    }

    private static void CopyRadio(V1.Aircrafts.FA18.Radio radioV1, Radio radioV2)
    {
        for (var i = 0; i < radioV1.Channels.Length; i++)
        {
            var channel = radioV1.Channels[i];
            if (channel.ToBeUpdated)
            {
                radioV2.AddPreset(new RadioPreset(channel.Channel) { Frequency = channel.Frequency.ToString("#.000", CultureInfo.InvariantCulture) });
            }
        }

        if (radioV1.SelectedChannel != null)
        {
            radioV2.SelectedPreset = radioV1.SelectedChannel.Channel.ToString();
            radioV2.Mode = RadioMode.Preset;
        }
    }

    private static void CopyPreplanned(FA18ConfigurationV1 v1, FA18ConfigurationV2 v2)
    {
        if (v1.PrePlanned == null) return;

        foreach (var kv in v1.PrePlanned.Stations)
        {
            var v1Station = v1.PrePlanned.Stations[kv.Key];
            var v2Station = v2.PrePlanned.Stations[kv.Key];

            StationType type;
            switch (kv.Value.stationType)
            {
                case V1.Aircrafts.FA18.StationType.GBU38:
                    type = StationType.GBU38; break;
                case V1.Aircrafts.FA18.StationType.GBU32:
                    type = StationType.GBU32; break;
                case V1.Aircrafts.FA18.StationType.GBU31NP:
                    type = StationType.GBU31NP; break;
                case V1.Aircrafts.FA18.StationType.GBU31PP:
                    type = StationType.GBU31PP; break;
                case V1.Aircrafts.FA18.StationType.JSOWA:
                    type = StationType.JSOWA; break;
                case V1.Aircrafts.FA18.StationType.JSOWC:
                    type = StationType.JSOWC; break;
                case V1.Aircrafts.FA18.StationType.SLAM:
                    type = StationType.SLAM; break;
                case V1.Aircrafts.FA18.StationType.SLAMER:
                    type = StationType.SLAMER; break;
                default:
                    type = StationType.EMPTY; break;
            }
            v2Station.Type = type;

            for (var i = 0; i < v1Station.Steerpoints.Length; i++)
            {
                var v2Stpt = v2Station.Steerpoints[i];
                var v1Stpt = v1Station.Steerpoints[i];
                v2Stpt.UseCoordinate = v1Stpt.useCoordinate;
                v2Stpt.WaypointNumber = v1Stpt.waypointNumber;
                v2Stpt.Lat = v1Stpt.Lat;
                v2Stpt.Lon = v1Stpt.Lon;
                v2Stpt.Elev = v1Stpt.Elev;
                v2Stpt.Enabled = v1Stpt.Enabled;
            }

            foreach (var ppKV in v1Station.PP)
            {
                var v1PP = v1Station.PP[ppKV.Key];
                var v2PP = v2Station.PP[ppKV.Key];
                v2PP.Lat = v1PP.Lat;
                v2PP.Lon = v1PP.Lon;
                v2PP.Elev = v1PP.Elev;
                v2PP.Enabled = v1PP.Enabled;
            }
        }
    }

    private static void CopySequences(FA18ConfigurationV1 v1, FA18ConfigurationV2 v2)
    {
        if (v1.Sequences == null) return;
        v2.Sequences.EnableUpload1 = v1.Sequences.EnableUpload1;
        v2.Sequences.EnableUpload2 = v1.Sequences.EnableUpload2;
        v2.Sequences.EnableUpload3 = v1.Sequences.EnableUpload3;
        v2.Sequences.Seq1.Mode = SequenceMode.UseSpecific;
        v2.Sequences.Seq2.Mode = SequenceMode.UseSpecific;
        v2.Sequences.Seq3.Mode = SequenceMode.UseSpecific;
        v2.Sequences.Seq1.Waypoints = new List<int>(v1.Sequences.Seq1._seq);
        v2.Sequences.Seq2.Waypoints = new List<int>(v1.Sequences.Seq2._seq);
        v2.Sequences.Seq3.Waypoints = new List<int>(v1.Sequences.Seq3._seq);
    }

    private static void CopyWaypoints(FA18ConfigurationV1 v1, FA18ConfigurationV2 v2)
    {
        if (v1.Waypoints == null) return;
        v2.Waypoints.Waypoints.AddRange(v1.Waypoints.Waypoints.Select(CopyWaypoint));
    }

    private static Waypoint CopyWaypoint(V1.Aircrafts.FA18.Waypoint w)
    {
        var coord = Coordinate.FromString(w.Latitude, w.Longitude);
        var latlon = coord.ToHornetPreciseSteerpointFormat();
        var wpt = new Waypoint()
        {
            Sequence = w.Sequence,
            Name = w.Name,
            Latitude = latlon.Lat,
            Longitude = latlon.Lon,
            Elevation = w.Elevation
        };

        return wpt;
    }

    private static void CopyUpload(FA18ConfigurationV1 v1, FA18ConfigurationV2 v2)
    {
        if (v1.Waypoints != null) v2.Upload.Waypoints = v1.Waypoints.EnableUpload;
        if (v1.Sequences != null) v2.Upload.Sequences = v1.Sequences.EnableUpload;
        if (v1.PrePlanned != null) v2.Upload.PrePlanned = v1.PrePlanned.EnableUpload;
        if (v1.Radios != null) v2.Upload.Radios = v1.Radios.EnableUpload;
        if (v1.CMS != null) v2.Upload.CMS = v1.CMS.EnableUpload;
        if (v1.Misc != null) v2.Upload.Misc = v1.Misc.EnableUpload;
    }
}
