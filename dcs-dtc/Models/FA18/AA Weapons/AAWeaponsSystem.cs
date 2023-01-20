using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.Models.FA18.AAWeapons
{

	public class AAWeaponsSystem
	{
		public bool AzElToBeUpdated { get; set; }
		public bool AIM9ToBeUpdated { get; set; }
		public string AIM9Bars { get; set; }
		public string AIM9Range { get; set; }
		public string AIM9Az { get; set; }
		public string AIM9PRF { get; set; }
		public string AIM9Timeout { get; set; }
		public bool AIM7ToBeUpdated { get; set; }
		public string AIM7Bars { get; set; }
		public string AIM7Range { get; set; }
		public string AIM7Az { get; set; }
		public string AIM7PRF { get; set; }
		public string AIM7Timeout { get; set; }
		public bool AIM120ToBeUpdated { get; set; }
		public string AIM120Bars { get; set; }
		public string AIM120Range { get; set; }
		public string AIM120Az { get; set; }
		public string AIM120PRF { get; set; }
		public string AIM120Timeout { get; set; }
		public bool EnableUpload { get; set; }

		public AAWeaponsSystem()
		{
			AzElToBeUpdated = true;

			AIM9ToBeUpdated = false;
			AIM9Bars = "6B";
			AIM9Range = "10";
			AIM9Az = "20";
			AIM9PRF = "MED";
			AIM9Timeout = "16";

			AIM7ToBeUpdated = false;
			AIM7Bars = "4B";
			AIM7Range = "40";
			AIM7Az = "40";
			AIM7PRF = "INTL";
			AIM7Timeout = "16";

			AIM120ToBeUpdated = false;
			AIM120Bars = "4B";
			AIM120Range = "40";
			AIM120Az = "40";
			AIM120PRF = "INTL";
			AIM120Timeout = "16";

			EnableUpload = true;
		}
	}
}