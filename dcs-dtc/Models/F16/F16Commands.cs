using DTC.Utilities;
using DTC.Models.DCS;
using System.Collections.Generic;

namespace DTC.Models.F16
{
	public class F16Commands : IAircraftDeviceManager
	{
		private Dictionary<string, Device> Devices = new Dictionary<string, Device>();

		public F16Commands()
		{
			var delay = Settings.ViperCommandDelayMs;

			var delayMFDs = delay / 4;
			var delayList = delay / 4;
			var delayEntr = delay / 2;
			var delayDown = delay;
			var delayUp = delay;
			var delaySeq = delay;
			var delayRtn = delay;

			var sms = new Device(22, "SMS");
			sms.AddCommand(new Command(3002, "LEFT_HDPT", 0, 1));
			sms.AddCommand(new Command(3003, "RIGHT_HDPT", 0, 1));
			AddDevice(sms);

            var ufc = new Device(17, "UFC");
			ufc.AddCommand(new Command(3002, "0", 0, 1));
			ufc.AddCommand(new Command(3003, "1", 0, 1));
			ufc.AddCommand(new Command(3004, "2", 0, 1));
			ufc.AddCommand(new Command(3005, "3", 0, 1));
			ufc.AddCommand(new Command(3006, "4", 0, 1));
			ufc.AddCommand(new Command(3007, "5", 0, 1));
			ufc.AddCommand(new Command(3008, "6", 0, 1));
			ufc.AddCommand(new Command(3009, "7", 0, 1));
			ufc.AddCommand(new Command(3010, "8", 0, 1));
			ufc.AddCommand(new Command(3011, "9", 0, 1));
			ufc.AddCommand(new Command(3012, "COM1", 0, 1));
			ufc.AddCommand(new Command(3013, "COM2", 0, 1));
			ufc.AddCommand(new Command(3015, "LIST", delayList, 1));
			ufc.AddCommand(new Command(3016, "ENTR", delayEntr, 1));
			ufc.AddCommand(new Command(3017, "RCL", 0, 1));
			ufc.AddCommand(new Command(3018, "AA", delay, 1));
			ufc.AddCommand(new Command(3019, "AG", delay, 1));
			ufc.AddCommand(new Command(3030, "INC", delay, 1));
			ufc.AddCommand(new Command(3031, "DEC", delay, 1));
			ufc.AddCommand(new Command(3032, "RTN", delayRtn, -1));
			ufc.AddCommand(new Command(3033, "SEQ", delaySeq, 1));
			ufc.AddCommand(new Command(3034, "UP", delayUp, 1));
			ufc.AddCommand(new Command(3035, "DOWN", delayDown, -1));
			AddDevice(ufc);

			var hotas = new Device(16, "HOTAS");
			hotas.AddCommand(new Command(3030, "DGFT", -1, 1));
			hotas.AddCommand(new Command(3030, "MSL", -1, -1));
			hotas.AddCommand(new Command(3030, "CENTER", -1, 0));
			AddDevice(hotas);

			var leftMFD = new Device(24, "LMFD");
			leftMFD.AddCommand(new Command(3012, "OSB-12-PG3", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3013, "OSB-13-PG2", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3014, "OSB-14-PG1", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3001, "OSB-01-BLANK", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3002, "OSB-02-HAD", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3003, "OSB-03", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3004, "OSB-04-RCCE", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3005, "OSB-05", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3006, "OSB-06-SMS", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3007, "OSB-07-HSD", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3008, "OSB-08-DTE", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3009, "OSB-09-TEST", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3010, "OSB-10-FLCS", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3016, "OSB-16-FLIR", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3017, "OSB-17-TFR", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3018, "OSB-18-WPN", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3019, "OSB-19-TGP", delayMFDs, 1));
			leftMFD.AddCommand(new Command(3020, "OSB-20-FCR", delayMFDs, 1));
			AddDevice(leftMFD);

			var rightMFD = new Device(25, "RMFD");
			rightMFD.AddCommand(new Command(3012, "OSB-12-PG3", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3013, "OSB-13-PG2", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3014, "OSB-14-PG1", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3001, "OSB-01-BLANK", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3002, "OSB-02-HAD", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3003, "OSB-03", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3004, "OSB-04-RCCE", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3005, "OSB-05", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3006, "OSB-06-SMS", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3007, "OSB-07-HSD", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3008, "OSB-08-DTE", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3009, "OSB-09-TEST", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3010, "OSB-10-FLCS", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3016, "OSB-16-FLIR", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3017, "OSB-17-TFR", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3018, "OSB-18-WPN", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3019, "OSB-19-TGP", delayMFDs, 1));
			rightMFD.AddCommand(new Command(3020, "OSB-20-FCR", delayMFDs, 1));
			AddDevice(rightMFD);
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