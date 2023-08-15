using DTC.Utilities;
using DTC.UI.Base;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DTC.UI
{
    public partial class MainForm : Form
    {
        private MainPage _mainPage = new MainPage();

        private Stack<Page> _pages = new Stack<Page>();

        private bool showDTCPressed = false;
        private bool hideDTCPressed = false;
        private bool toggleDTCPressed = false;

        private bool showHideDTCState = false;

        public MainForm()
        {
            InitializeComponent();
            lblVersion.Text = "Version " + Application.ProductVersion;

            ResetToPage(_mainPage);
            this.TopMost = Settings.AlwaysOnTop;

            DataReceiver.DataReceived += DataReceiver_DataReceived;
            DataReceiver.Start();
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private void DataReceiver_DataReceived(DataReceiver.Data d)
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
        }

        private void SetPage(Page page)
        {
            pnlPages.Controls.Add(page);
            page.Dock = DockStyle.Fill;
            page.Visible = true;
            page.BringToFront();
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
        }

        private void lblClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void lblMinimize_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}