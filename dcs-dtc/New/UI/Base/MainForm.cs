using DTC.Utilities;
using DTC.UI.Base;
using DTC.UI.Base.Controls;
using DTC.New.UI.Base.Pages;
using DTC.Utilities.Network;

namespace DTC.New.UI.Base;

public partial class MainForm : Form
{
    private MainPage _mainPage = new MainPage();

    private Stack<Page> _pages = new Stack<Page>();

    private bool showDTCPressed = false;
    private bool hideDTCPressed = false;
    private bool toggleDTCPressed = false;

    private bool showHideDTCState = false;

    private PresetNamedPipeImport presetNamedPipeImport;
    private CommandLineProcessor commandLineProcessor;

    public MainForm()
    {
        InitializeComponent();
        lblVersion.Text = "Version " + Util.GetAppVersion();

        ResetToPage(_mainPage);
        SetTopMost(Settings.AlwaysOnTop);

        CockpitInfoReceiver.DataReceived += DataReceiver_DataReceived;
        CockpitInfoReceiver.Start();

        presetNamedPipeImport = new();
        presetNamedPipeImport.Start();

        commandLineProcessor = new(this);

        var position = new Point(Settings.MainWindowX, Settings.MainWindowY);
        if (!IsVisibleOnAnyScreen(new Rectangle(position, this.Size)))
        {
            position = new Point(Math.Max(Settings.MainWindowX, 0), Math.Max(Settings.MainWindowY, 0));
        }

        this.Location = position;
        this.ResizeEnd += MainForm_Move;
    }

    private bool IsVisibleOnAnyScreen(Rectangle rect)
    {
        foreach (Screen screen in Screen.AllScreens)
        {
            if (screen.WorkingArea.Contains(rect))
            {
                return true;
            }
        }

        return false;
    }

    private void MainForm_Move(object? sender, EventArgs e)
    {
        Settings.MainWindowX = Location.X;
        Settings.MainWindowY = Location.Y;
    }

    protected override bool ShowWithoutActivation
    {
        get { return true; }
    }

    private void DataReceiver_DataReceived(CockpitInfoReceiver.Data d)
    {
        if (d.toggleDTC == "1" && !toggleDTCPressed)
        {
            toggleDTCPressed = true;
            Invoke(new Action(() =>
            {
                ShowHideDTC(!showHideDTCState);
            }));
        }

        if (d.toggleDTC == "0" && toggleDTCPressed)
        {
            toggleDTCPressed = false;
        }

        if (d.showDTC == "1" && !showDTCPressed)
        {
            showDTCPressed = true;
            Invoke(new Action(() =>
            {
                ShowHideDTC(true);
            }));
        }

        if (d.showDTC == "0" && showDTCPressed)
        {
            showDTCPressed = false;
        }

        if (d.hideDTC == "1" && !hideDTCPressed)
        {
            hideDTCPressed = true;
            Invoke(new Action(() =>
            {
                ShowHideDTC(false);
            }));
        }

        if (d.hideDTC == "0" && hideDTCPressed)
        {
            hideDTCPressed = false;
        }
    }

    private void ShowHideDTC(bool show)
    {
        if (show)
        {
            BringToFront();
            SetTopMost(true);
            showHideDTCState = true;
        }
        else
        {
            SetTopMost(false);
            SendToBack();
            showHideDTCState = false;
        }
    }

    private void MainForm_Load(object sender, System.EventArgs e)
    {
        this.Activate();
        if (!DCSInstallCheck.Check())
        {
            Application.Exit();
        }

        commandLineProcessor.ProcessCommandLineArgs();
    }

    private void SetPage(Page page)
    {
        pnlPages.Controls.Add(page);
        page.Dock = DockStyle.Fill;
        page.Visible = true;
        page.Enabled = true;
        page.BringToFront();
        page.Focus();

        btnKneeboard.Visible = btnUpload.Visible = page is AircraftPage;
    }

    private void ResetToPage(Page page)
    {
        foreach (Control control in pnlPages.Controls)
        {
            if (control != page)
            {
                control.Dispose();
            }
        }

        pnlPages.Controls.Clear();

        SetPage(page);

        _pages.Clear();
        _pages.Push(page);

        breadCrumbs.SetCrumbs(new DTCBreadCrumb.Crumb(page.PageTitle, () => { ResetToPage(page); }));
    }

    public void AddPage(Page page)
    {
        var lastPage = _pages.Peek();
        if (lastPage != null)
        {
            lastPage.Enabled = false;
        }

        SetPage(page);

        _pages.Push(page);

        breadCrumbs.AddCrumb(new DTCBreadCrumb.Crumb(page.PageTitle, () => { PopUntilPage(page); }));
    }

    private void PopUntilPage(Page page)
    {
        while (_pages.Peek() != page)
        {
            var p = _pages.Pop();
            pnlPages.Controls.Remove(p);
            p.Dispose();
            breadCrumbs.PopCrumb();
        }

        SetPage(page);
    }

    private void pnlBackground_MouseDown(object sender, MouseEventArgs e)
    {
        Draggable.Drag(Handle, e);
    }

    public void ToggleEnabled()
    {
        //_planeForm.ToggleEnabled();
    }

    private void lblPin_Click(object sender, System.EventArgs e)
    {
        SetTopMost(!this.TopMost);
    }

    public void SetTopMost(bool topMost)
    {
        this.TopMost = topMost;
        Settings.AlwaysOnTop = topMost;
        lblPin.Image = topMost ? Properties.Resources.redpin : Properties.Resources.pin;
    }

    private void lblClose_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void lblMinimize_Click(object sender, System.EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void btnUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        ExecuteUpload(false, false);
    }

    private void btnKneeboard_Click(object sender, EventArgs e)
    {
        var page = _pages.Peek();
        if (page is AircraftPage)
        {
            ((AircraftPage)page).ShowKneeboard();
        }
    }

    internal PresetsPage NavigateTo(string ac)
    {
        return _mainPage.NavigateTo(ac);
    }

    internal void ExecuteUpload(bool pilot, bool cpg)
    {
        var page = _pages.Peek();
        if (page is AircraftPage)
        {
            ((AircraftPage)page).UploadToJet(pilot, cpg);
        }
    }
}