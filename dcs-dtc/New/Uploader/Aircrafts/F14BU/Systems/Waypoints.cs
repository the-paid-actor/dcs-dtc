using DTC.New.Presets.V2.Aircrafts.F14BU.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.F14BU;

public partial class F14BUUploader
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
        //foreach (var c in str.ToUpper())
        //{
        //    if (c == ' ')
        //    {
        //        continue;
        //    }
        //    try
        //    {
        //        Cmd(UFC.GetCommand("BTN" + c));
        //    }
        //    catch
        //    {
        //        continue;
        //    }
        //}
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {
    }
}
