using DTC.New.Presets.V2.Aircrafts.C130.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace DTC.New.Uploader.Aircrafts.C130;

public partial class C130Uploader
{
    private void BuildWaypoints(bool pilot)
    {
       
        if (config.Upload.Waypoints && config.Waypoints != null && config.Waypoints.HasWaypoints())
        {
            UploadPoints(config.Waypoints/*, "W", display, keyboard*/, true);
        }
        /*if (config.Upload.ControlMeasures && config.ControlMeasures != null && config.ControlMeasures.HasWaypoints())
        {
            UploadPoints(config.ControlMeasures, "C", display, keyboard, false);
        }
       */
    }

    private void strToCmd(string str)
    {
        foreach (var c in str.ToUpper())
        {
            if (c == ' ')
            {
                continue;
            }
            Cmd(CNI.GetCommand("Btn" + c));
        }
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {

        Cmd(CNI.CLR);
        Cmd(CNI.CLR);
        Cmd(CNI.Index);
        Cmd(CNI.NextPage);
        Cmd(CNI.LSK_R2);
        foreach (var wpt in config.Waypoints.Waypoints)
        {

            strToCmd(wpt.Name);
            Cmd(CNI.LSK_L1);


            var coord = Coordinate.FromString(wpt.Latitude, wpt.Longitude);
            var mgrs = coord.ToMGRSEightDigits().Replace(" ", "");

            strToCmd(mgrs);
            Cmd(CNI.LSK_L2);


            strToCmd(wpt.Elevation.ToString());

            Cmd(CNI.LSK_L3);
            Cmd(CNI.LSK_R6);

        }

        }
    
    
}