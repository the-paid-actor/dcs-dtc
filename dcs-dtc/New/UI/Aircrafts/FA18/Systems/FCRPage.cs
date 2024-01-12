using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    public partial class FCRPage : AircraftSystemPage
    {
        public override string GetPageTitle()
        {
            return "FCR";
        }

        public FCRPage(FA18Page parent, FCRSystem fcr) : base(parent)
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(FCRDeclutterMode)))
            {
                cboMode.Items.Add(item);
            }
            cboMode.SelectedItem = fcr.DeclutterMode;
            cboMode.SelectedIndexChanged += (s, e) =>
            {
                fcr.DeclutterMode = (FCRDeclutterMode)cboMode.SelectedItem;
                this.SavePreset();
            };

            chkEnableRWR.Checked = fcr.EnableRWR;
            chkEnableRWR.CheckedChanged += (s, e) =>
            {
                fcr.EnableRWR = chkEnableRWR.Checked;
                this.SavePreset();
            };

            chkEnableBRA.Checked = fcr.EnableBRA;
            chkEnableBRA.CheckedChanged += (s, e) =>
            {
                fcr.EnableBRA = chkEnableBRA.Checked;
                this.SavePreset();
            };

            foreach (var range in FCRWeaponSettings.RangeValues)
            {
                cboAMRAAMRange.Items.Add(range);
                cboSparrowRange.Items.Add(range);
                cboSidewinderRange.Items.Add(range);
            }
            cboAMRAAMRange.SelectedItem = fcr.AMRAAMSettings.Range;
            cboAMRAAMRange.SelectedIndexChanged += (s, e) =>
            {
                fcr.AMRAAMSettings.Range = (int)cboAMRAAMRange.SelectedItem;
                this.SavePreset();
            };
            cboSparrowRange.SelectedItem = fcr.AIM7Settings.Range;
            cboSparrowRange.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM7Settings.Range = (int)cboSparrowRange.SelectedItem;
                this.SavePreset();
            };
            cboSidewinderRange.SelectedItem = fcr.AIM9Settings.Range;
            cboSidewinderRange.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM9Settings.Range = (int)cboSidewinderRange.SelectedItem;
                this.SavePreset();
            };

            foreach (var bars in FCRWeaponSettings.BarsValues)
            {
                cboAMRAAMBars.Items.Add(bars);
                cboSparrowBars.Items.Add(bars);
                cboSidewinderBars.Items.Add(bars);
            }
            cboAMRAAMBars.SelectedItem = fcr.AMRAAMSettings.Bars;
            cboAMRAAMBars.SelectedIndexChanged += (s, e) =>
            {
                fcr.AMRAAMSettings.Bars = (int)cboAMRAAMBars.SelectedItem;
                this.SavePreset();
            };
            cboSparrowBars.SelectedItem = fcr.AIM7Settings.Bars;
            cboSparrowBars.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM7Settings.Bars = (int)cboSparrowBars.SelectedItem;
                this.SavePreset();
            };
            cboSidewinderBars.SelectedItem = fcr.AIM9Settings.Bars;
            cboSidewinderBars.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM9Settings.Bars = (int)cboSidewinderBars.SelectedItem;
                this.SavePreset();
            };

            foreach (var az in FCRWeaponSettings.AzimuthValues)
            {
                cboAMRAAMAz.Items.Add(az);
                cboSparrowAz.Items.Add(az);
                cboSidewinderAz.Items.Add(az);
            }
            cboAMRAAMAz.SelectedItem = fcr.AMRAAMSettings.Azimuth;
            cboAMRAAMAz.SelectedIndexChanged += (s, e) =>
            {
                fcr.AMRAAMSettings.Azimuth = (int)cboAMRAAMAz.SelectedItem;
                this.SavePreset();
            };
            cboSparrowAz.SelectedItem = fcr.AIM7Settings.Azimuth;
            cboSparrowAz.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM7Settings.Azimuth = (int)cboSparrowAz.SelectedItem;
                this.SavePreset();
            };
            cboSidewinderAz.SelectedItem = fcr.AIM9Settings.Azimuth;
            cboSidewinderAz.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM9Settings.Azimuth = (int)cboSidewinderAz.SelectedItem;
                this.SavePreset();
            };

            foreach (var aging in FCRWeaponSettings.AgingValues)
            {
                cboAMRAAMAging.Items.Add(aging);
                cboSparrowAging.Items.Add(aging);
                cboSidewinderAging.Items.Add(aging);
            }
            cboAMRAAMAging.SelectedItem = fcr.AMRAAMSettings.Aging;
            cboAMRAAMAging.SelectedIndexChanged += (s, e) =>
            {
                fcr.AMRAAMSettings.Aging = (int)cboAMRAAMAging.SelectedItem;
                this.SavePreset();
            };
            cboSparrowAging.SelectedItem = fcr.AIM7Settings.Aging;
            cboSparrowAging.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM7Settings.Aging = (int)cboSparrowAging.SelectedItem;
                this.SavePreset();
            };
            cboSidewinderAging.SelectedItem = fcr.AIM9Settings.Aging;
            cboSidewinderAging.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM9Settings.Aging = (int)cboSidewinderAging.SelectedItem;
                this.SavePreset();
            };

            foreach (var item in Enum.GetValues(typeof(FCRPRFMode)))
            {
                cboAMRAAMPRF.Items.Add(item);
                cboSparrowPRF.Items.Add(item);
                cboSidewinderPRF.Items.Add(item);
            }
            cboAMRAAMPRF.SelectedItem = fcr.AMRAAMSettings.PRF;
            cboAMRAAMPRF.SelectedIndexChanged += (s, e) =>
            {
                fcr.AMRAAMSettings.PRF = (FCRPRFMode)cboAMRAAMPRF.SelectedItem;
                this.SavePreset();
            };
            cboSparrowPRF.SelectedItem = fcr.AIM7Settings.PRF;
            cboSparrowPRF.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM7Settings.PRF = (FCRPRFMode)cboSparrowPRF.SelectedItem;
                this.SavePreset();
            };
            cboSidewinderPRF.SelectedItem = fcr.AIM9Settings.PRF;
            cboSidewinderPRF.SelectedIndexChanged += (s, e) =>
            {
                fcr.AIM9Settings.PRF = (FCRPRFMode)cboSidewinderPRF.SelectedItem;
                this.SavePreset();
            };
        }
    }
}
