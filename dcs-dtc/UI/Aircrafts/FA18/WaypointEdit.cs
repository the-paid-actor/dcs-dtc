using DTC.Utilities;
using DTC.Models.DCS;
using DTC.Models.FA18.Waypoints;
using DTC.UI.Base;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace DTC.UI.Aircrafts.FA18
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
		private WaypointSystem _flightPlan;
		private Waypoint _waypoint = null;
		private WaypointCapture _waypointCapture;

		public WaypointEdit(WaypointSystem flightPlan, WaypointEditCallback callback)
		{
			InitializeComponent();

			foreach (var theater in Theater.Theaters)
			{
				foreach (var ab in theater.Airbases)
				{
					cboAirbases.Items.Add(new AirbaseComboBoxItem(theater.Name, ab.Name, ab.Latitude, ab.Longitude, ab.Elevation));
				}
			}

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
				txtWptName.Focus();
			}
			else
			{
				ResetFields();
			}
		}

		private void LoadWaypoint(Waypoint wpt)
		{
			txtWptName.Text = wpt.Name;
			TbCoordinates.Text = Waypoint.ToStringCoordinate(wpt.GetCoordinate());
			DisplayCurrentCoordinateDetail();
			txtWptElevation.Text = wpt.Elevation.ToString();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (ValidateFields())
			{
				var wpt = new Waypoint(0);
				wpt.Name = txtWptName.Text;
				wpt.SetCoordinate(GetCurrentCoordinate());
				wpt.Elevation = int.Parse(txtWptElevation.Text);

				if (_waypoint == null)
				{
					_flightPlan.Add(wpt);
					_callback(WaypointEditResult.Add, wpt);
					ResetFields();
				}
				else
				{
					_waypoint.Elevation = wpt.Elevation;
					_waypoint.Latitude = wpt.Latitude;
					_waypoint.Longitude = wpt.Longitude;
					_waypoint.Name = wpt.Name;
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
			if (ValidateElevation() && ValidateLatLong() && ValidateName())
			{
				return true;
			}
			return false;
		}

		private bool ValidateLatLong()
		{
			CoordinateSharp.Coordinate? coordinate = GetCurrentCoordinate();
			if (coordinate is null)
			{
				lblValidation.Text = "Invalid coordinate";
				TbCoordinates.Focus();
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

		private bool ValidateName()
		{
			if (txtWptName.Text == "")
			{
				lblValidation.Text = "Name required";
				txtWptName.Focus();
				return false;
			}

			return true;
		}

		private void ResetFields()
		{
			cboAirbases.SelectedIndex = -1;
			txtWptName.Text = "WPT " + (_flightPlan.Waypoints.Count + 1).ToString();
			TbCoordinates.Text = "";
			txtWptElevation.Text = "0";
			TbCoordinates.Focus();
		}

		private void cboAirbases_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboAirbases.SelectedIndex > -1)
			{
				var item = (AirbaseComboBoxItem)cboAirbases.SelectedItem;
				CoordinateSharp.Coordinate? coordinate = ToolsCoordinateSharp.FromString(item.Latitude + " " + item.Longitude);

				var wpt = new Waypoint(0);
				wpt.Name = item.Airbase;
				wpt.SetCoordinate(coordinate);
				wpt.Elevation = item.Elevation;
				LoadWaypoint(wpt);
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
						TbCoordinates.Text = Waypoint.ToStringCoordinate(coord.InternalCoordinateSharp);
						txtWptElevation.Text = elevation;
					}));
				});
			}
			else
			{
				DisposeWptCapture();
				DisplayCurrentCoordinateDetail();
			}
		}

		/// <summary>
		/// /////////////////////////
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>


		private CoordinateSharp.Coordinate? GetCurrentCoordinate()
		{
			return ToolsCoordinateSharp.FromString(TbCoordinates.Text);
		}

		private void DisplayCurrentCoordinateDetail()
		{
			CoordinateSharp.Coordinate? coordinate = GetCurrentCoordinate();
			LbCoordinatesDetail.Text = $"{ToolsCoordinateSharp.ToStringDDM(coordinate)}{Environment.NewLine}{ToolsCoordinateSharp.ToStringDMS(coordinate)}{Environment.NewLine}{ToolsCoordinateSharp.ToStringMGRS(coordinate)}";
		}

		private void ValidateCurrentCoordinate()
		{
			CoordinateSharp.Coordinate? coordinate = GetCurrentCoordinate();
			if (coordinate is not null)
				TbCoordinates.Text = Waypoint.ToStringCoordinate(coordinate);

			DisplayCurrentCoordinateDetail();
		}

		private void TbCoordinates_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ValidateCurrentCoordinate();
		}
	}
}
