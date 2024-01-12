namespace DTC.New.Presets.V2.Aircrafts.F15E.Systems;

public class SmartWeaponsSystem
{
    public Dictionary<string, SmartWeaponsStation> Stations = new();

    public void Set(string stationName, SmartWeaponSetting coordinate)
    {
        if (Stations.ContainsKey(stationName))
        {
            Stations[stationName].Settings = new[] { coordinate };
        }
        else
        {
            Stations.Add(stationName, new SmartWeaponsStation() { Name = stationName, Settings = new[] { coordinate } });
        }
    }

    internal void ResetAll()
    {
        foreach (var str in StationNames.Ordered)
        {
            if (Stations.ContainsKey(str))
            {
                Stations[str].Settings = null;
            }
        }
    }
}

public class StationNames
{
    public const string LWING = "LWING";
    public const string CENTERLINE = "CENTERLINE";
    public const string RWING = "RWING";
    public const string LCFTFRONT = "LCFTFRONT";
    public const string LCFTMID = "LCFTMID";
    public const string LCFTREAR = "LCFTREAR";
    public const string RCFTFRONT = "RCFTFRONT";
    public const string RCFTMID = "RCFTMID";
    public const string RCFTREAR = "RCFTREAR";

    public static string[] Ordered = new[] { LWING, LCFTREAR, LCFTMID, LCFTFRONT, CENTERLINE, RCFTREAR, RCFTMID, RCFTFRONT, RWING };
}

public class SmartWeaponsStation
{
    public string Name { get; set; }
    public SmartWeaponSetting[] Settings { get; set; }
}

public class SmartWeaponSetting
{
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
}