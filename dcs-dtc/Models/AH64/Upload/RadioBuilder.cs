
using DTC.Models.DCS;
using DTC.Models.AH64.Radios;
using System.Linq;
using System.Text;

namespace DTC.Models.AH64.Upload
{
    class RadioBuilder : BaseBuilder
    {
        private AH64Configuration _cfg;

        public RadioBuilder(AH64Configuration cfg, AH64Commands AH64, StringBuilder sb) : base(AH64, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var mpd = _aircraft.GetDevice("CPG_Right_MPD");
            var ku = _aircraft.GetDevice("CPG_KU");

            AppendCommand(mpd.GetCommand("COM"));
            AppendCommand(mpd.GetCommand("B2"));
            if (_cfg.Radios.VHF.Channels.Any(c => c.ToBeUpdated))
                BuildRadio("VHF", _cfg.Radios.VHF, mpd, ku);
            if (_cfg.Radios.UHF.Channels.Any(c => c.ToBeUpdated))
                BuildRadio("UHF", _cfg.Radios.UHF, mpd, ku);
            if (_cfg.Radios.FM1.Channels.Any(c => c.ToBeUpdated))
                BuildRadio("FM1", _cfg.Radios.FM1, mpd, ku);
            if (_cfg.Radios.FM2.Channels.Any(c => c.ToBeUpdated))
                BuildRadio("FM2", _cfg.Radios.FM2, mpd, ku);
        }

        private void BuildRadio(string radioCmd, Radio radio, Device mpd, Device ku)
        {
            //AppendCommand(mpd.GetCommand(radioCmd));


            for (var i = 0; i < radio.Channels.Length; i++)
            {
                var ch = radio.Channels[i];
                if (!ch.ToBeUpdated)
                    continue;

                if (radioCmd == "VHF")
                    AppendCommand(mpd.GetCommand("L1"));
                if (radioCmd == "UHF")
                    AppendCommand(mpd.GetCommand("L2"));
                if (radioCmd == "FM1")
                    AppendCommand(mpd.GetCommand("L3"));
                if (radioCmd == "FM2")
                    AppendCommand(mpd.GetCommand("L4"));


                var freq = ch.GetFrequency().ToString();
                freq = DeleteLeadingZeros(freq);

                AppendCommand(BuildDigits(ku, freq));
                AppendCommand(ku.GetCommand("ENTR"));
            }

        }
    }
}
