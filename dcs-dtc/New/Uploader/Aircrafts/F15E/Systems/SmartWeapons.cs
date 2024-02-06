using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F15E;

public partial class F15EUploader : Base.Uploader
{
    private void BuildSmartWeapons()
    {
        if (!config.Upload.SmartWeapons || 
            config.SmartWeapons == null ||
            config.SmartWeapons.Stations == null ||
            config.SmartWeapons.Stations.Count == 0 ||
            !config.SmartWeapons.Stations.Any((kv) => kv.Value.Settings != null && kv.Value.Settings.Length > 0))
        {
            return;
        }

        StartIf(InFrontCockpit());
        {
            BuildSmartWeapons(FRMPD, UFC_PILOT);
        }
        EndIf();
        StartIf(InRearCockpit());
        {
            BuildSmartWeapons(RRMPCD, UFC_WSO);
        }
        EndIf();
    }

    private void BuildSmartWeapons(Device display, Device devUFC)
    {
        NavigateToMainMenu(display);

        Cmd(display.GetCommand("PB11"));
        Cmd(display.GetCommand("PB14"));
        Cmd(display.GetCommand("PB14")); //EDIT MSN

        foreach (var stationKey in StationNames.Ordered)
        {
            if (!config.SmartWeapons.Stations.ContainsKey(stationKey))
            {
                continue;
            }

            var smartStation = config.SmartWeapons.Stations[stationKey];
            if (smartStation.Settings == null || smartStation.Settings.Length == 0)
            {
                continue;
            }
            var coord = smartStation.Settings[0];
            string planeStation;
            switch (stationKey)
            {
                case StationNames.LWING: planeStation = "2-1"; break;
                case StationNames.RWING: planeStation = "8-1"; break;
                case StationNames.CENTERLINE: planeStation = "5-1"; break;
                case StationNames.LCFTFRONT: planeStation = "L1-3"; break;
                case StationNames.LCFTMID: planeStation = "L1-2"; break;
                case StationNames.LCFTREAR: planeStation = "L1-1"; break;
                case StationNames.RCFTFRONT: planeStation = "R1-3"; break;
                case StationNames.RCFTMID: planeStation = "R1-2"; break;
                case StationNames.RCFTREAR: planeStation = "R1-1"; break;
                default: continue;
            }
            planeStation = "STA-WPN: " + planeStation;

            Loop(SmartStationSelected(display, planeStation), display.GetCommand("PB02"), Wait(250));
            StartIf(SmartStationSelected(display, planeStation));
            {
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));

                InputCoordinate(devUFC, coord.Latitude);
                Cmd(display.GetCommand("PB08"));
                Cmd(display.GetCommand("PB05"));

                InputCoordinate(devUFC, coord.Longitude);
                Cmd(display.GetCommand("PB08"));
                Cmd(display.GetCommand("PB05"));

                Cmd(Digits(devUFC, coord.Elevation.ToString()));
                Cmd(display.GetCommand("PB08"));

                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));
                Cmd(display.GetCommand("PB05"));

                Cmd(display.GetCommand("PB10"));
                Cmd(Wait(2000));
            }
            EndIf();
        }
        Cmd(display.GetCommand("PB14"));
    }

    private Condition SmartStationSelected(Device display, string station)
    {
        return new Condition($"SmartStationSelected('{display.Name}','{station}')");
    }
}