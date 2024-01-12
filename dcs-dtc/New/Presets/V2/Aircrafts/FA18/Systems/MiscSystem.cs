using System.Linq.Expressions;

namespace DTC.New.Presets.V2.Aircrafts.FA18.Systems;

public enum TACANBands
{
    X = 0,
    Y = 1
}

public class MiscSystem
{
    public int Bingo { get; set; }
    public bool BingoToBeUpdated { get; set; }
    public bool BullseyeToBeUpdated { get; set; }
    public int BullseyeWP { get; set; }
    public int BaroWarn { get; set; }
    public bool BaroToBeUpdated { get; set; }
    public int RadarWarn { get; set; }
    public bool RadarToBeUpdated { get; set; }
    public bool BlimTac { get; set; }
    public int TACANChannel { get; set; }
    public TACANBands TACANBand { get; set; }
    public bool TACANToBeUpdated { get; set; }
    public bool ILSToBeUpdated { get; set; }
    public int ILSChannel { get; set; }
    public bool HideMapOnHSI { get; set; }
    public bool LaserSettingsToBeUpdated { get; set; }
    public int TGPCode { get; set; }
    public int LSTCode { get; set; }

    public MiscSystem()
    {
        Bingo = 2000;
        BaroWarn = 5000;
        RadarWarn = 200;
        TGPCode = 1688;
        LSTCode = 1688;
        BullseyeWP = 59;
        TACANChannel = 1;
        TACANBand = TACANBands.X;
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

    public string SetBullseyeWP(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            BullseyeWP = val;
        }
        return BullseyeWP.ToString();
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
    public string SetBaro(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 0 && val <= 99999)
            {
                BaroWarn = val;
            }
        }
        return BaroWarn.ToString();
    }
    public string SetRadar(string txt)
    {
        if (int.TryParse(txt, out int val))
        {
            if (val >= 0 && val <= 99999)
            {
                RadarWarn = val;
            }
        }
        return RadarWarn.ToString();
    }
}
