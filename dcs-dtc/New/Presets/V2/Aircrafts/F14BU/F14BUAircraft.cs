using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.F14BU;

public class F14BUAircraft : Aircraft
{
    public override string Name => "F-14BU";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(F14BUConfiguration);
    }

    public override string GetAircraftModelName()
    {
        return "F14BU";
    }

    public override Configuration NewConfiguration()
    {
        return new F14BUConfiguration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 35000;
    }
}
