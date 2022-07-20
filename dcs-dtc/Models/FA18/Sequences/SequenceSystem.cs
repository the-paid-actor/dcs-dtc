using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.Models.FA18.Sequences
{
    public class SequenceSystem
    {
        public Sequence Seq1 { get; }
        public Sequence Seq2 { get; }
        public Sequence Seq3 { get; }
		public bool EnableUpload { get; set; }
		public bool EnableUpload1 { get; set; }
		public bool EnableUpload2 { get; set; }
		public bool EnableUpload3 { get; set; }

        public SequenceSystem()
        {
            Seq1 = new Sequence();
            Seq2 = new Sequence(); 
            Seq3 = new Sequence();  
            EnableUpload = false; 
            EnableUpload1 = false; 
            EnableUpload2 = false; 
            EnableUpload3 = false; 
        }
   }

    public class Sequence
    {
        public List<int> _seq { get; set; }

        public Sequence()
        {
            _seq = new List<int>();
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
