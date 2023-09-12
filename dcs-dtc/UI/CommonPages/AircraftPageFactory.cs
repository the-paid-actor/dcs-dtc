using DTC.Models.Presets;
using DTC.UI.Aircrafts.F15E;
using DTC.UI.Aircrafts.F16;
using DTC.UI.Aircrafts.FA18;
using System;

namespace DTC.UI.CommonPages
{
    internal class AircraftPageFactory
    {
        public static AircraftPage Make(Aircraft aircraft, Preset preset)
        {
            if (aircraft.Model == AircraftModel.F16C)
            {
                return new F16Page(aircraft, preset);
            }
            else if (aircraft.Model == AircraftModel.FA18C)
            {
                return new FA18Page(aircraft, preset);
            }
            else if (aircraft.Model == AircraftModel.F15E)
            {
                return new F15EPage(aircraft, preset);
            }

            throw new NotImplementedException();
        }
    }
}
