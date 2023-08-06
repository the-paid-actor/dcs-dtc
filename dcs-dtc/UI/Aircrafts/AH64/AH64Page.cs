using DTC.Models.AH64;
using DTC.Models.Base;
using DTC.Models.Presets;
using DTC.UI.CommonPages;

namespace DTC.UI.Aircrafts.AH64
{
    internal class AH64Page : AircraftPage
    {
        public AH64Page(Aircraft aircraft, Preset preset)
            : base(aircraft, preset)
        {
        }

        protected override AircraftSettingPage[] GetPages(IConfiguration configuration)
        {
            var cfg = (AH64Configuration)configuration;
            return new AircraftSettingPage[]
            {
                new UploadToHeliPage(this, cfg),
                new LoadSavePage(this, cfg),
                new WaypointsPage(this, cfg.Waypoints),
                new RadioPage(this, cfg.Radios)
            };
        }
    }
}
