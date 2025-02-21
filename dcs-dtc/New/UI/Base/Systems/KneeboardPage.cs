using DTC.New.UI.Base.Pages;

namespace DTC.New.UI.Base.Systems;

public partial class KneeboardPage : AircraftSystemPage
{
    public KneeboardPage()
    {
        InitializeComponent();
    }

    public KneeboardPage(AircraftPage parent) : base(parent)
    {
        InitializeComponent();
    }

    public void UpdateFields()
    {
        txtNotes.Text = this.parent.Configuration.KneeboardNotes;
        txtInfo.Text = this.parent.GetKneeboardInfoText();
        txtInfo.Select(0, 0);
        txtNotes.Select(0, 0);
        this.Invalidate();
    }

    private void btnInfo_Click(object sender, EventArgs e)
    {
        txtInfo.Visible = true;
        txtNotes.Visible = false;
    }

    private void btnNotes_Click(object sender, EventArgs e)
    {
        txtInfo.Visible = false;
        txtNotes.Visible = true;
    }
}
