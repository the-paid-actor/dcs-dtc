using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.FA18.PrePlanned
{
    public class PrePlannedStation
    {
        public StationType stationType {  get; set; }  

        public int stationNumber { get; }
        public PrePlannedCoordinate PP1 {  get; set; }  
        public PrePlannedCoordinate PP2 {  get; set; }  
        public PrePlannedCoordinate PP3 {  get; set; }  
        public PrePlannedCoordinate PP4 {  get; set; }  
        public PrePlannedCoordinate PP5 {  get; set; }  

        public bool AnySelected
        {
            get
            {
                return PP1.Enabled || PP2.Enabled || PP3.Enabled || PP4.Enabled || PP5.Enabled;
            }
        }

        public PrePlannedStation(int number)
        {
            stationType = StationType.GBU38;
            stationNumber = number;

            PP1 = new PrePlannedCoordinate();
            PP2 = new PrePlannedCoordinate();
            PP3 = new PrePlannedCoordinate();
            PP4 = new PrePlannedCoordinate();  
            PP5 = new PrePlannedCoordinate();
        }
        public StationType fromString(string s)
        {
            switch (s)
            {
                case "GBU38":
                    return StationType.GBU38;
                case "GBU32":
                    return StationType.GBU32;
                case "GBU31":
                    return StationType.GBU31;
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
                case StationType.GBU31:
                    return "GBU31";
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
    }

    public enum StationType
    {
        GBU38,
        GBU32,
        GBU31,
        JSOWA,
        JSOWC,
        SLAM,
        SLAMER,
        AA,
        OTHER
    }


}
