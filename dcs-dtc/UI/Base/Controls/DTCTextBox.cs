using System;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
	class DTCTextBox : UserControl
	{
		private MaskedTextBox textBox;

		public override string Text
		{
			get { return textBox.Text; }
			set { textBox.Text = value; }
		}

		public string Mask
		{
			get { return textBox.Mask; }
			set { textBox.Mask = value; }
		}
		
		public bool AllowPromptAsInput
		{
			get { return textBox.AllowPromptAsInput; }
			set { textBox.AllowPromptAsInput = value; }
		}

		public bool HidePromptOnLeave
		{
			get { return textBox.HidePromptOnLeave; }
			set { textBox.HidePromptOnLeave = value; }
		}

		public InsertKeyMode InsertKeyMode
		{
			get { return textBox.InsertKeyMode; }
			set { textBox.InsertKeyMode = value; }
		}

		public char PromptChar
		{
			get { return textBox.PromptChar; }
			set { textBox.PromptChar = value; }
		}

		public Type ValidatingType
		{
			get { return textBox.ValidatingType; }
			set { textBox.ValidatingType = value; }
		}

		public bool MaskFull
		{
			get { return textBox.MaskFull; }
		}

		public DTCTextBox()
		{
			InitializeComponent();

			textBox.LostFocus += TextBox_LostFocus;
			textBox.GotFocus += TextBox_GotFocus;
		}

		private void TextBox_GotFocus(object sender, EventArgs e)
		{
			OnGotFocus(e);
		}

		private void TextBox_LostFocus(object sender, EventArgs e)
		{
			OnLostFocus(e);
		}

		public void SelectAll()
		{
			textBox.SelectAll();
		}

		private void InitializeComponent()
		{
			this.textBox = new System.Windows.Forms.MaskedTextBox();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox.Location = new System.Drawing.Point(4, 4);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(143, 19);
			this.textBox.TabIndex = 0;
			// 
			// DTCTextBox
			// 
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.textBox);
			this.Name = "DTCTextBox";
			this.Size = new System.Drawing.Size(150, 28);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
