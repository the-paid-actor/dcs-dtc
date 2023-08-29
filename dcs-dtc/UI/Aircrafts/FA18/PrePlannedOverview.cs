using DTC.Models.FA18.PrePlanned;
using DTC.UI.Base.Controls;

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

            for (int i = 1; i <= 5; i++)
            {
                this.Controls.Add(DTCLabel.Make(station.PP[i].Lat.Replace(" ", ""), left, top, colWidth, rowHeight));
                top += padding + rowHeight;
                this.Controls.Add(DTCLabel.Make(station.PP[i].Lon.Replace(" ", ""), left, top, colWidth, rowHeight));
                top += padding + rowHeight;
                this.Controls.Add(DTCLabel.Make(station.PP[i].Elev.ToString() + " ft", left, top, colWidth, rowHeight));
                left += padding + colWidth;
                top -= 2 * (padding + rowHeight);
            }
        }


		public void ShowDialog()
		{
			this.Visible = true;
			this.BringToFront();

            var top = 2 * (padding + rowHeight);
            foreach (PrePlannedStation sta in _prePlanned.Stations.Values)
			{
                DisplayStation(top, sta);
                top += 4 * (padding + rowHeight) + padding;
            }
		}

		private void lblClose_Click(object sender, EventArgs e)
		{
			Visible = false;
		}
    }
}
