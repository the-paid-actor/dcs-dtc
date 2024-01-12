using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.FA18.Systems.Controls
{
    public partial class SteerPointEditControl : UserControl
    {
        private PrePlannedSteerpoint _stp;
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

        public void Connect(PrePlannedSteerpoint stp, SteerPointEditControl[] STPEdControls)
        {
            this._stp = stp;
            this._STPEdControls = STPEdControls;
            cbEnable.Checked = stp.Enabled;
            dtcDropDown1.SelectedIndex = stp.UseCoordinate ? 0 : 1;
            if (stp.UseCoordinate)
            {
                var c = Coordinate.FromString(stp.Lat, stp.Lon);
                txtCoord.Coordinate = c;
            }
            else
            {
                txtCoord.Coordinate = null;
            }
            txtAlt.Text = String.Format("{0:00000}", stp.Elev);
            domainUpDown1.SelectedIndex = stp.WaypointNumber;
        }

        public void StoreValues()
        {
            _stp.Enabled = cbEnable.Checked;

            if (dtcDropDown1.SelectedIndex == 0)
            {
                _stp.UseCoordinate = true;

                if (txtCoord.Coordinate != null)
                {
                    var c = txtCoord.Coordinate.ToHornetPreplannedFormat();
                    _stp.Lat = c.Lat;
                    _stp.Lon = c.Lon;

                    if (int.TryParse(txtAlt.Text, out int n))
                        _stp.Elev = n;

                    _stp.WaypointNumber = 0;
                }
                else
                {
                    _stp.Enabled = false;
                }
            }
            else
            {
                _stp.UseCoordinate = false;
                _stp.WaypointNumber = domainUpDown1.SelectedIndex;

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

        public bool ValidateFields(out string error)
        {
            if (cbEnable.Checked == false)
            {
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
            if (!txtCoord.Valid)
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
                domainUpDown1.Visible = false;
            }
            else
            {
                txtCoord.Visible = false;
                txtAlt.Visible = false;
                domainUpDown1.Visible = true;
            }
        }

        private void CtrlsEnableSet(bool enable)
        {
            dtcDropDown1.Enabled = enable;
            txtCoord.Enabled = enable;
            txtAlt.Enabled = enable;
            foreach (var stpEdCtrl in _STPEdControls)
            {
                if (stpEdCtrl != this)
                {
                    stpEdCtrl.Enabled = enable;
                }
            }
        }
    }
}
