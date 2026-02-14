using DTC.New.Presets.V2.Aircrafts.AV8B;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.AV8B;

public partial class AV8BUploader : Base.Uploader
{
    private AV8BConfiguration config;

    public AV8BUploader(AV8BAircraft ac, AV8BConfiguration cfg) : base(ac, Settings.C130CommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute(bool pilot)
    {
        BuildWaypoints(pilot);
        //BuildRoutes(pilot);
        //BuildTSD(pilot);
        Send();
    }
}
