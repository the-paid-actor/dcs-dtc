using System.Text;
using DTC.Utilities;
using DTC.Models.AH64.Upload;

namespace DTC.Models.AH64
{
    public class AH64Upload
    {
        private AH64Configuration _cfg;
        private AH64Commands ah64 = new AH64Commands();

        public AH64Upload(AH64Configuration cfg)
        {
            _cfg = cfg;
        }

        internal AH64Configuration Cfg => _cfg;

        public void Load()
        {
            var sb = new StringBuilder();

            if (_cfg.Waypoints.EnableUpload)
            {
                var waypointBuilder = new WaypointBuilder(_cfg, ah64, sb);
                waypointBuilder.Build();
            }
            if (_cfg.Radios.EnableUpload)
            {
                var radioBuilder = new RadioBuilder(_cfg, ah64, sb);
                radioBuilder.Build();
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