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

        StartIf(IsInFrontCockpit());
        {
            BuildRoutes(UFC_PILOT, hasRouteA, hasRouteB, hasRouteC);
        }
        EndIf();
        StartIf(IsInRearCockpit());
        {
            BuildRoutes(UFC_WSO, hasRouteA, hasRouteB, hasRouteC);
        }
        EndIf();
    }

    private void BuildRoutes(Device device, bool hasRouteA, bool hasRouteB, bool hasRouteC)
    {
        if (hasRouteA)
        {
            BuildWaypoints(device, config.RouteA.Waypoints, "A");
        }

        if (hasRouteB)
        {
            BuildWaypoints(device, config.RouteB.Waypoints, "B");
        }

        if (hasRouteC)
        {
            BuildWaypoints(device, config.RouteC.Waypoints, "C");
        }
    }

    private void BuildWaypoints(Device device, List<Waypoint> waypoints, string route)
    {
        Cmd(device.GetCommand("CLR"));
        Cmd(device.GetCommand("CLR"));
        Cmd(device.GetCommand("MENU"));
        Cmd(device.GetCommand("SHF"));
        Cmd(device.GetCommand("D3"));
        Cmd(device.GetCommand("PB10"));
        Cmd(device.GetCommand("PB10"));

        foreach (var wpt in waypoints)
        {
            Cmd(Digits(device, wpt.Sequence.ToString()));
            Cmd(device.GetCommand("SHF"));
            if (route == "A")
            {
                Cmd(device.GetCommand("D1"));
            }
            else if (route == "B")
            {
                Cmd(device.GetCommand("D3"));
            }
            else if (route == "C")
            {
                Cmd(device.GetCommand("D9"));
            }
            Cmd(device.GetCommand("PB01"));
            Cmd(Wait(500));

            StartIf(IsStrDifferent(device.Name, $"STR {wpt.Sequence}{route}"));
            {
                Cmd(device.GetCommand("CLR"));
                Cmd(device.GetCommand("CLR"));
                Cmd(Digits(device, wpt.Sequence.ToString()));
                Cmd(device.GetCommand("DOT"));
                Cmd(device.GetCommand("SHF"));
                if (route == "A")
                {
                    Cmd(device.GetCommand("D1"));
                }
                else if (route == "B")
                {
                    Cmd(device.GetCommand("D3"));
                }
                else if (route == "C")
                {
                    Cmd(device.GetCommand("D9"));
                }
                Cmd(device.GetCommand("PB01"));
                Cmd(Wait(500));
            }
            EndIf();

            StartIf(IsStrDifferent(device.Name, $"STR {wpt.Sequence}{route}"));
            {
                Cmd(Digits(device, wpt.Sequence.ToString()));
                Cmd(device.GetCommand("SHF"));
                if (route == "A")
                {
                    Cmd(device.GetCommand("D1"));
                }
                else if (route == "B")
                {
                    Cmd(device.GetCommand("D3"));
                }
                else if (route == "C")
                {
                    Cmd(device.GetCommand("D9"));
                }
                Cmd(device.GetCommand("PB01"));
            }
            EndIf();

            if (wpt.Target)
            {
                Cmd(Digits(device, wpt.Sequence.ToString()));
                Cmd(device.GetCommand("DOT"));
                Cmd(device.GetCommand("SHF"));
                if (route == "A")
                {
                    Cmd(device.GetCommand("D1"));
                }
                else if (route == "B")
                {
                    Cmd(device.GetCommand("D3"));
                }
                else if (route == "C")
                {
                    Cmd(device.GetCommand("D9"));
                }
                Cmd(device.GetCommand("PB01"));
            }

            Coordinate(device, wpt.Latitude);
            Cmd(device.GetCommand("PB02"));

            Coordinate(device, wpt.Longitude);
            Cmd(device.GetCommand("PB03"));

            Cmd(Digits(device, wpt.Elevation.ToString()));
            Cmd(device.GetCommand("PB07"));

            Cmd(Digits(device, wpt.MEA.ToString()));
            Cmd(device.GetCommand("PB08"));
        }

        Cmd(device.GetCommand("MENU"));
        Cmd(device.GetCommand("D1"));
        Cmd(device.GetCommand("SHF"));
        Cmd(device.GetCommand("D1"));
        Cmd(device.GetCommand("PB10"));
    }
}