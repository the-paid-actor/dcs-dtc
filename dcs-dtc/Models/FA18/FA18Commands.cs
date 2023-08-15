using System.Collections.Generic;
using DTC.Utilities;
using DTC.Models.DCS;

namespace DTC.Models.FA18
{
    public class FA18Commands : IAircraftDeviceManager
    {
        private Dictionary<string, Device> Devices = new Dictionary<string, Device>();

        public FA18Commands()
        {
            var delay = Settings.HornetCommandDelayMs;

            var delayMFDs = delay;
            var delayUFC = delay / 4;
            var delayUFCOpt = delay / 4;
            var delayUFCOnOff = delay;
            var delayUFCEnt = delay / 2;
            var delayIFEI = delay / 2;
            var delayRot = delay / 20;

            var ufc = new Device(25, "UFC");
            ufc.AddCommand(new Command(3001, "AP", delayUFC, 1));
            ufc.AddCommand(new Command(3002, "IFF", delayUFC, 1));
            ufc.AddCommand(new Command(3003, "TCN", delayUFC, 1));
            ufc.AddCommand(new Command(3004, "ILS", delayUFC, 1));
            ufc.AddCommand(new Command(3005, "DL", delayUFC, 1));
            ufc.AddCommand(new Command(3006, "BCN", delayUFC, 1));
            ufc.AddCommand(new Command(3007, "OnOff", delayUFCOnOff, 1));
            ufc.AddCommand(new Command(3008, "COM1", delayUFCOnOff, 1));
            ufc.AddCommand(new Command(3009, "COM2", delayUFCOnOff, 1));
            ufc.AddCommand(new Command(3010, "Opt1", delayUFCOpt, 1));
            ufc.AddCommand(new Command(3011, "Opt2", delayUFCOpt, 1));
            ufc.AddCommand(new Command(3012, "Opt3", delayUFCOpt, 1));
            ufc.AddCommand(new Command(3013, "Opt4", delayUFCOpt, 1));
            ufc.AddCommand(new Command(3014, "Opt5", delayUFCOpt, 1));
            ufc.AddCommand(new Command(3018, "0", delayUFC, 1));
            ufc.AddCommand(new Command(3019, "1", delayUFC, 1));
            ufc.AddCommand(new Command(3020, "2", delayUFC, 1));
            ufc.AddCommand(new Command(3021, "3", delayUFC, 1));
            ufc.AddCommand(new Command(3022, "4", delayUFC, 1));
            ufc.AddCommand(new Command(3023, "5", delayUFC, 1));
            ufc.AddCommand(new Command(3024, "6", delayUFC, 1));
            ufc.AddCommand(new Command(3025, "7", delayUFC, 1));
            ufc.AddCommand(new Command(3026, "8", delayUFC, 1));
            ufc.AddCommand(new Command(3027, "9", delayUFC, 1));
            ufc.AddCommand(new Command(3028, "CLR", delayUFC, 1));
            ufc.AddCommand(new Command(3029, "ENT", delayUFCEnt, 1));

            ufc.AddCommand(new Command(3033, "COM1ChDec", -1, 0));
            ufc.AddCommand(new Command(3033, "COM1ChInc", -1, 2));
            ufc.AddCommand(new Command(3034, "COM2ChDec", -1, 0));
            ufc.AddCommand(new Command(3034, "COM2ChInc", -1, 2));
            AddDevice(ufc);

            var ifei = new Device(33, "IFEI");
            ifei.AddCommand(new Command(3003, "UP", delayIFEI, 1));
            ifei.AddCommand(new Command(3004, "DOWN", delayIFEI, 1));
            AddDevice(ifei);

            var leftMFD = new Device(35, "LMFD");

            leftMFD.AddCommand(new Command(3011, "OSB-01", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3012, "OSB-02", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3013, "OSB-03", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3014, "OSB-04", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3015, "OSB-05", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3016, "OSB-06", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3017, "OSB-07", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3018, "OSB-08", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3019, "OSB-09", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3020, "OSB-10", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3021, "OSB-11", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3022, "OSB-12", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3023, "OSB-13", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3024, "OSB-14", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3025, "OSB-15", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3026, "OSB-16", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3027, "OSB-17", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3028, "OSB-18", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3029, "OSB-19", delayMFDs, 1));
            leftMFD.AddCommand(new Command(3030, "OSB-20", delayMFDs, 1));
            AddDevice(leftMFD);

            var rightMFD = new Device(36, "RMFD");
            rightMFD.AddCommand(new Command(3011, "OSB-01", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3012, "OSB-02", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3013, "OSB-03", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3014, "OSB-04", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3015, "OSB-05", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3016, "OSB-06", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3017, "OSB-07", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3018, "OSB-08", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3019, "OSB-09", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3020, "OSB-10", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3021, "OSB-11", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3022, "OSB-12", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3023, "OSB-13", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3024, "OSB-14", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3025, "OSB-15", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3026, "OSB-16", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3027, "OSB-17", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3028, "OSB-18", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3029, "OSB-19", delayMFDs, 1));
            rightMFD.AddCommand(new Command(3030, "OSB-20", delayMFDs, 1));
            AddDevice(rightMFD);

            var radarAltimeter = new Device(30, "RadAlt");
            radarAltimeter.AddCommand(new Command(3002, "Decrease", delayRot, -8));
            radarAltimeter.AddCommand(new Command(3002, "Increase", delayRot, 0.015));
            radarAltimeter.AddCommand(new Command(3001, "Test", delay, 1));
            AddDevice(radarAltimeter);

            var cmds = new Device(54, "CMDS");
            cmds.AddCommand(new Command(3001, "ON", -1, 0.1));
            cmds.AddCommand(new Command(3001, "OFF", -1, -1));
            cmds.AddCommand(new Command(3001, "BYPASS", -1, 1));
            AddDevice(cmds);
        }

        private void AddDevice(Device d)
        {
            Devices.Add(d.Name, d);
        }

        public Device GetDevice(string id)
        {
            return Devices[id];
        }
    }
}