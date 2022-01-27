namespace DTC.Models.F16.CMS
{
	public class Program
	{
		public int Number { get; set; }

		public int FlareBurstQty { get; set; }
		public decimal FlareBurstInterval { get; set; }
		public int FlareSalvoQty { get; set; }
		public decimal FlareSalvoInterval { get; set; }

		public int ChaffBurstQty { get; set; }
		public decimal ChaffBurstInterval { get; set; }
		public int ChaffSalvoQty { get; set; }
		public decimal ChaffSalvoInterval { get; set; }
		public bool ToBeUpdated { get; set; }

		public Program(int number, int chaffBurstQty, decimal chaffBurstInterval, int chaffSalvoQty, decimal chaffSalvoInterval, int flareBurstQty, decimal flareBurstInterval, int flareSalvoQty, decimal flareSalvoInterval, bool toBeUpdated)
		{
			Number = number;
			FlareBurstQty = flareBurstQty;
			FlareBurstInterval = flareBurstInterval;
			FlareSalvoQty = flareSalvoQty;
			FlareSalvoInterval = flareSalvoInterval;
			ChaffBurstQty = chaffBurstQty;
			ChaffBurstInterval = chaffBurstInterval;
			ChaffSalvoQty = chaffSalvoQty;
			ChaffSalvoInterval = chaffSalvoInterval;
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

		private bool ValidateBurstInterval(string txt)
		{
			if (!decimal.TryParse(txt, out decimal f))
			{
				return false;
			}

			if (f < new decimal(0.020) || f > new decimal(10.0))
			{
				return false;
			}

			return true;
		}

		private bool ValidateSalvoInterval(string txt)
		{
			if (!decimal.TryParse(txt, out decimal f))
			{
				return false;
			}

			if (f < new decimal(0.50) || f > new decimal(150.0))
			{
				return false;
			}

			return true;
		}

		public string GetChaffBurstQty()
		{
			return ChaffBurstQty.ToString("00");
		}

		public string GetChaffBurstInterval()
		{
			return ChaffBurstInterval.ToString("00.000");
		}

		public string GetChaffSalvoQty()
		{
			return ChaffSalvoQty.ToString("00");
		}

		public string GetChaffSalvoInterval()
		{
			return ChaffSalvoInterval.ToString("000.00");
		}

		public string SetChaffBurstQty(string txt)
		{
			if (ValidateQty(txt))
			{
				ChaffBurstQty = int.Parse(txt);
			}

			return GetChaffBurstQty();
		}

		public string SetChaffBurstInterval(string txt)
		{
			if (ValidateBurstInterval(txt))
			{
				ChaffBurstInterval = decimal.Parse(txt);
			}

			return GetChaffBurstInterval();
		}

		public string SetChaffSalvoQty(string txt)
		{
			if (ValidateQty(txt))
			{
				ChaffSalvoQty = int.Parse(txt);
			}

			return GetChaffSalvoQty();
		}

		public string SetChaffSalvoInterval(string txt)
		{
			if (ValidateSalvoInterval(txt))
			{
				ChaffSalvoInterval = decimal.Parse(txt);
			}

			return GetChaffSalvoInterval();
		}

		public string GetFlareBurstQty()
		{
			return FlareBurstQty.ToString("00");
		}

		public string GetFlareBurstInterval()
		{
			return FlareBurstInterval.ToString("00.000");
		}

		public string GetFlareSalvoQty()
		{
			return FlareSalvoQty.ToString("00");
		}

		public string GetFlareSalvoInterval()
		{
			return FlareSalvoInterval.ToString("000.00");
		}

		public string SetFlareBurstQty(string txt)
		{
			if (ValidateQty(txt))
			{
				FlareBurstQty = int.Parse(txt);
			}

			return GetFlareBurstQty();
		}

		public string SetFlareBurstInterval(string txt)
		{
			if (ValidateBurstInterval(txt))
			{
				FlareBurstInterval = decimal.Parse(txt);
			}

			return GetFlareBurstInterval();
		}

		public string SetFlareSalvoQty(string txt)
		{
			if (ValidateQty(txt))
			{
				FlareSalvoQty = int.Parse(txt);
			}

			return GetFlareSalvoQty();
		}

		public string SetFlareSalvoInterval(string txt)
		{
			if (ValidateSalvoInterval(txt))
			{
				FlareSalvoInterval = decimal.Parse(txt);
			}

			return GetFlareSalvoInterval();
		}
	}
}
