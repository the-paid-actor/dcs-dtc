using DTC.New.Presets.V2.Aircrafts.AH64D;
using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.FA18;

namespace DTC.New.Presets.V2.Base
{
    internal static class AircraftRepository
    {
        private static Dictionary<string, Aircraft> aircrafts;

        public static Aircraft GetAircraft(string code)
        {
            if (aircrafts == null)
            {
                aircrafts = new();

                Aircraft ac;

                ac = new F16Aircraft();
                aircrafts.Add(ac.GetAircraftModelName(), ac);

                ac = new FA18Aircraft();
                aircrafts.Add(ac.GetAircraftModelName(), ac);

                ac = new F15EAircraft();
                aircrafts.Add(ac.GetAircraftModelName(), ac);

                ac = new AH64DAircraft();
                aircrafts.Add(ac.GetAircraftModelName(), ac);
            }

            return aircrafts[code];
        }
    }
}
