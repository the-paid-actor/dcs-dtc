using System;
using System.Windows.Forms;
using DTC.Utilities;
using DTC.Models.FA18.PrePlanned;
using DTC.UI.Base;

namespace DTC.UI.Aircrafts.FA18.CompositeControls
{
    public partial class SteerPointEditControl : UserControl
    {
        private PrePlannedSteerpoint _stp;
        private WaypointCapture _waypointCapture;
        SteerPointEditControl[] _STPEdControls;

        public SteerPointEditControl()
        {
            InitializeComponent();
            dtcDropDown1.SelectedIndex = 0;

            for (int i = 0; i < 20; i++)
            {
                domainUpDown1.Items.Add(String.Format("Waypoint {0}", i));
            }
            
            ResetFields();
        }

        public void Connect(PrePlannedSteerpoint stp, SteerPointEditControl[] STPEdControls) {
            this._stp = stp;
            this._STPEdControls = STPEdControls;
            cbEnable.Checked = stp.Enabled;
            dtcDropDown1.SelectedIndex = stp.useCoordinate ? 0 : 1;
            txtCoord.Text = stp.Lat + " " + stp.Lon;
            txtAlt.Text = String.Format("{0:00000}", stp.Elev);
            domainUpDown1.SelectedIndex = stp.waypointNumber;
        }

        public void StoreValues()
        {
            _stp.Enabled = cbEnable.Checked;

            if (dtcDropDown1.SelectedIndex == 0)
            {
                _stp.useCoordinate = true;

                var match = PrePlannedCoordinate.coordRegex.Match(txtCoord.Text);
                _stp.Lat = match.Groups[1].Value;
                _stp.Lon = match.Groups[2].Value;

                if (int.TryParse(txtAlt.Text, out int n))
                    _stp.Elev = n;

                _stp.waypointNumber = 0;
            }
            else
            {
                _stp.useCoordinate = false;
                _stp.waypointNumber = domainUpDown1.SelectedIndex;

                _stp.Lat = "";
                _stp.Lon = "";
                _stp.Elev = 0;
            }
        }

        public void ResetFields()
        {
            cbEnable.Checked = false;
            txtCoord.Text = "";
            txtAlt.Text = "";
            domainUpDown1.SelectedIndex = 0;
        }

        public bool ValidateFields(out string error) {
            if (cbEnable.Checked == false) {
                error = "";
                return true;
            }

            if (dtcDropDown1.SelectedIndex == 0) return ValidateLatLong(out error) && ValidateElevation(out error);
            else
            {
                error = "";
                return true;
            }
        }

        private bool ValidateLatLong(out string error)
        {
            if (!txtCoord.MaskFull || !PrePlannedCoordinate.IsCoordinateValid(txtCoord.Text))
            {
                error = "Invalid coordinate";
                txtCoord.Focus();
                return false;
            }

            error = "";
            return true;
        }

        private bool ValidateElevation(out string error)
        {
            if (!Util.IsValidInt(txtAlt.Text))
            {
                error = "Invalid elevation";
                txtAlt.Focus();
                return false;
            }

            error = "";
            return true;
        }

        private void dtcDropDown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtcDropDown1.SelectedIndex == 0)
            {
                txtCoord.Visible = true;
                txtAlt.Visible = true;
                btnCapture.Visible = true;
                domainUpDown1.Visible = false;
            }
            else
            {
                txtCoord.Visible = false;
                txtAlt.Visible = false;
                btnCapture.Visible = false;
                domainUpDown1.Visible = true;
            }
        }

        private void CtrlsEnableSet(bool enable)
        {
            dtcDropDown1.Enabled = enable;
            txtCoord.Enabled = enable;
            txtAlt.Enabled = enable;
            foreach (var stpEdCtrl in _STPEdControls) {
                if (stpEdCtrl != this) {
                    stpEdCtrl.Enabled = enable;
                }
            }
        }

        public void DisposeWptCapture()
        {
            if (_waypointCapture != null)
            {
                btnCapture.Text = "Capture";
                _waypointCapture.Dispose();
                _waypointCapture = null;

                CtrlsEnableSet(true);
            }
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (_waypointCapture == null)
            {
                btnCapture.Text = "Capturing...";
                CtrlsEnableSet(false);

                _waypointCapture = new WaypointCapture((Coordinate coord, string elevation) =>
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        txtCoord.Text = coord.ToDegreesMinutesSecondsHundredths();
                    }));
                });
            }
            else
            {
                DisposeWptCapture();
                txtAlt.Focus();
            }
        }
    }
}
