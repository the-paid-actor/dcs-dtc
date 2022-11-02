using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTC.Models.FA18.PrePlanned;
using DTC.UI.Aircrafts.FA18.CompositeControls;
using DTC.UI.Base;
using DTC.UI.Base.Controls;
using static DTC.UI.Aircrafts.FA18.PrePlannedEdit;

namespace DTC.UI.Aircrafts.FA18
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
            foreach (var stpEdCtrl in stpEditCtrls) {
                stpEdCtrl.DisposeWptCapture();
            }
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
            this.lblTitle.Text = String.Format("Set Steerpoint (station {0})", station.stationNumber);
            this.Visible = true;
            this.BringToFront();
            
            _station = station;

            for (int i = 0; i < 5; i++)
                stpEditCtrls[i].Connect(_station.Steerpoints[i], stpEditCtrls);
        }
    }
}
