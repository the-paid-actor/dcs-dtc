using DTC.Utilities;
using DTC.Models.FA18.PrePlanned;
using DTC.UI.Base;
using System;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.FA18
{
    public partial class PrePlannedEdit : UserControl
    {
        public delegate void PrePlannedEditCallback(PrePlannedCoordinate coord, int station, int pos);

        private readonly PrePlannedEditCallback _callback;
        private PrePlannedCoordinate _prePlanned;
        private int _station;
        private int _pos;
        private WaypointCapture _waypointCapture;

        public PrePlannedEdit(PrePlannedEditCallback callback)
        {
            InitializeComponent();

            _callback = callback;
        }

        public void ShowDialog(PrePlannedCoordinate coord, int station, int position)
        {
            this.Visible = true;
            this.BringToFront();
            _prePlanned = coord;
            _station = station;
            _pos = position;
            txtWptLatLong.Text = coord.Lat + coord.Lon;
            txtWptElevation.Text = coord.Elev.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (int.TryParse(txtWptElevation.Text, out int n))
                {
                    _prePlanned.Elev = n;
                }
                var match = PrePlannedCoordinate.coordRegex.Match(txtWptLatLong.Text);

                _prePlanned.Lat = match.Groups[1].Value;
                _prePlanned.Lon = match.Groups[2].Value;
                _callback(_prePlanned, _station, _pos);
                CloseDialog();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void CloseDialog()
        {
            DisposeWptCapture();

            Visible = false;
            ResetFields();
        }

        private void DisposeWptCapture()
        {
            if (_waypointCapture != null)
            {
                btnCapture.Text = "Start Capture";
                _waypointCapture.Dispose();
                _waypointCapture = null;
            }
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
            if (!txtWptLatLong.MaskFull || !PrePlannedCoordinate.IsCoordinateValid(txtWptLatLong.Text))
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

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (_waypointCapture == null)
            {
                btnCapture.Text = "Stop Capture";
                _waypointCapture = new WaypointCapture((Coordinate coord, string elevation) =>
                {
                    this.ParentForm.Invoke(new MethodInvoker(delegate ()
                    {
                        txtWptLatLong.Text = coord.ToDegreesMinutesSecondsHundredths();
                        txtWptElevation.Text = elevation;
                    }));
                });
            }
            else
            {
                DisposeWptCapture();
            }
        }
    }
}
