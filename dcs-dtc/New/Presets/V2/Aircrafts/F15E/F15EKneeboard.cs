using DTC.Utilities;
using DTC.New.Presets.V2.Aircrafts.F15E.Systems;

namespace DTC.New.Presets.V2.Aircrafts.F15E;

public static class F15EKneeboard
{
    public static string GetKneeboardText(F15EConfiguration cfg)
    {
        var sb = new KneeboardBuilder();

        MakeRoute(sb, cfg.RouteA, "A");
        MakeRoute(sb, cfg.RouteB, "B");
        MakeRoute(sb, cfg.RouteC, "C");
        if (cfg.Misc != null && cfg.Misc.BullseyeToBeUpdated)
        {
            sb.Append("BULLSEYE ");
            sb.Append(cfg.Misc.BullseyeCoord);
            sb.AppendLine();
        }
        MakeRadios(cfg, sb);
        MakePrePlanned(cfg, sb);

        return sb.ToString();
    }

    private static void MakeRoute(KneeboardBuilder sb, WaypointSystem wpts, string route)
    {
        if (!wpts.HasWaypoints())
        {
            return;
        }

        sb.AppendLineDivider();
        sb.AppendCentered("ROUTE " + route);
        sb.AppendLineDivider();

        var dist = 0;
        var totaldist = 0;
        Waypoint prevWp = null;

        foreach (var wp in wpts.Waypoints)
        {
            if (prevWp != null)
            {
                var coord1 = Coordinate.FromString(prevWp.Latitude, prevWp.Longitude);
                var coord2 = Coordinate.FromString(wp.Latitude, wp.Longitude);
                dist = coord1.Distance(coord2);
                totaldist += dist;
            }

            if (!wp.Target)
            {
                sb.AppendSpace();
            }
            sb.AppendJustifyRight(wp.Sequence, 2);
            if (wp.Target)
            {
                sb.Append(".");
            }
            sb.Append(route);

            sb.AppendSpace();
            sb.AppendJustifyLeft(wp.Name, 21);
            sb.AppendSpace();
            sb.Append(wp.Latitude);
            sb.AppendSpace();
            sb.Append(wp.Longitude);
            sb.AppendSpace();
            sb.AppendJustifyRight(wp.Elevation, 5);
            sb.Append("FT ");
            sb.AppendJustifyRight(dist, 4);
            sb.Append("NM ");
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
        sb.Append("NM");
        sb.AppendLine();
    }

    private static void MakeRadios(F15EConfiguration cfg, KneeboardBuilder sb)
    {
        sb.AppendLineDivider();
        sb.AppendCentered("RADIOS");
        sb.AppendLineDivider();

        var maxRadio = GetMaxRadio(cfg);

        sb.AppendCenteredColumn("COMM 1");
        sb.AppendColumnDivider();
        sb.AppendCenteredColumn("COMM 2");
        sb.AppendLine();
        sb.AppendLineDivider();

        for (var i = 0; i < maxRadio; i++)
        {
            if (cfg.Radios != null &&
                cfg.Radios.Radio1 != null &&
                cfg.Radios.Radio1.Presets != null &&
                cfg.Radios.Radio1.Presets.Count > i)
            {
                var radio = cfg.Radios.Radio1.Presets[i];
                sb.AppendJustifyRight(radio.Number, 2, '0');
                sb.AppendSpace();
                sb.AppendJustifyLeft(radio.Name, 26);
                sb.AppendSpace();
                sb.Append(radio.Frequency);
            }
            else
            {
                sb.AppendColumnBlank();
            }

            sb.Append(" | ");

            if (cfg.Radios != null &&
                cfg.Radios.Radio2 != null &&
                cfg.Radios.Radio2.Presets != null &&
                cfg.Radios.Radio2.Presets.Count > i)
            {
                var radio = cfg.Radios.Radio2.Presets[i];
                sb.AppendJustifyRight(radio.Number, 2, '0');
                sb.AppendSpace();
                sb.AppendJustifyLeft(radio.Name, 26);
                sb.AppendSpace();
                sb.Append(radio.Frequency);
            }
            else
            {
                sb.AppendColumnBlank();
            }

            sb.AppendLine();
        }
    }

    private static void MakePrePlanned(F15EConfiguration cfg, KneeboardBuilder sb)
    {
        sb.AppendLineDivider();
        sb.AppendCentered("PRE-PLANNED");
        sb.AppendLineDivider();

        foreach (var staName in StationNames.Ordered)
        {
            var sta = cfg.SmartWeapons.Get(staName);

            if (sta != null)
            {
                var wpn = sta.GetFirst();
                if (wpn != null)
                {
                    sb.AppendJustifyLeft(staName, 10);
                    sb.AppendSpace();
                    sb.Append(wpn.Latitude);
                    sb.AppendSpace();
                    sb.Append(wpn.Longitude);
                    sb.AppendSpace();
                    sb.AppendJustifyRight(wpn.Elevation, 5);
                    sb.Append("FT | ");
                    sb.AppendJustifyLeft(wpn.Notes, 29);
                    sb.AppendLine();
                }
            }
        }
    }

    private static int GetMaxRadio(F15EConfiguration cfg)
    {
        var radio1Max = 0;
        if (cfg.Radios != null &&
            cfg.Radios.Radio1 != null &&
            cfg.Radios.Radio1.Presets != null)
        {
            radio1Max = cfg.Radios.Radio1.Presets.Count;
        }
        var radio2Max = 0;
        if (cfg.Radios != null &&
            cfg.Radios.Radio2 != null &&
            cfg.Radios.Radio2.Presets != null)
        {
            radio2Max = cfg.Radios.Radio2.Presets.Count;
        }

        return Math.Max(radio1Max, radio2Max);
    }
}