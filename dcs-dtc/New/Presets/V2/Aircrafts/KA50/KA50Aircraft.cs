using DTC.New.Presets.V2.Base;
using DTC.Utilities;

namespace DTC.New.Presets.V2.Aircrafts.KA50;

public class KA50Aircraft : Aircraft
{
    public override string Name => "Ka-50 III";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(KA50Configuration);
    }

    public override string GetAircraftModelName()
    {
        return "KA50";
    }

    public override Configuration NewConfiguration()
    {
        return new KA50Configuration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 35000;
    }

    public override CoordinateFormat GetWaypointCoordinateFormat()
    {
        return CoordinateFormat.DegreesMinutesTenths;
    }
}
