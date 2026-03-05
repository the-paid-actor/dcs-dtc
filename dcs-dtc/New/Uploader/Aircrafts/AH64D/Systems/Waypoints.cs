using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.AH64D;

public partial class AH64DUploader
{
    private void BuildWaypoints(bool pilot)
    {
        Device display = pilot ? MFD_PLT_RIGHT : MFD_CPG_RIGHT;
        Device keyboard = pilot ? KU_PILOT : KU_CPG;

        if (config.Upload.DeleteWaypoints || config.Upload.DeleteControlMeasures || config.Upload.DeleteTargets)
        {
            if (config.Upload.DeleteWaypoints && config.Upload.DeleteControlMeasures && config.Upload.DeleteTargets)
            {
                DeletePoints(display);
            }
            else
            {
                Cmd(display.GetCommand("TSD"));
                Cmd(display.GetCommand("T5"));
                Cmd(StoreCurrentCoords(display));

                if (config.Upload.DeleteWaypoints)
                {
                    DeletePoints(display, keyboard, "W", config.Waypoints.GetFirstAllowedSequence(), config.Waypoints.GetLastAllowedSequence());
                }
                if (config.Upload.DeleteControlMeasures)
                {
                    DeletePoints(display, keyboard, "C", config.ControlMeasures.GetFirstAllowedSequence(), config.ControlMeasures.GetLastAllowedSequence());
                }
                if (config.Upload.DeleteTargets)
                {
                    DeletePoints(display, keyboard, "T", config.Targets.GetFirstAllowedSequence(), config.Targets.GetLastAllowedSequence());
                }
            }
        }

        Cmd(display.GetCommand("TSD"));

        if (!config.Upload.Waypoints &&
            !config.Upload.ControlMeasures &&
            !config.Upload.Targets)
        {
            return;
        }

        Cmd(display.GetCommand("T5"));
        Cmd(StoreCurrentCoords(display));

        if (config.Upload.Waypoints && config.Waypoints != null && config.Waypoints.HasWaypoints())
        {
            UploadPoints(config.Waypoints, "W", display, keyboard, true);
        }
        if (config.Upload.ControlMeasures && config.ControlMeasures != null && config.ControlMeasures.HasWaypoints())
        {
            UploadPoints(config.ControlMeasures, "C", display, keyboard, false);
        }
        if (config.Upload.Targets && config.Targets != null && config.Targets.HasWaypoints())
        {
            UploadPoints(config.Targets, "T", display, keyboard, false);
        }
    }

    private void DeletePoints(Device display, Device keyboard, string genericPointType, int first, int last)
    {
        Cmd(display.GetCommand("TSD"));
        Cmd(display.GetCommand("B6"));

        for (var i = first; i <= last; i++)
        {
            StartIf(SequenceInUse(genericPointType, i));
            {
                DeletePoint(display, keyboard, genericPointType, i);
            }
            EndIf();
        }
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, string genericPointType, Device display, Device keyboard, bool fullSync)
    {
        Cmd(display.GetCommand("TSD"));
        Cmd(display.GetCommand("B6"));

        var startSeq = wptList.GetFirstAllowedSequence();
        var endSeq = wptList.GetLastAllowedSequence();
        var lastSeq = wptList.LastSequence();

        var pointsToDelete = new List<int>();

        for (var i = startSeq; i <= endSeq; i++)
        {
            var wpt = wptList.GetBySequence(i);
            if (wpt == null)
            {
                pointsToDelete.Add(i);
                StartIf(SequenceInUse(genericPointType, i));
                {
                    if (fullSync)
                    {
                        Cmd(QueuePointToDelete(genericPointType, i));
                    }
                }
                Else();
                {
                    if (i <= lastSeq)
                    {
                        AddPoint(genericPointType, display, keyboard, "", "", -1, "");
                        Cmd(QueuePointToDelete(genericPointType, i));
                    }
                }
                EndIf();
            }
            else
            {
                AddWaypoint(display, keyboard, wpt);
            }
        }

        foreach (var i in pointsToDelete)
        {
            StartIf(IsPointQueuedToDelete(genericPointType, i));
            {
                DeletePoint(display, keyboard, genericPointType, i);
            }
            EndIf();
        }

        Cmd(display.GetCommand("B6"));
    }

    private void AddWaypoint(Device display, Device keyboard, Waypoint? wpt)
    {
        var coord = Coordinate.FromString(wpt.Latitude, wpt.Longitude);
        var mgrs = coord.ToMGRSEightDigits().Replace(" ", "");
        var type = wpt.GetDCSPointType();

        StartIf(SequenceInUse(type, wpt.Sequence));
        {
            StartIf(IsPointEqual(type, wpt.Sequence, wpt.Identifier, wpt.Free, mgrs, wpt.Elevation));
            Else();
            {
                DeletePoint(display, keyboard, type, wpt.Sequence);
                AddPoint(type, display, keyboard, wpt.Identifier, wpt.Free, wpt.Elevation, mgrs);
            }
            EndIf();
        }
        Else();
        {
            AddPoint(type, display, keyboard, wpt.Identifier, wpt.Free, wpt.Elevation, mgrs);
        }
        EndIf();
    }

