
using System.Globalization;

namespace DTC.New.Uploader.Base;

public interface ICommand
{
    string ToString(string aircraftModel, decimal baseDelay);
}

public abstract class Command : ICommand
{
    public abstract int Id { get; }
    public abstract decimal DelayFactor { get; }
    public abstract decimal Activation { get; }
    public abstract decimal PostDelayFactor { get; }

    public Device Device { get; }

    public Command(Device device)
    {
        this.Device = device;
    }

    public string ToString(string aircraftModel, decimal baseDelay)
    {
        var delay = "-1";
        var postDelay = "0";
        if (DelayFactor > -1)
        {
            delay = (baseDelay * DelayFactor).ToString(CultureInfo.InvariantCulture);
        }
        if (PostDelayFactor > 0)
        {
            postDelay = (baseDelay * PostDelayFactor).ToString(CultureInfo.InvariantCulture);
        }
        return $"DTC_ExecCommand({Device.Id}, {Id}, {delay}, {Activation.ToString(CultureInfo.InvariantCulture)}, {postDelay})";
    }
}

public class CustomCommand : ICommand
{
    private string cmd;

    public CustomCommand(string cmd)
    {
        this.cmd = cmd;
    }

    public override string ToString()
    {
        return this.cmd;
    }

    public string ToString(string aircraftModel, decimal baseDelay)
    {
        return $"DTC_{aircraftModel}_ExecCmd_{this.cmd}";
    }
}

