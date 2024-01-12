using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class UploadPage : AircraftSystemPage
    {
        private readonly UploadSystem _cfg;

        public UploadPage(F16Page parent, UploadSystem upload) : base(parent)
        {
            InitializeComponent();

            _cfg = upload;

            chkWaypoints.Checked = _cfg.Waypoints;
            chkCMS.Checked = _cfg.CMS;
            chkRadios.Checked = _cfg.Radios;
            chkMisc.Checked = _cfg.Misc;
            chkMFDs.Checked = _cfg.MFDs;
            chkHARMHTS.Checked = _cfg.HARMHTS;
            chkDatalink.Checked = _cfg.Datalink;
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

        private void chkCMS_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.CMS = chkCMS.Checked;
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

        private void chkMFDs_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.MFDs = chkMFDs.Checked;
            this.SavePreset();
        }

        private void chkHARM_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.HARMHTS = chkHARMHTS.Checked;
            this.SavePreset();
        }

        private void chkDatalink_CheckedChanged(object sender, EventArgs e)
        {
            _cfg.Datalink = chkDatalink.Checked;
            this.SavePreset();
        }
    }
}
