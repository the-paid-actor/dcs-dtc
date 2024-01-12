using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.FA18.Systems.Controls
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
            Controls.Add(DTCLabel.Make("Station " + station.Number, left, top, colWidth, rowHeight));
            top += padding + rowHeight;

            foreach (var kv in station.PP)
            {
                var pp = kv.Value;
                if (pp.Lat == null || pp.Lon == null || pp.Elev == null) continue;
                Controls.Add(DTCLabel.Make(pp.Lat.Replace(" ", ""), left, top, colWidth, rowHeight));
                top += padding + rowHeight;
                Controls.Add(DTCLabel.Make(pp.Lon.Replace(" ", ""), left, top, colWidth, rowHeight));
                top += padding + rowHeight;
                Controls.Add(DTCLabel.Make(pp.Elev.ToString() + " ft", left, top, colWidth, rowHeight));
                left += padding + colWidth;
                top -= 2 * (padding + rowHeight);
            }
        }

        public void ShowDialog()
        {
            Visible = true;
            BringToFront();

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
