using System.Collections.Generic;
using DTC.Utilities;
using DTC.Models.DCS;

namespace DTC.Models.F15E
{
	public class F15ECommands : IAircraftDeviceManager
	{
		private Dictionary<string, Device> Devices = new Dictionary<string, Device>();

		public F15ECommands()
		{
			var delay = Settings.StrikeEagleCommandDelayMs;

            var ufc = new Device(56, "UFC_PILOT");
            ufc.AddCommand(new Command(3001, "PB1", delay, 1));
            ufc.AddCommand(new Command(3002, "PB2", delay, 1));
            ufc.AddCommand(new Command(3003, "PB3", delay, 1));
            ufc.AddCommand(new Command(3004, "PB4", delay, 1));
            ufc.AddCommand(new Command(3005, "PB5", delay, 1));
            ufc.AddCommand(new Command(3006, "PB6", delay, 1));
            ufc.AddCommand(new Command(3007, "PB7", delay, 1));
            ufc.AddCommand(new Command(3008, "PB8", delay, 1));
            ufc.AddCommand(new Command(3009, "PB9", delay, 1));
            ufc.AddCommand(new Command(3010, "PB10", delay, 1));
            ufc.AddCommand(new Command(3019, "GCML", delay, 1));
            ufc.AddCommand(new Command(3020, "1", delay, 1));
            ufc.AddCommand(new Command(3021, "2", delay, 1));
            ufc.AddCommand(new Command(3022, "3", delay, 1));
            ufc.AddCommand(new Command(3023, "GCMR", delay, 1));
            ufc.AddCommand(new Command(3025, "4", delay, 1));
            ufc.AddCommand(new Command(3026, "5", delay, 1));
            ufc.AddCommand(new Command(3027, "6", delay, 1));
            ufc.AddCommand(new Command(3030, "7", delay, 1));
            ufc.AddCommand(new Command(3031, "8", delay, 1));
            ufc.AddCommand(new Command(3032, "9", delay, 1));
            ufc.AddCommand(new Command(3036, "0", delay, 1));
            ufc.AddCommand(new Command(3029, ".", delay, 1));
            ufc.AddCommand(new Command(3033, "SHF", delay, 1));
            ufc.AddCommand(new Command(3038, "MENU", delay, 1));
            ufc.AddCommand(new Command(3035, "CLR", delay, 1));

            ufc.AddCommand(new Command(3011, "PRESLCCW", delay, -1));
            ufc.AddCommand(new Command(3012, "PRESRCCW", delay, -1));
            ufc.AddCommand(new Command(3055, "PRESL", delay, 1));
            ufc.AddCommand(new Command(3056, "PRESR", delay, 1));
            AddDevice(ufc);

            var mpdCommands = new Command[] {
                new Command(3061, "PB01", delay, 1),
                new Command(3062, "PB02", delay, 1),
                new Command(3063, "PB03", delay, 1),
                new Command(3064, "PB04", delay, 1),
                new Command(3065, "PB05", delay, 1),
                new Command(3066, "PB06", delay, 1),
                new Command(3067, "PB07", delay, 1),
                new Command(3068, "PB08", delay, 1),
                new Command(3069, "PB09", delay, 1),
                new Command(3070, "PB10", delay, 1),
                new Command(3071, "PB11", delay, 1),
                new Command(3072, "PB12", delay, 1),
                new Command(3073, "PB13", delay, 1),
                new Command(3074, "PB14", delay, 1),
                new Command(3075, "PB15", delay, 1),
                new Command(3076, "PB16", delay, 1),
                new Command(3077, "PB17", delay, 1),
                new Command(3078, "PB18", delay, 1),
                new Command(3079, "PB19", delay, 1),
                new Command(3080, "PB20", delay, 1)
            };

            var frontLeftMPD = new Device(34, "FLMPD");
            AddDevice(frontLeftMPD);
            foreach (var cmd in mpdCommands)
            {
                frontLeftMPD.AddCommand(cmd);
            }

            var frontMPCD = new Device(35, "FMPCD");
            AddDevice(frontMPCD);
            foreach (var cmd in mpdCommands)
            {
                frontMPCD.AddCommand(cmd);
            }

            var frontRightMPD = new Device(36, "FRMPD");
            AddDevice(frontRightMPD);
            foreach (var cmd in mpdCommands)
            {
                frontRightMPD.AddCommand(cmd);
            }

            var rearLeftMPCD = new Device(37, "RLMPCD");
            AddDevice(rearLeftMPCD);
            foreach (var cmd in mpdCommands)
            {
                rearLeftMPCD.AddCommand(cmd);
            }

            var rearLeftMPD = new Device(38, "RLMPD");
            AddDevice(rearLeftMPD);
            foreach (var cmd in mpdCommands)
            {
                rearLeftMPD.AddCommand(cmd);
            }

            var rearRightMPD = new Device(39, "RRMPD");
            AddDevice(rearRightMPD);
            foreach (var cmd in mpdCommands)
            {
                rearRightMPD.AddCommand(cmd);
            }

            var rearRightMPCD = new Device(40, "RRMPCD");
            AddDevice(rearRightMPCD);
            foreach (var cmd in mpdCommands)
            {
                rearRightMPCD.AddCommand(cmd);
            }

            var fltInst = new Device(17, "FLTINST");
            fltInst.AddCommand(new Command(3385, "BingoIncrease", 0, 0.1));
            fltInst.AddCommand(new Command(3385, "BingoDecrease", 0, -0.1));
            AddDevice(fltInst);
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