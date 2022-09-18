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

        public Dictionary<int, PrePlannedStation> Stations;

        public PrePlannedSystem()
        {
            EnableUpload = false;

            Stations = new Dictionary<int, PrePlannedStation>();
            Stations.Add(2, new PrePlannedStation(2));
            Stations.Add(3, new PrePlannedStation(3));
            Stations.Add(7, new PrePlannedStation(7));
            Stations.Add(8, new PrePlannedStation(8));
        }
    }
}
