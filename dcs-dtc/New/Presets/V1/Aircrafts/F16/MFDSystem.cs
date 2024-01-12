namespace DTC.New.Presets.V1.Aircrafts.F16;

public class MFDSystem
{
    public ModeConfiguration[] Configurations { get; set; }
    public bool EnableUpload { get; set; }

    public MFDSystem()
    {
        ResetToDefault();
    }

    private void ResetToDefault()
    {
        Configurations = new ModeConfiguration[]
        {
            new ModeConfiguration(
                Mode.NAV,
                new MFDConfiguration(Page.FCR, Page.BLANK, Page.BLANK, 1),
                new MFDConfiguration(Page.SMS, Page.HSD, Page.BLANK, 2)),
            new ModeConfiguration(
                Mode.AA,
                new MFDConfiguration(Page.FCR, Page.BLANK, Page.BLANK, 1),
                new MFDConfiguration(Page.SMS, Page.HSD, Page.BLANK, 2)),
            new ModeConfiguration(
                Mode.AG,
                new MFDConfiguration(Page.TGP, Page.WPN, Page.BLANK, 1),
                new MFDConfiguration(Page.SMS, Page.HSD, Page.BLANK, 2)),
            new ModeConfiguration(
                Mode.DGFT,
                new MFDConfiguration(Page.FCR, Page.BLANK, Page.BLANK, 1),
                new MFDConfiguration(Page.SMS, Page.HSD, Page.BLANK, 2)),
            new ModeConfiguration(
                Mode.MSL,
                new MFDConfiguration(Page.FCR, Page.BLANK, Page.BLANK, 1),
                new MFDConfiguration(Page.SMS, Page.HSD, Page.BLANK, 2)),
        };
    }
}
