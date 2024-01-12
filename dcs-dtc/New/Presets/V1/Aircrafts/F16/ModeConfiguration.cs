namespace DTC.New.Presets.V1.Aircrafts.F16;

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
