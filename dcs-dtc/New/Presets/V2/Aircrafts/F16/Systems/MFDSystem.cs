namespace DTC.New.Presets.V2.Aircrafts.F16.Systems;

public enum Page
{
    BLANK = 1,
    FCR = 2,
    HSD = 3,
    SMS = 4,
    TGP = 5,
    WPN = 6,
    HAD = 7,
    FLCS = 8,
    DTE = 9,
    TEST = 10,
    FLIR = 11,
    TFR = 12,
    RCCE = 13
}

public enum FCRMode
{
    RWS = 1,
    VSR = 2,
    TWS = 3,
    GM = 4,
    GMT = 5,
    SEA = 6
}

public class MFDConfiguration
{
    public int SelectedPage { get; set; }
    public Page Page1 { get; set; }
    public Page Page2 { get; set; }
    public Page Page3 { get; set; }
    public FCRMode? FCRMode { get; set; }
    public int? FCRAzimuth { get; set; }
    public int? FCRBars { get; set; }
    public int? FCRRange { get; set; }

    public MFDConfiguration(Page page1, Page page2, Page page3, int selectedPage, FCRMode? fcrMode = null, int? fcrAz = null, int? fcrBars = null, int? fcrRange = null)
    {
        Page1 = page1;
        Page2 = page2;
        Page3 = page3;
        SelectedPage = selectedPage;
        FCRMode = fcrMode;
        FCRAzimuth = fcrAz;
        FCRBars = fcrBars;
        FCRRange = fcrRange;
    }

    public void SetPage(int number, Page value)
    {
        if (number == 1)
        {
            Page1 = value;
        }
        else if (number == 2)
        {
            Page2 = value;
        }
        else if (number == 3)
        {
            Page3 = value;
        }
    }

    public Page GetPage(int number)
    {
        if (number == 1)
        {
            return Page1;
        }
        else if (number == 2)
        {
            return Page2;
        }
        else
        {
            return Page3;
        }
    }
}

public enum Mode
{
    NAV = 1,
    AA = 2,
    AG = 3,
    DGFT = 4,
    MSL = 5
}

public class ModeConfiguration
{
    public Mode Mode { get; set; }
    public MFDConfiguration LeftMFD { get; set; }
    public MFDConfiguration RightMFD { get; set; }
    public bool ToBeUpdated { get; set; }

    public ModeConfiguration(Mode mode, MFDConfiguration leftMFD, MFDConfiguration rightMFD)
    {
        Mode = mode;
        LeftMFD = leftMFD;
        RightMFD = rightMFD;
    }
}

public class MFDSystem
{
    public ModeConfiguration[] Configurations { get; set; }

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
                new MFDConfiguration(Page.FCR, Page.BLANK, Page.BLANK, 1, FCRMode.RWS, 6, 4, 40),
                new MFDConfiguration(Page.SMS, Page.HSD, Page.BLANK, 2)),
            new ModeConfiguration(
                Mode.AA,
                new MFDConfiguration(Page.FCR, Page.BLANK, Page.BLANK, 1, FCRMode.RWS, 6, 4, 40),
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
                new MFDConfiguration(Page.FCR, Page.BLANK, Page.BLANK, 1, FCRMode.RWS, 6, 4, 40),
                new MFDConfiguration(Page.SMS, Page.HSD, Page.BLANK, 2)),
        };
    }

    internal void AfterLoadFromJson()
    {
        foreach (var cfg in Configurations)
        {
            FixFCR(cfg.Mode, cfg.LeftMFD);
            FixFCR(cfg.Mode, cfg.RightMFD);
        }
    }

    private void FixFCR(Mode mode, MFDConfiguration mfd)
    {
        if (mfd.Page1 == Page.FCR || mfd.Page2 == Page.FCR || mfd.Page3 == Page.FCR)
        {
            if (mode == Mode.AA || mode == Mode.MSL || mode == Mode.NAV)
            {
                if (mfd.FCRMode == null) mfd.FCRMode = FCRMode.RWS;
                if (mfd.FCRAzimuth == null) mfd.FCRAzimuth = 6;
                if (mfd.FCRBars == null) mfd.FCRBars = 4;
                if (mfd.FCRRange == null) mfd.FCRRange = 40;
            }
            else if (mode == Mode.AG)
            {
                if (mfd.FCRMode == null) mfd.FCRMode = FCRMode.GM;
                if (mfd.FCRRange == null) mfd.FCRRange = 40;
                if (mfd.FCRAzimuth == null) mfd.FCRAzimuth = 6;
            }
        }
    }
}
