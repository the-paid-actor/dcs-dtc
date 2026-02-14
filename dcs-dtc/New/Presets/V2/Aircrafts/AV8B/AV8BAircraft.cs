using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.AV8B;

public class AV8BAircraft : Aircraft
{
    public override string Name => "AV-8B";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(AV8BConfiguration);
    }

    public override string GetAircraftModelName()
    {
        return "AV8B";
    }

    public override Configuration NewConfiguration()
    {
        return new AV8BConfiguration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 35000;
    }
}
