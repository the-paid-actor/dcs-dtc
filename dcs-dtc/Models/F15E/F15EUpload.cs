using System.Text;
using DTC.Utilities;
using DTC.Models.F15E;
using DTC.Models.F15E.Upload;

namespace DTC.Models
{
    public class F15EUpload
    {
        private F15EConfiguration _cfg;
        private F15ECommands F15E = new F15ECommands();

        public F15EUpload(F15EConfiguration cfg)
        {
            _cfg = cfg;
        }

        internal F15EConfiguration Cfg => _cfg;

        public void Load()
        {
            var sb = new StringBuilder();

            if (_cfg.Waypoints.EnableUpload)
            {
                var waypointBuilder = new WaypointBuilder(_cfg, F15E, sb);
                waypointBuilder.Build();
            }

            if (_cfg.Displays.EnableUpload)
            {
                var displayBuilder = new DisplayBuilder(_cfg, F15E, sb);
                displayBuilder.Build();
            }

            if (_cfg.Radios.EnableUpload)
            {
                var radiosBuilder = new RadioBuilder(_cfg, F15E, sb);
                radiosBuilder.Build();
            }

            if (_cfg.Misc.EnableUpload)
            {
                var miscBuilder = new MiscBuilder(_cfg, F15E, sb);
                miscBuilder.Build();
            }

            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            var str = sb.ToString();

            if (str != "")
            {
                DataSender.Send(str);
            }
        }
    }
}