using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.New.Presets.V2.Aircrafts.F16.Systems;

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

    public string SetBullseyeWP(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 1 && val <= 99)
            {
                BullseyeWP = val;
            }
        }
        return BullseyeWP.ToString();
    }

    public string SetILSCourse(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 0 && val <= 359)
            {
                ILSCourse = val;
            }
        }
        return ILSCourse.ToString();
    }

    public string SetILSFrequency(string txt)
    {
        if (!ilsRegex.IsMatch(txt))
        {
            return GetILSFrequency();
        }

        if (decimal.TryParse(txt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val))
        {
            if (val >= 108.1M && val <= 111.95M)
            {
                ILSFrequency = val;
            }
        }
        return GetILSFrequency();
    }

    public string GetILSFrequency()
    {
        return ILSFrequency.ToString("000.00").Replace(",", ".");
    }

    public string SetTacanChannel(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 1 && val <= 126)
            {
                TACANChannel = val;
            }
        }
        return TACANChannel.ToString();
    }

    public string SetBingo(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 0 && val <= 99999)
            {
                Bingo = val;
            }
        }
        return Bingo.ToString();
    }

    public string SetCARAALOW(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 0 && val <= 50000)
            {
                var lastDigit = int.Parse(txt.Substring(txt.Length - 1, 1));
                if (lastDigit >= 1 && lastDigit <= 4)
                {
                    val -= lastDigit;
                }
                if (lastDigit >= 5 && lastDigit <= 9)
                {
                    val += 10 - lastDigit;
                }
                CARAALOW = val;
            }
        }
        return CARAALOW.ToString();
    }

    public string SetMSLFloor(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 0 && val <= 80000)
            {
                MSLFloor = val;
            }
        }
        return MSLFloor.ToString();
    }

    public string SetTGPCode(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if
            (
                txt.Length == 4 &&
                (txt.Substring(0, 1) == "1" || txt.Substring(0, 1) == "2") &&
                int.Parse(txt.Substring(1, 1)) >= 1 &&
                int.Parse(txt.Substring(1, 1)) <= 8 &&
                int.Parse(txt.Substring(2, 1)) >= 1 &&
                int.Parse(txt.Substring(2, 1)) <= 8 &&
                int.Parse(txt.Substring(3, 1)) >= 1 &&
                int.Parse(txt.Substring(3, 1)) <= 8
            )
            {
                TGPCode = val;
            }
        }
        return TGPCode.ToString();
    }

    public string SetLSTCode(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if
            (
                txt.Length == 4 &&
                (txt.Substring(0, 1) == "1" || txt.Substring(0, 1) == "2") &&
                int.Parse(txt.Substring(1, 1)) >= 1 &&
                int.Parse(txt.Substring(1, 1)) <= 8 &&
                int.Parse(txt.Substring(2, 1)) >= 1 &&
                int.Parse(txt.Substring(2, 1)) <= 8 &&
                int.Parse(txt.Substring(3, 1)) >= 1 &&
                int.Parse(txt.Substring(3, 1)) <= 8
            )
            {
                LSTCode = val;
            }
        }
        return LSTCode.ToString();
    }

    public string SetLaserStartTime(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 0 && val <= 176)
            {
                LaserStartTime = val;
            }
        }
        return LaserStartTime.ToString();
    }
}
