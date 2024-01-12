
using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.FA18;

namespace DTC.New.UI.Base.Pages;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }

    public override string PageTitle => "Home";

    private void btnF16_Click(object sender, System.EventArgs e)
    {
        MainForm.AddPage(new PresetsPage(new F16Aircraft()));
    }

    private void btnF18_Click(object sender, System.EventArgs e)
    {
        MainForm.AddPage(new PresetsPage(new FA18Aircraft()));
    }

    private void btnAH64_Click(object sender, System.EventArgs e)
    {
        //MainForm.AddPage(new PresetsPage(PresetsStore.GetAircraft(AircraftModel.AH64D)));
    }

    private void btnWptDatabase_Click(object sender, System.EventArgs e)
    {
        //MainForm.AddPage(new WaypointDatabase());
    }

    private void btnF15E_Click(object sender, System.EventArgs e)
    {
        MainForm.AddPage(new PresetsPage(new F15EAircraft()));
    }
}
