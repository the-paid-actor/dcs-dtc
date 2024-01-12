namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class SequenceSystem
{
    public Sequence Seq1 { get; }
    public Sequence Seq2 { get; }
    public Sequence Seq3 { get; }
    public bool EnableUpload { get; set; }
    public bool EnableUpload1 { get; set; }
    public bool EnableUpload2 { get; set; }
    public bool EnableUpload3 { get; set; }

    public SequenceSystem()
    {
        Seq1 = new Sequence();
        Seq2 = new Sequence();
        Seq3 = new Sequence();
        EnableUpload = false;
        EnableUpload1 = false;
        EnableUpload2 = false;
        EnableUpload3 = false;
    }
}

public class Sequence
{
    public List<int> _seq { get; set; }

    public Sequence()
    {
        _seq = new List<int>();
    }
}
