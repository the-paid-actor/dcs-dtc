using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.Globalization;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader
{
    private void BuildPrePlanned()
    {
        if (!config.Upload.PrePlanned ||
            config.PrePlanned == null ||
            !config.PrePlanned.HasAnyPPEnabled())
        {
            return;
        }

        var stationGroups = GroupStationsByPayloadType();

        foreach (var group in stationGroups)
        {
            SetLeftMFDTac();
            Cmd(LMFD.OSB05);

            Cmd(SelectStore(GetDCSWeaponCode(group.Key)));

            if (group.Key == StationType.SLAM || group.Key == StationType.SLAMER)
            {
                foreach (var station in group.Value)
                {
                    if (!station.HasAnyStptEnabled()) continue;

                    Loop(IsStationSelected(station.Number), LMFD.OSB13);
                    InputSteerpoints(station);
                }
            }

            if (group.Key == StationType.GBU38 ||
                group.Key == StationType.GBU32 ||
                group.Key == StationType.GBU31PP ||
                group.Key == StationType.GBU31NP)
            {
                Cmd(LMFD.OSB11); //JDAM DISPLAY
            }
            else
            {
                Cmd(LMFD.OSB12); //JSOW/SLMR DISPLAY
            }

            Cmd(LMFD.OSB04); //MSN

            If(IsTargetOfOpportunity(), LMFD.OSB05);
            Cmd(LMFD.OSB14); //TGT UFC

            foreach (var station in group.Value)
            {
                Loop(IsInPPStation(station.Number), LMFD.OSB13);
                foreach (var kv in station.PP)
                {
                    var idx = kv.Key;
                    var pp = kv.Value;
                    if (!pp.Enabled) continue;

                    ICommand cmd;
                    if (idx == 1)
                        cmd = LMFD.OSB06;
                    else if (idx == 2)
                        cmd = LMFD.OSB07;
                    else if (idx == 3)
                        cmd = LMFD.OSB08;
                    else if (idx == 4)
                        cmd = LMFD.OSB09;
                    else if (idx == 5)
                        cmd = LMFD.OSB10;
                    else
                        cmd = LMFD.OSB11;

                    If(IsPPNotSelected(idx), cmd);

                    Cmd(LMFD.OSB14); //TGT UFC
                    Cmd(LMFD.OSB14); //TGT UFC

                    Cmd(UFC.OPT3); //POSN

                    Cmd(UFC.OPT1); //LAT
                    Coord(pp.Lat);
                    Cmd(Wait());

                    Cmd(UFC.OPT3); //LON
                    Coord(pp.Lon);
                    Cmd(Wait());

                    Cmd(LMFD.OSB14); //TGT UFC
                    Cmd(LMFD.OSB14); //TGT UFC

                    Cmd(UFC.OPT4); //ELEV
                    Cmd(UFC.OPT3); //FEET

                    Cmd(Digits(UFC, pp.Elev.ToString()));
                    Cmd(UFC.ENT);
                    Cmd(Wait());
                }
            }

            Cmd(LMFD.OSB14); //TGT UFC
            Cmd(LMFD.OSB19); //RETURN
        }
    }

    private void InputSteerpoints(PrePlannedStation sta)
    {
        Cmd(LMFD.OSB11); //STP

        for (int i = 1; i <= 5; i++)
        {
            Cmd(UFC.OPT1);
            Cmd(UFC.OPT5);
        }

        int stpProgNumber = 1;
        foreach (var stp in sta.Steerpoints)
        {
            if (!stp.Enabled) continue;

            ICommand cmdStptNumber;
            if (stpProgNumber == 1)
                cmdStptNumber = UFC.OPT1;
            else if (stpProgNumber == 2)
                cmdStptNumber = UFC.OPT2;
            else if (stpProgNumber == 3)
                cmdStptNumber = UFC.OPT3;
            else if (stpProgNumber == 4)
                cmdStptNumber = UFC.OPT4;
            else
                cmdStptNumber = UFC.OPT5;

            Cmd(LMFD.OSB11); //STP
            Cmd(LMFD.OSB11); //STP
            Cmd(cmdStptNumber);

            if (stp.UseCoordinate)
            {
                Cmd(UFC.OPT3); //POSN
                Cmd(UFC.OPT1); //LAT
                Coord(stp.Lat);
                Cmd(Wait());

                Cmd(UFC.OPT3); //POSN
                Cmd(UFC.OPT3); //LON
                Coord(stp.Lon);
                Cmd(Wait());

                Cmd(UFC.OPT4); //ELEV
                Cmd(UFC.OPT3); //FEET
                Cmd(Digits(UFC, stp.Elev.ToString()));
                Cmd(UFC.ENT);
                Cmd(Wait());
            }
            else
            {
                Cmd(UFC.OPT2); //WYPT
                Cmd(Digits(UFC, stp.WaypointNumber.ToString()));
                Cmd(UFC.ENT);
                Cmd(Wait());
            }

            stpProgNumber++;
        }

        Cmd(LMFD.OSB11); //STP
    }

    private string GetDCSWeaponCode(StationType type)
    {
        switch (type)
        {
            case StationType.GBU38:
                return "J-82";
            case StationType.GBU32:
                return "J-83";
            case StationType.GBU31NP:
                return "J-84";
            case StationType.GBU31PP:
                return "J-109";
            case StationType.JSOWA:
                return "JSA";
            case StationType.JSOWC:
                return "JSC";
            case StationType.SLAM:
                return "SLAM";
            case StationType.SLAMER:
                return "SLMR";
            default:
                throw new Exception("Invalid weapon");
        }
    }

    private Dictionary<StationType, List<PrePlannedStation>> GroupStationsByPayloadType()
    {
        var result = new Dictionary<StationType, List<PrePlannedStation>>();

        foreach (var sta in config.PrePlanned.Stations.Values)
        {
            if (sta.Type == StationType.EMPTY ||
                !sta.HasAnyPPEnabled())
            {
                continue;
            }

            result.TryGetValue(sta.Type, out var list);
            if (list == null)
            {
                list = new List<PrePlannedStation>();
                result.Add(sta.Type, list);
            }
            list.Add(sta);
        }

        return result;
    }


    private Condition IsStationSelected(int station)
    {
        return new Condition($"StationSelected('{station}')");
    }

    private Condition IsTargetOfOpportunity()
    {
        return new Condition($"IsTargetOfOpportunity()");
    }

    private Condition IsInPPStation(int station)
    {
        return new Condition($"InPPStation('{station}')");
    }

    private Condition IsPPNotSelected(int pp)
    {
        return new Condition($"IsPPNotSelected('{pp}')");
    }

    private CustomCommand SelectStore(string store)
    {
        var device = LMFD.Id;
        var b1 = LMFD.OSB06.Id;
        var b2 = LMFD.OSB07.Id;
        var b3 = LMFD.OSB08.Id;
        var b4 = LMFD.OSB09.Id;
        var b5 = LMFD.OSB10.Id;
        var delay = (Settings.HornetCommandDelayMs * LMFD.OSB06.DelayFactor).ToString(CultureInfo.InvariantCulture);
        var act = LMFD.OSB06.Activation;

        return new CustomCommand($"SelectStore('{store}', {device}, {b1}, {b2}, {b3}, {b4}, {b5}, {delay}, {act})");
    }
}
