using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F15E;

public partial class F15EUploader : Base.Uploader
{
    private void BuildWaypoints()
    {
        var hasRouteA = config.Upload.RouteA && config.RouteA != null && config.RouteA.Waypoints.Count > 0;
        var hasRouteB = config.Upload.RouteB && config.RouteB != null && config.RouteB.Waypoints.Count > 0;
        var hasRouteC = config.Upload.RouteC && config.RouteC != null && config.RouteC.Waypoints.Count > 0;

        if (!hasRouteA && !hasRouteB && !hasRouteC)
        {
            return;
        }

        StartIf(InFrontCockpit());
        {
            BuildRoutes(UFC_PILOT, hasRouteA, hasRouteB, hasRouteC);
        }
        EndIf();
        StartIf(InRearCockpit());
        {
            BuildRoutes(UFC_WSO, hasRouteA, hasRouteB, hasRouteC);
        }
        EndIf();
    }

    private void BuildRoutes(Device ufc, bool hasRouteA, bool hasRouteB, bool hasRouteC)
    {
        if (hasRouteA)
        {
            BuildWaypoints(ufc, config.RouteA.Waypoints, "A");
        }

        if (hasRouteB)
        {
            BuildWaypoints(ufc, config.RouteB.Waypoints, "B");
        }

        if (hasRouteC)
        {
            BuildWaypoints(ufc, config.RouteC.Waypoints, "C");
        }

        InputFirstWP(ufc, hasRouteA, hasRouteB, hasRouteC);
    }

