using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.C130;

public class C130Aircraft : Aircraft
{
    public override string Name => "C-130";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(C130Configuration);
    }

    public override string GetAircraftModelName()
    {
        return "C130";
    }

    public override Configuration NewConfiguration()
    {
        return new C130Configuration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 30000;
    }
}
