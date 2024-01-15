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
            Cmd(Digits(ufc, wpt.Sequence.ToString()));
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

            StartIf(UFCScratchPadDifferent(ufc, $"STR {wpt.Sequence}{route}"));
            {
                Cmd(ufc.GetCommand("CLR"));
                Cmd(ufc.GetCommand("CLR"));
                Cmd(Digits(ufc, wpt.Sequence.ToString()));
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

            StartIf(UFCScratchPadDifferent(ufc, $"STR {wpt.Sequence}{route}"));
            {
                Cmd(Digits(ufc, wpt.Sequence.ToString()));
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

            if (wpt.Target)
            {
                Cmd(Digits(ufc, wpt.Sequence.ToString()));
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

            Coordinate(ufc, wpt.Latitude);
            Cmd(ufc.GetCommand("PB02"));

            Coordinate(ufc, wpt.Longitude);
            Cmd(ufc.GetCommand("PB03"));

            Cmd(Digits(ufc, wpt.Elevation.ToString()));
            Cmd(ufc.GetCommand("PB07"));

            Cmd(Digits(ufc, wpt.MEA.ToString()));
            Cmd(ufc.GetCommand("PB08"));
        }

        Cmd(ufc.GetCommand("MENU"));
        Cmd(ufc.GetCommand("D1"));
        Cmd(ufc.GetCommand("SHF"));
        Cmd(ufc.GetCommand("D1"));
        Cmd(ufc.GetCommand("PB10"));
    }

    private Condition UFCScratchPadDifferent(Device ufc, string str)
    {
        return new Condition($"UFCScratchPadDifferent('{ufc.Name}', '{str}')");
    }
}