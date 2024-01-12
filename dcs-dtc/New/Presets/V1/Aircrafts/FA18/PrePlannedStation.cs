namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class PrePlannedStation
{
    public StationType stationType { get; set; }

    public int stationNumber { get; set; }
    public Dictionary<int, PrePlannedCoordinate> PP;
    public PrePlannedSteerpoint[] Steerpoints = new PrePlannedSteerpoint[5]; /* for SLAM-ER */

    public PrePlannedStation(int number)
    {
        stationType = StationType.GBU38;
        stationNumber = number;

        PP = new Dictionary<int, PrePlannedCoordinate>();
        for (int i = 1; i <= 5; i++)
            PP.Add(i, new PrePlannedCoordinate());

        for (int i = 0; i < 5; i++)
        {
            Steerpoints[i] = new PrePlannedSteerpoint();
        }
    }
}

public enum StationType
{
    GBU38,
    GBU32,
    GBU31NP,
    GBU31PP,
    JSOWA,
    JSOWC,
    SLAM,
    SLAMER,
    AA,
    OTHER
}
