using DTC.Utilities;

namespace DTC.New.Presets.V2.Base;

public abstract class Aircraft : IAircraft
{
    public abstract string Name { get; }

    public abstract Type GetAircraftConfigurationType();

    public abstract Configuration NewConfiguration();

    public abstract string GetAircraftModelName();

    public abstract int GetMaxWaypointElevation();

    public List<IPreset> Presets { get; } = new List<IPreset>();

    public Aircraft()
    {
        RefreshPresetList();
    }

    public void RefreshPresetList()
    {
        Presets.Clear();
        var presets = ConfigLoader.LoadPresets(this);
        foreach (var name in presets.Keys)
        {
            CreatePreset(name, (Configuration)presets[name]);
        }
    }

    public Preset CreatePreset(string name, Configuration cfg = null)
    {
        if (cfg == null)
        {
            cfg = NewConfiguration();
        }
        var p = new Preset(name, cfg);
        Presets.Add(p);
        return p;
    }

    internal IPreset ClonePreset(IPreset preset)
    {
        var p = preset.Clone();
        Presets.Add(p);
        FileStorage.PersistPreset(this, p);
        return p;
    }

    public void PersistPreset(IPreset preset)
    {
        FileStorage.PersistPreset(this, preset);
    }


    internal void DeletePreset(IPreset preset)
    {
        Presets.Remove(preset);
        FileStorage.DeletePreset(this, preset);
    }
}