    private void DeletePoint(Device display, Device keyboard, string type, int sequence)
    {
        Cmd(display.GetCommand("L1"));
        Cmd(keyboard.GetCommand("CLR"));
        Cmd(Keyboard(keyboard, type + sequence.ToString().PadLeft(2, '0')));
        Cmd(keyboard.GetCommand("ENTER"));
        Cmd(display.GetCommand("L4"));
        Cmd(display.GetCommand("L3"));
    }

    private void AddPoint(string type, Device display, Device keyboard, string identifier, string free, int elev, string mgrs)
    {
        Cmd(display.GetCommand("L2"));

        if (type == "W")
            Cmd(display.GetCommand("L3"));
        if (type == "H")
            Cmd(display.GetCommand("L4"));
        if (type == "C")
            Cmd(display.GetCommand("L5"));
        if (type == "T")
            Cmd(display.GetCommand("L6"));

        Cmd(display.GetCommand("L1"));

        if (!string.IsNullOrEmpty(identifier))
        {
            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, identifier));
        }
        Cmd(keyboard.GetCommand("ENTER"));

        if (!string.IsNullOrEmpty(free))
        {
            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, free));
        }
        Cmd(keyboard.GetCommand("ENTER"));

        if (!string.IsNullOrEmpty(mgrs))
        {
            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, mgrs));
        }
        Cmd(keyboard.GetCommand("ENTER"));

        if (elev >= 0)
        {
            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, elev.ToString()));
        }
        Cmd(keyboard.GetCommand("ENTER"));
    }



    private void DeletePoints(Device display)
    {
        Cmd(display.GetCommand("TSD"));
        Cmd(display.GetCommand("B6"));
        Cmd(display.GetCommand("L4"));
        Loop(100, CannotDeletePoint(display), display.GetCommand("L3"), display.GetCommand("B6"), display.GetCommand("B6"), display.GetCommand("L4"));
        Cmd(display.GetCommand("B6"));
    }

    private ICommand[] Keyboard(Device d, string text)
    {
        var list = new List<ICommand>();
        var type = d.GetType();
        var props = type.GetProperties();

        foreach (var c in text)
        {
            var name = c.ToString();

            if (c == '.')
            {
                name = "DOT";
            }
            else if (char.IsDigit(c))
            {
                name = "D" + c.ToString();
            }

            var prop = props.First(p => p.Name == name);
            list.Add((ICommand)prop.GetValue(d, null));
        }
        return list.ToArray();
    }

    private CustomCommand QueuePointToDelete(string type, int sequence)
    {
        return new CustomCommand($"QueuePointToDelete('{type}', {sequence})");
    }

    private Condition IsPointQueuedToDelete(string type, int sequence)
    {
        return new Condition($"IsPointQueuedToDelete('{type}', {sequence})");
    }

    private Condition SequenceInUse(string type, int sequence)
    {
        return new Condition($"SequenceInUse('{type}', {sequence})");
    }

    private Condition IsPointEqual(string type, int sequence, string ident, string free, string coord, int alt)
    {
        return new Condition($"IsPointEqual('{type}', {sequence}, '{ident}', '{free}', '{coord}', {alt})");
    }

    private Condition CannotDeletePoint(Device mfd)
    {
        return new Condition($"CannotDeletePoint('{mfd.Name}')");
    }

    private Condition RouteEmpty(Device mfd)
    {
        return new Condition($"RouteEmpty('{mfd.Name}')");
    }

    private CustomCommand StoreCurrentCoords(Device mfd)
    {
        var s = "{" +
            $"deviceID = {mfd.Id}, " +
            $"next = {MFD_PLT_RIGHT.B3.Id}, " +
            $"T1 = {MFD_PLT_RIGHT.T1.Id}, " +
            $"T2 = {MFD_PLT_RIGHT.T2.Id}, " +
            $"delay = {Settings.ApacheCommandDelayMs * MFD_PLT_RIGHT.B3.DelayFactor}, " +
            $"action = {MFD_PLT_RIGHT.B3.Activation}" +
            "}";
        return new CustomCommand($"StoreCurrentCoords('{mfd.Name}', {s})");
    }
    private CustomCommand ClickEnd(Device mfd)
    {
        var s = "{" +
            $"deviceID = {mfd.Id}, " +
            $"R5 = {MFD_PLT_RIGHT.R5.Id}, " +
            $"R4 = {MFD_PLT_RIGHT.R4.Id}, " +
            $"R3 = {MFD_PLT_RIGHT.R3.Id}, " +
            $"R2 = {MFD_PLT_RIGHT.R2.Id}, " +
            $"delay = {Settings.ApacheCommandDelayMs * MFD_PLT_RIGHT.R2.DelayFactor}, " +
            $"action = {MFD_PLT_RIGHT.R2.Activation}" +
            "}";
        return new CustomCommand($"ClickEnd('{mfd.Name}', {s})");
    }
}