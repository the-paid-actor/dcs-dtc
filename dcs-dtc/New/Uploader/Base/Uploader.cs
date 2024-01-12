using DTC.New.Presets.V2.Base;
using DTC.Utilities;
using System.Globalization;
using System.Text;

namespace DTC.New.Uploader.Base;

public abstract partial class Uploader
{
    private class WaitCommand : ICommand
    {
        private int delay = -1;

        public WaitCommand(int delay)
        {
            this.delay = delay;
        }

        public string ToString(string aircraftModel, decimal baseDelay)
        {
            var strDelay = this.delay == -1 ? "" : this.delay.ToString(CultureInfo.InvariantCulture);
            return "DTC_Wait(" + strDelay + ")";
        }
    }

    private StringBuilder sb = new();
    private string aircraftModel;
    private readonly decimal baseDelay;

    public Uploader(Aircraft aircraft, decimal baseDelay)
    {
        this.aircraftModel = aircraft.GetAircraftModelName();
        this.baseDelay = baseDelay;
    }

    protected void Cmd(ICommand cmd)
    {
        this.sb.AppendLine(FormatCommand(cmd));
    }

    protected void Cmd(params ICommand[] cmds)
    {
        foreach (var cmd in cmds)
        {
            this.sb.AppendLine(FormatCommand(cmd));
        }
    }

    protected void If(Condition condition, params ICommand[]? ifs)
    {
        IfElse(condition, ifs, null);
    }

    protected void IfElse(Condition condition, ICommand[]? ifs, ICommand[]? elses = null)
    {
        var ifsStr = new string[] { };
        if (ifs != null) ifsStr = ifs.Select(FormatCommand).ToArray();

        var elsesStr = new string[] { };
        if (elses != null) elsesStr = elses.Select(FormatCommand).ToArray();

        this.sb.AppendLine(@$"
            if {FormatCondition(condition)} then
                {String.Join('\n', ifsStr)}
            else
                {String.Join('\n', elsesStr)}
            end
        ");
    }

    protected void StartIf(Condition condition)
    {
        this.sb.AppendLine(@$"
            if {FormatCondition(condition)} then
        ");
    }

    protected void EndIf()
    {
        this.sb.AppendLine(@$"
            end
        ");
    }

    protected void Loop(Condition breakCondition, params ICommand[] cmds)
    {
        Loop(10, breakCondition, cmds);
    }

    protected void Loop(int count, Condition breakCondition, params ICommand[] cmds)
    {
        var cmdStr = new string[] { };
        if (cmds != null) cmdStr = cmds.Select(FormatCommand).ToArray();

        this.sb.AppendLine(@$"
            for i = 1, {count}, 1 do
                if {FormatCondition(breakCondition)} then
                    break
                end
                {String.Join('\n', cmdStr)}
                coroutine.yield()
            end
        ");
    }

    protected ICommand[] Digits(Device d, string digits)
    {
        var list = new List<ICommand>();
        var type = d.GetType();
        var props = type.GetProperties();

        foreach (var c in digits.ToCharArray())
        {
            var first = props.First(p => p.Name == "D" + c);
            if (first != null)
            {
                var v = first.GetValue(d, null);
                if (v != null)
                {
                    var cmd = (Command)v;
                    list.Add(cmd);
                }
            }
        }

        return list.ToArray();
    }

    protected ICommand Wait(int delay = -1)
    {
        return new WaitCommand(delay);
    }

    protected string IntegerString(decimal v)
    {
        return ((int)v).ToString(CultureInfo.InvariantCulture);
    }

    protected string DecimalString(decimal v)
    {
        return v.ToString("###.0", CultureInfo.InvariantCulture).Replace(".", "");
    }

    private string FormatCondition(Condition condition)
    {
        return $"DTC_{this.aircraftModel}_CheckCondition_{condition}";
    }

    private string FormatCommand(ICommand cmd)
    {
        return cmd.ToString(this.aircraftModel, this.baseDelay);
    }

    public void Send()
    {
        var cmds = this.sb.ToString();
        if (string.IsNullOrEmpty(cmds)) return;
        DataSender.SendNew(cmds);
    }

    protected string RemoveSeparators(string s)
    {
        return s.Replace(",", "").Replace(".", "").Replace("°", "").Replace("’", "").Replace("”", "").Replace("\"", "").Replace("'", "");
    }
}
