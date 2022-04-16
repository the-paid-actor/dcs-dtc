using DTC.Models.FA18.Sequences;
using DTC.UI.Base;
using DTC.UI.CommonPages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.FA18
{
	public partial class SequencePage : AircraftSettingPage
	{
		private SequenceSystem _sequences;

		public SequencePage(AircraftPage parent, SequenceSystem sqss) : base(parent)
		{
			InitializeComponent();

			seq1.LostFocus += seq1_LostFocus;
			seq2.LostFocus += seq2_LostFocus;
			seq3.LostFocus += seq3_LostFocus;

			cbSeq1.CheckedChanged += seq1_CheckedChanged;
			cbSeq2.CheckedChanged += seq2_CheckedChanged;
			cbSeq3.CheckedChanged += seq3_CheckedChanged;

			_sequences = sqss;
			seq1.Text = _sequences.Seq1.ToString();
			cbSeq1.Checked = _sequences.EnableUpload1;
			seq2.Text = _sequences.Seq2.ToString();
			cbSeq2.Checked = _sequences.EnableUpload2;
			seq3.Text = _sequences.Seq3.ToString();
			cbSeq3.Checked = _sequences.EnableUpload3;
		}

		public override string GetPageTitle()
		{
			return "Sequences";
		}

		private void seq1_LostFocus(object sender, EventArgs e)
		{
			_sequences.Seq1.Set(seq1.Text);
			if (_sequences.Seq1.IsEmpty()) _sequences.EnableUpload1 = false;
			seq1.Text = _sequences.Seq1.ToString();
			cbSeq1.Checked = _sequences.EnableUpload1;
			_parent.DataChangedCallback();
		}

		private void seq2_LostFocus(object sender, EventArgs e)
		{
			_sequences.Seq2.Set(seq2.Text);
			if (_sequences.Seq2.IsEmpty()) _sequences.EnableUpload2 = false;
			seq2.Text = _sequences.Seq2.ToString();
			cbSeq2.Checked = _sequences.EnableUpload2;
			_parent.DataChangedCallback();
		}

		private void seq3_LostFocus(object sender, EventArgs e)
		{
			_sequences.Seq3.Set(seq3.Text);
			if (_sequences.Seq3.IsEmpty()) _sequences.EnableUpload3 = false;
			seq3.Text = _sequences.Seq3.ToString();
			cbSeq3.Checked = _sequences.EnableUpload3;
			_parent.DataChangedCallback();
		}

		private void seq1_CheckedChanged(object sender, EventArgs e)
        {
			if (!_sequences.Seq1.IsEmpty()) _sequences.EnableUpload1 = cbSeq1.Checked;
			cbSeq1.Checked = _sequences.EnableUpload1;
			_parent.DataChangedCallback();
        }

		private void seq2_CheckedChanged(object sender, EventArgs e)
        {
			if (!_sequences.Seq2.IsEmpty()) _sequences.EnableUpload2 = cbSeq2.Checked;
			cbSeq2.Checked = _sequences.EnableUpload2;
			_parent.DataChangedCallback();
        }

		private void seq3_CheckedChanged(object sender, EventArgs e)
        {
			if (!_sequences.Seq3.IsEmpty()) _sequences.EnableUpload3 = cbSeq3.Checked;
			cbSeq3.Checked = _sequences.EnableUpload3;
			_parent.DataChangedCallback();
        }
	}
}
