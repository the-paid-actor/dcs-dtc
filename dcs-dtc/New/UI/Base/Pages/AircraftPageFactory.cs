using DTC.New.Presets.V2.Aircrafts.AH64D;
using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.FA18;
using DTC.New.Presets.V2.Aircrafts.C130;
using DTC.New.Presets.V2.Aircrafts.A10;
using DTC.New.Presets.V2.Aircrafts.CH47F;
using DTC.New.Presets.V2.Aircrafts.AV8B;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.AH64D;
using DTC.New.UI.Aircrafts.F15E;
using DTC.New.UI.Aircrafts.F16;
using DTC.New.UI.Aircrafts.FA18;
using DTC.New.UI.Aircrafts.C130;
using DTC.New.UI.Aircrafts.A10;
using DTC.New.UI.Aircrafts.CH47F;
using DTC.New.UI.Aircrafts.AV8B;

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
            else if (aircraft is AH64DAircraft)
            {
                return new AH64DPage(aircraft, preset);
            }
            else if (aircraft is C130Aircraft)
            {
                return new C130Page(aircraft, preset);
            }
            else if (aircraft is A10Aircraft)
            {
                return new A10Page(aircraft, preset);
            }
            else if (aircraft is CH47FAircraft)
            {
                return new CH47FPage(aircraft, preset);
            }
            else if (aircraft is AV8BAircraft)
            {
                return new AV8BPage(aircraft, preset);
            }

            throw new NotImplementedException();
        }
    }
}
