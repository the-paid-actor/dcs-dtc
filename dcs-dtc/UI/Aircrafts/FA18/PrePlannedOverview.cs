using DTC.Models;
using DTC.Models.Base;
using DTC.Models.DCS;
using DTC.Models.FA18.PrePlanned;
using DTC.UI.Base.Controls;
using DTC.UI.Base;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.FA18
{
	public partial class PrePlannedOverview : UserControl
	{

		private PrePlannedSystem _prePlanned;
            private int padding = 5;
            private int rowHeight = 15;
            private int colWidth = 110;

		public PrePlannedOverview(PrePlannedSystem pp)
		{
			_prePlanned = pp;
			InitializeComponent();
		}

		public void DisplayStation(int top, PrePlannedStation station)
        {
            var left = padding;
            this.Controls.Add(DTCLabel.Make("Station " + station.stationNumber, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP1.Lat, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP1.Lon, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP1.Elev.ToString() + " ft", left, top, colWidth, rowHeight));
            left += padding + colWidth;
            top -= 2*(padding + rowHeight);
            this.Controls.Add(DTCLabel.Make(station.PP2.Lat, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP2.Lon, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP2.Elev.ToString() + " ft", left, top, colWidth, rowHeight));
            left += padding + colWidth;
            top -= 2*(padding + rowHeight);
            this.Controls.Add(DTCLabel.Make(station.PP3.Lat, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP3.Lon, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP3.Elev.ToString() + " ft", left, top, colWidth, rowHeight));
            left += padding + colWidth;
            top -= 2*(padding + rowHeight);
            this.Controls.Add(DTCLabel.Make(station.PP4.Lat, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP4.Lon, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP4.Elev.ToString() + " ft", left, top, colWidth, rowHeight));
            left += padding + colWidth;
            top -= 2*(padding + rowHeight);
            this.Controls.Add(DTCLabel.Make(station.PP5.Lat, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP5.Lon, left, top, colWidth, rowHeight));
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make(station.PP5.Elev.ToString() + " ft", left, top, colWidth, rowHeight));
            left += padding + colWidth;
        }


		public void ShowDialog()
		{
			this.Visible = true;
			this.BringToFront();

            var top = 2*(padding + rowHeight);
			DisplayStation(top, _prePlanned.Sta2);
            top += 4*(padding + rowHeight) + padding;
			DisplayStation(top, _prePlanned.Sta3);
            top += 4*(padding + rowHeight) + padding;
			DisplayStation(top, _prePlanned.Sta7);
            top += 4*(padding + rowHeight) + padding;
			DisplayStation(top, _prePlanned.Sta8);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
		}

		private void lblClose_Click(object sender, EventArgs e)
		{
			CloseDialog();
		}

		private void CloseDialog()
		{
			DisposeWptCapture();

			Visible = false;
		}

		private void DisposeWptCapture()
		{
		}

	}
}
