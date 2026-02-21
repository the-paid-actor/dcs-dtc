using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.A10;

public class A10Aircraft : Aircraft
{
    public override string Name => "A-10C";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(A10Configuration);
    }

    public override string GetAircraftModelName()
    {
        return "A10";
    }

    public override Configuration NewConfiguration()
    {
        return new A10Configuration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 20000;
    }
}
