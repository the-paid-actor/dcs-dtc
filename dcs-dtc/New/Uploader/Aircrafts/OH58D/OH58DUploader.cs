using DTC.New.Presets.V2.Aircrafts.OH58D;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.OH58D;

public partial class OH58DUploader : Base.Uploader
{
    private OH58DConfiguration config;

    public OH58DUploader(OH58DAircraft ac, OH58DConfiguration cfg) : base(ac, Settings.C130CommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute(bool pilot)
    {
        BuildWaypoints(pilot);
        BuildRadios(pilot);
        Send();
    }
}
