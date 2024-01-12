using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.F16;

public class F16Aircraft : Aircraft
{
    public override string Name => "F-16C";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(F16Configuration);
    }

    public override string GetAircraftModelName()
    {
        return "F16C";
    }

    public override Configuration NewConfiguration()
    {
        return new F16Configuration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 80000;
    }
}
