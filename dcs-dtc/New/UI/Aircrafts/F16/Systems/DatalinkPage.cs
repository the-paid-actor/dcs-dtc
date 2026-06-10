using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class DatalinkPage : AircraftSystemPage
    {
        private DatalinkSystem datalink;

        public DatalinkSystem Datalink { get => datalink; set => datalink = value; }

        public void ForceSavePresets()
        {
            this.SavePreset();
        }
        public void RefreshDatalinkConfig()
        {
            //this is invoked only via 476th DTC so we always want to set callsign
            chkFlightLead.Checked = this.datalink.FlightLead??false;
           
            if (!string.IsNullOrEmpty(datalink.OwnCallsign) && datalink.OwnCallsign.Length == 4)
            {
                pnlOwnCallsign.Enabled = true; //we should always know the callsign of the flight and want to set it
                cboCallsign1.SelectedItem = datalink.OwnCallsign[0].ToString().ToUpper();
                cboCallsign2.SelectedItem = datalink.OwnCallsign[1].ToString().ToUpper();
                cboCallsign3.SelectedItem = datalink.OwnCallsign[2].ToString();
                cboCallsign4.SelectedItem = datalink.OwnCallsign[3].ToString();
            }
            if (datalink.Members != null)
            {
                txtSTN1.Text = datalink.Members[0] == "-1" ? null : datalink.Members[0];
                txtSTN2.Text = datalink.Members[1] == "-1" ? null : datalink.Members[1];
                txtSTN3.Text = datalink.Members[2] == "-1" ? null : datalink.Members[2];
                txtSTN4.Text = datalink.Members[3] == "-1" ? null : datalink.Members[3];
                txtSTN5.Text = datalink.Members[4] == "-1" ? null : datalink.Members[4];
                txtSTN6.Text = datalink.Members[5] == "-1" ? null : datalink.Members[5];
                txtSTN7.Text = datalink.Members[6] == "-1" ? null : datalink.Members[6];
                txtSTN8.Text = datalink.Members[7] == "-1" ? null : datalink.Members[7];
            }
            if (datalink.OwnshipIndex.HasValue)
            {
                if (datalink.OwnshipIndex == 1) radOwn1.Checked = true;
                if (datalink.OwnshipIndex == 2) radOwn2.Checked = true;
                if (datalink.OwnshipIndex == 3) radOwn3.Checked = true;
                if (datalink.OwnshipIndex == 4) radOwn4.Checked = true;
                if (datalink.OwnshipIndex == 5) radOwn5.Checked = true;
                if (datalink.OwnshipIndex == 6) radOwn6.Checked = true;
                if (datalink.OwnshipIndex == 7) radOwn7.Checked = true;
                if (datalink.OwnshipIndex == 8) radOwn8.Checked = true;
            }
        }
        public DatalinkPage(F16Page parent) : base(parent, nameof(parent.Configuration.Datalink))
        {
            this.datalink = parent.Configuration.Datalink;

            InitializeComponent();

            chkOwnCallsign.Checked = datalink.EnableOwnCallsign ?? false;
            pnlOwnCallsign.Enabled = chkOwnCallsign.Checked;
            if (!string.IsNullOrEmpty(datalink.OwnCallsign) && datalink.OwnCallsign.Length == 4)
            {
                cboCallsign1.SelectedItem = datalink.OwnCallsign[0].ToString();
                cboCallsign2.SelectedItem = datalink.OwnCallsign[1].ToString();
                cboCallsign3.SelectedItem = datalink.OwnCallsign[2].ToString();
                cboCallsign4.SelectedItem = datalink.OwnCallsign[3].ToString();
            }
            chkFlightLead.Checked = datalink.FlightLead ?? false;

            chkFlightMembers.Checked = datalink.EnableMembers ?? false;
            pnlMembers.Enabled = chkFlightMembers.Checked;
            if (datalink.OwnshipIndex.HasValue)
            {
                if (datalink.OwnshipIndex == 1) radOwn1.Checked = true;
                if (datalink.OwnshipIndex == 2) radOwn2.Checked = true;
                if (datalink.OwnshipIndex == 3) radOwn3.Checked = true;
                if (datalink.OwnshipIndex == 4) radOwn4.Checked = true;
                if (datalink.OwnshipIndex == 5) radOwn5.Checked = true;
                if (datalink.OwnshipIndex == 6) radOwn6.Checked = true;
                if (datalink.OwnshipIndex == 7) radOwn7.Checked = true;
                if (datalink.OwnshipIndex == 8) radOwn8.Checked = true;
            }

            if (datalink.Members != null)
            {
                txtSTN1.Text = datalink.Members[0] == "-1" ? null : datalink.Members[0];
                txtSTN2.Text = datalink.Members[1] == "-1" ? null : datalink.Members[1];
                txtSTN3.Text = datalink.Members[2] == "-1" ? null : datalink.Members[2];
                txtSTN4.Text = datalink.Members[3] == "-1" ? null : datalink.Members[3];
                txtSTN5.Text = datalink.Members[4] == "-1" ? null : datalink.Members[4];
                txtSTN6.Text = datalink.Members[5] == "-1" ? null : datalink.Members[5];
                txtSTN7.Text = datalink.Members[6] == "-1" ? null : datalink.Members[6];
                txtSTN8.Text = datalink.Members[7] == "-1" ? null : datalink.Members[7];
            }

            if (datalink.TDOAMembers != null)
            {
                chkTDOA1.Checked = datalink.TDOAMembers[0];
                chkTDOA2.Checked = datalink.TDOAMembers[1];
                chkTDOA3.Checked = datalink.TDOAMembers[2];
                chkTDOA4.Checked = datalink.TDOAMembers[3];
                chkTDOA5.Checked = datalink.TDOAMembers[4];
                chkTDOA6.Checked = datalink.TDOAMembers[5];
                chkTDOA7.Checked = datalink.TDOAMembers[6];
                chkTDOA8.Checked = datalink.TDOAMembers[7];
            }

            if (datalink.DatalinkMode != null)
            {
                if (datalink.DatalinkMode == DatalinkMode.OFF) cboDatalinkMode.SelectedIndex = 1;
                if (datalink.DatalinkMode == DatalinkMode.TNDL) cboDatalinkMode.SelectedIndex = 2;
                if (datalink.DatalinkMode == DatalinkMode.SMDL) cboDatalinkMode.SelectedIndex = 3;
            }

            chkOwnCallsign.CheckedChanged += (s, e) =>
            {
                datalink.EnableOwnCallsign = chkOwnCallsign.Checked;
                pnlOwnCallsign.Enabled = chkOwnCallsign.Checked;
                this.SavePreset();
            };

            cboCallsign1.SelectedValueChanged += (s, e) => CallsignLeterChanged1();
            cboCallsign2.SelectedValueChanged += (s, e) => CallsignLeterChanged2();
            cboCallsign3.SelectedValueChanged += (s, e) => CallsignLeterChanged3();
            cboCallsign4.SelectedValueChanged += (s, e) => CallsignLeterChanged4();

            chkFlightLead.CheckedChanged += (s, e) =>
            {
                datalink.FlightLead = chkFlightLead.Checked;
                this.SavePreset();
            };

            chkFlightMembers.CheckedChanged += (s, e) =>
            {
                datalink.EnableMembers = chkFlightMembers.Checked;
                pnlMembers.Enabled = chkFlightMembers.Checked;
                this.SavePreset();
            };

            radOwn1.CheckedChanged += (s, e) => OwnshipIndexChanged(1, radOwn1);
            radOwn2.CheckedChanged += (s, e) => OwnshipIndexChanged(2, radOwn2);
            radOwn3.CheckedChanged += (s, e) => OwnshipIndexChanged(3, radOwn3);
            radOwn4.CheckedChanged += (s, e) => OwnshipIndexChanged(4, radOwn4);
            radOwn5.CheckedChanged += (s, e) => OwnshipIndexChanged(5, radOwn5);
            radOwn6.CheckedChanged += (s, e) => OwnshipIndexChanged(6, radOwn6);
            radOwn7.CheckedChanged += (s, e) => OwnshipIndexChanged(7, radOwn7);
            radOwn8.CheckedChanged += (s, e) => OwnshipIndexChanged(8, radOwn8);

            txtSTN1.TextBoxChanged += (txt) => MembersChanged(1, txt);
            txtSTN2.TextBoxChanged += (txt) => MembersChanged(2, txt);
            txtSTN3.TextBoxChanged += (txt) => MembersChanged(3, txt);
            txtSTN4.TextBoxChanged += (txt) => MembersChanged(4, txt);
            txtSTN5.TextBoxChanged += (txt) => MembersChanged(5, txt);
            txtSTN6.TextBoxChanged += (txt) => MembersChanged(6, txt);
            txtSTN7.TextBoxChanged += (txt) => MembersChanged(7, txt);
            txtSTN8.TextBoxChanged += (txt) => MembersChanged(8, txt);

            chkTDOA1.CheckedChanged += (s, e) => TDOAMembersChanged(1, chkTDOA1);
            chkTDOA2.CheckedChanged += (s, e) => TDOAMembersChanged(2, chkTDOA2);
            chkTDOA3.CheckedChanged += (s, e) => TDOAMembersChanged(3, chkTDOA3);
            chkTDOA4.CheckedChanged += (s, e) => TDOAMembersChanged(4, chkTDOA4);
            chkTDOA5.CheckedChanged += (s, e) => TDOAMembersChanged(5, chkTDOA5);
            chkTDOA6.CheckedChanged += (s, e) => TDOAMembersChanged(6, chkTDOA6);
            chkTDOA7.CheckedChanged += (s, e) => TDOAMembersChanged(7, chkTDOA7);
            chkTDOA8.CheckedChanged += (s, e) => TDOAMembersChanged(8, chkTDOA8);

            cboDatalinkMode.SelectedValueChanged += (s, e) =>
            {
                if (cboDatalinkMode.SelectedIndex == 0) datalink.DatalinkMode = null;
                if (cboDatalinkMode.SelectedIndex == 1) datalink.DatalinkMode = DatalinkMode.OFF;
                if (cboDatalinkMode.SelectedIndex == 2) datalink.DatalinkMode = DatalinkMode.TNDL;
                if (cboDatalinkMode.SelectedIndex == 3) datalink.DatalinkMode = DatalinkMode.SMDL;
                this.SavePreset();
            };
        }

        private void TDOAMembersChanged(int v, CheckBox chkTDOA7)
        {
            if (datalink.TDOAMembers == null)
            {
                datalink.TDOAMembers = new bool[8];
            }
            datalink.TDOAMembers[v - 1] = chkTDOA7.Checked;
            this.SavePreset();
        }

        private void MembersChanged(int v, DTCNumericTextBox txt)
        {
            if (datalink.Members == null)
            {
                datalink.Members = new string[8];
            }
            datalink.Members[v - 1] = txt.Text ?? "-1";
            this.SavePreset();
        }

        private void OwnshipIndexChanged(int index, RadioButton rad)
        {
            if (rad.Checked)
            {
                datalink.OwnshipIndex = index;
            }
            this.SavePreset();
        }

        private void CallsignChanged()
        {
            if (cboCallsign1.SelectedItem != null && cboCallsign2.SelectedItem != null && cboCallsign3.SelectedItem != null && cboCallsign4.SelectedItem != null)
            {
                var callsign = cboCallsign1.SelectedItem.ToString() + cboCallsign2.SelectedItem.ToString() + cboCallsign3.SelectedItem.ToString() + cboCallsign4.SelectedItem.ToString();
                this.datalink.OwnCallsign = callsign;
                this.SavePreset();
            }
        }
        private void CallsignLeterChanged1()
        {
            if (cboCallsign1.SelectedItem != null && cboCallsign2.SelectedItem != null && cboCallsign3.SelectedItem != null && cboCallsign4.SelectedItem != null)
            {
                var callsign = cboCallsign1.SelectedItem.ToString() + datalink.OwnCallsign[1].ToString() + datalink.OwnCallsign[2].ToString() + datalink.OwnCallsign[3].ToString();// DateRangeEventArgs=ta.SelectedItem.ToString() + cboCallsign3.SelectedItem.ToString() + cboCallsign4.SelectedItem.ToString();
                this.datalink.OwnCallsign = callsign;
                this.SavePreset();
            }
        }
        private void CallsignLeterChanged2()
        {
            if (cboCallsign1.SelectedItem != null && cboCallsign2.SelectedItem != null && cboCallsign3.SelectedItem != null && cboCallsign4.SelectedItem != null)
            {
                var callsign = datalink.OwnCallsign[0].ToString() + cboCallsign2.SelectedItem.ToString() + datalink.OwnCallsign[2].ToString() + datalink.OwnCallsign[3].ToString();
                this.datalink.OwnCallsign = callsign;
                this.SavePreset();
            }
        }

        private void CallsignLeterChanged3()
        {
            if (cboCallsign1.SelectedItem != null && cboCallsign2.SelectedItem != null && cboCallsign3.SelectedItem != null && cboCallsign4.SelectedItem != null)
            {
                var callsign = datalink.OwnCallsign[0].ToString() + datalink.OwnCallsign[1].ToString() + cboCallsign3.SelectedItem.ToString() + datalink.OwnCallsign[3].ToString();
                this.datalink.OwnCallsign = callsign;
                this.SavePreset();
            }
        }
        private void CallsignLeterChanged4()
        {
            if (cboCallsign1.SelectedItem != null && cboCallsign2.SelectedItem != null && cboCallsign3.SelectedItem != null && cboCallsign4.SelectedItem != null)
            {
                var callsign = datalink.OwnCallsign[0].ToString() + datalink.OwnCallsign[1].ToString() + datalink.OwnCallsign[2].ToString() + cboCallsign4.SelectedItem.ToString() ;
                this.datalink.OwnCallsign = callsign;
                this.SavePreset();
            }
        }

        public override string GetPageTitle()
        {
            return "Datalink";
        }
    }
}
