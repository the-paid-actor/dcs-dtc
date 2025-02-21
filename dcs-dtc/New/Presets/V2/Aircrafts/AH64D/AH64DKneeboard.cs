using DTC.Utilities;
using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

namespace DTC.New.Presets.V2.Aircrafts.AH64D;

public static class AH64DKneeboard
{
    public static string GetKneeboardText(AH64DConfiguration cfg)
    {
        var sb = new KneeboardBuilder();

        MakeSteerpoints(cfg, sb);

        return sb.ToString();
    }

    private static void MakeSteerpoints(AH64DConfiguration cfg, KneeboardBuilder sb)
    {
        sb.AppendLineDivider();
        sb.AppendCentered("WAYPOINTS");
        sb.AppendLineDivider();

        var dist = 0;
        var totaldist = 0;
        Waypoint prevWp = null;

        foreach (var wp in cfg.Waypoints.Waypoints)
        {
            if (prevWp != null)
            {
                var coord1 = Coordinate.FromString(prevWp.Latitude, prevWp.Longitude);
                var coord2 = Coordinate.FromString(wp.Latitude, wp.Longitude);
                dist = coord1.Distance(coord2);
                totaldist += dist;
            }

            sb.Append(wp.GetDCSPointType());
            sb.AppendJustifyRight(wp.Sequence, 2, '0');
            sb.AppendSpace();
            sb.Append(wp.Identifier);
            sb.AppendSpace();
            sb.AppendJustifyLeft(wp.Free, 3);
            sb.AppendSpace();
            sb.AppendJustifyLeft(wp.Name, 13);
            sb.AppendSpace();
            sb.Append(wp.Latitude);
            sb.AppendSpace();
            sb.Append(wp.Longitude);
            sb.AppendSpace();
            sb.AppendJustifyRight(wp.Elevation, 5);
            sb.Append(" FT ");
            sb.AppendJustifyRight(dist, 4);
            sb.Append(" NM ");
            if (wp.TimeOverSteerpoint != null)
            {
                sb.Append(wp.TimeOverSteerpoint);
            }
            sb.AppendLine();
            prevWp = wp;
        }

        sb.AppendLine();
        sb.Append("ROUTE LENGTH: ");
        sb.Append(totaldist);
        sb.Append(" NM");
        sb.AppendLine();
    }
}
