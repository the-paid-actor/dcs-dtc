using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Pages;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.FA18.Systems.Controls
{
    public partial class PrePlannedStationControl : UserControl
    {
        private PrePlannedStation station;
        private AircraftPage _parent;
        private PrePlannedEdit ppEditDialog;
        SteerPointEdit stpEditDialog;
        private Dictionary<int, CheckBox> checkBoxPP;
        private Dictionary<int, Button> buttonPP;

        public PrePlannedStationControl()
        {
            InitializeComponent();

            checkBoxPP = new()
            {
                { 1, cbPP1 },
                { 2, cbPP2 },
                { 3, cbPP3 },
                { 4, cbPP4 },
                { 5, cbPP5 },
                { 6, cbPP6 }
            };

            buttonPP = new()
            {
                { 1, staPP1 },
                { 2, staPP2 },
                { 3, staPP3 },
                { 4, staPP4 },
                { 5, staPP5 },
                { 6, staPP6 }
            };

            for (int i = 1; i <= 6; i++)
                checkBoxPP[i].Tag = i;

            staPP1.Tag = 1;
            staPP2.Tag = 2;
            staPP3.Tag = 3;
            staPP4.Tag = 4;
            staPP5.Tag = 5;
            staPP6.Tag = 6;

            var storeTypes = Enum.GetValues<StationType>();
            foreach (var type in storeTypes)
                ddType.Items.Add(PrePlannedSystem.StoreTypeToString(type));
        }

        public void Connect(PrePlannedStation station, AircraftPage _parent, PrePlannedEdit _edit, SteerPointEdit _stpEdit)
        {
            this.station = station;
            this.label1.Text = "Station " + station.Number;
            this._parent = _parent;
            this.ppEditDialog = _edit;
            this.stpEditDialog = _stpEdit;

            ddType.Text = PrePlannedSystem.StoreTypeToString(station.Type);

            for (int i = 1; i <= 6; i++)
            {
                var pp = station.PP[i];
                checkBoxPP[i].Checked = pp.Enabled;
                buttonPP[i].Font = new Font(buttonPP[i].Font, FontStyle.Regular);
                toolTip.SetToolTip(buttonPP[i], "");

                if (pp.CanBeEnabled())
                {
                    toolTip.SetToolTip(buttonPP[i], $"{pp.Lat}\n{pp.Lon}\n{pp.Elev} ft\n{pp.Notes}");
                    buttonPP[i].Font = new Font(buttonPP[i].Font, FontStyle.Bold);
                }
            }
        }

        private void cbn_CheckedChanged(object sender, EventArgs e)
        {
            int pp_number = (int)(((CheckBox)sender).Tag);

            if (station.PP[pp_number].CanBeEnabled()) station.PP[pp_number].Enabled = checkBoxPP[pp_number].Checked;
            checkBoxPP[pp_number].Checked = station.PP[pp_number].Enabled;
            _parent.SavePreset();
        }

        private void staPPn_Click(object sender, EventArgs e)
        {
            int pp_number = (int)(((DTCButton)sender).Tag);
            ppEditDialog.ShowDialog(station.PP[pp_number], station.Number, pp_number);
        }

        private void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddType.SelectedItem.ToString() == PrePlannedSystem.StoreTypeToString(StationType.EMPTY))
            {
                foreach (var cb in checkBoxPP.Values)
                {
                    cb.Checked = false;
                    cb.Enabled = false;
                }
            }
            else
            {
                foreach (var cb in checkBoxPP.Values)
                {
                    cb.Enabled = true;
                }
            }

            station.Type = PrePlannedSystem.StoreTypeFromString(ddType.SelectedItem.ToString());

            btnSTP.Visible = (ddType.SelectedItem.ToString() == PrePlannedSystem.StoreTypeToString(StationType.SLAMER));

            _parent.SavePreset();
        }

        private void btnSTP_Click(object sender, EventArgs e)
        {
            stpEditDialog.ShowDialog(station);
        }
    }
}
