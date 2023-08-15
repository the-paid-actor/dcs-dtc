using DTC.Utilities;
using DTC.Models.DCS;
using DTC.Models.F15E.Waypoints;
using DTC.UI.Base;
using System;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.F15E
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
                _waypoint.AutoName();
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

        private void LoadWaypoint()
        {
            txtWptName.Text = _waypoint.Name;
            txtWptLatLong.Text = _waypoint.Latitude + " " + _waypoint.Longitude;
            txtWptElevation.Value = _waypoint.Elevation;
            chkTarget.Checked = _waypoint.Target;
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

            _waypoint.Name = txtWptName.Text;
            _waypoint.SetCoordinate(txtWptLatLong.Text);
            _waypoint.Elevation = (int)(txtWptElevation.Value ?? 0);
            _waypoint.Target = chkTarget.Checked;

            return true;
        }
    }
}