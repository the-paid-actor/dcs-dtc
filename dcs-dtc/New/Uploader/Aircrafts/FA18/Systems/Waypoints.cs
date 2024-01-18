using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.Globalization;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader
{
    private bool CheckWaypoints()
    {
        if (config.Upload.Waypoints == false ||
            config.Waypoints == null ||
            config.Waypoints.Waypoints == null ||
            config.Waypoints.Waypoints.Count == 0)
        {
            return false;
        }

        return true;
    }

    private bool CheckSequences()
    {
        if (!config.Upload.Sequences ||
            config.Sequences == null ||
            !(config.Sequences.EnableUpload1 ||
            config.Sequences.EnableUpload2 ||
            config.Sequences.EnableUpload3))
        {
            return false;
        }
        return true;
    }

    private void BuildWaypointsAndSequences()
    {
        var doWaypoints = CheckWaypoints();
        var doSequences = CheckSequences();
        var doBullseye = false;
        var hideMapHSI = false;
        var blimTac = false;
        var baroWarn = false;
        var radarWarn = false;

        if (config.Upload.Misc && config.Misc != null)
        {
            if (config.Misc.BullseyeToBeUpdated) doBullseye = true;
            if (config.Misc.HideMapOnHSI) hideMapHSI = true;
            if (config.Misc.BlimTac) blimTac = true;
            if (config.Misc.BaroToBeUpdated) baroWarn = true;
            if (config.Misc.RadarToBeUpdated) radarWarn = true;
        }

        if (!doWaypoints && !doSequences && !doBullseye && !hideMapHSI && !blimTac && !baroWarn && !radarWarn)
        {
            return;
        }

        Loop(RightMFDSUPT(), RMFD.OSB18);
        Cmd(RMFD.OSB02); //HSI

        if (hideMapHSI)
        {
            Cmd(RMFD.OSB03); //Mode
            IfElse(MapBoxed(), new[] { RMFD.OSB03 }, new[] { RMFD.OSB01 });
        }

        Cmd(RMFD.OSB10); //Data
        Cmd(RMFD.OSB06); //A/C
        
        if (blimTac)
        {
            If(IsBankLimitOnNav(), RMFD.OSB04); //BLIM
        }
        if (baroWarn)
        {
            Cmd(RMFD.OSB20);
            Cmd(Digits(UFC, config.Misc.BaroWarn.ToString()));
            Cmd(UFC.ENT);
        }
        if (radarWarn)
        {
            Cmd(RMFD.OSB19);
            Cmd(Digits(UFC, config.Misc.RadarWarn.ToString()));
            Cmd(UFC.ENT);
        }

        if (doWaypoints)
        {
            Cmd(RMFD.OSB06); //AC
            If(IsLatLongNotDecimal(), RMFD.OSB15);
            Cmd(RMFD.OSB07); //WYPT
            If(IsPreciseNotSelected(), RMFD.OSB19);
            Loop(SequencesDeselected(), RMFD.OSB15, Wait());

            foreach (var wpt in config.Waypoints.Waypoints)
            {
                Cmd(GoToWaypoint(wpt.Sequence));
                Cmd(RMFD.OSB05); //UFC
                Cmd(UFC.OPT1);
                Cmd(Wait());
                Coord(wpt.Latitude);
                Coord(wpt.Longitude);
                Cmd(UFC.OPT3);
                Cmd(Wait());
                Cmd(UFC.OPT1);
                Cmd(Digits(UFC, wpt.Elevation.ToString()));
                Cmd(UFC.ENT);

                if (doBullseye)
                {
                    if (wpt.Sequence == config.Misc.BullseyeWP)
                    {
                        If(IsNotBullseye(), RMFD.OSB02);
                        doBullseye = false;
                    }
                }
            }
        }

        if (doBullseye)
        {
            Cmd(RMFD.OSB07); //WYPT
            Loop(SequencesDeselected(), RMFD.OSB15, Wait());
            Cmd(GoToWaypoint(config.Misc.BullseyeWP));
            If(IsNotBullseye(), RMFD.OSB02);
        }

        if (doWaypoints || doBullseye)
        {
            Cmd(GoToWaypoint(1));
        }

        if (doSequences)
        {
            Cmd(RMFD.OSB07); //WYPT

            if (config.Sequences.EnableUpload1)
            {
                Loop(IsSequenceSelected(1), RMFD.OSB15, Wait());
                Cmd(RMFD.OSB01); // SEQUFC
                ClearSequence();
                InputSequence(config.Sequences.Seq1);
            }
            if (config.Sequences.EnableUpload2)
            {
                Loop(IsSequenceSelected(2), RMFD.OSB15, Wait());
                Cmd(RMFD.OSB01); // SEQUFC
                ClearSequence();
                InputSequence(config.Sequences.Seq2);
            }
            if (config.Sequences.EnableUpload3)
            {
                Loop(IsSequenceSelected(3), RMFD.OSB15, Wait());
                Cmd(RMFD.OSB01); // SEQUFC
                ClearSequence();
                InputSequence(config.Sequences.Seq3);
            }
        }

        Cmd(UFC.CLR);

        Loop(RightMFDSUPT(), RMFD.OSB18);
        Cmd(RMFD.OSB15); //FCS
    }

    private void InputSequence(Sequence seq)
    {
        var wpts = new List<int>();

        if (seq.Mode == SequenceMode.UseAll)
        {
            foreach (var wpt in config.Waypoints.Waypoints)
            {
                wpts.Add(wpt.Sequence);
            }
        }
        else if (seq.Mode == SequenceMode.UseRange)
        {
            var from = seq.Waypoints[0];
            var to = -1;
            if (seq.Waypoints.Count > 1)
            {
                to = seq.Waypoints[1];
            }
            if (to == -1 && config.Waypoints.Waypoints.Count > 0)
            {
                var lastSequence = config.Waypoints.LastSequence();
                if (lastSequence >= from)
                {
                    to = lastSequence;
                }
            }

            if (to == -1 || to < from)
            {
                to = from;
            }

            for (var i = from; i <= to; i++)
            {
                if (config.Waypoints.IsSequenceInUse(i))
                {
                    wpts.Add(i);
                }
            }
        }
        else if (seq.Mode == SequenceMode.UseSpecific && seq.Waypoints != null)
        {
            wpts.AddRange(seq.Waypoints);
        }

        foreach (var i in wpts)
        {
            Cmd(UFC.OPT4);
            Cmd(Wait());
            Cmd(Digits(UFC, i.ToString()));
            Cmd(UFC.ENT);
            Cmd(Wait());
        }
    }

    private void ClearSequence()
    {
        for (var i = 0; i < 60; i++)
        {
            var cmds = new List<ICommand>();
            cmds.Add(UFC.OPT5);
            cmds.AddRange(Digits(UFC, i.ToString()));
            cmds.Add(UFC.ENT);
            cmds.Add(Wait());
            If(IsInSequence(i), cmds.ToArray());
        }
    }


    private Condition MapBoxed()
    {
        return new Condition($"MapBoxed()");
    }

    private Condition SequencesDeselected()
    {
        return new Condition($"SequencesDeselected()");
    }

    private Condition IsBankLimitOnNav()
    {
        return new Condition($"IsBankLimitOnNav()");
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
}
