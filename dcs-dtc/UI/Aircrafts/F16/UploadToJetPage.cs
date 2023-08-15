using DTC.Utilities;
using DTC.Models;
using DTC.Models.F16;
using DTC.UI.CommonPages;
using System;

namespace DTC.UI.Aircrafts.F16
{
    public partial class UploadToJetPage : AircraftSettingPage
    {
        private F16Upload _jetInterface;
        private readonly F16Configuration _cfg;
        private CockpitUploadHelper cockpitUploadHelper;

        public UploadToJetPage(AircraftPage parent, F16Configuration cfg) : base(parent)
        {
            InitializeComponent();
            _jetInterface = new F16Upload(cfg);

            txtWaypointStart.LostFocus += TxtWaypointStart_LostFocus;
            txtWaypointEnd.LostFocus += TxtWaypointEnd_LostFocus;
            _cfg = cfg;

            chkWaypoints.Checked = _cfg.Waypoints.EnableUpload;
            chkCoordinatesElevation.Checked = _cfg.Waypoints.EnableUploadCoordsElevation;
            chkTimeOverSteerpoint.Checked = _cfg.Waypoints.EnableUploadTOS;
            chkOverwriteRange.Checked = _cfg.Waypoints.OverrideRange;
            txtWaypointStart.Text = _cfg.Waypoints.SteerpointStart.ToString();
            txtWaypointEnd.Text = _cfg.Waypoints.SteerpointEnd.ToString();
            chkCMS.Checked = _cfg.CMS.EnableUpload;
            chkRadios.Checked = _cfg.Radios.EnableUpload;
            chkMisc.Checked = _cfg.Misc.EnableUpload;
            chkMFDs.Checked = _cfg.MFD.EnableUpload;
            chkHARM.Checked = _cfg.HARM.EnableUpload;
            chkHTS.Checked = _cfg.HTS.EnableUpload;

            CheckUploadButtonEnabled();
            cockpitUploadHelper = new CockpitUploadHelper(_jetInterface.Load);
        }

        private void CheckUploadButtonEnabled()
        {
            btnUpload.Enabled = (_cfg.Waypoints.EnableUpload || _cfg.CMS.EnableUpload || _cfg.Radios.EnableUpload || _cfg.Misc.EnableUpload || _cfg.MFD.EnableUpload || _cfg.HARM.EnableUpload || _cfg.HTS.EnableUpload);
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
            chkCoordinatesElevation.Enabled = chkWaypoints.Checked;
            chkTimeOverSteerpoint.Enabled = chkWaypoints.Checked;
            chkOverwriteRange.Enabled = chkWaypoints.Checked;
            txtWaypointStart.Enabled = chkWaypoints.Checked;
            txtWaypointEnd.Enabled = chkWaypoints.Checked;
            _cfg.Waypoints.EnableUpload = chkWaypoints.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void chkCMS_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.CMS.EnableUpload = chkCMS.Checked;
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

        private void chkMFDs_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.MFD.EnableUpload = chkMFDs.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void chkHARM_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.HARM.EnableUpload = chkHARM.Checked;
            _parent.DataChangedCallback();
            CheckUploadButtonEnabled();
        }

        private void chkHTS_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.HTS.EnableUpload = chkHTS.Checked;
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

        private void chkCoordinatesElevation_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Waypoints.EnableUploadCoordsElevation = chkCoordinatesElevation.Checked;
            _parent.DataChangedCallback();
        }

        private void chkTimeOverSteerpoint_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Waypoints.EnableUploadTOS = chkTimeOverSteerpoint.Checked;
            _parent.DataChangedCallback();
        }
    }
}
