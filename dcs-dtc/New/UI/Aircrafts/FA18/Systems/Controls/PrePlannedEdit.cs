using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.FA18.Systems.Controls
{
    public partial class PrePlannedEdit : UserControl
    {
        public delegate void PrePlannedEditCallback(PrePlannedCoordinate coord, int station, int pos);

        private readonly PrePlannedEditCallback _callback;
        private PrePlannedCoordinate ppCoordinate;
        private int station;
        private int ppNumber;

        public PrePlannedEdit(PrePlannedEditCallback callback)
        {
            InitializeComponent();

            _callback = callback;
        }

        public void ShowDialog(PrePlannedCoordinate coord, int station, int position)
        {
            this.Visible = true;
            this.BringToFront();
            this.Dock = DockStyle.Fill;
            ppCoordinate = coord;
            this.station = station;
            ppNumber = position;
            var c = Coordinate.FromString(coord.Lat, coord.Lon);
            txtWptLatLong.Coordinate = c;
            txtWptElevation.Text = coord.Elev.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (int.TryParse(txtWptElevation.Text, out int n))
                {
                    ppCoordinate.Elev = n;
                }
                var c = txtWptLatLong.Coordinate.ToHornetPreplannedFormat();

                ppCoordinate.Lat = c.Lat;
                ppCoordinate.Lon = c.Lon;
                _callback(ppCoordinate, station, ppNumber);
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
            ppCoordinate.Reset();
            _callback(ppCoordinate, station, ppNumber);
            CloseDialog();
        }

        private void txtWptLatLong_ElevationPasted(int elev)
        {
            txtWptElevation.Value = elev;
        }
    }
}
