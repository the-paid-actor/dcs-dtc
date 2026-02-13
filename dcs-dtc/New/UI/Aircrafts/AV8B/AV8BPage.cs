using DTC.New.Presets.V2.Aircrafts.AV8B;
using DTC.New.Presets.V2.Aircrafts.AV8B.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.AV8B.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.AV8B;

public class AV8BPage : AircraftPage
{
    public AV8BPage(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
    }

    public new AV8BConfiguration Configuration
    {
        get { return (AV8BConfiguration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),
            new UploadPage(this),
            new AircraftSystemPage.Divider(),
            new WaypointsPage<Waypoint>(this, Configuration.Waypoints, null, nameof(Configuration.Waypoints), "Waypoints")
        };
    }

    public override void UploadToJet(bool pilot, bool cpg)
    {
        // TODO: implement AV-8B uploader integration
    }
}
