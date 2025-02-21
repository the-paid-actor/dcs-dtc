using DTC.Utilities;
using DTC.New.Presets.V2.Aircrafts.F16.Systems;

namespace DTC.New.Presets.V2.Aircrafts.F16;

public static class F16Kneeboard
{
    public static string GetKneeboardText(F16Configuration cfg)
    {
        var sb = new KneeboardBuilder();

        MakeSteerpoints(cfg, sb);
        MakeRadios(cfg, sb);

        return sb.ToString();
    }

    private static void MakeRadios(F16Configuration cfg, KneeboardBuilder sb)
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
                sb.AppendJustifyLeft(radio.Name, 27);
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
                sb.AppendJustifyLeft(radio.Name, 27);
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

    private static void MakeSteerpoints(F16Configuration cfg, KneeboardBuilder sb)
    {
        sb.AppendLineDivider();
        sb.AppendCentered("STEERPOINTS");
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

            sb.AppendJustifyRight(wp.Sequence, 3, ' ');
            sb.AppendSpace();
            sb.AppendJustifyLeft(wp.Name, 20);
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

        if (cfg.Misc != null && cfg.Misc.BullseyeToBeUpdated)
        {
            sb.Append("BULLSEYE WP ");
            sb.Append(cfg.Misc.BullseyeWP);
            sb.AppendLine();
        }
    }

    private static int GetMaxRadio(F16Configuration cfg)
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
