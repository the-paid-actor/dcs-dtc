using DTC.Models.Presets;
using DTC.Models.Base;
using DTC.UI.Base.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace DTC.UI.CommonPages
{
    public partial class AircraftPage : Page
    {
        protected readonly Aircraft _aircraft;
        protected readonly Preset _preset;

        private DataReceiver2 dataReceiver;

        public override string PageTitle
        {
            get { return _preset.Name; }
        }

        public AircraftPage(Aircraft aircraft, Preset preset)
        {
            InitializeComponent();
            _aircraft = aircraft;
            _preset = preset;

            RefreshPages();

            DataReceiver2.DataReceived += DataReceiver2_DataReceived; ;
            DataReceiver2.Start();
        }

        private void DataReceiver2_DataReceived(WaypointCaptureData[] obj)
        {
            this.Invoke(new Action<WaypointCaptureData[]>(WaypointCaptureReceived), new[] { obj });
        }

        protected virtual void WaypointCaptureReceived(WaypointCaptureData[] data)
        {
        }

        protected virtual AircraftSettingPage[] GetPages(IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        private void SetPage(AircraftSettingPage page)
        {
            foreach (AircraftSettingPage ctl in pnlMain.Controls)
            {
                ctl.Visible = false;
            }
            page.Visible = true;
        }

        public void ToggleEnabled()
        {
            pnlLeft.Enabled = !pnlLeft.Enabled;
        }

        public void DataChangedCallback()
        {
            PresetsStore.PresetChanged(_aircraft, _preset);
        }

        protected AircraftSettingPage GetPageOfType<T>()
        {
            foreach (AircraftSettingPage ctl in pnlMain.Controls)
            {
                if (ctl is T) return ctl;
            }
            return null;
        }

        internal void RefreshPages()
        {
            var pages = GetPages(_preset.Configuration);

            var lst = new List<AircraftSettingPage>(pages);
            lst.Reverse();

            pnlMain.Controls.Clear();
            pnlLeft.Controls.Clear();

            foreach (var page in lst)
            {
                page.Visible = false;
                var btn = new DTCButton();
                btn.Height = 35;
                btn.Text = page.GetPageTitle();
                btn.Dock = DockStyle.Top;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Font = new Font("Microsoft Sans Serif", 10);
                btn.Click += (object sender, EventArgs e) =>
                {
                    SetPage(page);
                    foreach (var ctl in pnlLeft.Controls)
                    {
                        var b = ((DTCButton)ctl);
                        b.BackColor = Color.DarkKhaki;
                        b.Font = new Font("Microsoft Sans Serif", 10);
                    }
                    btn.BackColor = btn.FlatAppearance.MouseOverBackColor;
                    btn.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                };

                page.Dock = DockStyle.Fill;
                page.Visible = false;
                pnlMain.Controls.Add(page);
                pnlLeft.Controls.Add(btn);
            }
        }
    }
}
