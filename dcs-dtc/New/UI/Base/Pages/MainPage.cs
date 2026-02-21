
using DTC.New.Presets.V2.Aircrafts.AH64D;
using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.FA18;
using DTC.New.Presets.V2.Base;

namespace DTC.New.UI.Base.Pages;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }

    public override string PageTitle => "Home";

    public PresetsPage NavigateTo(string aircraft)
    {
        var p = new PresetsPage(AircraftRepository.GetAircraft(aircraft));
        MainForm.AddPage(p);
        return p;
    }

    private void btnF16_Click(object sender, System.EventArgs e)
    {
        NavigateTo("F16C");
    }

    private void btnF18_Click(object sender, System.EventArgs e)
    {
        NavigateTo("FA18C");
    }

    private void btnAH64_Click(object sender, System.EventArgs e)
    {
        NavigateTo("AH64D");
    }

    private void btnWptDatabase_Click(object sender, System.EventArgs e)
    {
        //MainForm.AddPage(new WaypointDatabase());
    }

    private void btnF15E_Click(object sender, System.EventArgs e)
    {
        NavigateTo("F15E");
    }

    private void btnC130_Click(object sender, System.EventArgs e)
    {
        NavigateTo("C130");
    }

    private void btnA10_Click(object sender, System.EventArgs e)
    {
        NavigateTo("A10");
    }
    private void btnCH47F_Click(object sender, System.EventArgs e)
    {
        NavigateTo("CH47F");
    }


    private void btnAV8B_Click(object sender, System.EventArgs e)
    {
        NavigateTo("AV8B");
    }
}
