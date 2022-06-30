using DTC.Models.DCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.F16.Upload
{
    class TOSBuilder : BaseBuilder
    {
        private F16Configuration _cfg;

        public TOSBuilder(F16Configuration cfg, F16Commands f16, StringBuilder sb) : base(f16, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");

            AppendCommand(ufc.GetCommand("RTN")); // Ensure we're in main menu
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("4")); // STPT
            
            AppendCommand(ufc.GetCommand("1")); // Select first steerpoint
            AppendCommand(ufc.GetCommand("ENTR")); 
            AppendCommand(ufc.GetCommand("RTN")); // Back to main menu

            AppendCommand(ufc.GetCommand("5")); // CRUS
            AppendCommand(ufc.GetCommand("DOWN")); // DES TOS

            for (int i = 0; i < _cfg.TOS.TimesOnStation.Length; i++)
            {
                var item = _cfg.TOS.TimesOnStation[i]; 
                if(item.EnableUpload)
                {
                    AppendCommand(buildNumberString(ufc, item));
                    AppendCommand(ufc.GetCommand("ENTR")); 
                }
                AppendCommand(ufc.GetCommand("INC")); // Increment to next STPT
            }
            AppendCommand(ufc.GetCommand("RTN")); // Back to main menu

            AppendCommand(ufc.GetCommand("4")); // STPT
            
            AppendCommand(ufc.GetCommand("1")); // Select first steerpoint
            AppendCommand(ufc.GetCommand("ENTR")); 
            AppendCommand(ufc.GetCommand("RTN")); // Back to main menu
        }

        private string buildNumberString(Device ufc, TOS.TOSSetting setting)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0; i < setting.Time.Length; i++)
            {
                if(setting.Time[i] != ':')
                {
                    sb.Append(ufc.GetCommand(setting.Time[i].ToString()));
                }

            }
            return sb.ToString();
        }
            
    }
}
