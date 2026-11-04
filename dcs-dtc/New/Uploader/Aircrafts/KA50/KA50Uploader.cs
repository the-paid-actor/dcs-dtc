using DTC.New.Presets.V2.Aircrafts.KA50;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.KA50;

public partial class KA50Uploader : Base.Uploader
{
    private KA50Configuration config;

    public KA50Uploader(KA50Aircraft ac, KA50Configuration cfg) : base(ac, Settings.C130CommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute(bool pilot)
    {
        BuildWaypoints(pilot);
        Send();
    }
}
