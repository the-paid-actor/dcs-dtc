using DTC.New.Presets.V2.Aircrafts.OH58D.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.OH58D;

public partial class OH58DUploader
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
            try
            {
                if (c >= '0' && c <= '9')
                {
                    Cmd(Keyboard.GetCommand("Num" + c));
                }
                else if (c=='.')
                {
                    Cmd(Keyboard.NumDecimal);
                }
                else if (c == ' ')
                {
                    Cmd(Keyboard.Space);
                }
                else if (c == '-')
                {
                    Cmd(Keyboard.Minus);
                }
                else
                {
                    Cmd(Keyboard.GetCommand(c.ToString()));
                }
            }
            catch
            {
                continue;
            }
        }
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {
        Cmd(new CustomCommand($"ToWpPage()"));
       // return ;
        foreach (var wpt in config.Waypoints.Waypoints)
        {

            Cmd(LineAddress.L1);
            Cmd(Keyboard.LineClear);
            strToCmd(wpt.Sequence.ToString()+"W");
            Cmd(Keyboard.Enter);

            Cmd(LineAddress.L2);
            Cmd(Keyboard.LineClear);
            var coord = Coordinate.FromString(wpt.Latitude, wpt.Longitude).ToDegreesMinutesSeconds();
            strToCmd(new string(coord.Lat.Where(char.IsLetterOrDigit).ToArray()));
            Cmd(Keyboard.Enter);

            Cmd(LineAddress.L3);
            Cmd(Keyboard.LineClear);
            strToCmd(new string(coord.Lon.Where(char.IsLetterOrDigit).ToArray()));
            Cmd(Keyboard.Enter);

            Cmd(LineAddress.L4);
            Cmd(Keyboard.LineClear);
            strToCmd(wpt.Elevation.ToString());
            Cmd(Keyboard.Enter);

            Cmd(LineAddress.R5);

            Cmd(Wait(500));


        }
        //    strToCmd(kuris.ToString());
        //    Cmd(UFC.ENTER);
        //    Cmd(ODU.OPT2);

        //    var coord = Coordinate.FromString(wpt.Latitude, wpt.Longitude);
        //    var k = coord.ToDegreesMinutesSeconds();
        //    var X = k.Lat.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "").Replace("”","");
        //    var Y = k.Lon.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "").Replace("”", ""); ;

        //    strToCmd(X);
        //    Cmd(UFC.ENTER);
        //    strToCmd(Y);
        //    Cmd(UFC.ENTER);
        //    Cmd(ODU.OPT3);
        //    strToCmd(wpt.Elevation.ToString());
        //    Cmd(UFC.ENTER);
        //    Cmd(ODU.OPT1);
        //    kuris++;
        //}

        //Cmd(MPCD.L2);
    }
}
