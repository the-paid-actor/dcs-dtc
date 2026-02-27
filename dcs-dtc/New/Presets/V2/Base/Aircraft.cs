using DTC.Utilities;
using System.IO;
using System.Collections.ObjectModel;

namespace DTC.New.Presets.V2.Base;

public abstract class Aircraft : IAircraft, IDisposable
{
    public abstract string Name { get; }

    public abstract Type GetAircraftConfigurationType();

    public abstract Configuration NewConfiguration();

    public abstract string GetAircraftModelName();

    public abstract int GetMaxWaypointElevation();

    public ObservableCollection<IPreset> Presets { get; } = new ObservableCollection<IPreset>();

    private FileSystemWatcher _presetWatcher;
    private readonly object _refreshLock = new object();
    private System.Threading.Timer _debounceTimer;

    public event EventHandler PresetsChanged;

    public Aircraft()
    {
        RefreshPresetList();
        InitializeFileWatcher();
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

    private void InitializeFileWatcher()
    {
        try
        {
            var presetPath = FileStorage.GetAircraftPresetsPath(this);
            
            // Create directory if it doesn't exist
            Directory.CreateDirectory(presetPath);
            
            _presetWatcher = new FileSystemWatcher(presetPath)
            {
                Filter = "*.json",
                NotifyFilter = NotifyFilters.FileName,
                EnableRaisingEvents = true
            };

            // Only watch for newly created files
            _presetWatcher.Created += OnPresetFileCreated;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to initialize preset file watcher: {ex.Message}");
        }
    }

    private void OnPresetFileCreated(object sender, FileSystemEventArgs e)
    {
        // Debounce rapid file creates (in case multiple files are added at once)
        _debounceTimer?.Dispose();
        _debounceTimer = new System.Threading.Timer(_ => RefreshPresetsWithLock(), null, 500, System.Threading.Timeout.Infinite);
    }

    private void RefreshPresetsWithLock()
    {
        lock (_refreshLock)
        {
            try
            {
                Action refreshAction = () =>
                {
                    RefreshPresetList();
                    PresetsChanged?.Invoke(this, EventArgs.Empty);
                };

                // Run on UI thread to update ObservableCollection safely
                if (System.Windows.Forms.Application.OpenForms.Count > 0)
                {
                    var mainForm = System.Windows.Forms.Application.OpenForms[0];
                    if (mainForm.InvokeRequired)
                    {
                        mainForm.Invoke(refreshAction);
                    }
                    else
                    {
                        refreshAction();
                    }
                }
                else
                {
                    refreshAction();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error refreshing preset list: {ex.Message}");
            }
        }
    }

    public void Dispose()
    {
        _presetWatcher?.Dispose();
        _debounceTimer?.Dispose();
    }
}
