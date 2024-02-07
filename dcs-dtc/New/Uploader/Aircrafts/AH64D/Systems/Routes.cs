using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.AH64D;

public partial class AH64DUploader
{
    private void BuildRoutes(bool pilot)
    {
        if (!config.Upload.Routes ||
            config.Routes == null || 
            config.Routes.Routes == null || 
            config.Routes.Routes.Count == 0)
        {
            return;
        }

        Device display = pilot ? MFD_PLT_RIGHT : MFD_CPG_RIGHT;
        Device keyboard = pilot ? KU_PILOT : KU_CPG;

        Cmd(display.GetCommand("TSD"));
        Cmd(display.GetCommand("B5"));

        foreach (var route in config.Routes.Routes)
        {
            var wpts = GetWaypointsFromRoute(route);

            Cmd(display.GetCommand("B6"));
            Cmd(display.GetCommand("B2"));

            Cmd(display.GetCommand("L5"));

            if (route.Code == RouteCode.India ||
                route.Code == RouteCode.Lima ||
                route.Code == RouteCode.Oscar ||
                route.Code == RouteCode.Romeo ||
                route.Code == RouteCode.Tango)
            {
                Cmd(display.GetCommand("B3"));
            }

            if (route.Code == RouteCode.Alpha || route.Code == RouteCode.India)
            {
                Cmd(display.GetCommand("T1"));
            }
            if (route.Code == RouteCode.Bravo || route.Code == RouteCode.Lima)
            {
                Cmd(display.GetCommand("T2"));
            }
            if (route.Code == RouteCode.Delta || route.Code == RouteCode.Oscar)
            {
                Cmd(display.GetCommand("T3"));
            }
            if (route.Code == RouteCode.Echo || route.Code == RouteCode.Romeo)
            {
                Cmd(display.GetCommand("T4"));
            }
            if (route.Code == RouteCode.Hotel || route.Code == RouteCode.Tango)
            {
                Cmd(display.GetCommand("T5"));
            }

            Cmd(display.GetCommand("L4"));

            Cmd(display.GetCommand("B6"));

            Cmd(display.GetCommand("L2"));

            foreach (var wpt in wpts)
            {
                Cmd(display.GetCommand("R1"));
                Cmd(display.GetCommand("L1"));
                Cmd(Keyboard(keyboard, GetPointType(wpt.PointType) + wpt.Sequence.ToString().PadLeft(2, '0')));
                Cmd(keyboard.GetCommand("ENTER"));
                Cmd(ClickEnd(display));
            }
        }

        Cmd(display.GetCommand("B5"));
    }

    private List<Waypoint> GetWaypointsFromRoute(Route route)
    {
        var wpts = new List<Waypoint>();
        if (route.Mode == RouteMode.UseAll)
        {
            if (route.IncludeAllWaypoints || route.IncludeAllHazards)
            {
                wpts.AddRange(config.Waypoints.Waypoints.Where((w) =>
                {
                    return (route.IncludeAllWaypoints && w.PointType == PointType.Waypoint.Code) ||
                            (route.IncludeAllHazards && w.PointType == PointType.Hazard.Code);
                }));
            }
            if (route.IncludeAllControlMeasures)
            {
                wpts.AddRange(config.ControlMeasures.Waypoints);
            }
        }
        else if (route.Mode == RouteMode.UseRange)
        {
            var start = route.Waypoints[0];
            var end = -1;
            if (route.Waypoints.Count > 1)
            {
                end = route.Waypoints[1];
            }
            if (end == -1)
            {
                end = config.Waypoints.GetLastAllowedSequence();
            }
            
            foreach (var wpt in config.Waypoints.Waypoints)
            {
                if (wpt.Sequence >= start && wpt.Sequence <= end)
                {
                    wpts.Add(wpt);
                }
            }
            foreach (var wpt in config.ControlMeasures.Waypoints)
            {
                if (wpt.Sequence >= start && wpt.Sequence <= end)
                {
                    wpts.Add(wpt);
                }
            }
        }
        else if (route.Mode == RouteMode.UseSpecific)
        {
            foreach (var seq in route.Waypoints)
            {
                var wpt = config.Waypoints.GetBySequence(seq);
                if (wpt == null) wpt = config.ControlMeasures.GetBySequence(seq);
                if (wpt == null) continue;
                wpts.Add(wpt);
            }
        }
        return wpts;
    }
}