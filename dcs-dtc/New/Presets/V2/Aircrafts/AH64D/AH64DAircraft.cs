using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.AH64D;

public class AH64DAircraft : Aircraft
{
    public override string Name => "AH-64D";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(AH64DConfiguration);
    }

    public override string GetAircraftModelName()
    {
        return "AH64D";
    }

    public override Configuration NewConfiguration()
    {
        return new AH64DConfiguration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 59999;
    }
}
