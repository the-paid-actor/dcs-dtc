using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.Models.FA18.Radios
{
	public class RadioChannel
	{
		private static Regex uhfRegex = new Regex(@"^[2-3][0-9][0-9]\.?[0-9]?[0-9]?[0-9]?$");
		private static Regex vhfRegex = new Regex(@"^[0-1]?[0-8][0-9]\.?[0-9]?[0-9]?[0-9]?$");

		public RadioType Type { get; set; }
		public int Channel { get; set; }
		public decimal Frequency { get; set; }
		public bool ToBeUpdated { get; set; }

		public RadioChannel(RadioType type, int channel, decimal frequency,bool toBeUpdated)
		{
			Type = type;
			Channel = channel;
			Frequency = frequency;
			ToBeUpdated = toBeUpdated;
		}

		public string GetFrequency()
		{
			return Frequency.ToString("000.000").Replace(",", ".");
		}

		public string SetFrequency(string freq)
		{
            if (ValidateUHF(freq) || ValidateVHF(freq))
            {
                if (Parse(freq, out decimal f))
                {
                    Frequency = f;
                }
            }
			return GetFrequency();
		}

		private bool Parse(string s, out decimal f)
		{
			if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out f))
			{
				return true;
			}

			return false;
		}

		private bool ValidateVHF(string freq)
		{
			if (!vhfRegex.IsMatch(freq))
			{
				return false;
			}

			if (!Parse(freq, out decimal f))
			{
				return false;
			}

			if (f < new decimal(30.0))
			{
				return false;
			}

			if (f > new decimal(87.97) && f < new decimal(108.00))
			{
				return false;
			}

			if (f > new decimal(151.97))
			{
				return false;
			}

			return true;
		}

		private bool ValidateUHF(string freq)
		{
			if (!uhfRegex.IsMatch(freq))
			{
				return false;
			}

			if (!Parse(freq, out decimal f))
			{
				return false;
			}

			if (f < new decimal(225.00))
			{
				return false;
			}

			return true;
		}
	}

}
