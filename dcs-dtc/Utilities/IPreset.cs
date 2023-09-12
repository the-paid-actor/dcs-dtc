namespace DTC.Utilities;

public interface IPreset
{
    string Name { get; set; }
    IConfiguration Configuration { get; }
    IPreset Clone();
}
