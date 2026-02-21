using DTC.New.Presets.V2.Aircrafts.CH47F;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.CH47F;

public partial class CH47FUploader : Base.Uploader
{
    private CH47FConfiguration config;

    public CH47FUploader(CH47FAircraft ac, CH47FConfiguration cfg) : base(ac, Settings.C130CommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute(bool pilot)
    {
        BuildWaypoints(pilot);
        Send();
    }
}