namespace DTC.New.Presets.V1.Aircrafts.FA18;

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
}
