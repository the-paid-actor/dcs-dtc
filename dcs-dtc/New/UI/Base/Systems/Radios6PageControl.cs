using DTC.New.Presets.V2.Base.Systems;
using DTC.New.UI.Base.Pages;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    public partial class Radios6PageControl : AircraftSystemPage
    {
        public Radios6PageControl()
        {
            this.InitializeComponent();
        }

        public Radios6PageControl(AircraftPage parent, Radio6System radioSystem, string systemName, Radio6Conf? R1, Radio6Conf? R2, Radio6Conf? R3, Radio6Conf? R4, Radio6Conf? R5, Radio6Conf? R6) : base(parent, systemName)
        {
            InitializeComponent();
            radio1.Initialize(radioSystem.Radio, 10, R1, R2, R3, R4, R5, R6);
            radio1.PresetChanged += this.SavePreset;

        }

        protected virtual void ConfigurePresetList(DTCDropDown cbo, int radio)
        {
            throw new NotImplementedException();
        }

        protected virtual void ConfigureFreqTextBox(DTCRadioTextBox txt, int radio)
        {
            throw new NotImplementedException();
        }

        protected virtual string GetRadioName(int radio)
        {
            throw new NotImplementedException();
        }

        protected virtual int GetRadioPresetNumber(int radio)
        {
            throw new NotImplementedException();
        }

        protected virtual bool IsRadioGuardAvailable(int radio)
        {
            throw new NotImplementedException();
        }

        public override string GetPageTitle()
        {
            return "Radios";
        }

        private void radio2_Load(object sender, EventArgs e)
        {

        }
    }
}
