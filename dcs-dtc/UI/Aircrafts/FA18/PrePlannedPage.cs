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
        private PrePlannedOverview _overview;
        private SteerPointEdit _stpEdit;
        public PrePlannedPage(AircraftPage parent, PrePlannedSystem pps) : base(parent)
        {
            InitializeComponent();
            _preplanned = pps;
            _edit = new PrePlannedEdit(callback);
			_edit.Visible = false;
            _overview = new PrePlannedOverview(_preplanned);
            _overview.Visible = false;
            _stpEdit = new SteerPointEdit(callback2);
            _stpEdit.Visible = false;

            prePlannedStationControl2.Connect(pps.Stations[2], _parent, _edit, _stpEdit);
            prePlannedStationControl3.Connect(pps.Stations[3], _parent, _edit, _stpEdit);
            prePlannedStationControl7.Connect(pps.Stations[7], _parent, _edit, _stpEdit);
            prePlannedStationControl8.Connect(pps.Stations[8], _parent, _edit, _stpEdit);

            cbSta5.Checked = pps.Station5ToConsider;

			this.Controls.Add(this._edit);
			this.Controls.Add(this._overview);
            this.Controls.Add(this._stpEdit);
        }

		public override string GetPageTitle()
		{
			return "Pre Planned";
		}

        private void callback(PrePlannedCoordinate coord, int station, int position)
        {
            _preplanned.Stations[station].PP[position] = coord;
            _parent.DataChangedCallback();
        }
        private void callback2()
        {
            _parent.DataChangedCallback();
        }

        private void cbSta5_CheckedChanged(object sender, EventArgs e)
        {
            _preplanned.Station5ToConsider = cbSta5.Checked;
            _parent.DataChangedCallback();
        }

        private void btnOverview_click(object sender, EventArgs e)
        {
            _overview.ShowDialog();
        }
    }
}
