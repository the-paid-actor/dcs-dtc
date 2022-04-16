using System.Text;
using DTC.Models.DCS;
using DTC.Models.FA18.PrePlanned;

namespace DTC.Models.FA18.Upload
{
    internal class PrePlannedBuilder : BaseBuilder
    {
		private FA18Configuration _cfg;

		public PrePlannedBuilder(FA18Configuration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
		{
			_cfg = cfg;
		}

        public override void Build()
        {
			var ufc = _aircraft.GetDevice("UFC");
			var lmfd = _aircraft.GetDevice("LMFD");

			AppendCommand(lmfd.GetCommand("OSB-18")); // MENU
			AppendCommand(lmfd.GetCommand("OSB-05")); // STORES

			AppendCommand(StartCondition("STA_IS_GBUTT_2"));
			AppendCommand(lmfd.GetCommand("OSB-06")); // First-BTN aka Sta2
			AppendCommand(EndCondition("STA_IS_GBUTT_2"));
			AppendCommand(lmfd.GetCommand("OSB-11")); // JDAM-DSPLY

			AppendCommand(StartCondition("DEBUG"));
			AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
			AppendCommand(EndCondition("DEBUG"));
        }

		public string GoToMissionPage(PrePlannedStation station)
        {
			var sb = new StringBuilder();
			var condition = "";
            switch (station.stationType)
            {
				case StationType.GBU38:
					condition = "STA_IS_GBUTE_" + station.stationNumber;
					break;
				case StationType.GBU32:
					condition = "STA_IS_GBUTT_" + station.stationNumber;
					break;
				case StationType.GBU31:
					condition = "STA_IS_GBUTO_" + station.stationNumber;
					break;
				case StationType.JSOW:
					condition = "STA_IS_JSOW_" + station.stationNumber;
					break;
				case StationType.SLAM:
					condition = "STA_IS_SLAM_" + station.stationNumber;
					break;
				case StationType.SLAMER:
					condition = "STA_IS_SLAMER_" + station.stationNumber;
					break;
            }



			return sb.ToString();
        }
    }
}
