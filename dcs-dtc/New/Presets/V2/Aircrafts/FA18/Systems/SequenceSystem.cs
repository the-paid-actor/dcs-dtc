namespace DTC.New.Presets.V2.Aircrafts.FA18.Systems;

public class SequenceSystem
{
    public Sequence Seq1 { get; } = new();
    public Sequence Seq2 { get; } = new();
    public Sequence Seq3 { get; } = new();
    public bool EnableUpload1 { get; set; }
    public bool EnableUpload2 { get; set; }
    public bool EnableUpload3 { get; set; }
}

public enum SequenceMode
{
    UseAll = 1,
    UseRange = 2,
    UseSpecific = 3
}

public class Sequence
{
    public SequenceMode Mode { get; set; }
    public List<int>? Waypoints { get; set; }
}
