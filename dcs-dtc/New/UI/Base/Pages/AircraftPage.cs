using DTC.Utilities;
using DTC.UI.Base.Controls;
using DTC.New.UI.Base.Systems;
using DTC.New.Presets.V2.Base;

namespace DTC.New.UI.Base.Pages;

public partial class AircraftPage : Page
{
    protected readonly Aircraft aircraft;
    protected readonly Preset preset;
    private CockpitUploadHelper uploadHelper;

    public override string PageTitle
    {
        get { return preset.Name; }
    }

    public Configuration Configuration
    {
        get { return preset.Configuration; }
    }

    public Aircraft Aircraft
    {
        get { return aircraft; }
    }

    public AircraftPage(Aircraft aircraft, Preset preset)
    {
        InitializeComponent();
        this.aircraft = aircraft;
        this.preset = preset;

        RefreshPages();

        DataReceiver2.DataReceived += DataReceiver2_DataReceived;
        DataReceiver2.Start();

        uploadHelper = new CockpitUploadHelper(UploadToJet);
    }

    private void DataReceiver2_DataReceived(WaypointCaptureData obj)
    {
        this.Invoke(new Action<WaypointCaptureData>(WaypointCaptureReceived), new[] { obj });
    }

    protected virtual void WaypointCaptureReceived(WaypointCaptureData data)
    {
    }

    protected virtual AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    private void SetPage(AircraftSystemPage page)
    {
        foreach (AircraftSystemPage ctl in pnlMain.Controls)
        {
            ctl.Visible = false;
        }
        page.Visible = true;
        page.Shown();
        page.Focus();
    }

    public void ToggleEnabled()
    {
        pnlLeft.Enabled = !pnlLeft.Enabled;
    }

    public void SavePreset()
    {
        aircraft.PersistPreset(preset);
    }

    public AircraftSystemPage GetPageOfType<T>()
    {
        foreach (AircraftSystemPage ctl in pnlMain.Controls)
        {
            if (ctl is T) return ctl;
        }
        return null;
    }

    public AircraftSystemPage GetPageOfTitle(string title)
    {
        foreach (AircraftSystemPage ctl in pnlMain.Controls)
        {
            if (ctl.GetPageTitle() == title) return ctl;
        }
        return null;
    }

    internal void RefreshPages()
    {
        var pages = GetPages(preset.Configuration);

        var lst = new List<AircraftSystemPage>(pages);
        lst.Reverse();

        pnlMain.Controls.Clear();
        pnlLeft.Controls.Clear();

        var tabIndex = lst.Count-1;

        foreach (var page in lst)
        {
            if (page.IsDivider())
            {
                var lbl = new DTCDividerLine();
                lbl.Dock = DockStyle.Top;
                pnlLeft.Controls.Add(lbl);
                continue;
            }

            page.Visible = false;

            var pageBtn = new AircraftSystemButton(page);
            pageBtn.Dock = DockStyle.Top;
            pageBtn.TabIndex = tabIndex--;
            pageBtn.BringToFront();
            pageBtn.Click += (object sender, EventArgs e) =>
            {
                SetPage(page);
                foreach (var ctl in pnlLeft.Controls)
                {
                    if (!(ctl is AircraftSystemButton)) continue;
                    ((AircraftSystemButton)ctl).ResetAppearance();
                }
            };

            page.Dock = DockStyle.Fill;
            page.Visible = false;
            pnlMain.Controls.Add(page);
            pnlLeft.Controls.Add(pageBtn);
        }
    }

    public virtual void UploadToJet()
    {
        throw new NotImplementedException();
    }

    internal virtual bool AllowCopyFromClipboard(Configuration cfg, List<ConfigurationSystem> systems)
    {
        return false;
    }

    internal virtual Configuration ConvertConfigFromClipboard(Configuration cfg, List<ConfigurationSystem> systems)
    {
        return cfg;
    }
}
