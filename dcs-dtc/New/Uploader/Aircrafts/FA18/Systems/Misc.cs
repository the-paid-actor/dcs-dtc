using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.Globalization;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader
{
    private void BuildMisc()
    {
        if (!config.Upload.Misc ||
            config.Misc == null)
        {
            return;
        }

        if (config.Misc.BingoToBeUpdated)
        {
            Cmd(SetBingo(config.Misc.Bingo));
        }

        if (config.Misc.ILSToBeUpdated && config.Misc.ILSChannel != 0)
        {
            Cmd(UFC.ILS);
            Cmd(Digits(UFC, config.Misc.ILSChannel.ToString()));
            Cmd(UFC.ENT);
        }

        if (config.Misc.TACANToBeUpdated)
        {
            Cmd(UFC.TCN);
            Cmd(Digits(UFC, config.Misc.TACANChannel.ToString()));
            Cmd(UFC.ENT);
            if (config.Misc.TACANBand == TACANBands.X)
            {
                Cmd(UFC.OPT4);
            }
            else if (config.Misc.TACANBand == TACANBands.Y)
            {
                Cmd(UFC.OPT5);
            }
        }

        if (config.Misc.RadarToBeUpdated)
        {
            BuildRadarWarn();
        }

        if (config.Misc.LaserSettingsToBeUpdated)
        {
            BuildLaser();
        }
    }

    private void BuildLaser()
    {
        SetLeftMFDTac();

        StartIf(FLIRAvailable());
        {
            Cmd(LMFD.OSB06);
            StartIf(FLIROn());
            {
                Cmd(LMFD.OSB14);
                Cmd(UFC.OPT1);
                Cmd(Digits(UFC, config.Misc.TGPCode.ToString()));
                Cmd(UFC.ENT);

                Cmd(UFC.OPT2);
                Cmd(Digits(UFC, config.Misc.LSTCode.ToString()));
                Cmd(UFC.ENT);
                Cmd(LMFD.OSB14);
            }
            EndIf();
        }
        EndIf();
    }


    private void BuildRadarWarn()
    {
        if (config.Misc.RadarWarn <= 5000)
        {
            Cmd(RADALT.DEC);
            for (var i = 0; i < 7; i++)
            {
                Cmd(RADALT.INC);
            } // Reset to 0 exact

            // one line is ~5 steps
            // one line = 20ft while below 400
            if (config.Misc.RadarWarn > 400)
            {
                for (var i = 0; i < 5 * 20; i++)
                {
                    Cmd(RADALT.INC);
                }
            }
            else
            {
                var step = (20 / 5);
                for (var i = 0; i < (config.Misc.RadarWarn / step); i++)
                {
                    Cmd(RADALT.INC);
                }
            }
            // one line = 50ft while 400 < x < 1000 
            if (config.Misc.RadarWarn > 1000)
            {
                for (var i = 0; i < 5 * 12; i++)
                {
                    Cmd(RADALT.INC);
                }
            }
            else
            {
                var step = (50 / 5);
                for (var i = 0; i < ((config.Misc.RadarWarn - 400) / step); i++)
                {
                    Cmd(RADALT.INC);
                }
            }
            // one line = 500ft while 1000 < x < 5000 
            if (config.Misc.RadarWarn > 1000)
            {
                var step = (500 / 5);
                for (var i = 0; i < ((config.Misc.RadarWarn - 1000) / step); i++)
                {
                    Cmd(RADALT.INC);
                }
            }
        }
    }

    private Condition FLIRAvailable()
    {
        return new Condition($"FLIRAvailable()");
    }

    private Condition FLIROn()
    {
        return new Condition($"FLIROn()");
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