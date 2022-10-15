using DTC.Models.AH64.Radios;
using System.Collections.Generic;

namespace DTC.Models.AH64.Radios
{
    public class RadioSystem
    {
        public Radio UHF;
        public Radio VHF;
        public Radio FM1;
        public Radio FM2;
        public bool EnableUpload { get; set; }

        public RadioSystem()
        {
            ResetToDefaults();
            EnableUpload = true;
        }
        public void ResetToDefaults()
        {
            var uhfChannels = new List<RadioChannel>();

            for (int i = 0; i < 2; i++)
            {
                uhfChannels.Add(new RadioChannel(RadioType.UHF, i + 1, new decimal(251.00f + i), false));
            }

            UHF = new Radio("UHF", RadioType.UHF, uhfChannels.ToArray());

            var vhfChannels = new List<RadioChannel>();

            for (int i = 0; i < 2; i++)
            {
                vhfChannels.Add(new RadioChannel(RadioType.VHF, i + 1, new decimal(121.00f + i), false));
            }

            VHF = new Radio("VHF", RadioType.VHF, vhfChannels.ToArray());

            var fm1Channels = new List<RadioChannel>();

            for (int i = 0; i < 2; i++)
            {
                fm1Channels.Add(new RadioChannel(RadioType.FM, i + 1, new decimal(30.00f + i), false));
            }

            FM1 = new Radio("FM1", RadioType.FM, fm1Channels.ToArray());

            var fm2Channels = new List<RadioChannel>();
            
            for (int i = 0; i < 2; i++)
            {
                fm2Channels.Add(new RadioChannel(RadioType.FM, i + 1, new decimal(30.00f + i), false));
            }

            FM2 = new Radio("FM2", RadioType.FM, fm2Channels.ToArray());
        }
    }
}
