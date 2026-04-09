using DTC.New.Presets.V2.Aircrafts.CH47F.Systems;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Uploader.Aircrafts.CH47F;

public partial class CH47FUploader
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
        foreach (var cc in str.ToUpper())
        {
            var c = cc.ToString();
            if (c == " ")
            {
                continue;
            }
            if (c == ".")
            {
                c = "Point";
            }
            Cmd(CDU.GetCommand("Btn" + c));
        }
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {
        Cmd(CDU.CLR); Cmd(CDU.CLR); Cmd(CDU.CLR);
        Cmd(CDU.IDX);
        Cmd(CDU.LSK_L6);
        Cmd(CDU.LSK_L6);

        foreach (var wpt in config.Waypoints.Waypoints)
        {


            strToCmd(wpt.Sequence.ToString());
            Cmd(CDU.LSK_L1);

            var x = wpt.Latitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");
            var y = wpt.Longitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");

            var cmd = x.Substring(0, 5) + "." + x.Substring(x.Length - 3, 3) + y.Substring(0, 6) + "." + y.Substring(y.Length - 3, 3);
            strToCmd(cmd);
            Cmd(CDU.LSK_L1);

            strToCmd(wpt.Elevation.ToString());
            Cmd(CDU.LSK_L3);

            if (wpt.Name != "")
            {
                Cmd(CDU.SLASH);
                strToCmd(wpt.Name);
                Cmd(CDU.LSK_L2);
            }
        }
    }
}