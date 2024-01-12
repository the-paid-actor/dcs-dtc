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

        StartIf(IsInFrontCockpit());
        {
            BuildSmartWeapons(FRMPD, UFC_PILOT);
        }
        EndIf();
        StartIf(IsInRearCockpit());
        {
            BuildSmartWeapons(RRMPCD, UFC_WSO);
        }
        EndIf();
    }

    private void BuildSmartWeapons(Device devDisp, Device devUFC)
    {
        If(DisplayNotInMainMenu(devDisp.Name), devDisp.GetCommand("PB11"), Wait());
        If(DisplayNotInMainMenu(devDisp.Name), devDisp.GetCommand("PB11"), Wait());
        If(IsProgBoxed(devDisp.Name), devDisp.GetCommand("PB06"), Wait());

        Cmd(devDisp.GetCommand("PB11"));
        Cmd(devDisp.GetCommand("PB14"));
        Cmd(devDisp.GetCommand("PB14")); //EDIT MSN

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

            Loop(SmartStationSelected(devDisp.Name, planeStation), devDisp.GetCommand("PB02"), Wait(250));
            StartIf(SmartStationSelected(devDisp.Name, planeStation));
            {
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));

                Coordinate(devUFC, coord.Latitude);
                Cmd(devDisp.GetCommand("PB08"));
                Cmd(devDisp.GetCommand("PB05"));
                
                Coordinate(devUFC, coord.Longitude);
                Cmd(devDisp.GetCommand("PB08"));
                Cmd(devDisp.GetCommand("PB05"));
                
                Cmd(Digits(devUFC, coord.Elevation.ToString()));
                Cmd(devDisp.GetCommand("PB08"));

                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));
                Cmd(devDisp.GetCommand("PB05"));

                Cmd(devDisp.GetCommand("PB10"));
                Cmd(Wait(2000));
            }
            EndIf();
        }
        Cmd(devDisp.GetCommand("PB14"));
    }
}