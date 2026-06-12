using DTC.New.Presets.V2.Aircrafts.C130.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.C130;

public partial class C130Uploader
{
    private void BuildWaypoints(bool pilot)
    {
        if (config.Waypoints == null || !config.Waypoints.HasWaypoints())
        {
            return;
        }

        if (config.Upload.Waypoints)
        {
            UploadPoints(config.Waypoints, true);
        }

        if (config.Upload.Route)
        {
            BuildRoute(config.Waypoints.Waypoints);
        }
    }

    private void strToCmd(string str,int max)
    {
        strToCmd(str.Substring(0, Math.Min(max, str.Length)));
    }

    private void strToCmd(string str)
    {
        foreach (var c in str.ToUpper())
        {
            if (c == ' ')
            {
                continue;
            }
            if (c == '.')
            {
                Cmd(CNI.GetCommand("BtnPoint" ));
            }
            else
            {
                Cmd(CNI.GetCommand("Btn" + c));
            }
        }
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {
        Cmd(CNI.CLR);
        Cmd(Wait(5000));
        Cmd(CNI.CLRRelease);

        Cmd(CNI.Legs);
        Cmd(CNI.LSK_R6);
        Cmd(CNI.DEL);
        Cmd(CNI.LSK_L1);
        Cmd(CNI.CLR);

        Cmd(CNI.CLR);
        Cmd(CNI.CLR);
        Cmd(CNI.Index);
        Cmd(CNI.NextPage);
        Cmd(CNI.LSK_R2);

        foreach (var wpt in wptList.Waypoints)
        {
            var nm = wpt.Name.Replace(" ", "");
            if (nm.Length > 6)
            {
                nm = nm.Substring(0, 6);
            }
            strToCmd(nm);
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

    private void BuildRoute(List<Waypoint> waypoints)
    {
        var ordered = GetRouteWaypoints(waypoints);
        if (ordered.Count == 0)
        {
            return;
        }

        var last = ordered.LastOrDefault();
        if (last == null)
        {
            return;
        }

        Cmd(CNI.Mark);
        Cmd(CNI.LSK_L1);
        Cmd(CNI.Legs);
        Cmd(CNI.LSK_R6);
        Cmd(CNI.LSK_L1);
        strToCmd(GetRouteIdentifier(last));
        Cmd(CNI.LSK_R1);
        Cmd(CNI.NextPage);

        var slot = 1;

        foreach (var wpt in ordered)
        {
            strToCmd(GetRouteIdentifier(wpt));
            Cmd(CNI.GetCommand("LSK_R" + slot));

            slot++;
            // C-130 route pages accept 4 STPT entries per page (R1-R4).
            if (slot > 4)
            {
                Cmd(CNI.NextPage);
                slot = 1;
            }
        }

        Cmd(CNI.LSK_L6);
        Cmd(CNI.LSK_R6);
    }

    private string GetRouteIdentifier(Waypoint wpt)
    {
        return string.IsNullOrWhiteSpace(wpt.Name) ? wpt.Sequence.ToString() : wpt.Name;
    }

    private List<Waypoint> GetRouteWaypoints(List<Waypoint> sourceWaypoints)
    {
        var orderedSource = sourceWaypoints.OrderBy(w => w.Sequence).ToList();

        if (config.Route == null || config.Route.Route == null)
        {
            return orderedSource;
        }

        var route = config.Route.Route;

        if (route.Mode == RouteMode.UseRange && route.Waypoints != null && route.Waypoints.Count > 0)
        {
            var from = route.Waypoints[0];
            var to = route.Waypoints.Count > 1 ? route.Waypoints[1] : from;
            if (to < from)
            {
                (from, to) = (to, from);
            }

            return orderedSource.Where(w => w.Sequence >= from && w.Sequence <= to).ToList();
        }

        if (route.Mode == RouteMode.UseSpecific && route.Waypoints != null && route.Waypoints.Count > 0)
        {
            var list = new List<Waypoint>();
            foreach (var seq in route.Waypoints)
            {
                var wpt = orderedSource.FirstOrDefault(w => w.Sequence == seq);
                if (wpt != null)
                {
                    list.Add(wpt);
                }
            }
            return list;
        }

        return orderedSource;
    }
}