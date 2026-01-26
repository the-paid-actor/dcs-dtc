using DTC.New.Presets.V2.Aircrafts.C130;
using DTC.New.Presets.V2.Aircrafts.C130.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.C130;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.C130;

public class C130Page : AircraftPage
{
    public C130Page(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
    }

    public new C130Configuration Configuration
    {
        get { return (C130Configuration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),
            new WaypointsPage<Waypoint>(this, Configuration.Waypoints, null, nameof(Configuration.Waypoints), "Waypoints")
        };
    }

    public override void UploadToJet(bool pilot, bool cpg)
    {
        this.UploadToJet(this.Configuration, pilot);
    }

    public void UploadToJet(C130Configuration cfg, bool pilot)
    {
        var upload = new C130Uploader((C130Aircraft)this.aircraft, cfg);
        upload.Execute(pilot);
    }
}
