using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.FA18;

public class FA18Aircraft : Aircraft
{
    public override string Name => "F/A-18C";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(FA18Configuration);
    }

    public override string GetAircraftModelName()
    {
        return "FA18C";
    }

    public override Configuration NewConfiguration()
    {
        return new FA18Configuration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 25000;
    }
}
