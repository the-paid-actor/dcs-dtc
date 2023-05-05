using DTC.Models.FA18.Waypoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.FA18.Sequences
{
    public class SequenceSystem
    {
        public Sequence Seq1 { get
            {
                if(FillSeq1WithAllWaypoints) {
                    int start= IncludeWpt0WithFillSeq1 ? 0 : 1;
                    int count = WaypointSystem.Waypoints.Count();
                    if(IncludeWpt0WithFillSeq1)
                    {
                        count += 1;
                    }
                    List<int> seq = Enumerable.Range(start, count).ToList();
                    return new Sequence(seq); 
                }
                return _Seq1;
            }
        }

        private Sequence _Seq1;

        public Sequence Seq2 { get; }
        public Sequence Seq3 { get; }
		public bool EnableUpload { get; set; }
		public bool EnableUpload1 { get; set; }
		public bool EnableUpload2 { get; set; }
		public bool EnableUpload3 { get; set; }

		public bool FillSeq1WithAllWaypoints { get; set; }
		public bool IncludeWpt0WithFillSeq1 { get; set; }

        private WaypointSystem WaypointSystem;

        public SequenceSystem(WaypointSystem waypointSystem)
        {
            WaypointSystem = waypointSystem;

            _Seq1 = new Sequence();
            Seq2 = new Sequence(); 
            Seq3 = new Sequence();  
            EnableUpload = false; 
            EnableUpload1 = false; 
            EnableUpload2 = false; 
            EnableUpload3 = false;

            FillSeq1WithAllWaypoints = false;
            IncludeWpt0WithFillSeq1 = false;
        }
   }

    public class Sequence
    {
        public List<int> _seq { get; set; }

        public Sequence(List<int> seq = null)
        {
            if(seq == null)
            {
                seq = new List<int>();
            }
            _seq = seq;
        }

        public void Set(String s)
        {
            var split = s.Split(',');
            _seq.Clear();
            foreach(string item in split)
            {
                if (int.TryParse(item, out int n))
                {
                    if(!_seq.Contains(n) && n < 60 && n >= 0) _seq.Add(n);
                }
            }

        }

        public bool IsEmpty()
        {
            return _seq.Count == 0;
        }

        override public String ToString()
        {
            return joinToString(_seq);
        }

        private String joinToString(List<int> l)
        {
            var sb = new StringBuilder();
            var i = 0;
            
            foreach(int n in l)
            {
                sb.Append(n.ToString());
                if (i++ < l.Count - 1) { sb.Append(','); }
            }
            return sb.ToString();   
        }
    }
}
