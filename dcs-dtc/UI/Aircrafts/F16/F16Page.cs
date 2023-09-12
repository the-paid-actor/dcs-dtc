using DTC.Utilities;
using DTC.Models.F16;
using DTC.Models.F16.Waypoints;
using DTC.Models.Presets;
using DTC.UI.CommonPages;

namespace DTC.UI.Aircrafts.F16
{
    internal class F16Page : AircraftPage
    {
        public F16Page(Aircraft aircraft, Preset preset)
            : base(aircraft, preset)
        {
        }

        protected override AircraftSettingPage[] GetPages(IConfiguration configuration)
        {
            var cfg = (F16Configuration)configuration;
            return new AircraftSettingPage[]
            {
                new UploadToJetPage(this, cfg),
                new LoadSavePage(this, cfg),
                new WaypointsPage(this, cfg.Waypoints),
                new WaypointCapturePage(this, cfg.Waypoints.CaptureSettings),
                new CMSPage(this, cfg.CMS),
                new RadioPage(this, cfg.Radios),
                new MFDPage(this, cfg.MFD),
                new HARMPage(this, cfg.HARM),
                new HTSPage(this, cfg.HTS),
                new MiscPage(this, cfg.Misc)
            };
        }


        protected override void WaypointCaptureReceived(WaypointCaptureData[] data)
        {
            var cfg = ((F16Configuration)_preset.Configuration);
            var wpts = cfg.Waypoints;
            var settings = cfg.Waypoints.CaptureSettings;

            if (settings == null) return;

            var newWptList = new List<Waypoint>();

            foreach (var d in data)
            {
                var coord = Coordinate.FromString(d.latitude, d.longitude, CoordinateFormat.NativeDCSFormat);
                var wpt = new Waypoint(0);
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