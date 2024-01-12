using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.New.Presets.V2.Aircrafts.FA18.Systems;

public class Program
{
    public int Number { get; set; }
    public int FlareQty { get; set; }
    public int ChaffQty { get; set; }
    public decimal Interval { get; set; }
    public int Repeat { get; set; }
    public bool ToBeUpdated { get; set; }

    public Program(int number, int chaffQty, int flareQty, decimal interval, int repeat, bool toBeUpdated)
    {
        Number = number;
        FlareQty = flareQty;
        ChaffQty = chaffQty;
        Interval = interval;
        Repeat = repeat;
        ToBeUpdated = toBeUpdated;
    }

    private bool ValidateQty(string txt)
    {
        if (!int.TryParse(txt, NumberStyles.Number, CultureInfo.InvariantCulture, out int i))
        {
            return false;
        }

        if (i < 0 || i > 99)
        {
            return false;
        }

        return true;
    }

    private bool ValidateInterval(string txt)
    {
        var regex = new Regex("^([012345][,.][0257][05])$");
        if (!decimal.TryParse(txt, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal f))
        {
            return false;
        }

        if (f < new decimal(0.25) || f > new decimal(5.0) || !regex.Match(txt).Success)
        {
            return false;
        }

        return true;
    }

    public string GetChaffQty()
    {
        return ChaffQty.ToString("00", CultureInfo.InvariantCulture);
    }

    public string GetInterval()
    {
        return Interval.ToString("0.00", CultureInfo.InvariantCulture);
    }

    public string GetRepeat()
    {
        return Repeat.ToString("00", CultureInfo.InvariantCulture);
    }

    public string GetFlareQty()
    {
        return FlareQty.ToString("00", CultureInfo.InvariantCulture);
    }

    public string SetChaffQty(string txt)
    {
        if (ValidateQty(txt))
        {
            ChaffQty = int.Parse(txt, NumberStyles.Number, CultureInfo.InvariantCulture);
        }

        return GetChaffQty();
    }

    public string SetInterval(string txt)
    {
        if (ValidateInterval(txt))
        {
            Interval = decimal.Parse(txt, NumberStyles.Number, CultureInfo.InvariantCulture);
        }

        return GetInterval();
    }

    public string SetFlareQty(string txt)
    {
        if (ValidateQty(txt))
        {
            FlareQty = int.Parse(txt, NumberStyles.Number, CultureInfo.InvariantCulture);
        }

        return GetFlareQty();
    }

    public string SetRepeat(string txt)
    {
        if (ValidateQty(txt))
        {
            Repeat = int.Parse(txt, NumberStyles.Number, CultureInfo.InvariantCulture);
        }

        return GetRepeat();
    }
}

public enum CMSMode
{
    Unchanged = 1,
    Standby = 2,
    Manual = 3,
    SemiAuto = 4,
    Auto = 5
}

public class CMSystem
{
    public Program[] Programs { get; set; }

    public CMSMode? Mode { get; set; }
    public int SelectedProgram { get; set; }
    public bool EnableHUD { get; set; }

    public CMSystem()
    {
        Programs = new Program[5];
        Programs[0] = new Program(1, 1, 1, 1.0M, 10, false);
        Programs[1] = new Program(2, 1, 1, 0.5M, 10, false);
        Programs[2] = new Program(3, 2, 2, 1.0M, 5, false);
        Programs[3] = new Program(4, 2, 2, 0.5M, 10, false);
        Programs[4] = new Program(5, 1, 1, 1.0M, 2, false);
    }
}
