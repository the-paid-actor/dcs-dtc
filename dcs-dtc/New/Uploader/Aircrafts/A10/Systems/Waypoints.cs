using DTC.New.Presets.V2.Aircrafts.A10.Systems;
using DTC.New.Presets.V2.Base.Systems;

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

        foreach (var wpt in config.Waypoints.Waypoints)
        {
            strToCmd(wpt.Name);
            Cmd(SYS.CDU_LSK_R7);

            var x = wpt.Latitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’","");
            var y = wpt.Longitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");
            strToCmd(x);
            Cmd(SYS.CDU_LSK_L7);
            strToCmd(y);
            Cmd(SYS.CDU_LSK_L9);
            strToCmd(wpt.Elevation.ToString());
            Cmd(SYS.CDU_LSK_L5);
        }
    }
}