    private void InputFirstWP(Device ufc, bool hasRouteA, bool hasRouteB, bool hasRouteC)
    {
        Waypoint wpt;
        string route;

        if (hasRouteA)
        {
            wpt = config.RouteA.Waypoints[0];
            route = "A";
        }
        else if (hasRouteB)
        {
            wpt = config.RouteB.Waypoints[0];
            route = "B";
        }
        else if (hasRouteC)
        {
            wpt = config.RouteC.Waypoints[0];
            route = "C";
        }
        else
        {
            return;
        }

        Cmd(ufc.GetCommand("MENU"));
        Cmd(Digits(ufc, wpt.Identifier.WaypointNumber.ToString()));
        if (wpt.Target)
        {
            Cmd(ufc.GetCommand("DOT"));
        }
        if(wpt.Offset)
        {
            if(wpt.Target)
            {
                Cmd(Digits(ufc, 0.ToString()));
            }
            Cmd(Digits(ufc, wpt.Identifier.WaypointOffsetNumber.ToString()));
        }
        Cmd(ufc.GetCommand("SHF"));
        if (route == "A")
        {
            Cmd(ufc.GetCommand("D1"));
        }
        else if (route == "B")
        {
            Cmd(ufc.GetCommand("D3"));
        }
        else if (route == "C")
        {
            Cmd(ufc.GetCommand("D9"));
        }
        Cmd(ufc.GetCommand("PB10"));
    }
    private void InputDecimalDigits(Device ufc, string decimalString)
    {
        foreach (char c in decimalString)
        {
            if (c == '.')
            {
                Cmd(ufc.GetCommand("DOT"));
            }
            else
            {
                Cmd(Digits(ufc, c.ToString()));
            }
        }
    }
    private void InputRelativeLatOrLong(Device ufc, string direction, int value)
    {
        Cmd(ufc.GetCommand("SHF"));
        if (direction == "N" || direction == "E")
        {
            Cmd(ufc.GetCommand("D1"));
        }
        else if (direction == "S" || direction == "W")
        {
            Cmd(ufc.GetCommand("D3"));
        }
        InputDecimalDigits(ufc, value.ToString());

    }
    private void BuildWaypoints(Device ufc, List<Waypoint> waypoints, string route)
    {
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("MENU"));
        Cmd(ufc.GetCommand("SHF"));
        Cmd(ufc.GetCommand("D3"));
        Cmd(ufc.GetCommand("PB10"));
        Cmd(ufc.GetCommand("PB10"));
        foreach (var wpt in waypoints)
        {
            string ufcString = ""; 

            if (!wpt.Offset)
            {
                Cmd(Digits(ufc, wpt.Identifier.WaypointNumber.ToString()));
                ufcString = $"STR {wpt.Identifier.WaypointNumber}{route}";
            }
            else
            {
                if (wpt.Identifier.WaypointOffsetNumber > 1)
                {
                    // Go back to menu to reset coordinates mode if inputting multiple offset/aim points sequentially
                    Cmd(ufc.GetCommand("CLR"));
                    Cmd(ufc.GetCommand("CLR"));
                    Cmd(ufc.GetCommand("MENU"));
                    Cmd(ufc.GetCommand("SHF"));
                    Cmd(ufc.GetCommand("D3"));
                    Cmd(ufc.GetCommand("PB10"));
                    Cmd(ufc.GetCommand("PB10"));
                }
                //Enter Offset PT
                Cmd(Digits(ufc, wpt.Identifier.WaypointNumber.ToString()));
                Cmd(ufc.GetCommand("DOT"));
                if (wpt.Target)
                {
                    Cmd(Digits(ufc, 0.ToString()));
                    Cmd(Digits(ufc, wpt.Identifier.WaypointOffsetNumber.ToString()));
                    ufcString = $"STR {wpt.Identifier.WaypointNumber}.0{wpt.Identifier.WaypointOffsetNumber}{route}";
                }
                else
                {
                    Cmd(Digits(ufc, wpt.Identifier.WaypointOffsetNumber.ToString()));
                    ufcString = $"STR {wpt.Identifier.WaypointNumber}.{wpt.Identifier.WaypointOffsetNumber}{route}";
                }
            }

            Cmd(ufc.GetCommand("SHF"));
            if (route == "A")
            {
                Cmd(ufc.GetCommand("D1"));
            }
            else if (route == "B")
            {
                Cmd(ufc.GetCommand("D3"));
            }
            else if (route == "C")
            {
                Cmd(ufc.GetCommand("D9"));
            }
            Cmd(ufc.GetCommand("PB01"));
            Cmd(Wait(500));
            
            StartIf(UFCScratchPadDifferent(ufc, ufcString));
            {
                Cmd(ufc.GetCommand("CLR"));
                Cmd(ufc.GetCommand("CLR"));
                Cmd(Digits(ufc, wpt.Identifier.WaypointNumber.ToString())); // No need to account for offset or aim pts. Jet already handles that.
                Cmd(ufc.GetCommand("DOT"));
                Cmd(ufc.GetCommand("SHF"));
                if (route == "A")
                {
                    Cmd(ufc.GetCommand("D1"));
                }
                else if (route == "B")
                {
                    Cmd(ufc.GetCommand("D3"));
                }
                else if (route == "C")
                {
                    Cmd(ufc.GetCommand("D9"));
                }
                Cmd(ufc.GetCommand("PB01"));
                Cmd(Wait(500));
            }
            EndIf();
            StartIf(UFCScratchPadDifferent(ufc, ufcString));
            {
                Cmd(Digits(ufc, wpt.Identifier.WaypointNumber.ToString()));
                Cmd(ufc.GetCommand("SHF"));
                if (route == "A")
                {
                    Cmd(ufc.GetCommand("D1"));
                }
                else if (route == "B")
                {
                    Cmd(ufc.GetCommand("D3"));
                }
                else if (route == "C")
                {
                    Cmd(ufc.GetCommand("D9"));
                }
                Cmd(ufc.GetCommand("PB01"));
            }
            EndIf();

            if (wpt.Target && !wpt.Offset)
            {
                Cmd(Digits(ufc, wpt.Identifier.WaypointNumber.ToString()));
                Cmd(ufc.GetCommand("DOT"));
                Cmd(ufc.GetCommand("SHF"));
                if (route == "A")
                {
                    Cmd(ufc.GetCommand("D1"));
                }
                else if (route == "B")
                {
                    Cmd(ufc.GetCommand("D3"));
                }
                else if (route == "C")
                {
                    Cmd(ufc.GetCommand("D9"));
                }
                Cmd(ufc.GetCommand("PB01"));
            }

            if (wpt.Offset && wpt.UseRelativeOffsetBearingAndRange)
            {
                Cmd(ufc.GetCommand("PB04"));
                Cmd(ufc.GetCommand("PB04"));
                InputDecimalDigits(ufc, wpt.RelativeOffsetBearingAndRange.Range.ToString());
                Cmd(ufc.GetCommand("PB02"));
                Cmd(Digits(ufc, wpt.RelativeOffsetBearingAndRange.Direction.ToString()));
                Cmd(ufc.GetCommand("PB03"));

            } else if (wpt.Offset && wpt.UseRelativeOffsetLatLong){

                Cmd(ufc.GetCommand("PB04"));
                Cmd(ufc.GetCommand("PB04"));
                Cmd(ufc.GetCommand("PB04"));
                InputCoordinate(ufc, wpt.RelativeOffsetLatLong.LatitudeDirection + (wpt.RelativeOffsetLatLong.RelativeLatitude!=0? wpt.RelativeOffsetLatLong.RelativeLatitude:1));
                Cmd(ufc.GetCommand("PB02"));
                InputCoordinate(ufc, wpt.RelativeOffsetLatLong.LongitudeDirection + (wpt.RelativeOffsetLatLong.RelativeLongitude!=0? wpt.RelativeOffsetLatLong.RelativeLongitude:1));
                Cmd(ufc.GetCommand("PB03"));
            } else
            {
                InputCoordinate(ufc, wpt.Latitude);
                Cmd(ufc.GetCommand("PB02"));

                InputCoordinate(ufc, wpt.Longitude);
                Cmd(ufc.GetCommand("PB03"));

                Cmd(Digits(ufc, wpt.MEA.ToString()));
                Cmd(ufc.GetCommand("PB08"));
            }

            Cmd(Digits(ufc, wpt.Elevation.ToString()));
            Cmd(ufc.GetCommand("PB07"));

        }
    }

    private Condition UFCScratchPadDifferent(Device ufc, string str)
    {
        return new Condition($"UFCScratchPadDifferent('{ufc.Name}', '{str}')");
    }
}