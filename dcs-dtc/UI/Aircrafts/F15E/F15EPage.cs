using DTC.Models.Base;
using DTC.Models.F15E;
using DTC.Models.F15E.Waypoints;
using DTC.Models.Presets;
using DTC.UI.CommonPages;
using System.Collections.Generic;

namespace DTC.UI.Aircrafts.F15E
{
    internal class F15EPage : AircraftPage
    {
        public F15EPage(Aircraft aircraft, Preset preset)
            : base(aircraft, preset)
        {
        }

        protected override AircraftSettingPage[] GetPages(IConfiguration configuration)
        {
            var cfg = configuration as F15EConfiguration;
            return new AircraftSettingPage[]
            {
                new UploadToJetPage(this, cfg),
                new LoadSavePage(this, cfg),
                new WaypointsPage(this, cfg.Waypoints),
                new WaypointCapturePage(this, cfg.Waypoints.CaptureSettings),
                new RadiosPage(this, cfg.Radios),
                new DisplaysPage(this, cfg.Displays),
                new MiscPage(this, cfg.Misc)
            };
        }

        protected override void WaypointCaptureReceived(WaypointCaptureData[] data)
        {
            var cfg = ((F15EConfiguration)_preset.Configuration);
            var wpts = cfg.Waypoints;
            var settings = cfg.Waypoints.CaptureSettings;
            if (settings == null) return;

            var newWptList = new List<Waypoint>();

            foreach (var d in data)
            {
                var coord = Coordinate.FromString(d.latitude, d.longitude, CoordinateFormat.NativeDCSFormat);
                var wpt = new Waypoint(0);
                wpt.Target = d.target;
                wpt.SetCoordinate(coord.ToDegreesMinutesThousandths());
                wpt.Elevation = int.Parse(d.elevation);
                newWptList.Add(wpt);
            }

            if (settings.AppendToWaypointList)
            {
                foreach (var wpt in newWptList)
                {
                    var w = wpts.Add(wpt);
                    w.AutoName();
                }
            }
            else
            {
                var start = settings.OverwriteFrom;
                var end = start + newWptList.Count - 1;
                if (settings.OverwriteUntil > 0)
                {
                    end = settings.OverwriteUntil;
                }

                var current = start-1;

                foreach (var newWpt in newWptList)
                {
                    current++;
                    if (current > end) break;

                    var idxToInsert = wpts.Waypoints.Count;
                    Waypoint changedWpt = null;
                    Waypoint nextWpt = null;
                    foreach (var wpt in wpts.Waypoints)
                    {
                        if (wpt.Sequence == current)
                        {
                            changedWpt = wpt;
                            wpt.Latitude = newWpt.Latitude;
                            wpt.Longitude = newWpt.Longitude;
                            wpt.Elevation = newWpt.Elevation;
                            wpt.Target = newWpt.Target;
                            wpt.AutoName();
                            break;
                        }
                        if (wpt.Sequence > current)
                        {
                            nextWpt = wpt;
                            break;
                        }
                    }

                    if (changedWpt != null)
                    {
                        continue;
                    }

                    if (nextWpt != null)
                    {
                        idxToInsert = wpts.Waypoints.IndexOf(nextWpt);
                    }


                    newWpt.Sequence = current;
                    newWpt.AutoName();
                    wpts.Insert(idxToInsert, newWpt);
                }
            }

            this.DataChangedCallback();

            var page = GetPageOfType<WaypointsPage>();
            (page as WaypointsPage).RefreshList();

            //if (settings.Upload)
            //{
            //    var cfg = config.Clone();

            //    if (!settings.UploadSourceAll)
            //    {
            //        var start = settings.UploadSourceFrom;
            //        var end = 999;
            //        if (settings.UploadSourceUntil > 0)
            //        {
            //            end = settings.UploadSourceUntil;
            //        }
            //        cfg.Waypoints.Waypoints.Clear();
            //        foreach (var wpt in config.Waypoints.Waypoints)
            //        {
            //            if (wpt.Sequence >= start && wpt.Sequence <= end)
            //            {
            //                cfg.Waypoints.Waypoints.Add(wpt);
            //            }
            //        }
            //    }


            //    if (settings.UploadDestFrom > 1 || settings.UploadDestUntil > 0)
            //    {
            //        cfg.Waypoints.OverrideRange = true;
            //        cfg.Waypoints.SteerpointStart = settings.UploadDestFrom;
            //        cfg.Waypoints.SteerpointEnd = settings.UploadDestUntil;
            //    }

            //    var upload = new F15EUpload(cfg);
            //    upload.Load();

            //}
        }
    }
}
