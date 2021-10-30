using System;
using System.Drawing;
using System.Windows.Forms;
using DTC.Models.F16.CMS;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;

namespace DTC.UI.Aircrafts.F16
{
	public partial class CMSPage : AircraftSettingPage
	{
		private CMSystem _cms;

		private int _lastTabIndex = 0;

		public CMSPage(AircraftPage parent, CMSystem cms) : base(parent)
		{
			_cms = cms;
			InitializeComponent();

			var rowHeight = 35;
			var table = new TableLayoutPanel();
			table.RowCount = 1 + (_cms.Programs.Length * 2);
			table.ColumnCount = 6;
			table.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			table.Width = this.Width;
			table.Height = (table.RowCount * rowHeight);
			this.Controls.Add(table);

			table.Controls.Add(CreateLabel("Burst Qty"), 2, 0);
			table.Controls.Add(CreateLabel("Burst Intv"), 3, 0);
			table.Controls.Add(CreateLabel("Salvo Qty"), 4, 0);
			table.Controls.Add(CreateLabel("Salvo Intv"), 5, 0);

			table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));

			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
			table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));

			for (var i = 0; i < _cms.Programs.Length; i++)
			{
				var secondRow = (i + 1) * 2;
				var firstRow = secondRow - 1;
				var program = _cms.Programs[i];

				table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
				table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));

				var programLbl = CreateLabel("Program " + (i + 1).ToString());
				table.Controls.Add(programLbl, 0, firstRow);
				table.SetRowSpan(programLbl, 2);

				table.Controls.Add(CreateLabel("Chaff"), 1, firstRow);
				table.Controls.Add(CreateLabel("Flare"), 1, secondRow);

				var qtyMask = "00";
				var burstIntervalMask = @"00.000";
				var salvoIntervalMask = @"000.00";

				var txtChaffBurstQty = CreateTextBox(program.GetChaffBurstQty(), qtyMask, (txt) =>
				{
					txt.Text = program.SetChaffBurstQty(txt.Text);
					_parent.DataChangedCallback();
				});

				var txtChaffBurstInterval = CreateTextBox(program.GetChaffBurstInterval(), burstIntervalMask, (txt) =>
				{
					txt.Text = program.SetChaffBurstInterval(txt.Text);
					_parent.DataChangedCallback();
				});

				var txtChaffSalvoQty = CreateTextBox(program.GetChaffSalvoQty(), qtyMask, (txt) =>
				{
					txt.Text = program.SetChaffSalvoQty(txt.Text);
					_parent.DataChangedCallback();
				});

				var txtChaffSalvoInterval = CreateTextBox(program.GetChaffSalvoInterval(), salvoIntervalMask, (txt) =>
				{
					txt.Text = program.SetChaffSalvoInterval(txt.Text);
					_parent.DataChangedCallback();
				});

				var txtFlareBurstQty = CreateTextBox(program.GetFlareBurstQty(), qtyMask, (txt) =>
				{
					txt.Text = program.SetFlareBurstQty(txt.Text);
					_parent.DataChangedCallback();
				});

				var txtFlareBurstInterval = CreateTextBox(program.GetFlareBurstInterval(), burstIntervalMask, (txt) =>
				{
					txt.Text = program.SetFlareBurstInterval(txt.Text);
					_parent.DataChangedCallback();
				});

				var txtFlareSalvoQty = CreateTextBox(program.GetFlareSalvoQty(), qtyMask, (txt) =>
				{
					txt.Text = program.SetFlareSalvoQty(txt.Text);
					_parent.DataChangedCallback();
				});

				var txtFlareSalvoInterval = CreateTextBox(program.GetFlareSalvoInterval(), salvoIntervalMask, (txt) =>
				{
					txt.Text = program.SetFlareSalvoInterval(txt.Text);
					_parent.DataChangedCallback();
				});

				table.Controls.Add(txtChaffBurstQty, 2, firstRow);
				table.Controls.Add(txtFlareBurstQty, 2, secondRow);

				table.Controls.Add(txtChaffBurstInterval, 3, firstRow);
				table.Controls.Add(txtFlareBurstInterval, 3, secondRow);

				table.Controls.Add(txtChaffSalvoQty, 4, firstRow);
				table.Controls.Add(txtFlareSalvoQty, 4, secondRow);

				table.Controls.Add(txtChaffSalvoInterval, 5, firstRow);
				table.Controls.Add(txtFlareSalvoInterval, 5, secondRow);
			}
		}

		public override string GetPageTitle()
		{
			return "CMS";
		}

		private delegate void TextBoxChangedCallback(DTCTextBox txt);

		private DTCTextBox CreateTextBox(string value, string mask, TextBoxChangedCallback callback)
		{
			var txt = new DTCTextBox();
			txt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			txt.Text = value;
			txt.Mask = mask;
			txt.Tag = callback;
			txt.TabIndex = _lastTabIndex++;
			txt.LostFocus += Txt_LostFocus;
			txt.GotFocus += Txt_GotFocus;
			return txt;
		}

		private void Txt_GotFocus(object sender, EventArgs e)
		{
			var txt = (DTCTextBox)sender;
			txt.SelectAll();
		}

		private void Txt_LostFocus(object sender, EventArgs e)
		{
			var txt = (DTCTextBox)sender;
			var callback = (TextBoxChangedCallback)txt.Tag;
			callback(txt);
		}

		private Label CreateLabel(string text)
		{
			var lbl = new Label();
			lbl.Text = text;
			lbl.AutoSize = false;
			lbl.TextAlign = ContentAlignment.MiddleCenter;
			lbl.Dock = DockStyle.Fill;
			lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			return lbl;
		}
	}
}
