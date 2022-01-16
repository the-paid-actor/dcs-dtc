using DTC.Models.DCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.F16.Upload
{
    class HARMBuilder : BaseBuilder
    {
        private F16Configuration _cfg;

        public HARMBuilder(F16Configuration cfg, F16Commands f16, StringBuilder sb) : base(f16, sb)
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

            AppendCommand(StartCondition("NOT_IN_AA"));

            AppendCommand(ufc.GetCommand("SEQ"));
            AppendCommand(StartCondition("NOT_IN_AG"));
            
            
            if (_cfg.HARM.Tables.Any(t => t.ToBeUpdated))
            {
                BuildHARM();
            }
            
            AppendCommand(EndCondition("NOT_IN_AG"));

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("8"));
            AppendCommand(ufc.GetCommand("SEQ"));

            AppendCommand(EndCondition("NOT_IN_AA"));

            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildHARM()
        {
            var ufc = _aircraft.GetDevice("UFC");

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("0"));

            //AppendCommand(StartCondition("NAV"));
            AppendCommand(ufc.GetCommand("AG"));

            //condition
            AppendCommand(StartCondition("HARM"));
            AppendCommand(ufc.GetCommand("0"));

            foreach (var table in _cfg.HARM.Tables)
            {
                if (!table.ToBeUpdated)
                {
                    AppendCommand(ufc.GetCommand("INC"));
                    continue;
                }
                for (var i = 0; i < 5; i++)
                {
                    if (table.Emitters.Length > i)
                    {
                        AppendCommand(BuildDigits(ufc, table.Emitters[i].ToString()));
                    }
                    else
                    {
                        AppendCommand(ufc.GetCommand("0"));
                    }
                    AppendCommand(ufc.GetCommand("ENTR"));
                    AppendCommand(ufc.GetCommand("DOWN"));
                }

                AppendCommand(ufc.GetCommand("INC"));
            }

            AppendCommand(EndCondition("HARM"));

            AppendCommand(ufc.GetCommand("AG"));
            AppendCommand(ufc.GetCommand("RTN"));
        }
    }
}
