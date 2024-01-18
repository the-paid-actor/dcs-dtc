using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class UploadPage : AircraftSystemPage
    {
        private readonly UploadSystem _cfg;

        public UploadPage(F16Page parent) : base(parent, nameof(parent.Configuration.Upload))
        {
            InitializeComponent();

            _cfg = parent.Configuration.Upload;

            chkWaypoints.Checked = _cfg.Waypoints;
            chkCMS.Checked = _cfg.CMS;
            chkRadios.Checked = _cfg.Radios;
            chkMisc.Checked = _cfg.Misc;
            chkMFDs.Checked = _cfg.MFDs;
            chkHARMHTS.Checked = _cfg.HARMHTS;
            chkDatalink.Checked = _cfg.Datalink;

            chkWaypoints.CheckedChanged += (s, e) =>
            {
                _cfg.Waypoints = chkWaypoints.Checked;
                this.SavePreset();
            };

            chkCMS.CheckedChanged += (s, e) =>
            {
                _cfg.CMS = chkCMS.Checked;
                this.SavePreset();
            };

            chkRadios.CheckedChanged += (s, e) =>
            {
                _cfg.Radios = chkRadios.Checked;
                this.SavePreset();
            };

            chkMisc.CheckedChanged += (s, e) =>
            {
                _cfg.Misc = chkMisc.Checked;
                this.SavePreset();
            };

            chkMFDs.CheckedChanged += (s, e) =>
            {
                _cfg.MFDs = chkMFDs.Checked;
                this.SavePreset();
            };

            chkHARMHTS.CheckedChanged += (s, e) =>
            {
                _cfg.HARMHTS = chkHARMHTS.Checked;
                this.SavePreset();
            };

            chkDatalink.CheckedChanged += (s, e) =>
            {
                _cfg.Datalink = chkDatalink.Checked;
                this.SavePreset();
            };
        }

        public override string GetPageTitle()
        {
            return "Upload Settings";
        }
    }
}
