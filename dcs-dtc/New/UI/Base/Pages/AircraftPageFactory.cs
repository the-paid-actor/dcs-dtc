using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.FA18;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.F15E;
using DTC.New.UI.Aircrafts.F16;
using DTC.New.UI.Aircrafts.FA18;

namespace DTC.New.UI.Base.Pages
{
    internal class AircraftPageFactory
    {
        public static AircraftPage Make(Aircraft aircraft, Preset preset)
        {
            if (aircraft is F16Aircraft)
            {
                return new F16Page(aircraft, preset);
            }
            else if (aircraft is FA18Aircraft)
            {
                return new FA18Page(aircraft, preset);
            }
            else if (aircraft is F15EAircraft)
            {
                return new F15EPage(aircraft, preset);
            }

            throw new NotImplementedException();
        }
    }
}
