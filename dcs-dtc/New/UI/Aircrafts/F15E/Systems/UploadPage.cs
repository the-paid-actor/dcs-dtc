using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.F15E.Systems
{
    public partial class UploadPage : AircraftSystemPage
    {
        private UploadSystem upload;

        public UploadPage(F15EPage parent) : base(parent, nameof(parent.Configuration.Upload))
        {
            InitializeComponent();

            this.upload = parent.Configuration.Upload;

            chkRouteA.Checked = this.upload.RouteA;
            chkRouteB.Checked = this.upload.RouteB;
            chkRouteC.Checked = this.upload.RouteC;
            chkDisplays.Checked = this.upload.Displays;
            chkRadios.Checked = this.upload.Radios;
            chkMisc.Checked = this.upload.Misc;

            radDisplaysAuto.Checked = this.upload.DisplayUploadMode == DisplayUploadMode.AutoSelect;
            radDisplaysPilotAndWSO.Checked = this.upload.DisplayUploadMode == DisplayUploadMode.PilotAndWSO;
            chkSmartWeapons.Checked = this.upload.SmartWeapons;

            chkRouteA.CheckedChanged += (s, e) =>
            {
                upload.RouteA = chkRouteA.Checked;
                this.SavePreset();
            };
            chkRouteB.CheckedChanged += (s, e) =>
            {
                upload.RouteB = chkRouteB.Checked;
                this.SavePreset();
            };
            chkRouteC.CheckedChanged += (s, e) =>
            {
                upload.RouteC = chkRouteC.Checked;
                this.SavePreset();
            };
            chkSmartWeapons.CheckedChanged += (s, e) =>
            {
                upload.SmartWeapons = chkSmartWeapons.Checked;
                this.SavePreset();
            };
        }

        public override string GetPageTitle()
        {
            return "Upload Settings";
        }

        private void chkDisplays_CheckedChanged(object sender, EventArgs e)
        {
            upload.Displays = chkDisplays.Checked;
            radDisplaysAuto.Enabled = chkDisplays.Checked;
            radDisplaysPilotAndWSO.Enabled = chkDisplays.Checked;
            this.SavePreset();
        }

        private void chkMisc_CheckedChanged(object sender, EventArgs e)
        {
            upload.Misc = chkMisc.Checked;
            this.SavePreset();
        }

        private void radDisplaysAuto_CheckedChanged(object sender, EventArgs e)
        {
            upload.DisplayUploadMode = DisplayUploadMode.AutoSelect;
            this.SavePreset();
        }

        private void radDisplaysPilotAndWSO_CheckedChanged(object sender, EventArgs e)
        {
            upload.DisplayUploadMode = DisplayUploadMode.PilotAndWSO;
            this.SavePreset();
        }

        private void chkRadios_CheckedChanged(object sender, EventArgs e)
        {
            upload.Radios = chkRadios.Checked;
            this.SavePreset();
        }
    }
}
