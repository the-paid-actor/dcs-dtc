using System.Globalization;

namespace DTC.New.Presets.V1.Aircrafts.F16;

public class Program
{
    public int Number { get; set; }

    public int FlareBurstQty { get; set; }
    public decimal FlareBurstInterval { get; set; }
    public int FlareSalvoQty { get; set; }
    public decimal FlareSalvoInterval { get; set; }

    public int ChaffBurstQty { get; set; }
    public decimal ChaffBurstInterval { get; set; }
    public int ChaffSalvoQty { get; set; }
    public decimal ChaffSalvoInterval { get; set; }
    public bool ToBeUpdated { get; set; }

    public Program(int number, int chaffBurstQty, decimal chaffBurstInterval, int chaffSalvoQty, decimal chaffSalvoInterval, int flareBurstQty, decimal flareBurstInterval, int flareSalvoQty, decimal flareSalvoInterval, bool toBeUpdated)
    {
        Number = number;
        FlareBurstQty = flareBurstQty;
        FlareBurstInterval = flareBurstInterval;
        FlareSalvoQty = flareSalvoQty;
        FlareSalvoInterval = flareSalvoInterval;
        ChaffBurstQty = chaffBurstQty;
        ChaffBurstInterval = chaffBurstInterval;
        ChaffSalvoQty = chaffSalvoQty;
        ChaffSalvoInterval = chaffSalvoInterval;
        ToBeUpdated = toBeUpdated;
    }
}
