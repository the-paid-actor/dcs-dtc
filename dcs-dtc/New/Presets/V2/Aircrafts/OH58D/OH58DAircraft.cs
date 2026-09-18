using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.OH58D;

public class OH58DAircraft : Aircraft
{
    public override string Name => "OH-58D Kiowa";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(OH58DConfiguration);
    }

    public override string GetAircraftModelName()
    {
        return "OH58D";
    }

    public override Configuration NewConfiguration()
    {
        return new OH58DConfiguration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 35000;
    }
}
