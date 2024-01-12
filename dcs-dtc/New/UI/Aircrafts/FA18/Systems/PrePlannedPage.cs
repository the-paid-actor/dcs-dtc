using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Aircrafts.FA18.Systems.Controls;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    public partial class PrePlannedPage : AircraftSystemPage
    {
        private PrePlannedSystem prePlanned;
        private PrePlannedEdit _edit;
        private PrePlannedOverview _overview;
        private SteerPointEdit _stpEdit;

        public PrePlannedPage(FA18Page parent, PrePlannedSystem pps) : base(parent)
        {
            InitializeComponent();
            prePlanned = pps;
            _edit = new PrePlannedEdit(callback);
            _edit.Visible = false;
            _stpEdit = new SteerPointEdit(callback2);
            _stpEdit.Visible = false;

            RefreshStations();

            this.Controls.Add(this._edit);
            this.Controls.Add(this._stpEdit);
        }

        public void RefreshStations()
        {
            prePlannedStationControl2.Connect(prePlanned.Stations[2], base.parent, _edit, _stpEdit);
            prePlannedStationControl3.Connect(prePlanned.Stations[3], base.parent, _edit, _stpEdit);
            prePlannedStationControl7.Connect(prePlanned.Stations[7], base.parent, _edit, _stpEdit);
            prePlannedStationControl8.Connect(prePlanned.Stations[8], base.parent, _edit, _stpEdit);
        }

        public override string GetPageTitle()
        {
            return "Pre Planned";
        }

        private void callback(PrePlannedCoordinate coord, int station, int position)
        {
            prePlanned.Stations[station].PP[position] = coord;
            this.SavePreset();
            RefreshStations();
        }

        private void callback2()
        {
            this.SavePreset();
        }

        private void btnOverview_click(object sender, EventArgs e)
        {
            if (_overview != null)
            {
                this.Controls.Remove(_overview);
                _overview.Dispose();
            }
            _overview = new PrePlannedOverview(prePlanned);
            this.Controls.Add(_overview);
            _overview.ShowDialog();
        }

        internal void ResetAllPP()
        {
            foreach (var kv in prePlanned.Stations)
            {
                foreach (var kvPP in kv.Value.PP)
                {
                    kvPP.Value.Reset();
                }
            }
            this.SavePreset();
            this.RefreshStations();
        }

        private void btnResetAllPP_Click(object sender, EventArgs e)
        {
            this.ResetAllPP();
        }
    }
}
