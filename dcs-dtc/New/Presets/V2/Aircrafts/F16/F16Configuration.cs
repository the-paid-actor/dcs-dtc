using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.F16;

public class F16Configuration : Configuration
{
    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    [System("Steerpoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    [System("CMS")]
    public CMSSystem CMS { get; set; } = new();

    [System("Radios")]
    public Base.Systems.RadioSystem Radios { get; set; } = new();

    [System("MFDs")]
    public MFDSystem MFD { get; set; } = new();

    [System("HARM")]
    public HARMSystem HARM { get; set; } = new();

    [System("HTS")]
    public HTSSystem HTS { get; set; } = new();

    [System("Datalink")]
    public DatalinkSystem Datalink { get; set; } = new();

    [System("Misc")]
    public MiscSystem Misc { get; set; } = new();

    public override void AfterLoadFromJson()
    {
        if (CMS != null)
        {
            CMS.AfterLoadFromJson();
        }
        if (MFD != null)
        {
            MFD.AfterLoadFromJson();
        }
        FixWaypointCoordinateFormat();
    }

    private void FixWaypointCoordinateFormat()
    {
        if (Waypoints == null) return;

        foreach (var wpt in Waypoints.Waypoints)
        {
            if (!wpt.Latitude.Contains("°"))
            {
                var parts = wpt.Latitude.Split('.');
                wpt.Latitude = $"{parts[0]}°{parts[1]}.{parts[2]}’";
            }
            if (!wpt.Longitude.Contains("°"))
            {
                var parts = wpt.Longitude.Split('.');
                wpt.Longitude = $"{parts[0]}°{parts[1]}.{parts[2]}’";
            }
        }
    }

    protected override Type GetConfigurationType()
    {
        return typeof(F16Configuration);
    }
}
