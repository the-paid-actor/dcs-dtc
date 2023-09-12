using DTC.Models.FA18.Waypoints;
using DTC.UI.Base;
using DTC.UI.CommonPages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.FA18
{
	public partial class WaypointsPage : AircraftSettingPage
	{
		private WaypointSystem _waypoints;
		private WaypointEdit _wptEditDialog;

		public WaypointsPage(AircraftPage parent, WaypointSystem wpts) : base(parent)
		{
			InitializeComponent();

			_waypoints = wpts;
			_wptEditDialog = new WaypointEdit(_waypoints, this.WptDialogEditCallback);
			_wptEditDialog.Visible = false;
			dgWaypoints.ReorderCallback = Reorder;
			this.Controls.Add(this._wptEditDialog);

			RefreshList();
		}

		private void Reorder(int indexFrom, int indexTo)
		{
			_waypoints.Reorder(indexFrom, indexTo);
			RefreshList();
		}

		public override string GetPageTitle()
		{
			return "Waypoints";
		}

		private void WptDialogEditCallback(WaypointEdit.WaypointEditResult result, Waypoint wpt)
		{
			if (result != WaypointEdit.WaypointEditResult.Close) {
				_parent.DataChangedCallback();
				this.RefreshList();
			}

			if (result != WaypointEdit.WaypointEditResult.Add)
			{
				this.ToggleEnabled();
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			ShowWptDialog();
		}

		private void ShowWptDialog(Waypoint wpt = null)
		{
			this.ToggleEnabled();

			this._wptEditDialog.Location = new Point(
				(this.Size.Width - this._wptEditDialog.Size.Width) / 2,
				(this.Size.Height - this._wptEditDialog.Size.Height) / 2);

			_wptEditDialog.ShowDialog(wpt);
			this.RefreshList();
		}

		private void ToggleEnabled()
		{
			_parent.ToggleEnabled();
			dgWaypoints.Enabled = !dgWaypoints.Enabled;
			btnAdd.Enabled = !btnAdd.Enabled;
			btnDelete.Enabled = dgWaypoints.Enabled && dgWaypoints.SelectedRows.Count > 0;
		}

		public void RefreshList()
		{
			dgWaypoints.RefreshList(_waypoints.Waypoints);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			var wptsToDelete = new List<Waypoint>();

			foreach (DataGridViewRow row in dgWaypoints.SelectedRows)
			{
				var wpt = (Waypoint)row.DataBoundItem;
				wptsToDelete.Add(wpt);
			}

			foreach(var wpt in wptsToDelete)
			{
				_waypoints.Remove(wpt);
			}

			_parent.DataChangedCallback();
			RefreshList();
			dgWaypoints.Focus();
		}

		private void btnCapture_Click(object sender, EventArgs e)
		{
			var cap = new WaypointCaptureCrosshair();
			cap.Show();
		}

		private void dgWaypoints_SelectionChanged(object sender, EventArgs e)
		{
			btnDelete.Enabled = dgWaypoints.Enabled && dgWaypoints.SelectedRows.Count > 0;
		}

		private void dgWaypoints_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			Console.WriteLine("error");
		}

		private void dgWaypoints_DoubleClick(object sender, EventArgs e)
		{
			if (dgWaypoints.SelectedRows.Count > 0)
			{
				ShowWptDialog((Waypoint)dgWaypoints.SelectedRows[0].DataBoundItem);
			}
		}
	}
}
