using DTC.Models;
using DTC.Models.Base;
using DTC.Models.FA18;
using DTC.UI.CommonPages;
using System;

namespace DTC.UI.Aircrafts.FA18
{
    public partial class UploadToJetPage : AircraftSettingPage
    {
        private FA18Upload _jetInterface;
        private readonly FA18Configuration _cfg;

        private long uploadPressedTimestamp = 0;
        private CockpitUploadHelper cockpitUploadHelper;

        public UploadToJetPage(AircraftPage parent, FA18Configuration cfg) : base(parent)
        {
            InitializeComponent();
            _jetInterface = new FA18Upload(cfg);

            txtWaypointStart.LostFocus += TxtWaypointStart_LostFocus;
            txtWaypointStart.Text = cfg.Waypoints.SteerpointStart.ToString();
            _cfg = cfg;

            chkWaypoints.Checked = _cfg.Waypoints.EnableUpload;
            cbSequences.Checked = _cfg.Sequences.EnableUpload;
            cbPrePlanned.Checked = _cfg.PrePlanned.EnableUpload;
            cbCMS.Checked = _cfg.CMS.EnableUpload;
            chkRadios.Checked = _cfg.Radios.EnableUpload;
            chkMisc.Checked = _cfg.Misc.EnableUpload;

            CheckUploadButtonEnabled();
            cockpitUploadHelper = new CockpitUploadHelper(_jetInterface.Load);
        }

        private void CheckUploadButtonEnabled()
        {
            btnUpload.Enabled = (
                _cfg.Waypoints.EnableUpload ||
                _cfg.Sequences.EnableUpload ||
                _cfg.PrePlanned.EnableUpload ||
                _cfg.CMS.EnableUpload ||
                _cfg.Radios.EnableUpload ||
                _cfg.Misc.EnableUpload
                );
        }

        public override string GetPageTitle()
        {
            return "Upload to Jet";
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
            txtWaypointStart.Enabled = chkWaypoints.Checked;
            _cfg.Waypoints.EnableUpload = chkWaypoints.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void cbSequences_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Sequences.EnableUpload = cbSequences.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void cbPrePlanned_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.PrePlanned.EnableUpload = cbPrePlanned.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void chkRadios_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Radios.EnableUpload = chkRadios.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void chkMisc_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Misc.EnableUpload = chkMisc.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void cbCMS_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.CMS.EnableUpload = cbCMS.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
