using DTC.Models.DCS;
using DTC.Models.FA18.Radios;
using System.Linq;
using System.Text;

namespace DTC.Models.FA18.Upload
{
    class RadioBuilder : BaseBuilder
    {
        private FA18Configuration _cfg;

        public RadioBuilder(FA18Configuration cfg, FA18Commands f18, StringBuilder sb) : base(f18, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");

            if (_cfg.Radios.COM1.Channels.Any(c => c.ToBeUpdated))
                BuildRadio("COM1", _cfg.Radios.COM1, ufc);
            AppendCommand(WaitLong());
            if (_cfg.Radios.COM2.Channels.Any(c => c.ToBeUpdated))
                BuildRadio("COM2", _cfg.Radios.COM2, ufc);
        }

        private void BuildRadio(string radioCmd, Radio radio, Device ufc)
        {
            AppendCommand(ufc.GetCommand(radioCmd + "ChDec"));
            for (var i = 0; i < radio.Channels.Length; i++)
            {
                AppendCommand(ufc.GetCommand(radioCmd + "ChInc"));
                var ch = radio.Channels[i];
                if (!ch.ToBeUpdated)
                    continue;
                AppendCommand(ufc.GetCommand(radioCmd));
                AppendCommand(WaitLong());

                var freq = ch.GetFrequency().ToString();
                freq = DeleteLeadingZeros(RemoveSeparators(freq));

                AppendCommand(BuildDigits(ufc, freq));
                AppendCommand(ufc.GetCommand("ENT"));
                AppendCommand(Wait());
            }
            for (var i = 0; i < 5; i++)
            {
                AppendCommand(ufc.GetCommand(radioCmd + "ChInc")); // Reset
            }

        }
    }
}
