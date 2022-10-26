using System.Text.RegularExpressions;

namespace DTC.Models.FA18.CMS
{
	public class Program
	{
		public int Number { get; set; }
		public int FlareQty { get; set; }
		public int ChaffQty { get; set; }
		public decimal Interval { get; set; }
		public int Repeat { get; set; }
		public bool ToBeUpdated { get; set; }

		public Program(int number, int chaffQty, int flareQty, decimal interval, int repeat, bool toBeUpdated)
		{
			Number = number;
			FlareQty = flareQty;
			ChaffQty = chaffQty;
			Interval = interval;
			Repeat = repeat;
			ToBeUpdated = toBeUpdated;
		}

		private bool ValidateQty(string txt)
		{
			if (!int.TryParse(txt, out int i))
			{
				return false;
			}

			if (i < 0 || i > 99)
			{
				return false;
			}

			return true;
		}

		private bool ValidateInterval(string txt)
		{
            var regex = new Regex("^([012345][,.][0257][05])$");
			if (!decimal.TryParse(txt, out decimal f))
			{
				return false;
			}

			if (f < new decimal(0.25) || f > new decimal(5.0) || !regex.Match(txt).Success)
			{
				return false;
			}

			return true;
		}

		public string GetChaffQty()
		{
			return ChaffQty.ToString("00");
		}

		public string GetInterval()
		{
			return Interval.ToString("0.00");
		}

		public string GetRepeat()
		{
			return Repeat.ToString("00");
		}

		public string GetFlareQty()
		{
			return FlareQty.ToString("00");
		}

		public string SetChaffQty(string txt)
		{
			if (ValidateQty(txt))
			{
				ChaffQty = int.Parse(txt);
			}

			return GetChaffQty();
		}

		public string SetInterval(string txt)
		{
			if (ValidateInterval(txt))
			{
				Interval = decimal.Parse(txt);
			}

			return GetInterval();
		}

		public string SetFlareQty(string txt)
		{
			if (ValidateQty(txt))
			{
				FlareQty = int.Parse(txt);
			}

			return GetFlareQty();
		}

		public string SetRepeat(string txt)
		{
			if (ValidateQty(txt))
			{
				Repeat = int.Parse(txt);
			}

			return GetRepeat();
		}
	}
}
