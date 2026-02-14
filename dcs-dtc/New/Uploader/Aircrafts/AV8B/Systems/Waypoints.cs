using DTC.New.Presets.V2.Aircrafts.AV8B.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.Collections.Generic;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace DTC.New.Uploader.Aircrafts.AV8B;

public partial class AV8BUploader
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
            Cmd(UFC.GetCommand("BTN" + c));
        }
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {


        Cmd(new CustomCommand($"SetLeftMfd()"));

        Cmd(MPCD.L2);
        //MPCD
        /*Cmd(CDU.CLR); Cmd(CDU.CLR); Cmd(CDU.CLR);
        Cmd(CDU.IDX);
        Cmd(CDU.LSK_L6);
        Cmd(CDU.LSK_L6);
        */
        var kuris = 1;
        foreach (var wpt in config.Waypoints.Waypoints)
        {

            //Cmd(ODU.OPT1);
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

            /*

            var x = wpt.Latitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");
            var y = wpt.Longitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");

            
            strToCmd(x.Substring(0,5)+y.Substring(0, 6));
            Cmd(CDU.LSK_L1);
            //Cmd(CNI.LSK_L2);


            strToCmd(wpt.Elevation.ToString());
            Cmd(CDU.LSK_L3);

            if (wpt.Name != "")
            {
                Cmd(CDU.SLASH);
                strToCmd(wpt.Name);
                Cmd(CDU.LSK_L2);
            }

             

            //Cmd(CNI.LSK_L3);
            //Cmd(CNI.LSK_R6);
            */
        }
        
        Cmd(MPCD.L2);

    }


}
