using DTC.New.Presets.V2.Aircrafts.AH64D;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.AH64D;

public partial class AH64DUploader : Base.Uploader
{
    private AH64DConfiguration config;

    public AH64DUploader(AH64DAircraft ac, AH64DConfiguration cfg) : base(ac, Settings.ApacheCommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute(bool pilot)
    {
        BuildWaypoints(pilot);
        BuildRoutes(pilot);
        BuildTSD(pilot);
        BuildLaserCodes(pilot);
        BuildRadios(pilot);

        Send();
    }
}