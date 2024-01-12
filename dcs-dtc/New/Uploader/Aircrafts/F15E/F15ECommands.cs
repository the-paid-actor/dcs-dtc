using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F15E
{
    public partial class F15EUploader
    {
        private Condition IsStrDifferent(string device, string str)
        {
            return new Condition($"IsStrDifferent2('{device}', '{str}')");
        }

        private Condition DisplayNotInMainMenu(string deviceName)
        {
            return new Condition($"DisplayNotInMainMenu('{deviceName}')");
        }

        private Condition SmartStationSelected(string deviceName, string station)
        {
            return new Condition($"SmartStationSelected('{deviceName}','{station}')");
        }

        private Condition IsProgBoxed(string deviceName)
        {
            return new Condition($"IsProgBoxed('{deviceName}')");
        }

        private Condition NoDisplaysProgrammed(string deviceName)
        {
            return new Condition($"NoDisplaysProgrammed('{deviceName}')");
        }

        private CustomCommand GoToFrontCockpit()
        {
            return new CustomCommand("GoToFrontCockpit()");
        }

        private CustomCommand GoToRearCockpit()
        {
            return new CustomCommand("GoToRearCockpit()");
        }

        private CustomCommand SaveCockpitFrontRearState()
        {
            return new CustomCommand("SaveCockpitFrontRearState()");
        }

        private CustomCommand RestoreCockpitFrontRearState()
        {
            return new CustomCommand("RestoreCockpitFrontRearState()");
        }

        private CustomCommand TestUFC(string device, string str)
        {
            return new CustomCommand($"TestUFC('{device}', '{str}')");
        }

        private Condition IsInFrontCockpit()
        {
            return new Condition("IsInFrontCockpit()");
        }

        private Condition IsInRearCockpit()
        {
            return new Condition("IsInRearCockpit()");
        }

        private Condition IsOutsideCockpit()
        {
            return new Condition("IsOutsideCockpit()");
        }

        private Condition IsRadioPresetOrFreqSelected(string radio, string mode)
        {
            return new Condition($"IsRadioPresetOrFreqSelected('{radio}','{mode}')");
        }

        private Condition IsRadioGuardEnabledDisabled(string radio, string mode)
        {
            return new Condition($"IsRadioGuardEnabledDisabled('{radio}','{mode}')");
        }

        private Condition IsTACANBand(string ufc, string band)
        {
            return new Condition($"IsTACANBand('{band}', '{ufc}')");
        }

        private Condition IsTACANOff(string ufc)
        {
            return new Condition($"IsTACANOff('{ufc}')");
        }
    }
}
