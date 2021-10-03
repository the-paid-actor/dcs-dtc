using DTC.Models.F16.Waypoints;
using DTC.UI.Base;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.F16
{
	public partial class WaypointsPage : FeaturePage
	{
		private WaypointSystem _waypoints;
		private WaypointEdit _wptEditDialog;

		public WaypointsPage(WaypointSystem wpts, DataChanged dataChangedCallback) : base(dataChangedCallback)
		{
			InitializeComponent();

			_waypoints = wpts;
			_wptEditDialog = new WaypointEdit(_waypoints, this.WptDialogEditCallback);
			_wptEditDialog.Visible = false;
			this.Controls.Add(this._wptEditDialog);

			RefreshList();
		}

		private void WptDialogEditCallback(WaypointEdit.WaypointEditResult result, Waypoint wpt)
		{
			if (result != WaypointEdit.WaypointEditResult.Close) { 
				DataChangedCallback();
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
			((MainForm)this.ParentForm).ToggleEnabled();
			dgWaypoints.Enabled = !dgWaypoints.Enabled;
			btnAdd.Enabled = !btnAdd.Enabled;
			btnDelete.Enabled = dgWaypoints.Enabled && dgWaypoints.SelectedRows.Count > 0;
		}

		private void RefreshList()
		{
			dgWaypoints.SetWaypoints(_waypoints);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgWaypoints.SelectedRows)
			{
				var wpt = (Waypoint)row.DataBoundItem;
				_waypoints.Remove(wpt);
			}

			DataChangedCallback();
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
