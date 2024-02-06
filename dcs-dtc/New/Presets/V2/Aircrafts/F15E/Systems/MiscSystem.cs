using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.New.Presets.V2.Aircrafts.F15E.Systems;

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
    public string BullseyeCoord { get; set; }
    public int CARAALOW { get; set; }
    public bool CARAALOWToBeUpdated { get; set; }

    public int TACANChannel { get; set; }
    public TACANBands TACANBand { get; set; }
    public bool TACANToBeUpdated { get; set; }
    public decimal ILSFrequency { get; set; }
    public bool ILSToBeUpdated { get; set; }

    public MiscSystem()
    {
        Bingo = 4000;
        CARAALOW = 250;
        TACANChannel = 1;
        TACANBand = TACANBands.X;
        ILSFrequency = 108.10M;
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
            if (val >= 0 && val <= 14000)
            {
                if (val % 100 != 0)
                {
                    val = val / 100 * 100;
                }
                Bingo = val;
            }
        }
        return Bingo.ToString();
    }

    public string SetCARAALOW(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 0 && val <= 15000)
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
}