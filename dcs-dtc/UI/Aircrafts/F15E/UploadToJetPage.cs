using DTC.Models;
using DTC.Models.Base;
using DTC.Models.F15E;
using DTC.UI.CommonPages;
using System;

namespace DTC.UI.Aircrafts.F15E
{
    public partial class UploadToJetPage : AircraftSettingPage
    {
        private F15EUpload _jetInterface;
        private readonly F15EConfiguration _cfg;

        private long uploadPressedTimestamp = 0;

        public UploadToJetPage(AircraftPage parent, F15EConfiguration cfg) : base(parent)
        {
            InitializeComponent();
            _jetInterface = new F15EUpload(cfg);

            txtWaypointStart.LostFocus += TxtWaypointStart_LostFocus;
            txtWaypointEnd.LostFocus += TxtWaypointEnd_LostFocus;
            _cfg = cfg;

            chkWaypoints.Checked = _cfg.Waypoints.EnableUpload;
            chkOverwriteRange.Checked = _cfg.Waypoints.OverrideRange;
            txtWaypointStart.Text = _cfg.Waypoints.SteerpointStart.ToString();
            txtWaypointEnd.Text = _cfg.Waypoints.SteerpointEnd.ToString();

            chkDisplays.Checked = _cfg.Displays.EnableUpload;
            chkMisc.Checked = _cfg.Misc.EnableUpload;

            radDisplaysPilot.Checked = _cfg.Displays.UploadMode == Models.F15E.Displays.DisplayUploadMode.Pilot;
            radDisplaysWSO.Checked = _cfg.Displays.UploadMode == Models.F15E.Displays.DisplayUploadMode.WSO;

            CheckUploadButtonEnabled();

            DataReceiver.DataReceived += this.DataReceiver_DataReceived;
        }

        private void DataReceiver_DataReceived(DataReceiver.Data d)
        {
            if (d.upload == "1" && uploadPressedTimestamp == 0)
            {
                uploadPressedTimestamp = DateTime.Now.Ticks;
            }
            if (d.upload == "0")
            {
                uploadPressedTimestamp = 0;
            }

            if (uploadPressedTimestamp != 0)
            {
                var timespan = new TimeSpan(DateTime.Now.Ticks - uploadPressedTimestamp);
                if (timespan.TotalMilliseconds > 1000)
                {
                    uploadPressedTimestamp = 0;
                    _jetInterface.Load();
                }
            }
        }

        private void CheckUploadButtonEnabled()
        {
            btnUpload.Enabled = (_cfg.Waypoints.EnableUpload || _cfg.Displays.EnableUpload || _cfg.Misc.EnableUpload);
        }

        public override string GetPageTitle()
        {
            return "Upload to Jet";
        }

        private void TxtWaypointEnd_LostFocus(object sender, EventArgs e)
        {
            if (int.TryParse(txtWaypointEnd.Text, out int n))
            {
                _cfg.Waypoints.SetSteerpointEnd(n);
                _parent.DataChangedCallback();
            }

            txtWaypointEnd.Text = _cfg.Waypoints.SteerpointEnd.ToString();
        }

        private void TxtWaypointStart_LostFocus(object sender, EventArgs e)
        {
            if (int.TryParse(txtWaypointStart.Text, out int n))
            {
                _cfg.Waypoints.SetSteerpointStart(n);
                _parent.DataChangedCallback();
            }

            txtWaypointStart.Text = _cfg.Waypoints.SteerpointStart.ToString();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            _jetInterface.Load();
        }

        private void chkWaypoints_CheckedChanged(object sender, EventArgs e)
        {
            chkOverwriteRange.Enabled = chkWaypoints.Checked;
            txtWaypointStart.Enabled = chkWaypoints.Checked;
            txtWaypointEnd.Enabled = chkWaypoints.Checked;
            _cfg.Waypoints.EnableUpload = chkWaypoints.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void chkOverwriteRange_CheckedChanged(object sender, EventArgs e)
        {
            txtWaypointStart.Enabled = chkOverwriteRange.Checked;
            txtWaypointEnd.Enabled = chkOverwriteRange.Checked;
            _cfg.Waypoints.OverrideRange = chkOverwriteRange.Checked;
            _parent.DataChangedCallback();
        }

        private void chkDisplays_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Displays.EnableUpload = chkDisplays.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void chkMisc_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Misc.EnableUpload = chkMisc.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void radDisplaysPilot_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Displays.UploadMode = Models.F15E.Displays.DisplayUploadMode.Pilot;
            _parent.DataChangedCallback();
        }

        private void radDisplaysWSO_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Displays.UploadMode = Models.F15E.Displays.DisplayUploadMode.WSO;
            _parent.DataChangedCallback();
        }
    }
}
