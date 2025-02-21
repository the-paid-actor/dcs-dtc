using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    public partial class UploadPage : AircraftSystemPage
    {
        private readonly UploadSystem upload;

        public UploadPage(FA18Page parent) : base(parent, nameof(parent.Configuration.Upload))
        {
            InitializeComponent();

            upload = parent.Configuration.Upload;

            chkWaypoints.Checked = upload.Waypoints;
            cbSequences.Checked = upload.Sequences;
            cbPrePlanned.Checked = upload.PrePlanned;
            cbCMS.Checked = upload.CMS;
            chkRadios.Checked = upload.Radios;
            chkHMD.Checked = upload.HMD;
            chkMisc.Checked = upload.Misc;
            chkFCR.Checked = upload.FCR;

            chkHMD.CheckedChanged += (s, e) =>
            {
                upload.HMD = chkHMD.Checked;
                this.SavePreset();
            };

            chkFCR.CheckedChanged += (s, e) =>
            {
                upload.FCR = chkFCR.Checked;
                this.SavePreset();
            };

            chkKneeboard.Checked = upload.Kneeboard;
            chkKneeboard.CheckedChanged += (s, e) =>
            {
                upload.Kneeboard = chkKneeboard.Checked;
                this.SavePreset();
            };
        }

        public override string GetPageTitle()
        {
            return "Upload Settings";
        }

        private void chkWaypoints_CheckedChanged(object sender, EventArgs e)
        {
            upload.Waypoints = chkWaypoints.Checked;
            this.SavePreset();
        }

        private void cbSequences_CheckedChanged(object sender, EventArgs e)
        {
            upload.Sequences = cbSequences.Checked;
            this.SavePreset();
        }

        private void cbPrePlanned_CheckedChanged(object sender, EventArgs e)
        {
            upload.PrePlanned = cbPrePlanned.Checked;
            this.SavePreset();
        }

        private void chkRadios_CheckedChanged(object sender, EventArgs e)
        {
            upload.Radios = chkRadios.Checked;
            this.SavePreset();
        }

        private void chkMisc_CheckedChanged(object sender, EventArgs e)
        {
            upload.Misc = chkMisc.Checked;
            this.SavePreset();
        }

        private void cbCMS_CheckedChanged(object sender, EventArgs e)
        {
            upload.CMS = cbCMS.Checked;
            this.SavePreset();
        }
    }
}
