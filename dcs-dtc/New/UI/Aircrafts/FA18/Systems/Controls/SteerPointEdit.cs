using DTC.New.Presets.V2.Aircrafts.FA18.Systems;

namespace DTC.New.UI.Aircrafts.FA18.Systems.Controls
{
    public partial class SteerPointEdit : UserControl
    {
        public delegate void SteerpointEditCallback();

        SteerPointEditControl[] stpEditCtrls = new SteerPointEditControl[5];
        private PrePlannedStation _station;
        private readonly SteerpointEditCallback _callback;

        public SteerPointEdit(SteerpointEditCallback callback)
        {
            InitializeComponent();
            _callback = callback;

            stpEditCtrls[0] = steerPointEditControl1;
            stpEditCtrls[1] = steerPointEditControl2;
            stpEditCtrls[2] = steerPointEditControl3;
            stpEditCtrls[3] = steerPointEditControl4;
            stpEditCtrls[4] = steerPointEditControl5;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields()) {
                for (int i = 0; i < 5; i++) {
                    var stpEd = stpEditCtrls[i];
                    stpEd.StoreValues();
                }

                _callback();
                CloseDialog();
            }
        }

        private bool ValidateFields() {
            for (int i = 0; i < 5; i++)
            {
                string error;
                if (!stpEditCtrls[i].ValidateFields(out error)) {
                    lblValidation.Text = String.Format("STP {0}: {1}", i + 1, error);
                    return false;
                }
                
            }
            return true;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void CloseDialog()
        {
            Visible = false;
            ResetFields();
        }

        private void ResetFields()
        {
            foreach (var stpEdit in stpEditCtrls)
                stpEdit.ResetFields();
        }

        internal void ShowDialog(PrePlannedStation station)
        {
            this.lblTitle.Text = String.Format("Set Steerpoint (station {0})", station.Number);
            this.Visible = true;
            this.BringToFront();
            
            _station = station;

            for (int i = 0; i < 5; i++)
                stpEditCtrls[i].Connect(_station.Steerpoints[i], stpEditCtrls);
        }
    }
}
