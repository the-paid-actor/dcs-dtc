namespace DTC.New.Uploader.Base;

public class Condition
{
    private string cond;

    public Condition(string cond)
    {
        this.cond = cond;
    }

    public override string ToString()
    {
        return this.cond;
    }
}
