using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTC.UI.Base;
using DTC.UI.CommonPages;
using DTC.Models.FA18.PrePlanned;

namespace DTC.UI.Aircrafts.FA18
{
    public partial class PrePlannedPage : AircraftSettingPage
    {
        private PrePlannedSystem _preplanned;
        private PrePlannedEdit _edit;
        public PrePlannedPage(AircraftPage parent, PrePlannedSystem pps) : base(parent)
        {
            InitializeComponent();
            _preplanned = pps;
            _edit = new PrePlannedEdit(callback);
			_edit.Visible = false;

            ddType2.Text = pps.Sta2.stationType.ToString();
            ddType3.Text = pps.Sta3.stationType.ToString();
            ddType7.Text = pps.Sta7.stationType.ToString();
            ddType8.Text = pps.Sta8.stationType.ToString();

            cbSta5.Checked = pps.Station5ToConsider;

            cb21.Checked = pps.Sta2.PP1.Enabled;
            cb22.Checked = pps.Sta2.PP2.Enabled;
            cb23.Checked = pps.Sta2.PP3.Enabled;
            cb24.Checked = pps.Sta2.PP4.Enabled;
            cb25.Checked = pps.Sta2.PP5.Enabled;
            cb31.Checked = pps.Sta3.PP1.Enabled;
            cb32.Checked = pps.Sta3.PP2.Enabled;
            cb33.Checked = pps.Sta3.PP3.Enabled;
            cb34.Checked = pps.Sta3.PP4.Enabled;
            cb35.Checked = pps.Sta3.PP5.Enabled;
            cb71.Checked = pps.Sta7.PP1.Enabled;
            cb72.Checked = pps.Sta7.PP2.Enabled;
            cb73.Checked = pps.Sta7.PP3.Enabled;
            cb74.Checked = pps.Sta7.PP4.Enabled;
            cb75.Checked = pps.Sta7.PP5.Enabled;
            cb81.Checked = pps.Sta8.PP1.Enabled;
            cb82.Checked = pps.Sta8.PP2.Enabled;
            cb83.Checked = pps.Sta8.PP3.Enabled;
            cb84.Checked = pps.Sta8.PP4.Enabled;
            cb85.Checked = pps.Sta8.PP5.Enabled;
			this.Controls.Add(this._edit);
        }

		public override string GetPageTitle()
		{
			return "Pre Planned";
		}

