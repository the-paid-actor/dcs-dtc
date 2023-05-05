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

			fillWithAllWpts.Checked = _sequences.FillSeq1WithAllWaypoints;
			includeWpt0.Checked = _sequences.IncludeWpt0WithFillSeq1;
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
			if (!fillWithAllWpts.Checked && cbSeq1.Checked)
            {
				_sequences.EnableUpload1 = false;
            }
			if (!_sequences.Seq1.IsEmpty() || fillWithAllWpts.Checked)
			{
				_sequences.EnableUpload1 = cbSeq1.Checked;
			}
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

        private void fillWithAllWpts_CheckedChanged(object sender, EventArgs e)
        {
			if(fillWithAllWpts.Checked)
            {
                seq1.Enabled = false;
                cbSeq1.Checked = true;
                seq2.Enabled = false;
                cbSeq2.Checked = false;
                cbSeq2.Enabled = false;
                seq3.Enabled = false;
                cbSeq3.Checked = false;
                cbSeq3.Enabled = false;
				includeWpt0.Enabled = true;
            } else {
				if(_sequences.Seq1.IsEmpty())
                {
					cbSeq1.Checked = false;
                }
                seq1.Enabled = true;
                seq2.Enabled = true;
                cbSeq2.Enabled = true;
                seq3.Enabled = true;
                cbSeq3.Enabled = true;
				includeWpt0.Enabled = false;
				includeWpt0.Checked = false;
            }

			 _sequences.FillSeq1WithAllWaypoints = fillWithAllWpts.Checked;
			_parent.DataChangedCallback();
        }

        private void includeWpt0_CheckedChanged(object sender, EventArgs e)
        {
			 _sequences.IncludeWpt0WithFillSeq1 = includeWpt0.Checked;
			RefreshSeq1Text();
			_parent.DataChangedCallback();

        }

        // Happens when the user enters the page
        private void SequencePage_VisibleChanged(object sender, EventArgs e)
        {
			// Only really relevant if FillSeq1WithAllWaypoints is enabled:
			// Update the Sequence 1 text in case the waypoints have changed on the Waypoints page.
			RefreshSeq1Text();
        }

		private void RefreshSeq1Text()
        {
			seq1.Text = _sequences.Seq1.ToString();
        }
    }
}
