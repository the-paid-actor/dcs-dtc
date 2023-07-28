namespace DTC.Models.F15E.Displays
{
    public enum Display
    {
        None = 0,
        ADI = 1,
        ARMT = 2,
        HSI = 3,
        TSD = 4,
        ENG = 5,
        HUD = 6,
        AARDR = 7,
        AGRDR = 8,
        TEWS = 9,
        TPOD = 10,
        AGDLVRY = 11
    }

    public enum DisplayMode
    {
        None = 0,
        AA = 1,
        AG = 2,
        NAV = 3
    }

    public enum DisplayUploadMode
    {
        Pilot = 1,
        WSO = 2,
    }

    public class DisplayConfig
    {
        public Display FirstDisplay { get; set; }
        public Display SecondDisplay { get; set; }
        public Display ThirdDisplay { get; set; }
        public DisplayMode FirstDisplayMode { get; set; }
        public DisplayMode SecondDisplayMode { get; set; }
        public DisplayMode ThirdDisplayMode { get; set; }
    }

    public class PilotDisplays
    {
        public DisplayConfig LeftMPD { get; set; } = new DisplayConfig();
        public DisplayConfig RightMPD { get; set; } = new DisplayConfig();
        public DisplayConfig MPCD { get; set; } = new DisplayConfig();
    }

    public class WSODisplays
    {
        public DisplayConfig LeftMPCD { get; set; } = new DisplayConfig();
        public DisplayConfig LeftMPD { get; set; } = new DisplayConfig();
        public DisplayConfig RightMPD { get; set; } = new DisplayConfig();
        public DisplayConfig RightMPCD { get; set; } = new DisplayConfig();
    }

    public class DisplaySystem
    {
        public PilotDisplays Pilot { get; set; } = new PilotDisplays();
        public WSODisplays WSO { get; set; } = new WSODisplays();

        public DisplayUploadMode UploadMode { get; set; }

        public bool EnableUpload { get; set; }
    }
}
