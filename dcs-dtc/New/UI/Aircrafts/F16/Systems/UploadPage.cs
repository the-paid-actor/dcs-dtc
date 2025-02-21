using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class UploadPage : AircraftSystemPage
    {
        private readonly UploadSystem upload;

        public UploadPage(F16Page parent) : base(parent, nameof(parent.Configuration.Upload))
        {
            InitializeComponent();

            upload = parent.Configuration.Upload;

            chkWaypoints.Checked = upload.Waypoints;
            chkCMS.Checked = upload.CMS;
            chkRadios.Checked = upload.Radios;
            chkMisc.Checked = upload.Misc;
            chkMFDs.Checked = upload.MFDs;
            chkHARMHTS.Checked = upload.HARMHTS;
            chkDatalink.Checked = upload.Datalink;

            chkWaypoints.CheckedChanged += (s, e) =>
            {
                upload.Waypoints = chkWaypoints.Checked;
                this.SavePreset();
            };

            chkCMS.CheckedChanged += (s, e) =>
            {
                upload.CMS = chkCMS.Checked;
                this.SavePreset();
            };

            chkRadios.CheckedChanged += (s, e) =>
            {
                upload.Radios = chkRadios.Checked;
                this.SavePreset();
            };

            chkMisc.CheckedChanged += (s, e) =>
            {
                upload.Misc = chkMisc.Checked;
                this.SavePreset();
            };

            chkMFDs.CheckedChanged += (s, e) =>
            {
                upload.MFDs = chkMFDs.Checked;
                this.SavePreset();
            };

            chkHARMHTS.CheckedChanged += (s, e) =>
            {
                upload.HARMHTS = chkHARMHTS.Checked;
                this.SavePreset();
            };

            chkDatalink.CheckedChanged += (s, e) =>
            {
                upload.Datalink = chkDatalink.Checked;
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
    }
}
