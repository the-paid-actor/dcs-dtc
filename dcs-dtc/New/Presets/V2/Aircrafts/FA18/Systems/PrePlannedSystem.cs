namespace DTC.New.Presets.V2.Aircrafts.FA18.Systems;

public class PrePlannedSystem
{
    public Dictionary<int, PrePlannedStation> Stations = new()
    {
        { 2, new PrePlannedStation(2) },
        { 3, new PrePlannedStation(3) },
        { 7, new PrePlannedStation(7) },
        { 8, new PrePlannedStation(8) }
    };

    public bool HasAnyPPEnabled()
    {
        foreach (var station in Stations.Values)
        {
            if (station.HasAnyPPEnabled())
                return true;
        }
        return false;
    }

    private static Dictionary<string, StationType> StationTypes = new Dictionary<string, StationType>
    {
        { "Empty/Other", StationType.EMPTY },
        { "GBU-38", StationType.GBU38 },
        { "GBU-32", StationType.GBU32 },
        { "GBU-31 V1/2", StationType.GBU31NP },
        { "GBU-31 V3/4 Penetrator", StationType.GBU31PP },
        { "JSOW-A", StationType.JSOWA },
        { "JSOW-C", StationType.JSOWC },
        { "SLAM", StationType.SLAM },
        { "SLAM-ER", StationType.SLAMER },
    };

    public static StationType StoreTypeFromString(string s)
    {
        if (StationTypes.ContainsKey(s))
            return StationTypes[s];
        else
            return StationType.EMPTY;
    }

    public static string StoreTypeToString(StationType type)
    {
        foreach (var kvp in StationTypes)
        {
            if (kvp.Value == type)
                return kvp.Key;
        }
        return "Empty";
    }
}

public class PrePlannedStation
{
    public StationType Type { get; set; }
    public int Number { get; set; }

    public Dictionary<int, PrePlannedCoordinate> PP = new()
    {
        { 1, new PrePlannedCoordinate() },
        { 2, new PrePlannedCoordinate() },
        { 3, new PrePlannedCoordinate() },
        { 4, new PrePlannedCoordinate() },
        { 5, new PrePlannedCoordinate() },
        { 6, new PrePlannedCoordinate() },
    };

    public PrePlannedSteerpoint[] Steerpoints = new PrePlannedSteerpoint[]
    {
        new PrePlannedSteerpoint(),
        new PrePlannedSteerpoint(),
        new PrePlannedSteerpoint(),
        new PrePlannedSteerpoint(),
        new PrePlannedSteerpoint(),
    };

    public PrePlannedStation(int number)
    {
        Number = number;
    }

    public bool HasAnyStptEnabled()
    {
        foreach (var stp in Steerpoints)
        {
            if (stp.Enabled) return true;
        }
        return false;
    }

    public bool HasAnyPPEnabled()
    {
        foreach (var p in PP.Values)
        {
            if (p.Enabled) return true;
        }
        return false;
    }
}

public class PrePlannedCoordinate
{
    public string Lat { get; set; }
    public string Lon { get; set; }
    public int Elev { get; set; }
    public bool Enabled { get; set; }
    public string Notes { get; set; }


    public bool IsEqual(PrePlannedCoordinate other)
    {
        if (Lat != other.Lat) return false;
        if (Lon != other.Lon) return false;
        if (Elev != other.Elev) return false;
        return true;
    }

    public void Reset()
    {
        Lat = null;
        Lon = null;
        Elev = 0;
        Enabled = false;
    }

    public bool CanBeEnabled()
    {
        if (!string.IsNullOrEmpty(Lat) && !string.IsNullOrEmpty(Lon) && Elev >= 0) return true;
        return false;
    }
}

public class PrePlannedSteerpoint : PrePlannedCoordinate
{
    public bool UseCoordinate { get; set; }
    public int WaypointNumber { get; set; }
}

public enum StationType
{
    EMPTY = 1,
    GBU38,
    GBU32,
    GBU31NP,
    GBU31PP,
    JSOWA,
    JSOWC,
    SLAM,
    SLAMER
}
