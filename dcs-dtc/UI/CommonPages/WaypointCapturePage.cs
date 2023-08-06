using DTC.Models.Shared;
using System;

namespace DTC.UI.CommonPages
{
    public partial class WaypointCapturePage : AircraftSettingPage
    {
        private WaypointCaptureSettings settings;

        public WaypointCapturePage(AircraftPage parent, WaypointCaptureSettings settings) : base(parent)
        {
            InitializeComponent();
            this.settings = settings;
            radAppend.Checked = settings.AppendToWaypointList;
            radOverwrite.Checked = !settings.AppendToWaypointList;
            txtOverwriteFrom.Value = settings.OverwriteFrom;
            txtOverwriteUntil.Value = settings.OverwriteUntil > -1 ? settings.OverwriteUntil : txtOverwriteUntil.Value;

            //this.chkUpload.CheckedChanged += new System.EventHandler(this.chkUpload_CheckedChanged);
            //this.radSourceAll.CheckedChanged += new System.EventHandler(this.radSourceAll_CheckedChanged);
            //this.radSourceRange.CheckedChanged += new System.EventHandler(this.radSourceRange_CheckedChanged);
            //this.txtSourceRangeUntil.TextBoxChanged += new DTC.UI.Base.Controls.DTCNumericTextBox.TextBoxChangedCallback(this.txtSourceRangeUntil_TextBoxChanged);
            //this.txtSourceRangeFrom.TextBoxChanged += new DTC.UI.Base.Controls.DTCNumericTextBox.TextBoxChangedCallback(this.txtSourceRangeFrom_TextBoxChanged);
            //this.txtDestRouteFrom.TextBoxChanged += new DTC.UI.Base.Controls.DTCNumericTextBox.TextBoxChangedCallback(this.txtDestRouteFrom_TextBoxChanged);
            //this.txtDestRouteUntil.TextBoxChanged += new DTC.UI.Base.Controls.DTCNumericTextBox.TextBoxChangedCallback(this.txtDestRouteUntil_TextBoxChanged);

            //chkUpload.Checked = settings.Upload;
            //radSourceAll.Checked = settings.UploadSourceAll;
            //radSourceRange.Checked = !settings.UploadSourceAll;
            //txtSourceRangeFrom.Value = settings.UploadSourceFrom;
            //txtSourceRangeUntil.Value = settings.UploadSourceUntil > -1 ? settings.UploadSourceUntil : txtSourceRangeUntil.Value;
            //txtDestRouteFrom.Value = settings.UploadDestFrom;
            //txtDestRouteUntil.Value = settings.UploadDestUntil > -1 ? settings.UploadDestUntil : txtDestRouteUntil.Value;
        }

        public override string GetPageTitle()
        {
            return "Waypoints Capture";
        }

        private void radOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            lblOverwriteFrom.Enabled = radOverwrite.Checked;
            txtOverwriteFrom.Enabled = radOverwrite.Checked;
            lblOverwriteUntil.Enabled = radOverwrite.Checked;
            txtOverwriteUntil.Enabled = radOverwrite.Checked;

            settings.AppendToWaypointList = radAppend.Checked;
            _parent.DataChangedCallback();
        }

        private void radAppend_CheckedChanged(object sender, EventArgs e)
        {
            settings.AppendToWaypointList = radAppend.Checked;
            _parent.DataChangedCallback();
        }

        private void txtOverwriteFrom_TextBoxChanged(Base.Controls.DTCNumericTextBox textBox)
        {
            settings.OverwriteFrom = txtOverwriteFrom.Value == null ? 1 : (int)txtOverwriteFrom.Value;
        }

        private void txtOverwriteUntil_TextBoxChanged(Base.Controls.DTCNumericTextBox textBox)
        {
            settings.OverwriteUntil = txtOverwriteUntil.Value == null ? -1 : (int)txtOverwriteUntil.Value;
        }



        //private void chkUpload_CheckedChanged(object sender, EventArgs e)
        //{
        //    pnlSource.Enabled = chkUpload.Checked;
        //    pnlDestination.Enabled = chkUpload.Checked;

        //    settings.Upload = chkUpload.Checked;
        //    _parent.DataChangedCallback();
        //}

        //private void radSourceAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    settings.UploadSourceAll = radSourceAll.Checked;
        //    _parent.DataChangedCallback();
        //}

        //private void radSourceRange_CheckedChanged(object sender, EventArgs e)
        //{
        //    lblSourceRangeFrom.Enabled = radSourceRange.Checked;
        //    txtSourceRangeFrom.Enabled = radSourceRange.Checked;
        //    lblSourceRangeUntil.Enabled = radSourceRange.Checked;
        //    txtSourceRangeUntil.Enabled = radSourceRange.Checked;

        //    settings.UploadSourceAll = !radSourceRange.Checked;
        //    _parent.DataChangedCallback();
        //}

        //private void txtSourceRangeFrom_TextBoxChanged(Base.Controls.DTCNumericTextBox textBox)
        //{
        //    settings.UploadSourceFrom = txtSourceRangeFrom.Value == null ? 1 : (int)txtSourceRangeFrom.Value;
        //}

        //private void txtSourceRangeUntil_TextBoxChanged(Base.Controls.DTCNumericTextBox textBox)
        //{
        //    settings.UploadSourceUntil = txtSourceRangeUntil.Value == null ? -1 : (int)txtSourceRangeUntil.Value;
        //}

        //private void txtDestRouteFrom_TextBoxChanged(Base.Controls.DTCNumericTextBox textBox)
        //{
        //    settings.UploadDestFrom = txtDestRouteFrom.Value == null ? 1 : (int)txtDestRouteFrom.Value;
        //}

        //private void txtDestRouteUntil_TextBoxChanged(Base.Controls.DTCNumericTextBox textBox)
        //{
        //    settings.UploadDestUntil = txtDestRouteUntil.Value == null ? -1 : (int)txtDestRouteUntil.Value;
        //}
    }
}
