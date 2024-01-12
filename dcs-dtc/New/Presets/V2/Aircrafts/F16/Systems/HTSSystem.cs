namespace DTC.New.Presets.V2.Aircrafts.F16.Systems;

public class HTSSystem
{
    public int[] ManualEmitters { get; set; }
    public bool ManualEmittersToBeUpdated { get; set; }
    public bool[] EnabledClasses { get; set; }
    public bool ManualTableEnabledToBeUpdated { get; set; }

    public bool ManualTableEnabled;

    public HTSSystem()
    {
        ManualEmitters = new int[0];
        EnabledClasses = new bool[11];
        for (var i = 0; i < EnabledClasses.Length; i++)
        {
            EnabledClasses[i] = true;
        }
    }
}
