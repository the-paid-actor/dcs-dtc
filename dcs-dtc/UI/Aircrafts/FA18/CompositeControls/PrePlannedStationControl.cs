using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTC.Models.FA18.PrePlanned;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;

namespace DTC.UI.Aircrafts.FA18.CompositeControls
{
    public partial class PrePlannedStationControl : UserControl
    {
        private PrePlannedStation station;
        private AircraftPage _parent;
        private PrePlannedEdit _edit;
        SteerPointEdit _stpEdit;
        private Dictionary<int, CheckBox> cbPP;

        public PrePlannedStationControl()
        {
            InitializeComponent();

            cbPP = new Dictionary<int, CheckBox>
            {
                { 1, cbPP1 },
                { 2, cbPP2 },
                { 3, cbPP3 },
                { 4, cbPP4 },
                { 5, cbPP5 }
            };

            for (int i = 1; i <= 5; i++)
                cbPP[i].Tag = i;

            staPP1.Tag = 1;
            staPP2.Tag = 2;
            staPP3.Tag = 3;
            staPP4.Tag = 4;
            staPP5.Tag = 5;
        }

        public void Connect(PrePlannedStation station, AircraftPage _parent, PrePlannedEdit _edit, SteerPointEdit _stpEdit)
        {
            this.station = station;
            this.label1.Text = "Station " + station.stationNumber;
            this._parent = _parent;
            this._edit = _edit;
            this._stpEdit = _stpEdit;

            ddType.Text = PrePlannedStation.TypeToString(station.stationType);

            for (int i = 1; i <= 5; i++)
                cbPP[i].Checked = station.PP[i].Enabled;
        }

        private void cbn_CheckedChanged(object sender, EventArgs e)
        {
            int pp_number = (int)(((CheckBox)sender).Tag);

            if (station.PP[pp_number].CanBeEnabled) station.PP[pp_number].Enabled = cbPP[pp_number].Checked;
            cbPP[pp_number].Checked = station.PP[pp_number].Enabled;
            _parent.DataChangedCallback();
        }

        private void staPPn_Click(object sender, EventArgs e)
        {
            int pp_number = (int)(((DTCButton)sender).Tag);
            _edit.ShowDialog(station.PP[pp_number], station.stationNumber, pp_number);
        }

        private void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddType.SelectedItem.ToString() == "Other")
            {
                foreach (var cb in cbPP.Values)
                {
                    cb.Checked = false;
                    cb.Enabled = false;
                }
                station.stationType = station.FromString(ddType.SelectedItem.ToString());
            }
            else
            {
                foreach (var cb in cbPP.Values)
                    cb.Enabled = true;
                station.stationType = station.FromString(ddType.SelectedItem.ToString());
            }

            btnSTP.Visible = (ddType.SelectedItem.ToString() == "SLAMER");

            _parent.DataChangedCallback();
        }

        private void btnSTP_Click(object sender, EventArgs e)
        {
            _stpEdit.ShowDialog(station);
        }
    }
}
