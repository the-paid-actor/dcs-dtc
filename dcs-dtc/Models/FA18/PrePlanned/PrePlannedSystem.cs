using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.FA18.PrePlanned
{
    public class PrePlannedSystem
    {
		public bool EnableUpload { get; set; }
		public bool Station5ToConsider { get; set; }
        public PrePlannedStation Sta2 { get; set; }
        public PrePlannedStation Sta3 { get; set; } 
        public PrePlannedStation Sta7 { get; set; } 
        public PrePlannedStation Sta8 { get; set; }

        public PrePlannedSystem()
        {
            EnableUpload = false;

            Sta2 = new PrePlannedStation(2);
            Sta3 = new PrePlannedStation(3);
            Sta7 = new PrePlannedStation(7);
            Sta8 = new PrePlannedStation(8);
        }
    }
}
