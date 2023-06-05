using DTC.Models.DCS;
using DTC.Models.F16.Waypoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTC.Models.F16.Upload
{
    public class WaypointBuilder : BaseBuilder
    {
        private F16Configuration _cfg;

        public WaypointBuilder(F16Configuration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
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
            var ufc = _aircraft.GetDevice("UFC");

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

            BuildWaypoints(ufc, jetStpts);
            BuildVIP(ufc, jetStpts);
            BuildVRP(ufc, jetStpts);
        }

        private void BuildWaypoints(Device ufc, Dictionary<string, Waypoint> jetStpts)
        {
            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("1"));
            AppendCommand(ufc.GetCommand("SEQ"));

            foreach (var kv in jetStpts)
            {
                var stptId = kv.Key;
                var wpt = kv.Value;

                AppendCommand(BuildDigits(ufc, stptId));
                AppendCommand(ufc.GetCommand("ENTR"));
                AppendCommand(ufc.GetCommand("DOWN"));

                if (_cfg.Waypoints.EnableUploadCoordsElevation && !wpt.IsCoordinateBlank)
                {
                    AppendCommand(Helper.BuildCoordinate(ufc, wpt.Latitude));
                    AppendCommand(ufc.GetCommand("ENTR"));
                }
                AppendCommand(ufc.GetCommand("DOWN"));

                if (_cfg.Waypoints.EnableUploadCoordsElevation && !wpt.IsCoordinateBlank)
                {
                    AppendCommand(Helper.BuildCoordinate(ufc, wpt.Longitude));
                    AppendCommand(ufc.GetCommand("ENTR"));
                }
                AppendCommand(ufc.GetCommand("DOWN"));

                if (_cfg.Waypoints.EnableUploadCoordsElevation && !wpt.IsCoordinateBlank)
                {
                    AppendCommand(BuildDigits(ufc, wpt.Elevation.ToString()));
                    AppendCommand(ufc.GetCommand("ENTR"));
                }
                AppendCommand(ufc.GetCommand("DOWN"));

                if (_cfg.Waypoints.EnableUploadTOS && !string.IsNullOrEmpty(wpt.TimeOverSteerpoint))
                {
                    AppendCommand(Helper.BuildTimeString(ufc, wpt.TimeOverSteerpoint));
                    AppendCommand(ufc.GetCommand("ENTR"));
                }
                AppendCommand(ufc.GetCommand("DOWN"));

                if (wpt.UseOA)
                {
                    AppendCommand(ufc.GetCommand("SEQ"));

                    BuildOA(ufc, stptId, wpt.OffsetAimpoint1);
                    AppendCommand(ufc.GetCommand("SEQ"));
                    BuildOA(ufc, stptId, wpt.OffsetAimpoint2);
                    AppendCommand(ufc.GetCommand("SEQ"));
                    AppendCommand(ufc.GetCommand("SEQ"));
                }
            }

            AppendCommand(ufc.GetCommand("1"));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildOA(Device ufc, string stptId, Offset oa)
        {
            AppendCommand(BuildDigits(ufc, stptId));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, oa.Range.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, Helper.GetNumberString(oa.Bearing)));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            if (oa.Elevation < 0)
            {
                AppendCommand(ufc.GetCommand("0"));
                AppendCommand(ufc.GetCommand("0"));
            }
            AppendCommand(BuildDigits(ufc, Math.Abs(oa.Elevation).ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));
        }

        private void BuildVIP(Device ufc, Dictionary<string, Waypoint> jetStpts)
        {
            string stptId = null;
            Waypoint wpt = null;

            foreach (var kv in jetStpts)
            {
                if (kv.Value.UseVIP)
                {
                    stptId = kv.Key;
                    wpt = kv.Value;
                }
            }

            if (stptId == null) return;

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("3"));

            AppendCommand(Wait());

            AppendCommand(StartCondition("VIP_TO_TGT_NOT_SELECTED"));
            AppendCommand(ufc.GetCommand("SEQ"));
            AppendCommand(EndCondition("VIP_TO_TGT_NOT_SELECTED"));

            AppendCommand(StartCondition("VIP_TO_TGT_NOT_HIGHLIGHTED"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(EndCondition("VIP_TO_TGT_NOT_HIGHLIGHTED"));

            BuildVIPDetail(ufc, stptId, wpt.VIPtoTGT);
            AppendCommand(ufc.GetCommand("SEQ"));

            AppendCommand(StartCondition("VIP_TO_PUP_NOT_HIGHLIGHTED"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(EndCondition("VIP_TO_PUP_NOT_HIGHLIGHTED"));

            BuildVIPDetail(ufc, stptId, wpt.VIPtoPUP);
            AppendCommand(ufc.GetCommand("SEQ"));
            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildVIPDetail(Device ufc, string stptId, Offset vip)
        {
            AppendCommand(ufc.GetCommand("DOWN"));
            AppendCommand(BuildDigits(ufc, stptId));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, Helper.GetNumberString(vip.Bearing)));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, Helper.GetNumberString(vip.Range)));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            if (vip.Elevation < 0)
            {
                AppendCommand(ufc.GetCommand("0"));
                AppendCommand(ufc.GetCommand("0"));
            }
            AppendCommand(BuildDigits(ufc, Math.Abs(vip.Elevation).ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));
        }

        private void BuildVRP(Device ufc, Dictionary<string, Waypoint> jetStpts)
        {
            string stptId = null;
            Waypoint wpt = null;

            foreach (var kv in jetStpts)
            {
                if (kv.Value.UseVRP)
                {
                    stptId = kv.Key;
                    wpt = kv.Value;
                }
            }

            if (stptId == null) return;

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("9"));

            AppendCommand(Wait());

            AppendCommand(StartCondition("TGT_TO_VRP_NOT_SELECTED"));
            AppendCommand(ufc.GetCommand("SEQ"));
            AppendCommand(EndCondition("TGT_TO_VRP_NOT_SELECTED"));

            AppendCommand(StartCondition("TGT_TO_VRP_NOT_HIGHLIGHTED"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(EndCondition("TGT_TO_VRP_NOT_HIGHLIGHTED"));

            BuildVRPDetail(ufc, stptId, wpt.TGTtoVRP);
            AppendCommand(ufc.GetCommand("SEQ"));

            AppendCommand(StartCondition("TGT_TO_PUP_NOT_HIGHLIGHTED"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(EndCondition("TGT_TO_PUP_NOT_HIGHLIGHTED"));

            BuildVRPDetail(ufc, stptId, wpt.TGTtoPUP);
            AppendCommand(ufc.GetCommand("SEQ"));
            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildVRPDetail(Device ufc, string stptId, Offset vrp)
        {
            AppendCommand(ufc.GetCommand("DOWN"));
            AppendCommand(BuildDigits(ufc, stptId));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, Helper.GetNumberString(vrp.Bearing)));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, vrp.Range.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            if (vrp.Elevation < 0)
            {
                AppendCommand(ufc.GetCommand("0"));
                AppendCommand(ufc.GetCommand("0"));
            }
            AppendCommand(BuildDigits(ufc, Math.Abs(vrp.Elevation).ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));
        }

        private class Helper
        {
            public static string GetNumberString(float bearing)
            {
                return bearing.ToString("###.0", System.Globalization.CultureInfo.InvariantCulture).Replace(".", "");
            }

            public static string BuildTimeString(Device ufc, string time)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < time.Length; i++)
                {
                    if (time[i] != ':')
                    {
                        sb.Append(ufc.GetCommand(time[i].ToString()));
                    }

                }
                return sb.ToString();
            }

            public static string BuildCoordinate(Device ufc, string coord)
            {
                var sb = new StringBuilder();

                var latStr = RemoveSeparators(coord.Replace(" ", ""));

                foreach (var c in latStr.ToCharArray())
                {
                    if (c == 'N')
                    {
                        sb.Append(ufc.GetCommand("2"));
                    }
                    else if (c == 'S')
                    {
                        sb.Append(ufc.GetCommand("8"));
                    }
                    else if (c == 'E')
                    {
                        sb.Append(ufc.GetCommand("6"));
                    }
                    else if (c == 'W')
                    {
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
