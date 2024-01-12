using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.New.Presets.V2.Aircrafts.FA18.Systems
{
    public class FCRSystem
    {
        public FCRWeaponSettings AMRAAMSettings { get; set; } = new FCRWeaponSettings(40, 2, 140, FCRPRFMode.Interleaved, 4);
        public FCRWeaponSettings AIM9Settings { get; set; } = new FCRWeaponSettings(40, 4, 80, FCRPRFMode.Interleaved, 8);
        public FCRWeaponSettings AIM7Settings { get; set; } = new FCRWeaponSettings(40, 4, 140, FCRPRFMode.Interleaved, 8);

        public FCRDeclutterMode DeclutterMode { get; set; } = FCRDeclutterMode.Declutter2;
        public bool EnableRWR { get; set; }
        public bool EnableBRA { get; set; }
    }

    public class FCRWeaponSettings
    {
        public static int[] RangeValues = new[] { 5, 10, 20, 40, 80, 160 };
        public static int[] BarsValues = new[] { 1, 2, 4, 6 };
        public static int[] AzimuthValues = new[] { 20, 40, 60, 80, 140 };
        public static int[] AgingValues = new[] { 2, 4, 8, 16, 32 };

        public int Range { get; set; }
        public int Bars { get; set; }
        public int Azimuth { get; set; }
        public FCRPRFMode PRF { get; set; }
        public int Aging { get; set; }

        public FCRWeaponSettings(int range, int bars, int azimuth, FCRPRFMode pRF, int aging)
        {
            Range = range;
            Bars = bars;
            Azimuth = azimuth;
            PRF = pRF;
            Aging = aging;
        }
    }

    public enum FCRPRFMode
    {
        High = 1,
        Medium = 2,
        Interleaved = 3
    }

    public enum FCRDeclutterMode
    {
        Normal = 1,
        Declutter1 = 2,
        Declutter2 = 3
    }
}
