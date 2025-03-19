using DTC.New.Presets.V2.Base;
using DTC.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.New.UI.Base
{
    internal class PresetNamedPipeImport
    {
        NamedPipeServer namedPipeServer;

        public void Start()
        {
            namedPipeServer = new NamedPipeServer("DTC-Preset-Import");
            namedPipeServer.OnMessageReceived += NamedPipeServer_OnMessageReceived; ;
            namedPipeServer.Start();
        }

        public void Stop()
        {
            namedPipeServer.Stop();
            namedPipeServer = null;
        }

        private void NamedPipeServer_OnMessageReceived(NamedPipeServer.MessageReceivedEventArgs obj)
        {
            var message = obj.Message;
            try
            {
                //var json = StringCompressor.DecompressString(message);
                var json = message;
                var cfg = ConfigLoader.FromJson(json, null);
                var ac = AircraftRepository.GetAircraft(cfg.GetAircraftName());
                var date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                var p = ac.CreatePreset("Imported " + date, cfg);
                ac.PersistPreset(p);

                obj.Success = true;
            }
            catch
            {
            }
        }
    }
}
