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
        }

        private void cb22_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP2.CanBeEnabled) _preplanned.Sta2.PP2.Enabled = cb22.Checked;
            cb22.Checked = _preplanned.Sta2.PP2.Enabled;
        }

        private void cb23_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP3.CanBeEnabled) _preplanned.Sta2.PP3.Enabled = cb23.Checked;
            cb23.Checked = _preplanned.Sta2.PP3.Enabled;
        }
        private void cb24_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP4.CanBeEnabled) _preplanned.Sta2.PP4.Enabled = cb24.Checked;
            cb24.Checked = _preplanned.Sta2.PP4.Enabled;
        }

        private void cb25_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP5.CanBeEnabled) _preplanned.Sta2.PP5.Enabled = cb25.Checked;
            cb25.Checked = _preplanned.Sta2.PP5.Enabled;
        }

        private void cb31_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta2.PP1.CanBeEnabled) _preplanned.Sta2.PP1.Enabled = cb21.Checked;
            cb21.Checked = _preplanned.Sta2.PP1.Enabled;
        }

        private void cb32_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP2.CanBeEnabled) _preplanned.Sta3.PP2.Enabled = cb32.Checked;
            cb32.Checked = _preplanned.Sta3.PP2.Enabled;
        }

        private void cb33_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP3.CanBeEnabled) _preplanned.Sta3.PP3.Enabled = cb33.Checked;
            cb33.Checked = _preplanned.Sta3.PP3.Enabled;
        }
        private void cb34_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP4.CanBeEnabled) _preplanned.Sta3.PP4.Enabled = cb34.Checked;
            cb34.Checked = _preplanned.Sta3.PP4.Enabled;
        }

        private void cb35_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta3.PP5.CanBeEnabled) _preplanned.Sta3.PP5.Enabled = cb35.Checked;
            cb35.Checked = _preplanned.Sta3.PP5.Enabled;
        }

        private void cb71_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta7.PP1.CanBeEnabled) _preplanned.Sta7.PP1.Enabled = cb71.Checked;
            cb71.Checked = _preplanned.Sta7.PP1.Enabled;
        }

        private void cb72_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta7.PP2.CanBeEnabled) _preplanned.Sta7.PP2.Enabled = cb72.Checked;
            cb72.Checked = _preplanned.Sta7.PP2.Enabled;
        }

        private void cb73_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta7.PP3.CanBeEnabled) _preplanned.Sta7.PP3.Enabled = cb73.Checked;
            cb73.Checked = _preplanned.Sta7.PP3.Enabled;
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
        }

        private void cb81_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP1.CanBeEnabled) _preplanned.Sta8.PP1.Enabled = cb81.Checked;
            cb81.Checked = _preplanned.Sta8.PP1.Enabled;
        }

        private void cb82_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP2.CanBeEnabled) _preplanned.Sta8.PP2.Enabled = cb82.Checked;
            cb82.Checked = _preplanned.Sta8.PP2.Enabled;
        }

        private void cb83_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP3.CanBeEnabled) _preplanned.Sta8.PP3.Enabled = cb83.Checked;
            cb83.Checked = _preplanned.Sta8.PP3.Enabled;
        }
        private void cb84_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP4.CanBeEnabled) _preplanned.Sta8.PP4.Enabled = cb84.Checked;
            cb84.Checked = _preplanned.Sta8.PP4.Enabled;
        }

        private void cb85_Changed(object sender, EventArgs e)
        {
            if(_preplanned.Sta8.PP5.CanBeEnabled) _preplanned.Sta8.PP5.Enabled = cb85.Checked;
            cb85.Checked = _preplanned.Sta8.PP5.Enabled;
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
            _edit.ShowDialog(_preplanned.Sta3.PP1, 2, 1);   
        }

        private void sta3PP2_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP2, 2, 2);   
        }

        private void sta3PP3_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP3, 2, 3);   
        }

        private void sta3PP4_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP4, 2, 4);   
        }

        private void sta3PP5_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta3.PP5, 2, 5);   
        }

        private void sta7PP1_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP1, 2, 1);   
        }

        private void sta7PP2_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP2, 2, 2);   
        }

        private void sta7PP3_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP3, 2, 3);   
        }

        private void sta7PP4_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP4, 2, 4);   
        }

        private void sta7PP5_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta7.PP5, 2, 5);   
        }

        private void sta8PP1_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP1, 2, 1);   
        }

        private void sta8PP2_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP2, 2, 2);   
        }

        private void sta8PP3_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP3, 2, 3);   
        }

        private void sta8PP4_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP4, 2, 4);   
        }

        private void sta8PP5_Click(object sender, EventArgs e)
        {
            _edit.ShowDialog(_preplanned.Sta8.PP5, 2, 5);   
        }
    }
}
