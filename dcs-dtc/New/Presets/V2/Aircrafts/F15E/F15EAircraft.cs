using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.F15E;

public class F15EAircraft : Aircraft
{
    public override string Name => "F-15E";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(F15EConfiguration);
    }

    public override string GetAircraftModelName()
    {
        return "F15E";
    }

    public override Configuration NewConfiguration()
    {
        return new F15EConfiguration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 59999;
    }
}
