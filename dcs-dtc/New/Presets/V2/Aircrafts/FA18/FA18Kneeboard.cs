using DTC.Utilities;
using DTC.New.Presets.V2.Aircrafts.FA18.Systems;

namespace DTC.New.Presets.V2.Aircrafts.FA18;

public static class FA18Kneeboard
{
    public static string GetKneeboardText(FA18Configuration cfg)
    {
        var sb = new KneeboardBuilder();

        MakeSteerpoints(cfg, sb);
        MakeRadios(cfg, sb);
        MakePrePlanned(cfg, sb);

        return sb.ToString();
    }

    private static void MakePrePlanned(FA18Configuration cfg, KneeboardBuilder sb)
    {
        sb.AppendLineDivider();
        sb.AppendCentered("PRE-PLANNED");
        sb.AppendLineDivider();

        if (cfg.PrePlanned != null)
        {
            foreach (var staKV in cfg.PrePlanned.Stations)
            {
                var sta = staKV.Value;
                if (sta.HasAnyPPEnabled() || sta.HasAnyStptEnabled())
                {
                    sb.Append("STA");
                    sb.Append(staKV.Key);
                    sb.AppendSpace();
                    sb.Append(PrePlannedSystem.StoreTypeToString(staKV.Value.Type));
                    sb.AppendLine();
                    foreach (var ppKV in sta.PP)
                    {
                        var pp = ppKV.Value;
                        if (!pp.Enabled)
                        {
                            continue;
                        }

                        sb.Repeat(4, ' ');
                        sb.Append("PP");
                        sb.Append(ppKV.Key);
                        sb.AppendSpace();
                        sb.Append(pp.Lat);
                        sb.AppendSpace();
                        sb.Append(pp.Lon);
                        sb.AppendSpace();
                        sb.AppendJustifyRight(pp.Elev, 5);
                        sb.Append(" | ");
                        sb.AppendJustifyLeft(pp.Notes, 30);
                        sb.AppendLine();
                    }
                    for (var i = 0; i < sta.Steerpoints.Length; i++)
                    {
                        var stp = sta.Steerpoints[i];
                        if (!stp.Enabled)
                        {
                            continue;
                        }
                        sb.Repeat(4, ' ');
                        sb.Append("STP");
                        sb.Append(i);
                        sb.AppendSpace();
                        if (stp.UseCoordinate)
                        {
                            sb.Append(stp.Lat);
                            sb.AppendSpace();
                            sb.Append(stp.Lon);
                            sb.AppendSpace();
                            sb.AppendJustifyRight(stp.Elev, 5);
                        }
                        else
                        {
                            sb.Append("WP");
                            sb.Append(stp.WaypointNumber);
                        }
                        sb.AppendLine();
                    }
                    sb.AppendLine();
                }
            }
        }
    }

    private static void MakeRadios(FA18Configuration cfg, KneeboardBuilder sb)
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

    private static void MakeSteerpoints(FA18Configuration cfg, KneeboardBuilder sb)
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

            sb.AppendJustifyRight(wp.Sequence, 2, ' ');
            sb.AppendSpace();
            sb.AppendJustifyLeft(wp.Name, 21);
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

    private static int GetMaxRadio(FA18Configuration cfg)
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
