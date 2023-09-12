using DTC.Models.DCS;
using DTC.Models.F15E.Waypoints;
using System.Collections.Generic;
using System.Text;

namespace DTC.Models.F15E.Upload
{
    public class WaypointBuilder : BaseBuilder
    {
        private F15EConfiguration _cfg;

        public WaypointBuilder(F15EConfiguration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var wpts = _cfg.Waypoints.Waypoints;
            if (wpts.Count == 0)
            {
                return;
            }

            var wptStart = 1;
            var wptEnd = wpts.Count;

            if (_cfg.Waypoints.OverrideRange)
            {
                wptStart = _cfg.Waypoints.SteerpointStart;
                wptEnd = _cfg.Waypoints.SteerpointEnd;
            }

            var wptLength = wptEnd - wptStart + 1;
            var ufc = _aircraft.GetDevice("UFC_PILOT");

            var jetStpts = new Dictionary<string, Waypoint>();
            for (var i = 0; i < wptLength; i++)
            {
                Waypoint wpt;
                if (i < wpts.Count)
                {
                    wpt = wpts[i];
                }
                else
                {
                    //Repeats the last waypoint till it fills
                    wpt = wpts[wpts.Count - 1];
                }

                string stptId = (i + wptStart).ToString();
                jetStpts.Add(stptId, wpt);
            }

            AppendCommand(StartCondition("GoToFrontCockpit"));
            AppendCommand(EndCondition("GoToFrontCockpit"));

            BuildWaypoints(ufc, jetStpts);
        }

        private void BuildWaypoints(Device ufc, Dictionary<string, Waypoint> jetStpts)
        {
            AppendCommand(ufc.GetCommand("CLR"));
            AppendCommand(ufc.GetCommand("CLR"));
            AppendCommand(ufc.GetCommand("MENU"));
            AppendCommand(ufc.GetCommand("SHF"));
            AppendCommand(ufc.GetCommand("3")); //B
            AppendCommand(ufc.GetCommand("PB10"));
            AppendCommand(ufc.GetCommand("PB10"));

            foreach (var kv in jetStpts)
            {
                var stptId = kv.Key;
                var wpt = kv.Value;

                AppendCommand(BuildDigits(ufc, stptId));
                AppendCommand(ufc.GetCommand("SHF"));
                AppendCommand(ufc.GetCommand("1"));
                AppendCommand(ufc.GetCommand("PB1"));

                AppendCommand(StartCondition("IsStrDifferent", "STR " + stptId + "A"));
                AppendCommand(ufc.GetCommand("CLR"));
                AppendCommand(ufc.GetCommand("CLR"));
                AppendCommand(BuildDigits(ufc, stptId));
                AppendCommand(ufc.GetCommand("."));
                AppendCommand(ufc.GetCommand("SHF"));
                AppendCommand(ufc.GetCommand("1"));
                AppendCommand(ufc.GetCommand("PB1"));
                AppendCommand(EndCondition("IsStrDifferent"));

                AppendCommand(StartCondition("IsStrDifferent", "STR " + stptId + "A"));
                AppendCommand(BuildDigits(ufc, stptId));
                AppendCommand(ufc.GetCommand("SHF"));
                AppendCommand(ufc.GetCommand("1"));
                AppendCommand(ufc.GetCommand("PB1"));
                AppendCommand(EndCondition("IsStrDifferent"));

                if (wpt.Target)
                {
                    AppendCommand(BuildDigits(ufc, stptId));
                    AppendCommand(ufc.GetCommand("."));
                    AppendCommand(ufc.GetCommand("SHF"));
                    AppendCommand(ufc.GetCommand("1"));
                    AppendCommand(ufc.GetCommand("PB1"));
                }

                if (!wpt.IsCoordinateBlank)
                {
                    AppendCommand(Helper.BuildCoordinate(ufc, wpt.Latitude));
                    AppendCommand(ufc.GetCommand("PB2"));
                }

                if (!wpt.IsCoordinateBlank)
                {
                    AppendCommand(Helper.BuildCoordinate(ufc, wpt.Longitude));
                    AppendCommand(ufc.GetCommand("PB3"));
                }

                if (!wpt.IsCoordinateBlank)
                {
                    AppendCommand(BuildDigits(ufc, wpt.Elevation.ToString()));
                    AppendCommand(ufc.GetCommand("PB7"));
                }
            }

            AppendCommand(ufc.GetCommand("MENU"));
            AppendCommand(ufc.GetCommand("1"));
            AppendCommand(ufc.GetCommand("SHF"));
            AppendCommand(ufc.GetCommand("1"));
            AppendCommand(ufc.GetCommand("PB10"));
        }

        private class Helper
        {
            public static string BuildCoordinate(Device ufc, string coord)
            {
                var sb = new StringBuilder();

                var latStr = RemoveSeparators(coord.Replace(" ", ""));

                foreach (var c in latStr.ToCharArray())
                {
                    if (c == 'N')
                    {
                        sb.Append(ufc.GetCommand("SHF"));
                        sb.Append(ufc.GetCommand("2"));
                    }
                    else if (c == 'S')
                    {
                        sb.Append(ufc.GetCommand("SHF"));
                        sb.Append(ufc.GetCommand("8"));
                    }
                    else if (c == 'E')
                    {
                        sb.Append(ufc.GetCommand("SHF"));
                        sb.Append(ufc.GetCommand("6"));
                    }
                    else if (c == 'W')
                    {
                        sb.Append(ufc.GetCommand("SHF"));
                        sb.Append(ufc.GetCommand("4"));
                    }
                    else
                    {
                        sb.Append(ufc.GetCommand(c.ToString()));
                    }
                }

                return sb.ToString();
            }
        }
    }
}
