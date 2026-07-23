using DTC.New.Presets.V2.Aircrafts.CH47F.Systems;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Uploader.Aircrafts.CH47F;

public partial class CH47FUploader
{
    private void BuildWaypoints(bool pilot)
    {
        if (config.Waypoints == null || !config.Waypoints.HasWaypoints())
        {
            return;
        }

        if (config.Upload.Route)
        {
            var wptsToUpload = GetRouteWaypoints();
            if (wptsToUpload.Count > 0)
            {
                UploadPointsFpln(wptsToUpload, true);
            }

            return;
        }

        if (config.Upload.Waypoints)
        {
            UploadPointsAcp(config.Waypoints.Waypoints, true);
        }
    }

    private void strToCmd(string str, int max)
    {
        strToCmd(str.Substring(0, Math.Min(max, str.Length)));
    }

    private void strToCmd(string str)
    {
        foreach (var cc in str.ToUpper())
        {
            var c = cc.ToString();
            if (c == " ")
            {
                continue;
            }
            if (c == ".")
            {
                c = "Point";
            }
            try
            {
              Cmd(CDU.GetCommand("Btn" + c));
            }
            catch
            {
                continue;
            }
        }
    }

    private void UploadPointsFpln(List<Waypoint> wptList, bool fullSync)
    {
        Cmd(CDU.CLR); Cmd(CDU.CLR); Cmd(CDU.CLR);
        Cmd(CDU.FPLN);
        Cmd(CDU.LSK_L6);
        Cmd(CDU.LSK_R1);

        var submitted = 0;

        foreach (var wpt in wptList)
        {
            var slot = 5;

            if (submitted < 4)
            {
                slot = 2 + submitted;
            }
            else
            {
                Cmd(CDU.DOWN);
            }

            var x = wpt.Latitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");
            var y = wpt.Longitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");

            var cmd = x.Substring(0, 5) + "." + x.Substring(x.Length - 3, 3) +y.Substring(0, 6)+ "." + y.Substring(y.Length - 3, 3);
            strToCmd(cmd);
            Cmd(CDU.GetCommand("LSK_L" + slot));
            submitted++;
        }
    }

    private void UploadPointsAcp(List<Waypoint> wptList, bool fullSync)
    {
        Cmd(CDU.CLR); Cmd(CDU.CLR); Cmd(CDU.CLR);
        Cmd(CDU.IDX);
        Cmd(CDU.LSK_L6);
        Cmd(CDU.LSK_L6);

        foreach (var wpt in wptList)
        {
            strToCmd(wpt.Sequence.ToString());
            Cmd(CDU.LSK_L1);

            var x = wpt.Latitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");
            var y = wpt.Longitude.Replace(".", "").Replace("'", "").Replace("\"", "").Replace("°", "").Replace(" ", "").Replace("’", "");

            var cmd = x.Substring(0, 5) + "." + x.Substring(x.Length - 3, 3) + y.Substring(0, 6) + "." + y.Substring(y.Length - 3, 3);
            strToCmd(cmd);
            Cmd(CDU.LSK_L1);

            strToCmd(wpt.Elevation.ToString());
            Cmd(CDU.LSK_L3);

            if (wpt.Name != "")
            {
                Cmd(CDU.SLASH);
                strToCmd(wpt.Name);
                Cmd(CDU.LSK_L2);
            }
        }
    }

    private List<Waypoint> GetRouteWaypoints()
    {
        var source = config.Waypoints.Waypoints;

        if (!config.Upload.Route || config.Route == null || config.Route.Route == null)
        {
            return source.ToList();
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

            return source.Where(w => w.Sequence >= from && w.Sequence <= to).OrderBy(w => w.Sequence).ToList();
        }

        if (route.Mode == RouteMode.UseSpecific && route.Waypoints != null && route.Waypoints.Count > 0)
        {
            var list = new List<Waypoint>();
            foreach (var seq in route.Waypoints)
            {
                var wpt = config.Waypoints.GetBySequence(seq);
                if (wpt != null)
                {
                    list.Add(wpt);
                }
            }
            return list;
        }

        return source.ToList();
    }
}