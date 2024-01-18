using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    public partial class UploadPage : AircraftSystemPage
    {
        private readonly UploadSystem _cfg;

        public UploadPage(FA18Page parent) : base(parent, nameof(parent.Configuration.Upload))
        {
            InitializeComponent();

            _cfg = parent.Configuration.Upload;

            chkWaypoints.Checked = _cfg.Waypoints;
            cbSequences.Checked = _cfg.Sequences;
            cbPrePlanned.Checked = _cfg.PrePlanned;
            cbCMS.Checked = _cfg.CMS;
            chkRadios.Checked = _cfg.Radios;
            chkHMD.Checked = _cfg.HMD;
            chkMisc.Checked = _cfg.Misc;
            chkFCR.Checked = _cfg.FCR;

            chkHMD.CheckedChanged += (s, e) =>
            {
                _cfg.HMD = chkHMD.Checked;
                this.SavePreset();
            };

            chkFCR.CheckedChanged += (s, e) =>
            {
                _cfg.FCR = chkFCR.Checked;
                this.SavePreset();
            };
        }

        public override string GetPageTitle()
        {
            return "Upload Settings";
        }

        private void chkWaypoints_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Waypoints = chkWaypoints.Checked;
            this.SavePreset();
        }

        private void cbSequences_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Sequences = cbSequences.Checked;
            this.SavePreset();
        }

        private void cbPrePlanned_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.PrePlanned = cbPrePlanned.Checked;
            this.SavePreset();
        }

        private void chkRadios_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Radios = chkRadios.Checked;
            this.SavePreset();
        }

        private void chkMisc_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Misc = chkMisc.Checked;
            this.SavePreset();
        }

        private void cbCMS_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.CMS = cbCMS.Checked;
            this.SavePreset();
        }
    }
}
