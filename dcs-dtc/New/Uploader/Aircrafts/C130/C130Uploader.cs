using DTC.New.Presets.V2.Aircrafts.C130;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.C130;

public partial class C130Uploader : Base.Uploader
{
    private C130Configuration config;

    public C130Uploader(C130Aircraft ac, C130Configuration cfg) : base(ac, Settings.C130CommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute(bool pilot)
    {
        BuildWaypoints(pilot);
        Send();
    }
}