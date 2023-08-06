using DTC.Models.Base;
using DTC.Models.DCS;
using DTC.Models.F16.Waypoints;
using DTC.UI.Base;
using System;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.F16
{
    public partial class WaypointEdit : UserControl
    {
        public enum WaypointEditResult
        {
            Add = 1,
            SaveAndClose = 2,
            Close = 3
        }

        public delegate void WaypointEditCallback();

        private class AirbaseComboBoxItem
        {
            public string Theatre;
            public string Airbase;
            public string Latitude;
            public string Longitude;
            public int Elevation;

            public AirbaseComboBoxItem(string theatre, string airbase, string latitude, string longitude, int elevation)
            {
                Theatre = theatre;
                Airbase = airbase;
                Latitude = latitude;
                Longitude = longitude;
                Elevation = elevation;
            }

            public override string ToString()
            {
                return $"{Theatre} - {Airbase}";
            }
        }

        private readonly WaypointEditCallback _callback;
        private WaypointSystem _waypoints;
        private Waypoint _waypoint = null;
        private WaypointCapture _waypointCapture;
        private bool _addMode = false;

        public WaypointEdit(WaypointSystem waypoints, WaypointEditCallback callback)
        {
            InitializeComponent();
            LoadAirbases();

            _callback = callback;
            _waypoints = waypoints;
        }

        private void LoadAirbases()
        {
            foreach (var theater in Theater.Theaters)
            {
                foreach (var ab in theater.Airbases)
                {
                    cboAirbases.Items.Add(new AirbaseComboBoxItem(theater.Name, ab.Name, ab.Latitude, ab.Longitude, ab.Elevation));
                }
            }
        }

        public void ShowDialog(Waypoint wpt = null)
        {
            this.Visible = true;
            this.BringToFront();
            cboAirbases.SelectedIndex = -1;
            lblValidation.Text = "";

            if (wpt == null)
            {
                _addMode = true;
                _waypoint = new Waypoint(_waypoints.Waypoints.Count + 1);
                _waypoint.Name = "WPT " + _waypoint.Sequence.ToString();
            }
            else
            {
                _addMode = false;
                _waypoint = wpt;
            }

            LoadWaypoint();
            txtWptName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!SaveWaypoint()) return;

            if (_addMode)
            {
                _waypoints.Add(_waypoint);
                _callback();
                ShowDialog();
            }
            else
            {
                _callback();
                CloseDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void CloseDialog()
        {
            _waypoint = null;
            DisposeWptCapture();

            Visible = false;
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

        private void cboAirbases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAirbases.SelectedIndex > -1)
            {
                var item = (AirbaseComboBoxItem)cboAirbases.SelectedItem;
                _waypoint.Name = item.Airbase;
                _waypoint.SetCoordinate(item.Latitude + " " + item.Longitude);
                _waypoint.Elevation = item.Elevation;
                LoadWaypoint();
            }
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
                        txtWptLatLong.Text = coord.ToDegreesMinutesThousandths();
                        txtWptElevation.Value = decimal.Parse(elevation);
                    }));
                });
            }
            else
            {
                DisposeWptCapture();
            }
        }

        private void chkUseOA_CheckedChanged(object sender, EventArgs e)
        {
            pnlOA.Visible = chkUseOA.Checked;
            UpdateOAVIPVRPPanels();
        }

        private void chkUseVIP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseVIP.Checked)
            {
                if (!ClearVIPVRPOtherWpts())
                {
                    chkUseVIP.Checked = false;
                    return;
                }
            }

            if (chkUseVIP.Checked && chkUseVRP.Checked)
            {
                chkUseVRP.Checked = false;
            }

            UpdateOAVIPVRPPanels();
        }

        private void chkUseVRP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseVRP.Checked)
            {
                if (!ClearVIPVRPOtherWpts())
                {
                    chkUseVRP.Checked = false;
                    return;
                }
            }

            if (chkUseVRP.Checked && chkUseVIP.Checked)
            {
                chkUseVIP.Checked = false;
            }

            UpdateOAVIPVRPPanels();
        }

        private void UpdateOAVIPVRPPanels()
        {
            pnlVIP.Visible = chkUseVIP.Checked;
            pnlVRP.Visible = chkUseVRP.Checked;

            var topVIPPanel = pnlOA.Top;
            var topVRPPanel = pnlOA.Top;

            if (pnlOA.Visible)
            {
                topVIPPanel += pnlOA.Height;
                topVRPPanel += pnlOA.Height;
            }

            pnlVIP.Top = topVIPPanel;
            pnlVRP.Top = topVRPPanel;
        }

        private bool ClearVIPVRPOtherWpts()
        {
            foreach (var wpt in _waypoints.Waypoints)
            {
                if (wpt == _waypoint) continue;

                if (wpt.UseVIP || wpt.UseVRP)
                {
                    if (DTCMessageBox.ShowQuestion("Only one steerpoint can be designated as VIP or VRP.\nThis will clear VIP/VRP from other steerpoints. Do you want to proceed?"))
                    {
                        wpt.UseVIP = false;
                        wpt.UseVRP = false;
                        _callback();
                        break;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void LoadWaypoint()
        {
            txtWptName.Text = _waypoint.Name;
            txtWptLatLong.Text = _waypoint.Latitude + " " + _waypoint.Longitude;
            txtWptElevation.Value = _waypoint.Elevation;
            txtTimeOverSteerpoint.Text = _waypoint.TimeOverSteerpoint;

            chkUseOA.Checked = _waypoint.UseOA;
            if (_waypoint.UseOA)
            {
                txtOA1Range.Value = _waypoint.OffsetAimpoint1.Range;
                txtOA1Bearing.Value = _waypoint.OffsetAimpoint1.Bearing;
                txtOA1Elev.Value = _waypoint.OffsetAimpoint1.Elevation;

                txtOA2Range.Value = _waypoint.OffsetAimpoint2.Range;
                txtOA2Bearing.Value = _waypoint.OffsetAimpoint2.Bearing;
                txtOA2Elev.Value = _waypoint.OffsetAimpoint2.Elevation;
            }

            chkUseVIP.Checked = _waypoint.UseVIP;

            if (_waypoint.UseVIP)
            {
                txtVIPtoTGTRange.Value = _waypoint.VIPtoTGT.Range;
                txtVIPtoTGTBearing.Value = _waypoint.VIPtoTGT.Bearing;
                txtVIPtoTGTElev.Value = _waypoint.VIPtoTGT.Elevation;

                txtVIPtoPUPRange.Value = _waypoint.VIPtoPUP.Range;
                txtVIPtoPUPBearing.Value = _waypoint.VIPtoPUP.Bearing;
                txtVIPtoPUPElev.Value = _waypoint.VIPtoPUP.Elevation;
            }

            chkUseVRP.Checked = _waypoint.UseVRP;

            if (_waypoint.UseVRP)
            {
                txtTGTtoVRPRange.Value = _waypoint.TGTtoVRP.Range;
                txtTGTtoVRPBearing.Value = _waypoint.TGTtoVRP.Bearing;
                txtTGTtoVRPElev.Value = _waypoint.TGTtoVRP.Elevation;

                txtTGTtoPUPRange.Value = _waypoint.TGTtoPUP.Range;
                txtTGTtoPUPBearing.Value = _waypoint.TGTtoPUP.Bearing;
                txtTGTtoPUPElev.Value = _waypoint.TGTtoPUP.Elevation;
            }

            UpdateOAVIPVRPPanels();
        }

        private bool SaveWaypoint()
        {
            if (txtWptName.Text == "")
            {
                lblValidation.Text = "Name required";
                txtWptName.Focus();
                return false;
            }

            if (!txtWptLatLong.MaskFull || !Waypoint.IsCoordinateValid(txtWptLatLong.Text))
            {
                lblValidation.Text = "Invalid coordinate";
                txtWptLatLong.Focus();
                return false;
            }

            if (!txtTimeOverSteerpoint.MaskFull || !Util.IsValidTime(txtTimeOverSteerpoint.Text))
            {
                lblValidation.Text = "Invalid time-over-steerpoint";
                txtTimeOverSteerpoint.Focus();
                return false;
            }

            _waypoint.Name = txtWptName.Text;
            _waypoint.SetCoordinate(txtWptLatLong.Text);
            _waypoint.Elevation = (int)(txtWptElevation.Value ?? 0);
            _waypoint.TimeOverSteerpoint = txtTimeOverSteerpoint.Text;

            _waypoint.UseOA = chkUseOA.Checked;

            if (_waypoint.UseOA)
            {
                if (_waypoint.OffsetAimpoint1 == null) _waypoint.OffsetAimpoint1 = new Offset();
                _waypoint.OffsetAimpoint1.Range = txtOA1Range.Value ?? 0;
                _waypoint.OffsetAimpoint1.Bearing = txtOA1Bearing.Value ?? 0;
                _waypoint.OffsetAimpoint1.Elevation = txtOA1Elev.Value ?? 0;

                if (_waypoint.OffsetAimpoint2 == null) _waypoint.OffsetAimpoint2 = new Offset();
                _waypoint.OffsetAimpoint2.Range = txtOA2Range.Value ?? 0;
                _waypoint.OffsetAimpoint2.Bearing = txtOA2Bearing.Value ?? 0;
                _waypoint.OffsetAimpoint2.Elevation = txtOA2Elev.Value ?? 0;
            }
            else
            {
                _waypoint.OffsetAimpoint1 = null;
                _waypoint.OffsetAimpoint2 = null;
            }

            _waypoint.UseVIP = chkUseVIP.Checked;

            if (_waypoint.UseVIP)
            {
                if (_waypoint.VIPtoTGT == null) _waypoint.VIPtoTGT = new Offset();
                _waypoint.VIPtoTGT.Range = txtVIPtoTGTRange.Value ?? 0;
                _waypoint.VIPtoTGT.Bearing = txtVIPtoTGTBearing.Value ?? 0;
                _waypoint.VIPtoTGT.Elevation = txtVIPtoTGTElev.Value ?? 0;

                if (_waypoint.VIPtoPUP == null) _waypoint.VIPtoPUP = new Offset();
                _waypoint.VIPtoPUP.Range = txtVIPtoPUPRange.Value ?? 0;
                _waypoint.VIPtoPUP.Bearing = txtVIPtoPUPBearing.Value ?? 0;
                _waypoint.VIPtoPUP.Elevation = txtVIPtoPUPElev.Value ?? 0;
            }
            else
            {
                _waypoint.VIPtoTGT = null;
                _waypoint.VIPtoPUP = null;
            }

            _waypoint.UseVRP = chkUseVRP.Checked;

            if (_waypoint.UseVRP)
            {
                if (_waypoint.TGTtoVRP == null) _waypoint.TGTtoVRP = new Offset();
                _waypoint.TGTtoVRP.Range = txtTGTtoVRPRange.Value ?? 0;
                _waypoint.TGTtoVRP.Bearing = txtTGTtoVRPBearing.Value ?? 0;
                _waypoint.TGTtoVRP.Elevation = txtTGTtoVRPElev.Value ?? 0;

                if (_waypoint.TGTtoPUP == null) _waypoint.TGTtoPUP = new Offset();
                _waypoint.TGTtoPUP.Range = txtTGTtoPUPRange.Value ?? 0;
                _waypoint.TGTtoPUP.Bearing = txtTGTtoPUPBearing.Value ?? 0;
                _waypoint.TGTtoPUP.Elevation = txtTGTtoPUPElev.Value ?? 0;
            }
            else
            {
                _waypoint.TGTtoVRP = null;
                _waypoint.TGTtoPUP = null;
            }

            return true;
        }
    }
}