﻿using DTC.Models.DCS;
using DTC.Models.AH64.Waypoints;
using System.Text;
using DTC.Models.F16;

namespace DTC.Models.AH64.Upload
{
    public class WaypointBuilder : BaseBuilder
    {
        private AH64Configuration _cfg;

        public WaypointBuilder(AH64Configuration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var wpts = _cfg.Waypoints.Waypoints;
            var wptStart = _cfg.Waypoints.SteerpointStart;
            var wptEnd = _cfg.Waypoints.SteerpointEnd;

            if (wpts.Count == 0)
            {
                return;
            }

            var wptDiff = wptEnd - wptStart + 1;

            var mpd = _aircraft.GetDevice("CPG_Right_MPD");
            var ku = _aircraft.GetDevice("CPG_KU");

            AppendCommand(mpd.GetCommand("TSD"));
            for (var i = 0; i < wptDiff; i++)
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
                AppendCommand(mpd.GetCommand("B6"));
                AppendCommand(mpd.GetCommand("L2"));
                if (wpt.Type == "WP")
                {
                    AppendCommand(mpd.GetCommand("L3"));
                }
                if (wpt.Type == "HZ")
                {
                    AppendCommand(mpd.GetCommand("L4"));
                }
                if (wpt.Type == "TG")
                {
                    AppendCommand(mpd.GetCommand("L6"));
                }
                AppendCommand(mpd.GetCommand("L1"));

                AppendCommand(BuildString(ku,wpt.Ident));
                AppendCommand(ku.GetCommand("ENTR"));
                AppendCommand(BuildString(ku, wpt.Free));
                AppendCommand(ku.GetCommand("ENTR"));
                AppendCommand(ClearKU(ku));
                AppendCommand(BuildString(ku, wpt.Mgrs));
                AppendCommand(ku.GetCommand("ENTR"));
                AppendCommand(ku.GetCommand("ENTR"));
                AppendCommand(mpd.GetCommand("TSD"));
            }
            AppendCommand(mpd.GetCommand("TSD"));

        }

        private string BuildString(Device ku, string mgrs)
        {
            var sb = new StringBuilder();

            var mgrsStr = RemoveSeparators(mgrs.Replace(" ", ""));

            foreach (var c in mgrsStr.ToCharArray())
            {
                sb.Append(ku.GetCommand(c.ToString()));
            }

            return sb.ToString();
        }
        private string ClearKU(Device ku)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                sb.Append(ku.GetCommand("BKS"));
            }

            return sb.ToString();
        }
    }
}