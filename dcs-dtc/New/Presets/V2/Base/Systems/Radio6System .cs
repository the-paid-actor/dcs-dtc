using DTC.Utilities;
using Newtonsoft.Json;

namespace DTC.New.Presets.V2.Base.Systems;

public class Radio6System
{
    public Radio6 Radio { get; set; } = new();

}


public class Radio6SelectedMode
{
    public int Number { get; set; }
    public string? SelectedFrequency { get; set; } = string.Empty;
    public RadioMode SelectedMode { get; set; }
    public string SelectedPreset { get; set; } = string.Empty;


    public Radio6SelectedMode(int number)
    {
        Number = number;
    }

    public bool IsEmpty()
    {
        return string.IsNullOrWhiteSpace(SelectedFrequency)
            && string.IsNullOrWhiteSpace(SelectedPreset)
            && SelectedMode == RadioMode.Frequency;
    }
}

public class Radio6
{
    public List<Radio6Preset>? Presets { get; set; }

    private List<Radio6SelectedMode>? selectedModes;

    public List<Radio6SelectedMode>? SelectedModes
    {
        get { return selectedModes?.Where(m => !m.IsEmpty()).ToList(); }
        set { selectedModes = value; }
    }



    public Radio6SelectedMode? GetSelectedMode(int index)
    {
        return selectedModes?.FirstOrDefault(p => p.Number == index) ?? new Radio6SelectedMode(index)
        {
            SelectedMode = RadioMode.Frequency,
            SelectedFrequency = string.Empty,
            SelectedPreset = string.Empty
        };
    }

    public Radio6Preset? GetPreset(int index)
    {
        return Presets?.FirstOrDefault(p => p.Number == index);
    }

    internal void AddPreset(Radio6Preset radio6Preset)
    {
        if (Presets == null) Presets = new();
        Presets.Add(radio6Preset);
    }

    internal void RemovePreset(Radio6Preset preset)
    {
        Presets?.Remove(preset);
    }



    private Radio6SelectedMode EnsureSelectedMode(int index)
    {
        selectedModes ??= new();
        var selectedMode = selectedModes.FirstOrDefault(p => p.Number == index);
        if (selectedMode != null)
        {
            return selectedMode;
        }
        selectedMode = new Radio6SelectedMode(index)
        {
            SelectedMode = RadioMode.Frequency,
            SelectedFrequency = string.Empty,
            SelectedPreset = string.Empty
        };

        selectedModes.Add(selectedMode);
        return selectedMode;
    }

    public void SetSelectedMode(int index, RadioMode mode)
    {
        EnsureSelectedMode(index).SelectedMode = mode;
    }
    public void SetSelectedFrequency(int index, string? frequency)
    {
        EnsureSelectedMode(index).SelectedFrequency = frequency ?? string.Empty;
    }

    public void SetSelectedPreset(int index, string? preset)
    {
        EnsureSelectedMode(index).SelectedPreset = preset ?? string.Empty;
    }

}

public class Radio6Preset
{
    public int Number { get; set; }
    public string? Name { get; set; }
    public List<string> Frequencies { get; set; } = new();

    [JsonProperty("Frequency")]
    public string? LegacyFrequency
    {
        set
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            if (Frequencies.Count == 0)
            {
                Frequencies.Add(value);
            }
            else
            {
                Frequencies[0] = value;
            }
        }
    }

    public Radio6Preset(int number)
    {
        Number = number;
    }
}

public class Radio6Conf
{
    public int Number { get; set; }
    public RadioType Type { get; set; } = RadioType.UHF;
    public string Name { get; set; }
    public bool Visible { get; set; } = true;
    public bool VisibleMode { get; set; } = true;

    public int IntegerDigits { get; set; } = 3;
    public int FractionDigits { get; set; } = 3;
    public Decimal FractionInterval { get; set; } = 0.005M;

    public bool IsUHF()
    {
        return Type == RadioType.UHF;
    }
    public bool IsVHF()
    {
        return Type == RadioType.VHF;
    }
    public bool IsFM()
    {
        return Type == RadioType.FM;
    }
    public bool IsHF()
    {
        return Type == RadioType.HF;
    }
}

