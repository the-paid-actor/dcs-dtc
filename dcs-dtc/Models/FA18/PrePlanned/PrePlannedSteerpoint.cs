using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.FA18.PrePlanned
{
    public class PrePlannedSteerpoint: PrePlannedCoordinate
    {
        public bool useCoordinate;
        public int waypointNumber;
    }
}
