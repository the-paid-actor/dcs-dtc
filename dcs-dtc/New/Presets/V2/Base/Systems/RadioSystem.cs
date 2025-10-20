
namespace DTC.New.Presets.V2.Base.Systems;

public class RadioSystem
{
    public Radio Radio1 { get; set; } = new();
    public Radio Radio2 { get; set; } = new();

    internal void AfterLoadFromJson()
    {
        Radio1.SelectedFrequency = FixFrequency(Radio1.SelectedFrequency);
        Radio2.SelectedFrequency = FixFrequency(Radio2.SelectedFrequency);

        foreach (var preset in Radio1.Presets ?? Enumerable.Empty<RadioPreset>())
        {
            preset.Frequency = FixFrequency(preset.Frequency);
        }
        foreach (var preset in Radio2.Presets ?? Enumerable.Empty<RadioPreset>())
        {
            preset.Frequency = FixFrequency(preset.Frequency);
        }
    }

    private string FixFrequency(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;

        var p = s.Split(".");
        if (p.Length == 2 && p[1].Length == 2)
        {
            s += "0";
        }
        return s;
    }
}

public enum RadioMode
{
    Frequency = 1,
    Preset = 2
}

public class Radio
{
    public List<RadioPreset>? Presets { get; set; }
    public string? SelectedFrequency { get; set; }
    public string? SelectedPreset { get; set; }
    public bool EnableGuard { get; set; }
    public RadioMode Mode { get; set; }

    public RadioPreset? GetPreset(int number)
    {
        return Presets?.FirstOrDefault(p => p.Number == number);
    }

    internal void AddPreset(RadioPreset radioPreset)
    {
        if (Presets == null) Presets = new();
        Presets.Add(radioPreset);
    }

    internal void RemovePreset(RadioPreset preset)
    {
        Presets?.Remove(preset);
    }
}

public class RadioPreset
{
    public int Number { get; set; }
    public string? Name { get; set; }
    public string Frequency { get; set; }

    public RadioPreset(int number)
    {
        Number = number;
    }
}