using DTC.Models;
using DTC.Models.F16;
using DTC.UI.Base;
using System;

namespace DTC.UI.F16
{
	public partial class UploadToJetPage : FeaturePage
	{
		private F16Upload _jetInterface;
		private int _wptStart = 1;
		private int _wptEnd = 20;

		public UploadToJetPage(F16Configuration cfg)
		{
			InitializeComponent();
			_jetInterface = new F16Upload(cfg);
            txtWaypointStart.Text = string.IsNullOrEmpty(txtWaypointStart.Text) ? @"2" : txtWaypointStart.Text;
			txtWaypointStart.LostFocus += TxtWaypointStart_LostFocus;
            txtWaypointEnd.Text = _jetInterface.Cfg.Waypoints != null ? (_jetInterface.Cfg.Waypoints.Count()+1).ToString() : "20";
			txtWaypointEnd.LostFocus += TxtWaypointEnd_LostFocus;
		}

		private void TxtWaypointEnd_LostFocus(object sender, EventArgs e)
		{
			if (int.TryParse(txtWaypointEnd.Text, out int n))
			{
				if (n > _wptStart && n <= 127)
				{
					_wptEnd = n;
				}
			}

			txtWaypointEnd.Text = _wptEnd.ToString();
		}

		private void TxtWaypointStart_LostFocus(object sender, EventArgs e)
		{
			if (int.TryParse(txtWaypointStart.Text, out int n))
			{
				if (n >= 1 && n < _wptEnd)
				{
					_wptStart = n;
				}
			}

			txtWaypointStart.Text = _wptStart.ToString();
		}

		private void chkWaypoints_CheckedChanged(object sender, EventArgs e)
		{
			txtWaypointStart.Enabled = chkWaypoints.Checked;
			txtWaypointEnd.Enabled = chkWaypoints.Checked;
		}

		private void btnUpload_Click(object sender, EventArgs e)
		{
			var wptStart = int.Parse(txtWaypointStart.Text);
			var wptEnd = int.Parse(txtWaypointEnd.Text);
			_jetInterface.Load(chkWaypoints.Checked, wptStart, wptEnd, chkRadios.Checked, chkCMS.Checked, chkMFDs.Checked);
		}
	}
}
