using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.FA18.PrePlanned
{
    public class PrePlannedStation:IComparable<PrePlannedStation>
    {
        public StationType stationType {  get; set; }  

        public int stationNumber { get; set; }
        public Dictionary<int, PrePlannedCoordinate> PP;
        public PrePlannedSteerpoint[] Steerpoints = new PrePlannedSteerpoint[5]; /* for SLAM-ER */

        public bool AnyStpEnabled {
            get
            {
                foreach (var stp in Steerpoints)
                    if (stp.Enabled)
                        return true;
                return false;
            }
        }

        public bool AnySelected
        {
            get
            {
                foreach (var p in PP.Values)
                    if (p.Enabled)
                        return true;
                return false;
            }
        }

        public PrePlannedStation(int number)
        {
            stationType = StationType.GBU38;
            stationNumber = number;

            PP = new Dictionary<int, PrePlannedCoordinate>();
            for (int i = 1; i <= 5; i++)
                PP.Add(i, new PrePlannedCoordinate());

            for (int i = 0; i < 5; i++) {
                Steerpoints[i] = new PrePlannedSteerpoint();
            }
        }
        public StationType fromString(string s)
        {
            switch (s)
            {
                case "GBU38":
                    return StationType.GBU38;
                case "GBU32":
                    return StationType.GBU32;
                case "GBU31-1/2":
                    return StationType.GBU31NP;
                case "GBU31-3/4":
                    return StationType.GBU31PP;
                case "JSOWA":
                    return StationType.JSOWA;
                case "JSOWC":
                    return StationType.JSOWC;
                case "SLAM":
                    return StationType.SLAM;
                case "SLAMER":
                    return StationType.SLAMER;
                case "Anti-Air/Nothing":
                    return StationType.AA;
                default:
                    return StationType.OTHER;
            }
        }

        public static string TypeToString(StationType type)
        {
            switch(type)
            {
                case StationType.GBU38:
                    return "GBU38";
                case StationType.GBU32:
                    return "GBU32";
                case StationType.GBU31NP:
                    return "GBU31-1/2";
                case StationType.GBU31PP:
                    return "GBU31-3/4";
                case StationType.JSOWA:
                    return "JSOWA";
                case StationType.JSOWC:
                    return "JSOWC";
                case StationType.SLAM:
                    return "SLAM";
                case StationType.SLAMER:
                    return "SLAMER";
                case StationType.AA:
                    return "Anti-Air/Nothing";
                default:
                    return "Other-AG";
            }
        }

        private int StepOrder() {
            switch (stationNumber) {
                case 8: return 1;
                case 2: return 2;
                case 7: return 3;
                case 3: return 4;
                default:
                    throw new ApplicationException("Internal error -- invalid station number:" + stationNumber);
            }
        }

        public int CompareTo(PrePlannedStation other)
        {
            return StepOrder().CompareTo(other.StepOrder());
        }
    }

    public enum StationType
    {
        GBU38,
        GBU32,
        GBU31NP,
        GBU31PP,
        JSOWA,
        JSOWC,
        SLAM,
        SLAMER,
        AA,
        OTHER
    }


}
