using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.Globalization;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader
{
    private Condition InRadioChannel(int radio, string channel)
    {
        return new Condition($"InRadioChannel({radio}, '{channel}')");
    }

    private Condition IsRadioGuardDisabled()
    {
        return new Condition($"IsRadioGuardDisabled()");
    }

    private Condition MapBoxed()
    {
        return new Condition($"MapBoxed()");
    }

    private Condition HMDOn()
    {
        return new Condition($"HMDOn()");
    }

    private Condition FLIRAvailable()
    {
        return new Condition($"FLIRAvailable()");
    }

    private Condition FLIROn()
    {
        return new Condition($"FLIROn()");
    }

    private Condition HMDMode(string mode)
    {
        return new Condition($"HMDMode('{mode}')");
    }

    private Condition SequencesDeselected()
    {
        return new Condition($"SequencesDeselected()");
    }

    private Condition IsBankLimitOnNav()
    {
        return new Condition($"IsBankLimitOnNav()");
    }

    private Condition IsRightMFDSupt()
    {
        return new Condition($"RmfdSupt()");
    }

    private Condition IsLeftMFDTac()
    {
        return new Condition($"LmfdTac()");
    }

    private Condition IsPreciseNotSelected()
    {
        return new Condition($"IsPreciseNotSelected()");
    }

    private Condition IsLatLongNotDecimal()
    {
        return new Condition($"IsLatLongNotDecimal()");
    }

    private Condition IsNotBullseye()
    {
        return new Condition($"NotBullseye()");
    }

    private Condition IsSequenceSelected(int sequence)
    {
        return new Condition($"SequenceSelected('{sequence}')");
    }

    private Condition IsInSequence(int wpt)
    {
        return new Condition($"InSequence('{wpt}')");
    }

    private CustomCommand GoToWaypoint(int sequence)
    {
        var delay = (Settings.HornetCommandDelayMs * 2).ToString(CultureInfo.InvariantCulture);
        return new CustomCommand($"GoToWaypoint({sequence}, '{this.RMFD.Id}', '{this.RMFD.OSB12.Id}', '{this.RMFD.OSB13.Id}', {delay}, {this.RMFD.OSB12.Activation})");
    }

    private CustomCommand SelectStore(string store)
    {
        var device = LMFD.Id;
        var b1 = LMFD.OSB06.Id;
        var b2 = LMFD.OSB07.Id;
        var b3 = LMFD.OSB08.Id;
        var b4 = LMFD.OSB09.Id;
        var b5 = LMFD.OSB10.Id;
        var delay = (Settings.HornetCommandDelayMs * LMFD.OSB06.DelayFactor).ToString(CultureInfo.InvariantCulture);
        var act = LMFD.OSB06.Activation;

        return new CustomCommand($"SelectStore('{store}', {device}, {b1}, {b2}, {b3}, {b4}, {b5}, {delay}, {act})");
    }

    private CustomCommand BoxHMDSetting(string setting, string expected, Command btn)
    {
        var device = RMFD.Id;
        var down = RMFD.OSB04.Id;
        var right = RMFD.OSB07.Id;
        var delay = (Settings.HornetCommandDelayMs * RMFD.OSB04.DelayFactor).ToString(CultureInfo.InvariantCulture);
        var post = (Settings.HornetCommandDelayMs * RMFD.OSB04.PostDelayFactor).ToString(CultureInfo.InvariantCulture);
        var act = RMFD.OSB04.Activation;

        return new CustomCommand($"BoxHMDSetting('{setting}', '{expected}', {device}, {down}, {right}, {delay}, {act}, {post}, {btn.Id})");
    }

    private Condition IsStationSelected(int station)
    {
        return new Condition($"StationSelected('{station}')");
    }

    private Condition IsTargetOfOpportunity()
    {
        return new Condition($"IsTargetOfOpportunity()");
    }

    private Condition IsInPPStation(int station)
    {
        return new Condition($"InPPStation('{station}')");
    }

    private Condition IsPPNotSelected(int pp)
    {
        return new Condition($"IsPPNotSelected('{pp}')");
    }

    private Condition IsDispenserOff()
    {
        return new Condition($"DispenserOff()");
    }

    private Condition IsDispenserOn()
    {
        return new Condition($"DispenserOn()");
    }

    private Condition IsDispenserNotSelected()
    {
        return new Condition($"DispenserNotSelected()");
    }

    private Condition InDispenserMode(string mode)
    {
        return new Condition($"InDispenserMode('{mode}')");
    }

    private Condition EWHudNotBoxed()
    {
        return new Condition($"EWHudNotBoxed()");
    }

    private CustomCommand WaitUntilDispenserOn()
    {
        return new CustomCommand($"WaitUntilDispenserOn()");
    }

    private CustomCommand SelectDispenserProgram(int program)
    {
        var btn = LMFD.OSB20;
        var delay = (Settings.HornetCommandDelayMs * btn.DelayFactor).ToString(CultureInfo.InvariantCulture);
        var postDelay = (Settings.HornetCommandDelayMs * btn.PostDelayFactor).ToString(CultureInfo.InvariantCulture);
        return new CustomCommand($"SelectDispenserProgram({program}, {LMFD.Id}, {btn.Id}, {delay}, {btn.Activation}, {postDelay})");
    }

    private CustomCommand SetDispenser(string type, Command selectBtn, decimal qty)
    {
        var qtyStr = qty.ToString(CultureInfo.InvariantCulture);
        var inc = LMFD.OSB12;
        var dec = LMFD.OSB13;
        var delay = (Settings.HornetCommandDelayMs * inc.DelayFactor).ToString(CultureInfo.InvariantCulture);
        var postDelay = (Settings.HornetCommandDelayMs * inc.PostDelayFactor).ToString(CultureInfo.InvariantCulture);
        return new CustomCommand($"SetDispenser('{type}', {qtyStr}, {LMFD.Id}, {selectBtn.Id}, {inc.Id}, {dec.Id}, {delay}, {inc.Activation}, {postDelay})");
    }

    private CustomCommand SetBingo(int bingo)
    {
        var inc = IFEI.UP;
        var dec = IFEI.DOWN;
        var delay = (Settings.HornetCommandDelayMs * inc.DelayFactor).ToString(CultureInfo.InvariantCulture);
        var postDelay = (Settings.HornetCommandDelayMs * inc.PostDelayFactor).ToString(CultureInfo.InvariantCulture);
        return new CustomCommand($"SetBingo({bingo}, {IFEI.Id}, {inc.Id}, {dec.Id}, {delay}, {inc.Activation}, {postDelay})");
    }
}
