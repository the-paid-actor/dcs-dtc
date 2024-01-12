using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.New.Presets.V2.Aircrafts.FA18.Systems
{
    public enum HMDRejectMode
    {
        Normal = 1,
        Reject1 = 2,
        Reject2 = 3
    }

    public class HMDSystem
    {
        public static string[] RejectSettingsNames = new string[]
        {
            "ALTITUDE",
            "AIRSPEED",
            "BARO/RADALT",
            "BARO PRES",
            "VSI",
            "ALPHA",
            "NIRD CIRCLE",
            "MSL FOR",
            "SP/AMR FOV",
            "EW",
            "HMD HEADING",
            "HMD ELEV",
            "A/C HEADING",
            "TIME WINDOW",
            "FLIR FOV",
            "MEMBERS",
            "CLOSEST FRND",
            "TUCD TRACK",
            "WINDOW      1",
            "WINDOW      2",
            "WINDOW      3",
            "WINDOW      4",
            "WINDOW      5",
            "WINDOW      6",
            "WINDOW      7",
            "WINDOW      8",
            "WINDOW      9",
            "WINDOW     10",
            "ALT_ASPD_BOX",
            "CLIMD_ASPD",
            "MACH",
            "G",
            "MAX G",
            "DONORS",
            "OTHERS",
            "MIDS INFO"
        };

        public static HMDRejectMode[] DefaultRejectSettings = new HMDRejectMode[]
        {
            HMDRejectMode.Normal, // "ALTITUDE",
            HMDRejectMode.Normal, // "AIRSPEED",
            HMDRejectMode.Normal, // "BARO/RADALT",
            HMDRejectMode.Normal, // "BARO PRES",
            HMDRejectMode.Normal, // "VSI",
            HMDRejectMode.Normal, // "ALPHA",
            HMDRejectMode.Normal, // "NIRD CIRCLE",
            HMDRejectMode.Normal, // "MSL FOR",
            HMDRejectMode.Normal, // "SP/AMR FOV",
            HMDRejectMode.Normal, // "EW",
            HMDRejectMode.Reject2, // "HMD HEADING",
            HMDRejectMode.Reject2, // "HMD ELEV",
            HMDRejectMode.Reject2, // "A/C HEADING",
            HMDRejectMode.Reject2, // "TIME WINDOW",
            HMDRejectMode.Reject2, // "FLIR FOV",
            HMDRejectMode.Reject2, // "MEMBERS",
            HMDRejectMode.Reject1, // "CLOSEST FRND",
            HMDRejectMode.Reject1, // "TUCD TRACK",
            HMDRejectMode.Reject2, // "WINDOW      1",
            HMDRejectMode.Reject2, // "WINDOW      2",
            HMDRejectMode.Reject2, // "WINDOW      3",
            HMDRejectMode.Reject2, // "WINDOW      4",
            HMDRejectMode.Reject2, // "WINDOW      5",
            HMDRejectMode.Reject2, // "WINDOW      6",
            HMDRejectMode.Reject2, // "WINDOW      7",
            HMDRejectMode.Reject2, // "WINDOW      8",
            HMDRejectMode.Reject2, // "WINDOW      9",
            HMDRejectMode.Reject2, // "WINDOW     10",
            HMDRejectMode.Reject1, // "ALT_ASPD_BOX",
            HMDRejectMode.Reject1, // "CLIMD_ASPD",
            HMDRejectMode.Reject1, // "MACH",
            HMDRejectMode.Reject1, // "G",
            HMDRejectMode.Reject1, // "MAX G",
            HMDRejectMode.Reject2, // "DONORS",
            HMDRejectMode.Reject2, // "OTHERS",
            HMDRejectMode.Reject1 // "MIDS INFO"
        };

        public HMDRejectMode RejectMode { get; set; }

        public Dictionary<string, HMDRejectMode> RejectSettings = new();
    }
}
