using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.F15E.Systems
{
    public partial class SmartWeaponsPageEdit : UserControl
    {
        public delegate void PrePlannedEditCallback(SmartWeaponsStation station, SmartWeaponSetting coord);

        private readonly PrePlannedEditCallback _callback;
        private SmartWeaponSetting coord;
        private SmartWeaponsStation station;

        public SmartWeaponsPageEdit(PrePlannedEditCallback callback)
        {
            InitializeComponent();

            _callback = callback;
        }

        public void ShowDialog(SmartWeaponsStation station, SmartWeaponSetting coord)
        {
            this.Visible = true;
            this.BringToFront();
            this.Dock = DockStyle.Fill;
            this.coord = coord;
            this.station = station;
            var c = Coordinate.FromString(coord.Latitude, coord.Longitude);
            txtWptLatLong.Coordinate = c;
            txtWptElevation.Text = coord.Elevation.ToString();
            txtNotes.Text = coord.Notes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (int.TryParse(txtWptElevation.Text, out int n))
                {
                    coord.Elevation = n;
                }
                var c = txtWptLatLong.Coordinate.ToF15EFormat();

                coord.Latitude = c.Lat;
                coord.Longitude = c.Lon;
                coord.Notes = txtNotes.Text;
                _callback(station, coord);
                CloseDialog();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void CloseDialog()
        {
            Visible = false;
            ResetFields();
        }

        private bool ValidateFields()
        {
            lblValidation.Text = "";
            if (ValidateElevation() && ValidateLatLong())
            {
                return true;
            }
            return false;
        }

        private bool ValidateLatLong()
        {
            if (!txtWptLatLong.Valid)
            {
                lblValidation.Text = "Invalid coordinate";
                txtWptLatLong.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateElevation()
        {
            if (!Util.IsValidInt(txtWptElevation.Text))
            {
                lblValidation.Text = "Invalid elevation";
                txtWptElevation.Focus();
                return false;
            }

            return true;
        }

        private void ResetFields()
        {
            txtWptLatLong.Text = "";
            txtWptElevation.Text = "0";
            txtWptLatLong.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            coord.Latitude = "";
            coord.Longitude = "";
            coord.Elevation = 0;
            _callback(station, coord);
            CloseDialog();
        }

        private void txtWptLatLong_ElevationPasted(int elev)
        {
            txtWptElevation.Value = elev;
        }
    }
}
