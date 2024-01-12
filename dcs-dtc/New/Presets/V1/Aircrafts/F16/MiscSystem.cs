using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.New.Presets.V1.Aircrafts.F16;

public enum TACANBands
{
    X = 0,
    Y = 1
}

public class MiscSystem
{
    private static Regex ilsRegex = new Regex(@"^1[0-1][8|9|0|1]\.[1|3|5|7|9]?[0|5]?$");

    public int Bingo { get; set; }
    public bool BingoToBeUpdated { get; set; }
    public bool BullseyeToBeUpdated { get; set; }
    public int BullseyeWP { get; set; }
    public int CARAALOW { get; set; }
    public bool CARAALOWToBeUpdated { get; set; }
    public int MSLFloor { get; set; }
    public bool MSLFloorToBeUpdated { get; set; }

    public bool LaserSettingsToBeUpdated { get; set; }
    public int TGPCode { get; set; }
    public int LSTCode { get; set; }
    public int LaserStartTime { get; set; }

    public int TACANChannel { get; set; }
    public TACANBands TACANBand { get; set; }
    public bool TACANToBeUpdated { get; set; }
    public decimal ILSFrequency { get; set; }
    public int ILSCourse { get; set; }
    public bool ILSToBeUpdated { get; set; }
    public bool EnableUpload { get; set; }

    public MiscSystem()
    {
        Bingo = 2000;
        BullseyeWP = 25;
        CARAALOW = 500;
        MSLFloor = 5000;
        TGPCode = 1688;
        LSTCode = 1688;
        LaserStartTime = 8;

        TACANChannel = 1;
        TACANBand = TACANBands.X;
        ILSFrequency = 108.10M;
        ILSCourse = 0;
    }
}
