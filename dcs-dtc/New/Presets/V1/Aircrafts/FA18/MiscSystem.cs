namespace DTC.New.Presets.V1.Aircrafts.FA18;

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
    public bool EnableUpload { get; set; }

    public MiscSystem()
    {
        Bingo = 2000;
        BaroWarn = 5000;
        RadarWarn = 200;

        RadarToBeUpdated = true;

        TACANChannel = 1;
        TACANBand = TACANBands.X;
    }
}
