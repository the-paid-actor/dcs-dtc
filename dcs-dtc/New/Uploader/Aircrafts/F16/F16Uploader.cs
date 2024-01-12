using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader : Base.Uploader
{
    private F16Configuration config;

    public F16Uploader(F16Aircraft ac, F16Configuration cfg) : base(ac, Settings.ViperCommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute()
    {
        BuildWaypoints();
        BuildRadios();
        BuildCMS();
        BuildMisc();
        BuildMFDs();
        BuildHARMHTS();
        BuildDatalink();

        Send();
    }

    public void ResetToNavMode()
    {
        If(IsNotNAVMode(), HOTAS.CENTER);
        If(IsNotNAVMode(), UFC.AA);
        If(IsNotNAVMode(), UFC.AA);
    }
}