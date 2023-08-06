using DTC.Models.Base;
using DTC.Models.FA18;
using DTC.Models.FA18.Waypoints;
using DTC.Models.Presets;
using DTC.UI.CommonPages;
using System.Collections.Generic;

namespace DTC.UI.Aircrafts.FA18
{
    internal class FA18Page : AircraftPage
    {
        public FA18Page(Aircraft aircraft, Preset preset)
            : base(aircraft, preset)
        {
        }

        protected override AircraftSettingPage[] GetPages(IConfiguration configuration)
        {
            var cfg = (FA18Configuration)configuration;
            return new AircraftSettingPage[]
            {
                new UploadToJetPage(this, cfg),
                new LoadSavePage(this, cfg),
                new WaypointsPage(this, cfg.Waypoints),
                new WaypointCapturePage(this, cfg.Waypoints.CaptureSettings),
                new SequencePage(this, cfg.Sequences),
                new PrePlannedPage(this, cfg.PrePlanned),
                new CMSPage(this, cfg.CMS),
                new RadioPage(this, cfg.Radios),
                new MiscPage(this, cfg.Misc)
            };
        }

        protected override void WaypointCaptureReceived(WaypointCaptureData[] data)
        {
            var cfg = ((FA18Configuration)_preset.Configuration);
            var wpts = cfg.Waypoints;
            var settings = cfg.Waypoints.CaptureSettings;

            if (settings == null) return;

            var newWptList = new List<Waypoint>();

            foreach (var d in data)
            {
                var coord = Coordinate.FromString(d.latitude, d.longitude, CoordinateFormat.NativeDCSFormat);
                var wpt = new Waypoint(0);
                wpt.SetCoordinate(coord.ToDegreesMinutesHundredths());
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

                var current = start - 1;

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
        }
    }
}
