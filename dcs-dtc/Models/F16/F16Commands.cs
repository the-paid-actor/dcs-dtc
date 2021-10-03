using System.Collections.Generic;
using System.Configuration;
using DTC.Models.DCS;

namespace DTC.Models.F16
{
	public class F16Commands
	{
		public Dictionary<string, Device> Devices = new Dictionary<string, Device>();

		public F16Commands()
		{
			int delay;
			if (!int.TryParse(ConfigurationManager.AppSettings["CommandDelayMs"], out delay))
			{
				delay = 1000;
			}

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
			ufc.AddCommand(new Command(3015, "LIST", delay, 1));
			ufc.AddCommand(new Command(3016, "ENTR", delay, 1));
			ufc.AddCommand(new Command(3017, "RCL", 0, 1));
			ufc.AddCommand(new Command(3018, "AA", delay, 1));
			ufc.AddCommand(new Command(3019, "AG", delay, 1));
			ufc.AddCommand(new Command(3030, "INC", delay, 1));
			ufc.AddCommand(new Command(3031, "DEC", delay, 1));
			ufc.AddCommand(new Command(3032, "RTN", delay, -1));
			ufc.AddCommand(new Command(3033, "SEQ", delay * 2, 1));
			ufc.AddCommand(new Command(3034, "UP", delay, 1));
			ufc.AddCommand(new Command(3035, "DOWN", delay, -1));
			AddDevice(ufc);

			var hotas = new Device(16, "HOTAS");
			hotas.AddCommand(new Command(3030, "DGFT", -1, 1));
			hotas.AddCommand(new Command(3030, "MSL", -1, -1));
			hotas.AddCommand(new Command(3030, "CENTER", -1, 0));
			AddDevice(hotas);

			var leftMFD = new Device(24, "LMFD");
			leftMFD.AddCommand(new Command(3012, "OSB-12-PG3", delay, 1));
			leftMFD.AddCommand(new Command(3013, "OSB-13-PG2", delay, 1));
			leftMFD.AddCommand(new Command(3014, "OSB-14-PG1", delay, 1));
			leftMFD.AddCommand(new Command(3001, "OSB-01-BLANK", delay, 1));
			leftMFD.AddCommand(new Command(3002, "OSB-02-HAD", delay, 1));
			leftMFD.AddCommand(new Command(3004, "OSB-04-RCCE", delay, 1));
			leftMFD.AddCommand(new Command(3006, "OSB-06-SMS", delay, 1));
			leftMFD.AddCommand(new Command(3007, "OSB-07-HSD", delay, 1));
			leftMFD.AddCommand(new Command(3008, "OSB-08-DTE", delay, 1));
			leftMFD.AddCommand(new Command(3009, "OSB-09-TEST", delay, 1));
			leftMFD.AddCommand(new Command(3010, "OSB-10-FLCS", delay, 1));
			leftMFD.AddCommand(new Command(3016, "OSB-16-FLIR", delay, 1));
			leftMFD.AddCommand(new Command(3017, "OSB-17-TFR", delay, 1));
			leftMFD.AddCommand(new Command(3018, "OSB-18-WPN", delay, 1));
			leftMFD.AddCommand(new Command(3019, "OSB-19-TGP", delay, 1));
			leftMFD.AddCommand(new Command(3020, "OSB-20-FCR", delay, 1));
			AddDevice(leftMFD);

			var rightMFD = new Device(25, "RMFD");
			rightMFD.AddCommand(new Command(3012, "OSB-12-PG3", delay, 1));
			rightMFD.AddCommand(new Command(3013, "OSB-13-PG2", delay, 1));
			rightMFD.AddCommand(new Command(3014, "OSB-14-PG1", delay, 1));
			rightMFD.AddCommand(new Command(3001, "OSB-01-BLANK", delay, 1));
			rightMFD.AddCommand(new Command(3002, "OSB-02-HAD", delay, 1));
			rightMFD.AddCommand(new Command(3004, "OSB-04-RCCE", delay, 1));
			rightMFD.AddCommand(new Command(3006, "OSB-06-SMS", delay, 1));
			rightMFD.AddCommand(new Command(3007, "OSB-07-HSD", delay, 1));
			rightMFD.AddCommand(new Command(3008, "OSB-08-DTE", delay, 1));
			rightMFD.AddCommand(new Command(3009, "OSB-09-TEST", delay, 1));
			rightMFD.AddCommand(new Command(3010, "OSB-10-FLCS", delay, 1));
			rightMFD.AddCommand(new Command(3016, "OSB-16-FLIR", delay, 1));
			rightMFD.AddCommand(new Command(3017, "OSB-17-TFR", delay, 1));
			rightMFD.AddCommand(new Command(3018, "OSB-18-WPN", delay, 1));
			rightMFD.AddCommand(new Command(3019, "OSB-19-TGP", delay, 1));
			rightMFD.AddCommand(new Command(3020, "OSB-20-FCR", delay, 1));
			AddDevice(rightMFD);
		}

		public void AddDevice(Device d)
		{
			Devices.Add(d.Name, d);
		}
	}
}