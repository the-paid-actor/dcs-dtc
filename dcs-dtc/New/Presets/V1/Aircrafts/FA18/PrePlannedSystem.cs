namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class PrePlannedSystem
{
    public bool EnableUpload { get; set; }
    public bool Station5ToConsider { get; set; }

    public Dictionary<int, PrePlannedStation> Stations;

    public PrePlannedSystem()
    {
        Stations = new Dictionary<int, PrePlannedStation>();
        Stations.Add(2, new PrePlannedStation(2));
        Stations.Add(3, new PrePlannedStation(3));
        Stations.Add(7, new PrePlannedStation(7));
        Stations.Add(8, new PrePlannedStation(8));
    }
}
