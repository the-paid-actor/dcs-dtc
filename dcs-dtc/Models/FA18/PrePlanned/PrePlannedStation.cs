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
    }

    public enum StationType
    {
        GBU38,
        GBU32,
        GBU31,
        JSOW,
        SLAM,
        SLAMER
    }
}
