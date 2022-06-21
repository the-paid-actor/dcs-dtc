using System.Collections.Generic;

namespace DTC.Models.F16.TOS
{
	public class TOSSystem
	{
		public bool EnableUpload { get; set; }
		public TOSSetting[] TimesOnStation { get; set; }

		public TOSSystem()
		{
			TimesOnStation = new TOSSetting[24];
			initializeList();
			EnableUpload = true;
		}

		public void SetEnabled(int n, bool enabled)
        {
			TimesOnStation[n-1].EnableUpload = enabled;
        }

		public void SetTime(int n, string time)
        {
			TimesOnStation[n-1].Time = time;
        }

		private void initializeList()
        {
			for(int i = 1; i < 25; i++)
            {
				TimesOnStation[i-1] = new TOSSetting(false, "");
            }
        }
	}
}
