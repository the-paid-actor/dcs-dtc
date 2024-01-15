using DTC.Utilities;
using DTC.New.Presets.V2.Aircrafts.FA18;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader : Base.Uploader
{
    private FA18Configuration config;

    public FA18Uploader(FA18Aircraft ac, FA18Configuration cfg) : base(ac, Settings.HornetCommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute()
    {
        this.BuildWaypointsAndSequences();
        this.BuildCMS();
        this.BuildRadios();
        this.BuildFCR();
        this.BuildPrePlanned();
        this.BuildHMD();
        this.BuildMisc();
        this.Send();
    }

    private void Coord(string coord)
    {
        var (direction, (numbers, _)) = coord.Replace("°", "").Replace("’", "").Replace("”", "").Split(' ');
        var (coordDegMin, (coordDecimal, _)) = numbers.Split('.');
        if (coordDegMin.StartsWith('0')) coordDegMin = coordDegMin.Substring(1);
        if (coordDecimal.Length == 1)
        {
            coordDecimal += '5';
        }

        if (direction == "N")
        {
            Cmd(UFC.D2);
        }
        else if (direction == "S")
        {
            Cmd(UFC.D8);
        }
        else if (direction == "E")
        {
            Cmd(UFC.D6);
        }
        else if (direction == "W")
        {
            Cmd(UFC.D4);
        }

        Cmd(Digits(UFC, coordDegMin));
        Cmd(UFC.ENT);
        Cmd(Wait());
        Cmd(Wait());
        Cmd(Wait());
        Cmd(Digits(UFC, coordDecimal));
        Cmd(UFC.ENT);
        Cmd(Wait());
        Cmd(Wait());
        Cmd(Wait());
    }

    private void SetLeftMFDTac()
    {
        Loop(LeftMFDTAC(), LMFD.OSB18);
    }

    private Condition RightMFDSUPT()
    {
        return new Condition($"RightMFDSUPT()");
    }

    private Condition LeftMFDTAC()
    {
        return new Condition($"LeftMFDTAC()");
    }
}