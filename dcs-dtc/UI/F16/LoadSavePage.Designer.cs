
using DTC.UI.Base.Controls;

namespace DTC.UI.F16
{
	partial class LoadSavePage
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
			this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClipboard = new DTC.UI.Base.Controls.DTCButton();
			this.btnFile = new DTC.UI.Base.Controls.DTCButton();
			this.pnlFile = new System.Windows.Forms.Panel();
			this.groupBox3 = new DTC.UI.Controls.DTCGroupBox();
			this.btnFileApply = new DTC.UI.Base.Controls.DTCButton();
			this.btnFileLoad = new DTC.UI.Base.Controls.DTCButton();
			this.chkFileLoadMFDs = new System.Windows.Forms.CheckBox();
			this.chkFileLoadRadios = new System.Windows.Forms.CheckBox();
			this.chkFileLoadCMS = new System.Windows.Forms.CheckBox();
			this.chkFileLoadWaypoints = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new DTC.UI.Controls.DTCGroupBox();
			this.btnFileSave = new DTC.UI.Base.Controls.DTCButton();
			this.chkFileSaveMFDs = new System.Windows.Forms.CheckBox();
			this.chkFileSaveRadios = new System.Windows.Forms.CheckBox();
			this.chkFileSaveCMS = new System.Windows.Forms.CheckBox();
			this.chkFileSaveWaypoints = new System.Windows.Forms.CheckBox();
			this.pnlClipboard = new System.Windows.Forms.Panel();
			this.groupBox1 = new DTC.UI.Controls.DTCGroupBox();
			this.btnClipboardApply = new DTC.UI.Base.Controls.DTCButton();
			this.btnClipboardLoad = new DTC.UI.Base.Controls.DTCButton();
			this.chkClipLoadMFDs = new System.Windows.Forms.CheckBox();
			this.chkClipLoadRadios = new System.Windows.Forms.CheckBox();
			this.chkClipLoadCMS = new System.Windows.Forms.CheckBox();
			this.chkClipLoadWaypoints = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new DTC.UI.Controls.DTCGroupBox();
			this.btnClipboardSave = new DTC.UI.Base.Controls.DTCButton();
			this.chkClipSaveMFDs = new System.Windows.Forms.CheckBox();
			this.chkClipSaveRadios = new System.Windows.Forms.CheckBox();
			this.chkClipSaveCMS = new System.Windows.Forms.CheckBox();
			this.chkClipSaveWaypoints = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.pnlFile.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.pnlClipboard.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDlg
			// 
			this.openFileDlg.FileName = "dtc.json";
			// 
			// saveFileDlg
			// 
			this.saveFileDlg.DefaultExt = "json";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClipboard);
			this.panel1.Controls.Add(this.btnFile);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1006, 50);
			this.panel1.TabIndex = 4;
			// 
			// btnClipboard
			// 
			this.btnClipboard.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnClipboard.Location = new System.Drawing.Point(158, 5);
			this.btnClipboard.Name = "btnClipboard";
			this.btnClipboard.Size = new System.Drawing.Size(150, 40);
			this.btnClipboard.TabIndex = 1;
			this.btnClipboard.Text = "Clipboard";
			this.btnClipboard.UseVisualStyleBackColor = false;
			this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
			// 
			// btnFile
			// 
			this.btnFile.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnFile.Location = new System.Drawing.Point(5, 5);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(150, 40);
			this.btnFile.TabIndex = 0;
			this.btnFile.Text = "File";
			this.btnFile.UseVisualStyleBackColor = false;
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// pnlFile
			// 
			this.pnlFile.Controls.Add(this.groupBox3);
			this.pnlFile.Controls.Add(this.groupBox4);
			this.pnlFile.Location = new System.Drawing.Point(3, 153);
			this.pnlFile.Name = "pnlFile";
			this.pnlFile.Size = new System.Drawing.Size(469, 342);
			this.pnlFile.TabIndex = 5;
			this.pnlFile.Visible = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnFileApply);
			this.groupBox3.Controls.Add(this.btnFileLoad);
			this.groupBox3.Controls.Add(this.chkFileLoadMFDs);
			this.groupBox3.Controls.Add(this.chkFileLoadRadios);
			this.groupBox3.Controls.Add(this.chkFileLoadCMS);
			this.groupBox3.Controls.Add(this.chkFileLoadWaypoints);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.groupBox3.Location = new System.Drawing.Point(16, 17);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(205, 306);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Load from File";
			// 
			// btnFileApply
			// 
			this.btnFileApply.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnFileApply.Enabled = false;
			this.btnFileApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFileApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnFileApply.Location = new System.Drawing.Point(18, 247);
			this.btnFileApply.Name = "btnFileApply";
			this.btnFileApply.Size = new System.Drawing.Size(150, 40);
			this.btnFileApply.TabIndex = 0;
			this.btnFileApply.Text = "Apply";
			this.btnFileApply.UseVisualStyleBackColor = false;
			this.btnFileApply.Click += new System.EventHandler(this.btnFileApply_Click);
			// 
			// btnFileLoad
			// 
			this.btnFileLoad.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnFileLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFileLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnFileLoad.Location = new System.Drawing.Point(18, 36);
			this.btnFileLoad.Name = "btnFileLoad";
			this.btnFileLoad.Size = new System.Drawing.Size(150, 40);
			this.btnFileLoad.TabIndex = 0;
			this.btnFileLoad.Text = "Load";
			this.btnFileLoad.UseVisualStyleBackColor = false;
			this.btnFileLoad.Click += new System.EventHandler(this.btnFileLoad_Click);
			// 
			// chkFileLoadMFDs
			// 
			this.chkFileLoadMFDs.AutoSize = true;
			this.chkFileLoadMFDs.Enabled = false;
			this.chkFileLoadMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkFileLoadMFDs.Location = new System.Drawing.Point(18, 180);
			this.chkFileLoadMFDs.Name = "chkFileLoadMFDs";
			this.chkFileLoadMFDs.Size = new System.Drawing.Size(71, 24);
			this.chkFileLoadMFDs.TabIndex = 0;
			this.chkFileLoadMFDs.Text = "MFDs";
			this.chkFileLoadMFDs.UseVisualStyleBackColor = true;
			// 
			// chkFileLoadRadios
			// 
			this.chkFileLoadRadios.AutoSize = true;
			this.chkFileLoadRadios.Enabled = false;
			this.chkFileLoadRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkFileLoadRadios.Location = new System.Drawing.Point(18, 151);
			this.chkFileLoadRadios.Name = "chkFileLoadRadios";
			this.chkFileLoadRadios.Size = new System.Drawing.Size(78, 24);
			this.chkFileLoadRadios.TabIndex = 0;
			this.chkFileLoadRadios.Text = "Radios";
			this.chkFileLoadRadios.UseVisualStyleBackColor = true;
			// 
			// chkFileLoadCMS
			// 
			this.chkFileLoadCMS.AutoSize = true;
			this.chkFileLoadCMS.Enabled = false;
			this.chkFileLoadCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkFileLoadCMS.Location = new System.Drawing.Point(18, 122);
			this.chkFileLoadCMS.Name = "chkFileLoadCMS";
			this.chkFileLoadCMS.Size = new System.Drawing.Size(63, 24);
			this.chkFileLoadCMS.TabIndex = 0;
			this.chkFileLoadCMS.Text = "CMS";
			this.chkFileLoadCMS.UseVisualStyleBackColor = true;
			// 
			// chkFileLoadWaypoints
			// 
			this.chkFileLoadWaypoints.AutoSize = true;
			this.chkFileLoadWaypoints.Enabled = false;
			this.chkFileLoadWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkFileLoadWaypoints.Location = new System.Drawing.Point(18, 93);
			this.chkFileLoadWaypoints.Name = "chkFileLoadWaypoints";
			this.chkFileLoadWaypoints.Size = new System.Drawing.Size(102, 24);
			this.chkFileLoadWaypoints.TabIndex = 0;
			this.chkFileLoadWaypoints.Text = "Waypoints";
			this.chkFileLoadWaypoints.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnFileSave);
			this.groupBox4.Controls.Add(this.chkFileSaveMFDs);
			this.groupBox4.Controls.Add(this.chkFileSaveRadios);
			this.groupBox4.Controls.Add(this.chkFileSaveCMS);
			this.groupBox4.Controls.Add(this.chkFileSaveWaypoints);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.groupBox4.Location = new System.Drawing.Point(243, 17);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(203, 306);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Save to File";
			// 
			// btnFileSave
			// 
			this.btnFileSave.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnFileSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFileSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnFileSave.Location = new System.Drawing.Point(18, 247);
			this.btnFileSave.Name = "btnFileSave";
			this.btnFileSave.Size = new System.Drawing.Size(150, 40);
			this.btnFileSave.TabIndex = 0;
			this.btnFileSave.Text = "Save";
			this.btnFileSave.UseVisualStyleBackColor = false;
			this.btnFileSave.Click += new System.EventHandler(this.btnFileSave_Click);
			// 
			// chkFileSaveMFDs
			// 
			this.chkFileSaveMFDs.AutoSize = true;
			this.chkFileSaveMFDs.Checked = true;
			this.chkFileSaveMFDs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFileSaveMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkFileSaveMFDs.Location = new System.Drawing.Point(18, 123);
			this.chkFileSaveMFDs.Name = "chkFileSaveMFDs";
			this.chkFileSaveMFDs.Size = new System.Drawing.Size(71, 24);
			this.chkFileSaveMFDs.TabIndex = 0;
			this.chkFileSaveMFDs.Text = "MFDs";
			this.chkFileSaveMFDs.UseVisualStyleBackColor = true;
			// 
			// chkFileSaveRadios
			// 
			this.chkFileSaveRadios.AutoSize = true;
			this.chkFileSaveRadios.Checked = true;
			this.chkFileSaveRadios.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFileSaveRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkFileSaveRadios.Location = new System.Drawing.Point(18, 94);
			this.chkFileSaveRadios.Name = "chkFileSaveRadios";
			this.chkFileSaveRadios.Size = new System.Drawing.Size(78, 24);
			this.chkFileSaveRadios.TabIndex = 0;
			this.chkFileSaveRadios.Text = "Radios";
			this.chkFileSaveRadios.UseVisualStyleBackColor = true;
			// 
			// chkFileSaveCMS
			// 
			this.chkFileSaveCMS.AutoSize = true;
			this.chkFileSaveCMS.Checked = true;
			this.chkFileSaveCMS.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFileSaveCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkFileSaveCMS.Location = new System.Drawing.Point(18, 65);
			this.chkFileSaveCMS.Name = "chkFileSaveCMS";
			this.chkFileSaveCMS.Size = new System.Drawing.Size(63, 24);
			this.chkFileSaveCMS.TabIndex = 0;
			this.chkFileSaveCMS.Text = "CMS";
			this.chkFileSaveCMS.UseVisualStyleBackColor = true;
			// 
			// chkFileSaveWaypoints
			// 
			this.chkFileSaveWaypoints.AutoSize = true;
			this.chkFileSaveWaypoints.Checked = true;
			this.chkFileSaveWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFileSaveWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkFileSaveWaypoints.Location = new System.Drawing.Point(18, 36);
			this.chkFileSaveWaypoints.Name = "chkFileSaveWaypoints";
			this.chkFileSaveWaypoints.Size = new System.Drawing.Size(102, 24);
			this.chkFileSaveWaypoints.TabIndex = 0;
			this.chkFileSaveWaypoints.Text = "Waypoints";
			this.chkFileSaveWaypoints.UseVisualStyleBackColor = true;
			// 
			// pnlClipboard
			// 
			this.pnlClipboard.Controls.Add(this.groupBox1);
			this.pnlClipboard.Controls.Add(this.groupBox2);
			this.pnlClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.pnlClipboard.Location = new System.Drawing.Point(478, 153);
			this.pnlClipboard.Name = "pnlClipboard";
			this.pnlClipboard.Size = new System.Drawing.Size(466, 342);
			this.pnlClipboard.TabIndex = 6;
			this.pnlClipboard.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnClipboardApply);
			this.groupBox1.Controls.Add(this.btnClipboardLoad);
			this.groupBox1.Controls.Add(this.chkClipLoadMFDs);
			this.groupBox1.Controls.Add(this.chkClipLoadRadios);
			this.groupBox1.Controls.Add(this.chkClipLoadCMS);
			this.groupBox1.Controls.Add(this.chkClipLoadWaypoints);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.groupBox1.Location = new System.Drawing.Point(16, 17);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(205, 306);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Load from Clipboard";
			// 
			// btnClipboardApply
			// 
			this.btnClipboardApply.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnClipboardApply.Enabled = false;
			this.btnClipboardApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClipboardApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnClipboardApply.Location = new System.Drawing.Point(18, 247);
			this.btnClipboardApply.Name = "btnClipboardApply";
			this.btnClipboardApply.Size = new System.Drawing.Size(150, 40);
			this.btnClipboardApply.TabIndex = 0;
			this.btnClipboardApply.Text = "Apply";
			this.btnClipboardApply.UseVisualStyleBackColor = false;
			this.btnClipboardApply.Click += new System.EventHandler(this.btnClipboardApply_Click);
			// 
			// btnClipboardLoad
			// 
			this.btnClipboardLoad.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnClipboardLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClipboardLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnClipboardLoad.Location = new System.Drawing.Point(18, 36);
			this.btnClipboardLoad.Name = "btnClipboardLoad";
			this.btnClipboardLoad.Size = new System.Drawing.Size(150, 40);
			this.btnClipboardLoad.TabIndex = 0;
			this.btnClipboardLoad.Text = "Load";
			this.btnClipboardLoad.UseVisualStyleBackColor = false;
			this.btnClipboardLoad.Click += new System.EventHandler(this.btnClipboardLoad_Click);
			// 
			// chkClipLoadMFDs
			// 
			this.chkClipLoadMFDs.AutoSize = true;
			this.chkClipLoadMFDs.Enabled = false;
			this.chkClipLoadMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkClipLoadMFDs.Location = new System.Drawing.Point(18, 180);
			this.chkClipLoadMFDs.Name = "chkClipLoadMFDs";
			this.chkClipLoadMFDs.Size = new System.Drawing.Size(71, 24);
			this.chkClipLoadMFDs.TabIndex = 0;
			this.chkClipLoadMFDs.Text = "MFDs";
			this.chkClipLoadMFDs.UseVisualStyleBackColor = true;
			// 
			// chkClipLoadRadios
			// 
			this.chkClipLoadRadios.AutoSize = true;
			this.chkClipLoadRadios.Enabled = false;
			this.chkClipLoadRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkClipLoadRadios.Location = new System.Drawing.Point(18, 151);
			this.chkClipLoadRadios.Name = "chkClipLoadRadios";
			this.chkClipLoadRadios.Size = new System.Drawing.Size(78, 24);
			this.chkClipLoadRadios.TabIndex = 0;
			this.chkClipLoadRadios.Text = "Radios";
			this.chkClipLoadRadios.UseVisualStyleBackColor = true;
			// 
			// chkClipLoadCMS
			// 
			this.chkClipLoadCMS.AutoSize = true;
			this.chkClipLoadCMS.Enabled = false;
			this.chkClipLoadCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkClipLoadCMS.Location = new System.Drawing.Point(18, 122);
			this.chkClipLoadCMS.Name = "chkClipLoadCMS";
			this.chkClipLoadCMS.Size = new System.Drawing.Size(63, 24);
			this.chkClipLoadCMS.TabIndex = 0;
			this.chkClipLoadCMS.Text = "CMS";
			this.chkClipLoadCMS.UseVisualStyleBackColor = true;
			// 
			// chkClipLoadWaypoints
			// 
			this.chkClipLoadWaypoints.AutoSize = true;
			this.chkClipLoadWaypoints.Enabled = false;
			this.chkClipLoadWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkClipLoadWaypoints.Location = new System.Drawing.Point(18, 93);
			this.chkClipLoadWaypoints.Name = "chkClipLoadWaypoints";
			this.chkClipLoadWaypoints.Size = new System.Drawing.Size(102, 24);
			this.chkClipLoadWaypoints.TabIndex = 0;
			this.chkClipLoadWaypoints.Text = "Waypoints";
			this.chkClipLoadWaypoints.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnClipboardSave);
			this.groupBox2.Controls.Add(this.chkClipSaveMFDs);
			this.groupBox2.Controls.Add(this.chkClipSaveRadios);
			this.groupBox2.Controls.Add(this.chkClipSaveCMS);
			this.groupBox2.Controls.Add(this.chkClipSaveWaypoints);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.groupBox2.Location = new System.Drawing.Point(243, 17);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(203, 306);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Save to Clipboard";
			// 
			// btnClipboardSave
			// 
			this.btnClipboardSave.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnClipboardSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClipboardSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnClipboardSave.Location = new System.Drawing.Point(18, 247);
			this.btnClipboardSave.Name = "btnClipboardSave";
			this.btnClipboardSave.Size = new System.Drawing.Size(150, 40);
			this.btnClipboardSave.TabIndex = 0;
			this.btnClipboardSave.Text = "Copy";
			this.btnClipboardSave.UseVisualStyleBackColor = false;
			this.btnClipboardSave.Click += new System.EventHandler(this.btnClipboardSave_Click);
			// 
			// chkClipSaveMFDs
			// 
			this.chkClipSaveMFDs.AutoSize = true;
			this.chkClipSaveMFDs.Checked = true;
			this.chkClipSaveMFDs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkClipSaveMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkClipSaveMFDs.Location = new System.Drawing.Point(18, 123);
			this.chkClipSaveMFDs.Name = "chkClipSaveMFDs";
			this.chkClipSaveMFDs.Size = new System.Drawing.Size(71, 24);
			this.chkClipSaveMFDs.TabIndex = 0;
			this.chkClipSaveMFDs.Text = "MFDs";
			this.chkClipSaveMFDs.UseVisualStyleBackColor = true;
			// 
			// chkClipSaveRadios
			// 
			this.chkClipSaveRadios.AutoSize = true;
			this.chkClipSaveRadios.Checked = true;
			this.chkClipSaveRadios.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkClipSaveRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkClipSaveRadios.Location = new System.Drawing.Point(18, 94);
			this.chkClipSaveRadios.Name = "chkClipSaveRadios";
			this.chkClipSaveRadios.Size = new System.Drawing.Size(78, 24);
			this.chkClipSaveRadios.TabIndex = 0;
			this.chkClipSaveRadios.Text = "Radios";
			this.chkClipSaveRadios.UseVisualStyleBackColor = true;
			// 
			// chkClipSaveCMS
			// 
			this.chkClipSaveCMS.AutoSize = true;
			this.chkClipSaveCMS.Checked = true;
			this.chkClipSaveCMS.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkClipSaveCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkClipSaveCMS.Location = new System.Drawing.Point(18, 65);
			this.chkClipSaveCMS.Name = "chkClipSaveCMS";
			this.chkClipSaveCMS.Size = new System.Drawing.Size(63, 24);
			this.chkClipSaveCMS.TabIndex = 0;
			this.chkClipSaveCMS.Text = "CMS";
			this.chkClipSaveCMS.UseVisualStyleBackColor = true;
			// 
			// chkClipSaveWaypoints
			// 
			this.chkClipSaveWaypoints.AutoSize = true;
			this.chkClipSaveWaypoints.Checked = true;
			this.chkClipSaveWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkClipSaveWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.chkClipSaveWaypoints.Location = new System.Drawing.Point(18, 36);
			this.chkClipSaveWaypoints.Name = "chkClipSaveWaypoints";
			this.chkClipSaveWaypoints.Size = new System.Drawing.Size(102, 24);
			this.chkClipSaveWaypoints.TabIndex = 0;
			this.chkClipSaveWaypoints.Text = "Waypoints";
			this.chkClipSaveWaypoints.UseVisualStyleBackColor = true;
			// 
			// LoadSavePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.Controls.Add(this.pnlClipboard);
			this.Controls.Add(this.pnlFile);
			this.Controls.Add(this.panel1);
			this.Name = "LoadSavePage";
			this.Size = new System.Drawing.Size(1006, 756);
			this.panel1.ResumeLayout(false);
			this.pnlFile.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.pnlClipboard.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnlFile;
		private DTC.UI.Controls.DTCGroupBox groupBox3;
		private DTCButton btnFileApply;
		private DTCButton btnFileLoad;
		private System.Windows.Forms.CheckBox chkFileLoadMFDs;
		private System.Windows.Forms.CheckBox chkFileLoadRadios;
		private System.Windows.Forms.CheckBox chkFileLoadCMS;
		private System.Windows.Forms.CheckBox chkFileLoadWaypoints;
		private DTC.UI.Controls.DTCGroupBox groupBox4;
		private DTCButton btnFileSave;
		private System.Windows.Forms.CheckBox chkFileSaveMFDs;
		private System.Windows.Forms.CheckBox chkFileSaveRadios;
		private System.Windows.Forms.CheckBox chkFileSaveCMS;
		private System.Windows.Forms.CheckBox chkFileSaveWaypoints;
		private System.Windows.Forms.Panel pnlClipboard;
		private DTC.UI.Controls.DTCGroupBox groupBox1;
		private DTCButton btnClipboardApply;
		private DTCButton btnClipboardLoad;
		private System.Windows.Forms.CheckBox chkClipLoadMFDs;
		private System.Windows.Forms.CheckBox chkClipLoadRadios;
		private System.Windows.Forms.CheckBox chkClipLoadCMS;
		private System.Windows.Forms.CheckBox chkClipLoadWaypoints;
		private DTC.UI.Controls.DTCGroupBox groupBox2;
		private DTCButton btnClipboardSave;
		private System.Windows.Forms.CheckBox chkClipSaveMFDs;
		private System.Windows.Forms.CheckBox chkClipSaveRadios;
		private System.Windows.Forms.CheckBox chkClipSaveCMS;
		private System.Windows.Forms.CheckBox chkClipSaveWaypoints;
		private DTCButton btnFile;
		private DTCButton btnClipboard;
	}
}
