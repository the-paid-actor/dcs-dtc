using DTC.Models;
using DTC.Models.F16;
using DTC.UI.CommonPages;
using System;

namespace DTC.UI.Aircrafts.F16
{
	public partial class UploadToJetPage : AircraftSettingPage
	{
		private F16Upload _jetInterface;
		private readonly F16Configuration _cfg;

		public UploadToJetPage(AircraftPage parent, F16Configuration cfg) : base(parent)
		{
			InitializeComponent();
			_jetInterface = new F16Upload(cfg);

			txtWaypointStart.LostFocus += TxtWaypointStart_LostFocus;
			txtWaypointEnd.LostFocus += TxtWaypointEnd_LostFocus;
			txtWaypointStart.Text = cfg.Waypoints.SteerpointStart.ToString();
			txtWaypointEnd.Text = cfg.Waypoints.SteerpointEnd.ToString();
			_cfg = cfg;
		}

		public override string GetPageTitle()
		{
			return "Upload to Jet";
		}

		private void TxtWaypointEnd_LostFocus(object sender, EventArgs e)
		{
			if (int.TryParse(txtWaypointEnd.Text, out int n))
			{
				_cfg.Waypoints.SetSteerpointEnd(n);
				_parent.DataChangedCallback();
			}

			txtWaypointEnd.Text = _cfg.Waypoints.SteerpointEnd.ToString();
		}

		private void TxtWaypointStart_LostFocus(object sender, EventArgs e)
		{
			if (int.TryParse(txtWaypointStart.Text, out int n))
			{
				_cfg.Waypoints.SetSteerpointStart(n);
				_parent.DataChangedCallback();
			}

			txtWaypointStart.Text = _cfg.Waypoints.SteerpointStart.ToString();
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
