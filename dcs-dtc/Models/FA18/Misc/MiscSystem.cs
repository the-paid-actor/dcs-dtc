using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.Models.FA18.Misc
{
	public enum TACANBands
	{
		X = 0,
		Y = 1
	}

	public class MiscSystem
	{
		private static Regex ilsRegex = new Regex(@"^1[0-1][8|9|0|1]\.[1|3|5|7|9][0|5]$");

		public int Bingo { get; set; }
		public bool BingoToBeUpdated { get; set; }
		public int BaroWarn { get; set; }
		public bool BaroToBeUpdated { get; set; }
		public int RadarWarn { get; set; }
		public bool RadarToBeUpdated { get; set; }
		public bool BlimTac { get; set; }
		public int TACANChannel { get; set; }
		public TACANBands TACANBand { get; set; }
		public bool TACANToBeUpdated { get; set; }
		public bool EnableUpload { get; set; }

		public MiscSystem()
		{
			Bingo = 2000;
			BaroWarn = 5000;
			RadarWarn = 200;

			RadarToBeUpdated = true;

			TACANChannel = 1;
			TACANBand = TACANBands.X;

			EnableUpload = true;
		}

		public string SetTacanChannel(string txt)
		{
			if (int.TryParse(txt, out int val))
			{
				if (val >= 1 && val <= 126)
				{
					TACANChannel = val;
				}
			}
			return TACANChannel.ToString();
		}

		public string SetBingo(string txt)
		{
			if (int.TryParse(txt, out int val))
			{
				if (val >= 0 && val <= 99999)
				{
					Bingo = val;
				}
			}
			return Bingo.ToString();
		}
		public string SetBaro(string txt)
		{
			if (int.TryParse(txt, out int val))
			{
				if (val >= 0 && val <= 99999)
				{
					BaroWarn = val;
				}
			}
			return BaroWarn.ToString();
		}
		public string SetRadar(string txt)
		{
			if (int.TryParse(txt, out int val))
			{
				if (val >= 0 && val <= 99999)
				{
					RadarWarn = val;
				}
			}
			return RadarWarn.ToString();
		}
	}
}
