namespace DTC.UI.Base.Controls;

public class DTCGridColumn
{
    private int width;
    private string name;

    public string Name
    {
        get { return this.name; }
        set
        {
            this.name = value;
            if (string.IsNullOrEmpty(this.DataBindName))
            {
                this.DataBindName = value;
            }
        }
    }

    public string DataBindName { get; set; }

    public DataGridViewAutoSizeColumnMode AutoSizeMode { get; set; } = DataGridViewAutoSizeColumnMode.Fill;

    public DataGridViewContentAlignment Alignment { get; set; }

    public int Width
    {
        get { return this.width; }
        set
        {
            this.width = value;
            this.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }
    }
}
