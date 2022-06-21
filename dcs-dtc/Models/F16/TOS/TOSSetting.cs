using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.F16.TOS
{
    public class TOSSetting
    {
		public TOSSetting(bool enable, string time)
        {
			EnableUpload = enable;
			Time = time;
        }

		public bool EnableUpload { get; set; }

		public string Time {  get; set; }
    }
}
