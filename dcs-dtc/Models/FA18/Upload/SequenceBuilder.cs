using System.Text;
using DTC.Models.DCS;
using DTC.Models.FA18.Sequences;

namespace DTC.Models.FA18.Upload
{
    public class SequenceBuilder : BaseBuilder
	{
		private FA18Configuration _cfg;

		public SequenceBuilder(FA18Configuration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
		{
			_cfg = cfg;
		}
        public override void Build()
        {
			var seq1 = _cfg.Sequences.Seq1;
			var s1Enabled = _cfg.Sequences.EnableUpload1;
			var seq2 = _cfg.Sequences.Seq2;
			var s2Enabled = _cfg.Sequences.EnableUpload2;
			var seq3 = _cfg.Sequences.Seq3;
			var s3Enabled = _cfg.Sequences.EnableUpload3;

			var ufc = _aircraft.GetDevice("UFC");
			var rmfd = _aircraft.GetDevice("RMFD");
			if (s1Enabled || s2Enabled || s3Enabled)
			{
				AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
				AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
				AppendCommand(rmfd.GetCommand("OSB-02")); // HSI

				AppendCommand(rmfd.GetCommand("OSB-10")); // DATA
				AppendCommand(rmfd.GetCommand("OSB-07")); // WYPT
				AppendCommand(rmfd.GetCommand("OSB-01")); // SEQUFC

				if (s1Enabled)
				{
					ClearSequence(ufc);
					AppendCommand(rmfd.GetCommand("OSB-01")); // SEQUFC
					EnterSequence(ufc, seq1);
				}
				AppendCommand(rmfd.GetCommand("OSB-15")); // SEQX
				AppendCommand(rmfd.GetCommand("OSB-15")); // SEQX
				if (s2Enabled)
				{
					ClearSequence(ufc);
					AppendCommand(rmfd.GetCommand("OSB-01")); // SEQUFC
					EnterSequence(ufc, seq2);
				}
				AppendCommand(rmfd.GetCommand("OSB-15")); // SEQX
				AppendCommand(rmfd.GetCommand("OSB-15")); // SEQX
				if (s3Enabled)
				{
					ClearSequence(ufc);
					AppendCommand(rmfd.GetCommand("OSB-01")); // SEQUFC
					EnterSequence(ufc, seq3);
				}
				AppendCommand(rmfd.GetCommand("OSB-15")); // SEQX
				AppendCommand(rmfd.GetCommand("OSB-15")); // SEQX

				AppendCommand(Wait());
				AppendCommand(rmfd.GetCommand("OSB-18"));
				AppendCommand(Wait());
				AppendCommand(rmfd.GetCommand("OSB-18"));
				AppendCommand(rmfd.GetCommand("OSB-15"));
			}
        }

		public void ClearSequence(Device ufc)
        {
			for (var i = 0; i < 60; i++)
            {
				AppendCommand(StartCondition("IN_SEQ_" + i));
                AppendCommand(ufc.GetCommand("Opt5")); // DEL
				AppendCommand(Wait());
				AppendCommand(BuildNumber(ufc, i));
                AppendCommand(ufc.GetCommand("ENT")); // Enter
				AppendCommand(Wait());
				AppendCommand(EndCondition("IN_SEQ_" + i));
            }
        }

		public void EnterSequence(Device ufc, Sequence s)
        {
			foreach (int i in s._seq) {
				AppendCommand(ufc.GetCommand("Opt4")); // INS
				AppendCommand(Wait());
				AppendCommand(BuildNumber(ufc, i));
				AppendCommand(ufc.GetCommand("ENT")); // Enter
				AppendCommand(Wait());
			}
        }


		private string BuildNumber(Device ufc, int num)
        {
			var sb = new StringBuilder();

			foreach (var c in num.ToString().ToCharArray())
            {
				sb.Append(ufc.GetCommand(c.ToString()));
            }

			return sb.ToString();	
        }
    }
}
