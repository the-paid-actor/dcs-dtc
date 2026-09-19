using DTC.New.Presets.V2.Base.Systems;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Serialization;

namespace DTC.New.Presets.V2.Aircrafts.F15E.Systems;

public class WaypointIdentifier
{
    public int WaypointNumber { get; set; }
    public int WaypointOffsetNumber { get; set; }
    public string WaypointId { get; set; } = "";
}
public class RelativeOffsetBearingAndRange
{
    public int Direction { get; set; } = 0;
    public decimal Range { get; set; } = 0.1M;
}
public class RelativeOffsetLatLong
{
    public string LatitudeDirection { get; set; } = "N";
    public long RelativeLatitude { get; set; } = 1;
    public string LongitudeDirection { get; set; } = "E";
    public long RelativeLongitude { get; set; } = 1;
}
public class Waypoint : IWaypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
    public string? TimeOverSteerpoint { get; set; }
    public bool Target { get; set; }
    public bool Offset { get; set; }
    public int MEA { get; set; }
    public bool UseRelativeOffsetBearingAndRange { get; set; }
    public RelativeOffsetBearingAndRange? RelativeOffsetBearingAndRange { get; set; } = new();
    public bool UseRelativeOffsetLatLong { get; set; }
    public RelativeOffsetLatLong? RelativeOffsetLatLong { get; set; } = new();

    [Newtonsoft.Json.JsonIgnore]
    public WaypointIdentifier Identifier { get; set; } = new();

    [Newtonsoft.Json.JsonIgnore]
    public string DisplayName => Name + " (" + Identifier.WaypointId + ")";

    [Newtonsoft.Json.JsonIgnore]
    public string DisplayLatitude => Offset && UseRelativeOffsetBearingAndRange
        ? ""
        : Offset && UseRelativeOffsetLatLong
            ? $"{RelativeOffsetLatLong?.LatitudeDirection}{RelativeOffsetLatLong?.RelativeLatitude}"
            : Latitude;

    [Newtonsoft.Json.JsonIgnore]
    public string DisplayLongitude => Offset && UseRelativeOffsetBearingAndRange
        ? ""
        : Offset && UseRelativeOffsetLatLong
            ? $"{RelativeOffsetLatLong?.LongitudeDirection}{RelativeOffsetLatLong?.RelativeLongitude}"
            : Longitude;

    [Newtonsoft.Json.JsonIgnore]
    public String Route { get; set; } = "";

    [Newtonsoft.Json.JsonIgnore]
    public string ExtraDescription
    {
        get
        {
            if (Offset && UseRelativeOffsetBearingAndRange)
                return RelativeOffsetBearingAndRange != null
                    ? $"{RelativeOffsetBearingAndRange.Direction}°/{RelativeOffsetBearingAndRange.Range}nm"
                    : "OFST PT (DIR/RNG)";
            else if (Offset && UseRelativeOffsetLatLong)
                return "Rel. Lat/Long";
            else
                return "";
        }
    }
}

public class WaypointSystem : WaypointSystem<Waypoint>
{
    String route;
    public WaypointSystem(String route="")
    {
        this.route = route;
    }
    [OnDeserialized]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        this.RecalculateWaypointsProperties();
    }
    public int FirstAllowedWaypointNumber = 1;
    public override int GetFirstAllowedSequence()
    {
        return 1;
    }

    public override int GetLastAllowedSequence()
    {
        return 99;
    }
    public override void Add(Waypoint wpt)
    {
        base.Add(wpt);
        this.RecalculateWaypointsProperties();
    }

    public override void Remove(Waypoint wpt)
    {
        if (!this.Waypoints.Contains(wpt))
        {
            return;
        }

        if (!wpt.Offset)
        {
            var waypointIndex = this.Waypoints.IndexOf(wpt);
            var followingOffsets = this.Waypoints
                .Skip(waypointIndex + 1)
                .TakeWhile(waypoint => waypoint.Offset)
                .ToList();

            foreach (var offset in followingOffsets)
            {
                base.Remove(offset);
            }
        }

        base.Remove(wpt);
        this.RecalculateWaypointsProperties();
    }

    public override void ReorderBySequence()
    {
        base.ReorderBySequence();
        this.RecalculateWaypointsProperties();
    }

    public override bool IsEqual(IWaypoint a, IWaypoint b)
    {
        return base.IsEqual(a, b) && ((Waypoint)a).Offset == ((Waypoint)b).Offset;
    }

    private void RecalculateWaypointsProperties()
    {
        int wptNumber = FirstAllowedWaypointNumber - 1;
        int wptOffsetNumber = 0;
        bool mainWptIsTarget = false;
        foreach (Waypoint wpt in this.Waypoints) {
            if (!wpt.Offset)
            {
                wptNumber++;
                wptOffsetNumber = 0;
                mainWptIsTarget = wpt.Target;
            }
            else
            {
                if (wptOffsetNumber >= 7 || wptNumber == 0)
                {
                    wpt.Offset = false;
                    wptNumber++;
                    wptOffsetNumber = 0;
                } else
                {
                    wptOffsetNumber++;
                }

            }
            wpt.Identifier.WaypointNumber = wptNumber;
            wpt.Identifier.WaypointOffsetNumber = wptOffsetNumber;
            wpt.Target = mainWptIsTarget;
            wpt.Identifier.WaypointId = wpt.Target && wpt.Offset
                ? wptNumber + ".0" + wptOffsetNumber + this.route
                : wpt.Offset
                    ? wptNumber + "." + wptOffsetNumber + this.route
                    : wpt.Target
                        ? wptNumber + "." + this.route
                        : wptNumber + this.route;
            wpt.Route = this.route;
        }
    }
}
