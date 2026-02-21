using DTC.New.Presets.V2.Aircrafts.A10;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.A10;

public partial class A10Uploader : Base.Uploader
{
    private A10Configuration config;

    public A10Uploader(A10Aircraft ac, A10Configuration cfg) : base(ac, Settings.A10CommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute(bool pilot)
    {
        BuildWaypoints(pilot);
        Send();
    }
}
