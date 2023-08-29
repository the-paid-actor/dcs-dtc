using DTC.UI.Base.Controls;

namespace DTC.Utilities;

partial class PresetName
{
	/// <summary> 
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary> 
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Component Designer generated code

	/// <summary> 
	/// Required method for Designer support - do not modify 
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		this.dtcLabel1 = new DTC.UI.Base.Controls.DTCLabel();
		this.btnCancel = new DTC.UI.Base.Controls.DTCButton();
		this.btnOK = new DTC.UI.Base.Controls.DTCButton();
		this.txtName = new DTC.UI.Base.Controls.DTCTextBox();
		this.SuspendLayout();
		// 
		// dtcLabel1
		// 
		this.dtcLabel1.AutoSize = true;
		this.dtcLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
		this.dtcLabel1.Location = new System.Drawing.Point(16, 18);
		this.dtcLabel1.Name = "dtcLabel1";
		this.dtcLabel1.Size = new System.Drawing.Size(49, 17);
		this.dtcLabel1.TabIndex = 2;
		this.dtcLabel1.Text = "Name:";
		// 
		// btnCancel
		// 
		this.btnCancel.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCancel.FlatAppearance.BorderSize = 0;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Location = new System.Drawing.Point(227, 49);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(150, 40);
		this.btnCancel.TabIndex = 1;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = false;
		this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
		// 
		// btnOK
		// 
		this.btnOK.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnOK.FlatAppearance.BorderSize = 0;
		this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOK.Location = new System.Drawing.Point(71, 49);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new System.Drawing.Size(150, 40);
		this.btnOK.TabIndex = 1;
		this.btnOK.Text = "OK";
		this.btnOK.UseVisualStyleBackColor = false;
		this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
		// 
		// txtName
		// 
		this.txtName.AllowPromptAsInput = true;
		this.txtName.BackColor = System.Drawing.SystemColors.Window;
		this.txtName.HidePromptOnLeave = false;
		this.txtName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
		this.txtName.Location = new System.Drawing.Point(71, 15);
		this.txtName.Mask = "";
		this.txtName.Name = "txtName";
		this.txtName.PromptChar = '_';
		this.txtName.Size = new System.Drawing.Size(306, 28);
		this.txtName.TabIndex = 0;
		this.txtName.ValidatingType = null;
		this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
		// 
		// PresetName
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.PaleGoldenrod;
		this.Controls.Add(this.dtcLabel1);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.btnOK);
		this.Controls.Add(this.txtName);
		this.Name = "PresetName";
		this.Size = new System.Drawing.Size(390, 101);
		this.ResumeLayout(false);
		this.PerformLayout();

	}

	#endregion
	private DTCLabel dtcLabel1;
	public DTCTextBox txtName;
	public DTCButton btnCancel;
	public DTCButton btnOK;
}