        private void cb21_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP1.CanBeEnabled) _preplanned.Sta2.PP1.Enabled = cb21.Checked;
            cb21.Checked = _preplanned.Sta2.PP1.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb22_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP2.CanBeEnabled) _preplanned.Sta2.PP2.Enabled = cb22.Checked;
            cb22.Checked = _preplanned.Sta2.PP2.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb23_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP3.CanBeEnabled) _preplanned.Sta2.PP3.Enabled = cb23.Checked;
            cb23.Checked = _preplanned.Sta2.PP3.Enabled;
            _parent.DataChangedCallback();
        }
        private void cb24_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP4.CanBeEnabled) _preplanned.Sta2.PP4.Enabled = cb24.Checked;
            cb24.Checked = _preplanned.Sta2.PP4.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb25_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP5.CanBeEnabled) _preplanned.Sta2.PP5.Enabled = cb25.Checked;
            cb25.Checked = _preplanned.Sta2.PP5.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb31_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP1.CanBeEnabled) _preplanned.Sta3.PP1.Enabled = cb31.Checked;
            cb31.Checked = _preplanned.Sta3.PP1.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb32_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP2.CanBeEnabled) _preplanned.Sta3.PP2.Enabled = cb32.Checked;
            cb32.Checked = _preplanned.Sta3.PP2.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb33_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP3.CanBeEnabled) _preplanned.Sta3.PP3.Enabled = cb33.Checked;
            cb33.Checked = _preplanned.Sta3.PP3.Enabled;
            _parent.DataChangedCallback();
        }
        private void cb34_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP4.CanBeEnabled) _preplanned.Sta3.PP4.Enabled = cb34.Checked;
            cb34.Checked = _preplanned.Sta3.PP4.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb35_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP5.CanBeEnabled) _preplanned.Sta3.PP5.Enabled = cb35.Checked;
            cb35.Checked = _preplanned.Sta3.PP5.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb71_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta7.PP1.CanBeEnabled) _preplanned.Sta7.PP1.Enabled = cb71.Checked;
            cb71.Checked = _preplanned.Sta7.PP1.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb72_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta7.PP2.CanBeEnabled) _preplanned.Sta7.PP2.Enabled = cb72.Checked;
            cb72.Checked = _preplanned.Sta7.PP2.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb73_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta7.PP3.CanBeEnabled) _preplanned.Sta7.PP3.Enabled = cb73.Checked;
            cb73.Checked = _preplanned.Sta7.PP3.Enabled;
            _parent.DataChangedCallback();
        }
        private void cb74_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta7.PP4.CanBeEnabled) _preplanned.Sta7.PP4.Enabled = cb74.Checked;
            cb74.Checked = _preplanned.Sta7.PP4.Enabled;
        }

        private void cb75_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta7.PP5.CanBeEnabled) _preplanned.Sta7.PP5.Enabled = cb75.Checked;
            cb75.Checked = _preplanned.Sta7.PP5.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb81_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP1.CanBeEnabled) _preplanned.Sta8.PP1.Enabled = cb81.Checked;
            cb81.Checked = _preplanned.Sta8.PP1.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb82_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP2.CanBeEnabled) _preplanned.Sta8.PP2.Enabled = cb82.Checked;
            cb82.Checked = _preplanned.Sta8.PP2.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb83_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP3.CanBeEnabled) _preplanned.Sta8.PP3.Enabled = cb83.Checked;
            cb83.Checked = _preplanned.Sta8.PP3.Enabled;
            _parent.DataChangedCallback();
        }
        private void cb84_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP4.CanBeEnabled) _preplanned.Sta8.PP4.Enabled = cb84.Checked;
            cb84.Checked = _preplanned.Sta8.PP4.Enabled;
            _parent.DataChangedCallback();
        }

        private void cb85_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP5.CanBeEnabled) _preplanned.Sta8.PP5.Enabled = cb85.Checked;
            cb85.Checked = _preplanned.Sta8.PP5.Enabled;
            _parent.DataChangedCallback();
        }


        private void callback(PrePlannedCoordinate coord, int station, int position)
        {
            switch (station)
            {
                case 2:
                    _preplanned.Sta2 = EditPosAtStation(_preplanned.Sta2, coord, position);
                    break;
                case 3:
                    _preplanned.Sta3 = EditPosAtStation(_preplanned.Sta3, coord, position);
                    break;
                case 7:
                    _preplanned.Sta7 = EditPosAtStation(_preplanned.Sta7, coord, position);
                    break;
                case 8:
                    _preplanned.Sta8 = EditPosAtStation(_preplanned.Sta8, coord, position);
                    break;
            }
            _parent.DataChangedCallback();
        }

        private PrePlannedStation EditPosAtStation(PrePlannedStation station, PrePlannedCoordinate coord, int position)
        {
            var _station = station;
            switch (position)
            {
                case 1:
                    _station.PP1 = coord;
                    break;
                case 2:
                    _station.PP2 = coord;
                    break;
                case 3:
                    _station.PP3 = coord;
                    break;
                case 4:
                    _station.PP4 = coord;
                    break;
                case 5:
                    _station.PP5 = coord;
                    break;
            }
            return _station;
        }

        private void sta2PP1_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta2.PP1, 2, 1);   
        }

        private void sta2PP2_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta2.PP2, 2, 2);   
        }

        private void sta2PP3_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta2.PP3, 2, 3);   
        }

        private void sta2PP4_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta2.PP4, 2, 4);   
        }

        private void sta2PP5_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta2.PP5, 2, 5);   
        }

        private void sta3PP1_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP1, 3, 1);   
        }

        private void sta3PP2_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP2, 3, 2);   
        }

        private void sta3PP3_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP3, 3, 3);   
        }

        private void sta3PP4_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP4, 3, 4);   
        }

        private void sta3PP5_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP5, 3, 5);   
        }

        private void sta7PP1_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP1, 7, 1);   
        }

        private void sta7PP2_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP2, 7, 2);   
        }

        private void sta7PP3_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP3, 7, 3);   
        }

        private void sta7PP4_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP4, 7, 4);   
        }

        private void sta7PP5_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP5, 7, 5);   
        }

        private void sta8PP1_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP1, 8, 1);   
        }

        private void sta8PP2_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP2, 8, 2);   
        }

        private void sta8PP3_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP3, 8, 3);   
        }

        private void sta8PP4_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP4, 8, 4);   
        }

        private void sta8PP5_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP5, 8, 5);   
        }

        private void ddType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddType2.SelectedItem.ToString() == "Other") {
                cb21.Checked = false;
                cb21.Enabled = false;
                cb22.Checked = false;
                cb22.Enabled = false;
                cb23.Checked = false;
                cb23.Enabled = false;
                cb24.Checked = false;
                cb24.Enabled = false;
                cb25.Checked = false;
                cb25.Enabled = false;
                _preplanned.Sta2.stationType = _preplanned.Sta2.fromString(ddType2.SelectedItem.ToString());   
            } else {
                cb21.Enabled = true;
                cb22.Enabled = true;
                cb23.Enabled = true;
                cb24.Enabled = true;
                cb25.Enabled = true;
                _preplanned.Sta2.stationType = _preplanned.Sta2.fromString(ddType2.SelectedItem.ToString());   
            }
            _parent.DataChangedCallback();
        }

        private void ddType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddType3.SelectedItem.ToString() == "Other") {
                cb31.Checked = false;
                cb31.Enabled = false;
                cb32.Checked = false;
                cb32.Enabled = false;
                cb33.Checked = false;
                cb33.Enabled = false;
                cb34.Checked = false;
                cb34.Enabled = false;
                cb35.Checked = false;
                cb35.Enabled = false;
                _preplanned.Sta3.stationType = _preplanned.Sta3.fromString(ddType3.SelectedItem.ToString());   
            } else {
                cb31.Enabled = true;
                cb32.Enabled = true;
                cb33.Enabled = true;
                cb34.Enabled = true;
                cb35.Enabled = true;
                _preplanned.Sta3.stationType = _preplanned.Sta3.fromString(ddType3.SelectedItem.ToString());   
            }
            _parent.DataChangedCallback();
        }

        private void ddType7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddType7.SelectedItem.ToString() == "Other") {
                cb71.Checked = false;
                cb71.Enabled = false;
                cb72.Checked = false;
                cb72.Enabled = false;
                cb73.Checked = false;
                cb73.Enabled = false;
                cb74.Checked = false;
                cb74.Enabled = false;
                cb75.Checked = false;
                cb75.Enabled = false;
                _preplanned.Sta7.stationType = _preplanned.Sta7.fromString(ddType7.SelectedItem.ToString());   
            } else {
                cb71.Enabled = true;
                cb72.Enabled = true;
                cb73.Enabled = true;
                cb74.Enabled = true;
                cb75.Enabled = true;
                _preplanned.Sta7.stationType = _preplanned.Sta7.fromString(ddType7.SelectedItem.ToString());   
            }
            _parent.DataChangedCallback();
        }

        private void ddType8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddType8.SelectedItem.ToString() == "Other") {
                cb81.Checked = false;
                cb81.Enabled = false;
                cb82.Checked = false;
                cb82.Enabled = false;
                cb83.Checked = false;
                cb83.Enabled = false;
                cb84.Checked = false;
                cb84.Enabled = false;
                cb85.Checked = false;
                cb85.Enabled = false;
                _preplanned.Sta8.stationType = _preplanned.Sta8.fromString(ddType8.SelectedItem.ToString());   
            } else {
                cb81.Enabled = true;
                cb82.Enabled = true;
                cb83.Enabled = true;
                cb84.Enabled = true;
                cb85.Enabled = true;
                _preplanned.Sta8.stationType = _preplanned.Sta8.fromString(ddType8.SelectedItem.ToString());   
            }
            _parent.DataChangedCallback();
        }

        private void cbSta5_CheckedChanged(object sender, EventArgs e)
        {
            _preplanned.Station5ToConsider = cbSta5.Checked;
        }
    }
}
