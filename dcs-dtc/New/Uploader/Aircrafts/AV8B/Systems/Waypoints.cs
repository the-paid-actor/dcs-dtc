using DTC.New.Presets.V2.Aircrafts.AV8B.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.AV8B;

public partial class AV8BUploader
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
            Cmd(UFC.GetCommand("BTN" + c));
        }
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {
        Cmd(new CustomCommand($"SetLeftMfd()"));

        Cmd(MPCD.L2);

        var kuris = 1;
        foreach (var wpt in config.Waypoints.Waypoints)
        {
            strToCmd(kuris.ToString());
            Cmd(UFC.ENTER);
            Cmd(ODU.OPT2);

            var coord = Coordinate.FromString(wpt.Latitude, wpt.Longitude);
            var k = coord.ToDegreesMinutesSeconds();
            var X = k.Lat.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "").Replace("”","");
            var Y = k.Lon.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "").Replace("”", ""); ;

            strToCmd(X);
            Cmd(UFC.ENTER);
            strToCmd(Y);
            Cmd(UFC.ENTER);
            Cmd(ODU.OPT3);
            strToCmd(wpt.Elevation.ToString());
            Cmd(UFC.ENTER);
            Cmd(ODU.OPT1);
            kuris++;
        }

        Cmd(MPCD.L2);
    }
}
