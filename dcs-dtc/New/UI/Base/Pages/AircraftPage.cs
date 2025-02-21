using DTC.Utilities;
using DTC.UI.Base.Controls;
using DTC.New.UI.Base.Systems;
using DTC.New.Presets.V2.Base;
using DTC.Utilities.Network;

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

        WaypointCaptureReceiver.DataReceived += DataReceiver2_DataReceived;
        WaypointCaptureReceiver.KneeboardNotesReceived += KneeboardNotesReceived;
        WaypointCaptureReceiver.Start();

        uploadHelper = new CockpitUploadHelper(UploadToJet);
    }

    protected virtual void KneeboardNotesReceived(string presetName, string notes)
    {
        System.Diagnostics.Debug.WriteLine(notes);
        if (this.preset.Name == presetName)
        {
            this.Configuration.KneeboardNotes = notes;
            this.SavePreset();
            var p = (KneeboardPage)GetPageOfType<KneeboardPage>();
            if (p != null)
            {
                p.Invoke(p.UpdateFields);
            }
        }
    }

    public virtual void ShowKneeboard()
    {
        var p = (KneeboardPage)GetPageOfType<KneeboardPage>();
        if (p == null)
        {
            p = new KneeboardPage(this);
            p.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(p);
        }
        SetPage(p);
        p.UpdateFields();
    }

    public virtual string GetKneeboardInfoText()
    {
        return "";
    }

    protected virtual string GetKneeboardNotesText()
    {
        return this.Configuration.KneeboardNotes;
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
        HideAllPages();
        page.Visible = true;
        page.Shown();
        page.Focus();
    }

    private void HideAllPages()
    {
        foreach (AircraftSystemPage ctl in pnlMain.Controls)
        {
            ctl.Visible = false;
        }
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

    protected void ShowControlAsPage(Control control)
    {
        HideAllPages();
        control.Dock = DockStyle.Fill;
        pnlMain.Controls.Add(control);
    }

    public virtual void UploadToJet(bool pilot, bool cpg)
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
