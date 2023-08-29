using DTC.Utilities;

namespace DTC.Models.Presets
{
    public class PresetsStore
    {
        private static Dictionary<AircraftModel, Aircraft> _aircrafts = new Dictionary<AircraftModel, Aircraft>();

        public static Aircraft GetAircraft(AircraftModel model)
        {
            if (!_aircrafts.ContainsKey(model))
            {
                var ac = new Aircraft(model);
                _aircrafts.Add(model, ac);
                var presets = FileStorage.LoadPresets(ac);
                foreach (var name in presets.Keys)
                {
                    ac.CreatePreset(name, presets[name]);
                }
            }

            return _aircrafts[model];
        }

        public static void PresetChanged(Aircraft ac, IPreset preset)
        {
            FileStorage.PersistPreset(ac, preset);
        }
    }
}
