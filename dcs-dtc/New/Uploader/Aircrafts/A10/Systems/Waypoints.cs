using DTC.New.Presets.V2.Aircrafts.A10.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.A10;

public partial class A10Uploader
{
    private void BuildWaypoints(bool pilot)
    {
        if (config.Upload.Waypoints && config.Waypoints != null && config.Waypoints.HasWaypoints())
        {
            UploadPoints(config.Waypoints, true);
        }
    }
    private void strToCmd(string str, int max)
    {
        strToCmd(str.Substring(0, Math.Min(max, str.Length)));
    }

    private void strToCmd(string str)
    {
        foreach (var c in str.ToUpper())
        {
            if (c == ' ')
            {
                continue;
            }
            Cmd(SYS.GetCommand("CDU_BTN_" + c));
        }
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {
        Cmd(SYS.CDU_BTN_CLR);
        Cmd(SYS.BTN_WP);
        Cmd(SYS.CDU_LSK_L3);

        Cmd(new CustomCommand($"SetInputFormat()"));

        var maxW = 0;
        foreach (var wpt in config.Waypoints.Waypoints)
        {
            if (wpt.Sequence > maxW)
            {
                maxW = wpt.Sequence;
            }
        }

        if (maxW > 0)
        {
            Cmd(new CustomCommand($"SetReqWptQty({maxW.ToString()})"));
        }

        foreach (var wpt in config.Waypoints.Waypoints)
        {

            strToCmd(wpt.Sequence.ToString());
            Cmd(SYS.CDU_LSK_L3);

            if (!string.IsNullOrEmpty(wpt.Name))
            {
                strToCmd(wpt.Name, 12);
                Cmd(SYS.CDU_LSK_R3);
            }

            var x = wpt.Latitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");
            var y = wpt.Longitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");
            strToCmd(x);
            Cmd(SYS.CDU_LSK_L7);
            strToCmd(y);
            Cmd(SYS.CDU_LSK_L9);
            if (wpt.Elevation > 0)
            {
                strToCmd(wpt.Elevation.ToString());
                Cmd(SYS.CDU_LSK_L5);
            }
        }
    }
}
