using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F15E.Systems
{
    public partial class SmartWeaponsPage : AircraftSystemPage
    {
        private readonly SmartWeaponsSystem swsystem;
        private SmartWeaponsPageEdit dialog;

        public SmartWeaponsPage(F15EPage parent) : base(parent, nameof(parent.Configuration.SmartWeapons))
        {
            InitializeComponent();
            this.swsystem = parent.Configuration.SmartWeapons;

            btnLeftWing.Click += (s, e) => Edit(StationNames.LWING);
            btnCenter.Click += (s, e) => Edit(StationNames.CENTERLINE);
            btnRightWing.Click += (s, e) => Edit(StationNames.RWING);
            btnLCFTF.Click += (s, e) => Edit(StationNames.LCFTFRONT);
            btnLCFTM.Click += (s, e) => Edit(StationNames.LCFTMID);
            btnLCFTR.Click += (s, e) => Edit(StationNames.LCFTREAR);
            btnRCFTF.Click += (s, e) => Edit(StationNames.RCFTFRONT);
            btnRCFTM.Click += (s, e) => Edit(StationNames.RCFTMID);
            btnRCFTR.Click += (s, e) => Edit(StationNames.RCFTREAR);

            RefreshButtons();

            this.dialog = new SmartWeaponsPageEdit((station, coord) =>
            {
                if (string.IsNullOrEmpty(coord.Latitude))
                {
                    station.Settings = null;
                }
                else
                {
                    if (station.Settings == null || station.Settings.Length == 0)
                    {
                        station.Settings = new SmartWeaponSetting[] { coord };
                    }
                    else
                    {
                        station.Settings[0] = coord;
                    }
                }
                SavePreset();
                RefreshButtons();
            });
            this.Controls.Add(dialog);
            dialog.Visible = false;
        }

        public void RefreshButtons()
        {
            MarkButton(btnLeftWing, StationNames.LWING);
            MarkButton(btnCenter, StationNames.CENTERLINE);
            MarkButton(btnRightWing, StationNames.RWING);
            MarkButton(btnLCFTF, StationNames.LCFTFRONT);
            MarkButton(btnLCFTM, StationNames.LCFTMID);
            MarkButton(btnLCFTR, StationNames.LCFTREAR);
            MarkButton(btnRCFTF, StationNames.RCFTFRONT);
            MarkButton(btnRCFTM, StationNames.RCFTMID);
            MarkButton(btnRCFTR, StationNames.RCFTREAR);
        }

        private void MarkButton(DTCButton button, string stationName)
        {
            button.Font = new Font(button.Font, FontStyle.Regular);
            toolTip.SetToolTip(button, "");
            var sta = swsystem.Get(stationName);
            if (sta != null)
            {
                var wpn = sta.GetFirst();
                if (wpn != null)
                {
                    button.Font = new Font(button.Font, FontStyle.Bold);
                    toolTip.SetToolTip(button, $"{wpn.Latitude}\n{wpn.Longitude}\n{wpn.Elevation} ft\n{wpn.Notes}");
                }
            }
        }

        private void Edit(string stationKey)
        {
            if (!swsystem.Stations.ContainsKey(stationKey))
            {
                swsystem.Stations.Add(stationKey, new SmartWeaponsStation { Name = stationKey });
            }

            var station = swsystem.Stations[stationKey];
            var coord = new SmartWeaponSetting();
            if (station.Settings != null && station.Settings.Length > 0)
            {
                coord = station.Settings[0];
            }

            dialog.ShowDialog(station, coord);
        }

        public override string GetPageTitle()
        {
            return "Smart Weapons";
        }

        internal void ResetAll()
        {
            this.swsystem.ResetAll();
            this.SavePreset();
            this.RefreshButtons();
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            this.ResetAll();
        }
    }
}
