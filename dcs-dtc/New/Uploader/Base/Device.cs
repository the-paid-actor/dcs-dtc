
namespace DTC.New.Uploader.Base;

public abstract class Device
{
    public abstract int Id { get; }
    public abstract string Name { get; }

    public Device()
    {
    }

    public Command GetCommand(string name)
    {
        //uses reflection to find the property based on name
        var prop = this.GetType().GetProperty(name);
        if (prop == null)
            throw new Exception($"Property {name} not found on {this.GetType().Name}");

        //gets the value of the property
        var value = prop.GetValue(this);
        if (value == null)
            throw new Exception($"Property {name} is null on {this.GetType().Name}");

        //casts the value to Command
        var cmd = value as Command;
        if (cmd == null)
            throw new Exception($"Property {name} is not a Command on {this.GetType().Name}");

        return cmd;
    }
}