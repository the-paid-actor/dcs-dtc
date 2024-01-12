using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.New.Presets.V2.Aircrafts.F16.Systems
{
    public enum DatalinkMode
    {
        OFF,
        TNDL,
        SMDL
    }

    public class DatalinkSystem
    {
        public bool? EnableOwnCallsign { get; set; }
        public string? OwnCallsign { get; set; }
        public bool? FlightLead { get; set; }

        public bool? EnableMembers { get; set; }
        public int? OwnshipIndex { get; set; }
        public int[]? Members { get; set; }
        public bool[]? TDOAMembers { get; set; }

        public DatalinkMode? DatalinkMode { get; set; }
    }
}
