using DTC.Models;
using DTC.Models.Base;
using DTC.Models.DCS;
using DTC.Models.AH64.Waypoints;
using DTC.UI.Base;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.AH64
{
    public partial class WaypointEdit : UserControl
    {
        public enum WaypointEditResult
        {
            Add = 1,
            SaveAndClose = 2,
            Close = 3
        }

        public delegate void WaypointEditCallback(WaypointEditResult result, Waypoint wpt);

        private readonly WaypointEditCallback _callback;
        private WaypointSystem _flightPlan;
        private Waypoint _waypoint = null;

        public WaypointEdit(WaypointSystem flightPlan, WaypointEditCallback callback)
        {
            InitializeComponent();
            _callback = callback;
            _flightPlan = flightPlan;
        }
        public void ShowDialog(Waypoint wpt = null)
        {
            this.Visible = true;
            this.BringToFront();
            _waypoint = wpt;

            if (wpt != null)
            {
                LoadWaypoint(wpt);
                txtWptType.Focus();
            }
            else
            {
                ResetFields();
            }
        }
        private void LoadWaypoint(Waypoint wpt)
        {
            txtWptType.Text = wpt.Type;
            txtWptIdent.Text = wpt.Ident;
            txtWptFree.Text = wpt.Free;
            txtWptMGRS.Text = wpt.Mgrs;
            txtWptElevation.Text = wpt.Elevation.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                var wpt = Waypoint.FromStrings(txtWptType.Text, txtWptIdent.Text, txtWptFree.Text,txtWptMGRS.Text, txtWptElevation.Text);

                if (_waypoint == null)
                {
                    _flightPlan.Add(wpt);
                    _callback(WaypointEditResult.Add, wpt);
                    ResetFields();
                }
                else
                {
                    _waypoint.Elevation = wpt.Elevation;
                    _waypoint.Mgrs = wpt.Mgrs;
                    _waypoint.Free = wpt.Free;
                    _waypoint.Ident = wpt.Ident;
                    _waypoint.Type = wpt.Type;
                    _callback(WaypointEditResult.SaveAndClose, _waypoint);
                    CloseDialog();
                }
            }
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            _callback(WaypointEditResult.Close, null);
            CloseDialog();
        }

        private void CloseDialog()
        {
            _waypoint = null;

            Visible = false;
            ResetFields();
        }

        private bool ValidateFields()
        {
            lblValidation.Text = "";
            if (ValidateElevation() && ValidateMGRS() && ValidateIdent() && ValidateType())
            {
                return true;
            }
            return false;
        }

        private bool ValidateType()
        {
            if (txtWptType.Text != "WP" && txtWptType.Text != "TG" && txtWptType.Text != "HZ" && txtWptType.Text != "CM")
            {
                lblValidation.Text = "Invalid type";
                txtWptType.Focus();
                return false;
            }

            return true;
        }
        private bool ValidateMGRS()
        {
            if (!Waypoint.IsMGRSValid(txtWptMGRS.Text))
            {
                lblValidation.Text = "Invalid MGRS";
                txtWptMGRS.Focus();
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

        private bool ValidateIdent()
        {
            if (txtWptIdent.Text == "" || txtWptIdent.Text.Length > 2)
            {
                lblValidation.Text = "Invalid Ident";
                txtWptIdent.Focus();
                return false;
            }

            return true;
        }

        private void ResetFields()
        {
            txtWptType.Text = "WP";
            txtWptIdent.Text = "WP";
            txtWptFree.Text = "WP1";
            txtWptElevation.Text = "0";
            txtWptMGRS.Focus();
        }
    }
}
