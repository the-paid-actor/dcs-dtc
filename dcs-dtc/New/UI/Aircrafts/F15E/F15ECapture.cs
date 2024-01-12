using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.F15E;

internal class F15ECapture
{
    private F15EPage page;
    private F15EConfiguration cfg;

    public F15ECapture(F15EPage page, F15EConfiguration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        if (data.resetAllSmart)
        {
            page.GetSmartWeaponsPage().ResetAll();
            return;
        }

        var configBefore = (F15EConfiguration)cfg.Clone();

        CaptureSmartWeapons(data.data, cfg, configBefore);
        CaptureSteerpoints(data, cfg);

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }
    }

    private void CaptureSmartWeapons(WaypointCaptureWptData[] data, F15EConfiguration cfg, F15EConfiguration cfgBefore)
    {
        foreach (var d in data)
        {
            if (!d.smart) continue;
            var coord = Coordinate.FromDCS(d.latitude, d.longitude).ToF15EFormat();
            var elevation = int.Parse(d.elevation);
            string station;

            switch (d.smartStation)
            {
                case "LCFT F": station = StationNames.LCFTFRONT; break;
                case "LCFT M": station = StationNames.LCFTMID; break;
                case "LCFT R": station = StationNames.LCFTREAR; break;
                case "RCFT F": station = StationNames.RCFTFRONT; break;
                case "RCFT M": station = StationNames.RCFTMID; break;
                case "RCFT R": station = StationNames.RCFTREAR; break;
                case "L WING": station = StationNames.LWING; break;
                case "R WING": station = StationNames.RWING; break;
                case "CENTER": station = StationNames.CENTERLINE; break;
                default:
                    continue;
            }

            var c = new SmartWeaponSetting()
            {
                Latitude = coord.Lat,
                Longitude = coord.Lon,
                Elevation = elevation
            };

            cfg.SmartWeapons.Set(station, c);
            cfgBefore.SmartWeapons.Stations.Remove(station);
        }

        page.SavePreset();
        page.GetSmartWeaponsPage().RefreshButtons();
    }

    private void CaptureSteerpoints(WaypointCaptureData data, F15EConfiguration cfg)
    {
        foreach (var d in data.data)
        {
            if (d.smart) continue;
            var coord = Coordinate.FromDCS(d.latitude, d.longitude).ToF15EFormat();
            var wpt = new Waypoint();
            wpt.Latitude = coord.Lat;
            wpt.Longitude = coord.Lon;
            wpt.Elevation = int.Parse(d.elevation);
            wpt.Target = d.target;

            WaypointSystem wptSystem;
            if (d.route == "A") wptSystem = cfg.RouteA;
            else if (d.route == "B") wptSystem = cfg.RouteB;
            else if (d.route == "C") wptSystem = cfg.RouteC;
            else continue;

            if (!wpt.Target)
            {
                if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToEndOfList)
                {
                    wpt.Sequence = wptSystem.GetNextSequence();
                }
                else if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceOfFirstGap();
                }
                else if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToRange)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceFromSequence(cfg.WaypointsCapture.NavPointsRangeFrom);
                }
                wpt.Name = "STPT " + wpt.Sequence;
                wptSystem.Add(wpt);
            }
            else
            {
                if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToEndOfList)
                {
                    wpt.Sequence = wptSystem.GetNextSequence();
                }
                else if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceOfFirstGap();
                }
                else if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToRange)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceFromSequence(cfg.WaypointsCapture.TgtPointsRangeFrom);
                }
                wpt.Name = "TGT " + wpt.Sequence;
                wptSystem.Add(wpt);
            }
        }

        cfg.RouteA.ReorderBySequence();
        cfg.RouteB.ReorderBySequence();
        cfg.RouteC.ReorderBySequence();

        page.SavePreset();
        page.RefreshRoutePages();
    }

    private void UploadCapture(F15EConfiguration cfgBefore, F15EConfiguration cfgAfter)
    {
        var cfgUpload = (F15EConfiguration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

        RemoveIdenticalSmartWeapons(cfgBefore, cfgAfter, cfgUpload);
        RemoveIdenticalWpts(cfgBefore.RouteA, cfgAfter.RouteA, cfgUpload.RouteA);
        RemoveIdenticalWpts(cfgBefore.RouteB, cfgAfter.RouteB, cfgUpload.RouteB);
        RemoveIdenticalWpts(cfgBefore.RouteC, cfgAfter.RouteC, cfgUpload.RouteC);

        if (cfgUpload.SmartWeapons.Stations.Count > 0)
        {
            cfgUpload.Upload.SmartWeapons = true;
        }

        cfgUpload.Upload.RouteA = cfgUpload.RouteA.Waypoints.Count > 0;
        cfgUpload.Upload.RouteB = cfgUpload.RouteB.Waypoints.Count > 0;
        cfgUpload.Upload.RouteC = cfgUpload.RouteC.Waypoints.Count > 0;

        page.UploadToJet(cfgUpload);
    }

    private static void RemoveIdenticalSmartWeapons(F15EConfiguration cfgBefore, F15EConfiguration cfgAfter, F15EConfiguration cfgUpload)
    {
        foreach (var kv in cfgAfter.SmartWeapons.Stations)
        {
            if (cfgBefore.SmartWeapons.Stations.ContainsKey(kv.Key))
            {
                var stationBefore = cfgBefore.SmartWeapons.Stations[kv.Key];
                var stationAfter = kv.Value;
                var diff = false;

                if (stationBefore.Settings != null && stationAfter.Settings != null &&
                    stationBefore.Settings.Length == stationAfter.Settings.Length)
                {
                    for (var i = 0; i < stationBefore.Settings.Length; i++)
                    {
                        var settingBefore = stationBefore.Settings[i];
                        var settingAfter = stationAfter.Settings[i];

                        if (settingBefore.Latitude != settingAfter.Latitude ||
                            settingBefore.Longitude != settingAfter.Longitude ||
                            settingBefore.Elevation != settingAfter.Elevation)
                        {
                            diff = true;
                            break;
                        }
                    }
                }
                else
                {
                    diff = true;
                }

                if (!diff)
                {
                    cfgUpload.SmartWeapons.Stations.Remove(kv.Key);
                }
            }
        }
    }

    private static void RemoveIdenticalWpts(WaypointSystem cfgBefore, WaypointSystem cfgAfter, WaypointSystem cfgUpload)
    {
        var wptsToRemove = new List<Waypoint>();

        foreach (var wptAfter in cfgAfter.Waypoints)
        {
            var wptBefore = cfgBefore.GetBySequence(wptAfter.Sequence);
            if (wptBefore != null)
            {
                if (cfgAfter.IsEqual(wptBefore, wptAfter))
                {
                    wptsToRemove.Add(wptBefore);
                }
            }
        }

        foreach (var wpt in wptsToRemove)
        {
            cfgUpload.Waypoints.Remove(cfgUpload.GetBySequence(wpt.Sequence));
        }
    }
}
