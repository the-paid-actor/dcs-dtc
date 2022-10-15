using Newtonsoft.Json;
using DTC.Models.Base;
using DTC.Models.AH64.Waypoints;
using DTC.Models.AH64.Radios;

namespace DTC.Models.AH64
{
    public class AH64Configuration : IConfiguration
    {
        public WaypointSystem Waypoints = new WaypointSystem();
        public RadioSystem Radios = new RadioSystem();
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
        public static AH64Configuration FromJson(string s)
        {
            try
            {
                var cfg = JsonConvert.DeserializeObject<AH64Configuration>(s);
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
        public static AH64Configuration FromCompressedString(string s)
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

        public AH64Configuration Clone()
        {
            var json = ToJson();
            var cfg = FromJson(json);
            return cfg;
        }

        public void CopyConfiguration(AH64Configuration cfg)
        {
            if (cfg.Waypoints != null)
            {
                Waypoints = cfg.Waypoints;
            }
            if (cfg.Radios != null)
            {
                Radios = cfg.Radios;
            }
        }
        IConfiguration IConfiguration.Clone()
        {
            return Clone();
        }
    }
}