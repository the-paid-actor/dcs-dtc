namespace DTC.New.Presets.V1.Aircrafts.F15E;

public enum TACANBands
{
    X = 0,
    Y = 1
}

public class MiscSystem
{
    public int Bingo { get; set; }
    public bool BingoToBeUpdated { get; set; }
    public int CARAALOW { get; set; }
    public bool CARAALOWToBeUpdated { get; set; }

    public int TACANChannel { get; set; }
    public TACANBands TACANBand { get; set; }
    public bool TACANToBeUpdated { get; set; }
    public decimal ILSFrequency { get; set; }
    public bool ILSToBeUpdated { get; set; }
    public bool EnableUpload { get; set; }

    public MiscSystem()
    {
        Bingo = 4000;
        CARAALOW = 250;

        TACANChannel = 1;
        TACANBand = TACANBands.X;
        ILSFrequency = 108.10M;
    }
}
