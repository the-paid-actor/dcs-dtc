using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.CH47F;

public class CH47FAircraft : Aircraft
{
    public override string Name => "CH-47F";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(CH47FConfiguration);
    }

    public override string GetAircraftModelName()
    {
        return "CH47F";
    }

    public override Configuration NewConfiguration()
    {
        return new CH47FConfiguration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 30000;
    }
}
