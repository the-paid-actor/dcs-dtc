using DTC.Models.Base;
using DTC.Models.F15E.Displays;
using DTC.Models.F15E.Waypoints;
using Newtonsoft.Json;

namespace DTC.Models.F15E
{
    public class F15EConfiguration : IConfiguration
    {
        public WaypointSystem Waypoints = new WaypointSystem();
        public DisplaySystem Displays = new DisplaySystem();

        public string ToJson()
        {
            var json = JsonConvert.SerializeObject(this);
            return json;
        }

        public string ToCompressedString()
        {
            var json = ToJson();
            return StringCompressor.CompressString(json);
        }

        public static F15EConfiguration FromJson(string s)
        {
            try
            {
                var cfg = JsonConvert.DeserializeObject<F15EConfiguration>(s);
                cfg.AfterLoadFromJson();
                return cfg;
            }
            catch
            {
                return null;
            }
        }

        public void AfterLoadFromJson()
        {
        }

        public static F15EConfiguration FromCompressedString(string s)
        {
            try
            {
                var json = StringCompressor.DecompressString(s);
                var cfg = FromJson(json);
                return cfg;
            }
            catch
            {
                return null;
            }
        }

        public F15EConfiguration Clone()
        {
            var json = ToJson();
            var cfg = FromJson(json);
            return cfg;
        }

        public void CopyConfiguration(F15EConfiguration cfg)
        {
            if (cfg.Waypoints != null)
            {
                Waypoints = cfg.Waypoints;
            }
        }

        IConfiguration IConfiguration.Clone()
        {
            return Clone();
        }
    }
}
