using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.FA18;

public class FA18Configuration : Configuration
{
    public string Aircraft = "FA18C";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new UploadSystem();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new WaypointCaptureSystem();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new WaypointSystem();

    [System("Sequence")]
    public SequenceSystem Sequences { get; set; } = new SequenceSystem();

    [System("CMS")]
    public CMSystem CMS { get; set; } = new CMSystem();

    [System("Radios")]
    public Base.Systems.RadioSystem Radios { get; set; } = new Base.Systems.RadioSystem();

    [System("FCR")]
    public FCRSystem FCR { get; set; } = new FCRSystem();

    [System("PrePlanned")]
    public PrePlannedSystem PrePlanned { get; set; } = new PrePlannedSystem();

    [System("HMD")]
    public HMDSystem HMD { get; set; } = new HMDSystem();

    [System("Misc")]
    public MiscSystem Misc { get; set; } = new MiscSystem();

    public override void AfterLoadFromJson()
    {
    }

    public override string GetAircraftName()
    {
        return this.Aircraft;
    }

    protected override Type GetConfigurationType()
    {
        return typeof(FA18Configuration);
    }
}
