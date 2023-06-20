using DTC.Models.DCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.F16.Upload
{
    class HTSBuilder : BaseBuilder
    {
        private F16Configuration _cfg;

        public HTSBuilder(F16Configuration cfg, F16Commands f16, StringBuilder sb) : base(f16, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("8"));

            AppendCommand(Wait());

            AppendCommand(StartCondition("NotInAAMode"));

            AppendCommand(ufc.GetCommand("SEQ"));
            AppendCommand(StartCondition("NotInAGMode"));
            //if (_cfg.HTS.ManualTableEnabledToBeUpdated)
                BuildHTSManualTable();



            AppendCommand(EndCondition("NotInAGMode"));

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("8"));
            AppendCommand(ufc.GetCommand("SEQ"));

            AppendCommand(EndCondition("NotInAAMode"));

            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildHTSManualTable()
        {
            var ufc = _aircraft.GetDevice("UFC");

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(Wait());

            AppendCommand(StartCondition("HTSOnDED"));

            AppendCommand(ufc.GetCommand("ENTR"));

            for (var i = 0; i < 8; i++)
            {
                if (_cfg.HTS.ManualEmitters.Length > i)
                {
                    AppendCommand(BuildDigits(ufc, _cfg.HTS.ManualEmitters[i].ToString()));
                }
                else
                {
                    AppendCommand(ufc.GetCommand("0"));
                }
                AppendCommand(ufc.GetCommand("ENTR"));
            }

            AppendCommand(EndCondition("HTSOnDED"));
            AppendCommand(ufc.GetCommand("RTN"));
        }

    }
}
