using DTC.New.Presets.V2.Base.Systems;
using DTC.New.UI.Base.Pages;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    public partial class RadiosPageControl : AircraftSystemPage
    {
        public RadiosPageControl()
        {
            this.InitializeComponent();
        }

        public RadiosPageControl(AircraftPage parent, RadioSystem radioSystem, string systemName) : base(parent, systemName)
        {
            InitializeComponent();

            radio1.ConfigureFreqTextBox += (txt) => this.ConfigureFreqTextBox(txt, 1);
            radio2.ConfigureFreqTextBox += (txt) => this.ConfigureFreqTextBox(txt, 2);

            radio1.ConfigurePresetList += (cbo) => this.ConfigurePresetList(cbo, 1);
            radio2.ConfigurePresetList += (cbo) => this.ConfigurePresetList(cbo, 2);

            radio1.Initialize(radioSystem.Radio1, GetRadioName(1), IsRadioGuardAvailable(1), GetRadioPresetNumber(1));
            radio2.Initialize(radioSystem.Radio2, GetRadioName(2), IsRadioGuardAvailable(2), GetRadioPresetNumber(2));

            radio1.PresetChanged += this.SavePreset;
            radio2.PresetChanged += this.SavePreset;
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
    }
}
