
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

        btnF14BU.Enabled = false;
        btnF14BU.Paint += btnF14BU_Paint;
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

    private void btnF14BU_Click(object sender, System.EventArgs e)
    {
        NavigateTo("F14BU");
    }

    private void btnF14BU_Paint(object sender, PaintEventArgs e)
    {
        const string label = "2 Weeks...";
        const float angle = -25F;

        var state = e.Graphics.Save();
        e.Graphics.TranslateTransform(btnF14BU.ClientSize.Width / 2F, btnF14BU.ClientSize.Height / 2F);
        e.Graphics.RotateTransform(angle);

        var bannerWidth = MathF.Sqrt(
            btnF14BU.ClientSize.Width * btnF14BU.ClientSize.Width
            + btnF14BU.ClientSize.Height * btnF14BU.ClientSize.Height);
        var banner = new RectangleF(-bannerWidth / 2F, -20F, bannerWidth, 40F);

        using var background = new SolidBrush(Color.FromArgb(210, 160, 0, 0));
        using var foreground = new SolidBrush(Color.White);
        using var font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
        using var format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        e.Graphics.FillRectangle(background, banner);
        e.Graphics.DrawString(label, font, foreground, banner, format);
        e.Graphics.Restore(state);
    }

    private void btnOH58D_Click(object sender, System.EventArgs e)
    {
        NavigateTo("OH58D");
    }
}
