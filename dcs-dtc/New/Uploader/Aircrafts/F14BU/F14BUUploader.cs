using DTC.New.Presets.V2.Aircrafts.F14BU;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.F14BU;

public partial class F14BUUploader : Base.Uploader
{
    private F14BUConfiguration config;

    public F14BUUploader(F14BUAircraft ac, F14BUConfiguration cfg) : base(ac, Settings.C130CommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute(bool pilot)
    {
        BuildWaypoints(pilot);
        Send();
    }
}
