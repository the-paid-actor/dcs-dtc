using System.Runtime.CompilerServices;

namespace DTC.New.Presets.V2.Base;

public class SystemAttribute : Attribute
{
    public string Name { get; set; }
    public int Order { get; }
    public bool IgnoreForLoadSave { get; set; }

    public SystemAttribute(string name, [CallerLineNumber] int order = 0)
    {
        Name = name;
        Order = order;
    }
}
