
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
            this.btnCombatFlite = new DTC.UI.Base.Controls.DTCButton();
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
            this.pnlCombatFlite = new System.Windows.Forms.Panel();
            this.dtcGroupBox1 = new DTC.UI.Controls.DTCGroupBox();
            this.btnCombatFliteApply = new DTC.UI.Base.Controls.DTCButton();
            this.dtcButton2 = new DTC.UI.Base.Controls.DTCButton();
            this.chkCombatFliteLoadWpts = new System.Windows.Forms.CheckBox();
            this.dtcGroupBox2 = new DTC.UI.Controls.DTCGroupBox();
            this.btnCombatFliteSave = new DTC.UI.Base.Controls.DTCButton();
            this.chkCombatFliteMFDs = new System.Windows.Forms.CheckBox();
            this.chkCombatFliteRadios = new System.Windows.Forms.CheckBox();
            this.chkCombatFliteCMS = new System.Windows.Forms.CheckBox();
            this.chkCombatFliteWaypoints = new System.Windows.Forms.CheckBox();
            this.lblCombatFliteXMLHelp = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlFile.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlClipboard.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlCombatFlite.SuspendLayout();
            this.dtcGroupBox1.SuspendLayout();
            this.dtcGroupBox2.SuspendLayout();
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
            this.panel1.Controls.Add(this.btnCombatFlite);
            this.panel1.Controls.Add(this.btnClipboard);
            this.panel1.Controls.Add(this.btnFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1730, 77);
            this.panel1.TabIndex = 4;
            // 
            // btnCombatFlite
            // 
            this.btnCombatFlite.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCombatFlite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCombatFlite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCombatFlite.Location = new System.Drawing.Point(470, 8);
            this.btnCombatFlite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCombatFlite.Name = "btnCombatFlite";
            this.btnCombatFlite.Size = new System.Drawing.Size(225, 62);
            this.btnCombatFlite.TabIndex = 2;
            this.btnCombatFlite.Text = "Combat Flite";
            this.btnCombatFlite.UseVisualStyleBackColor = false;
            this.btnCombatFlite.Click += new System.EventHandler(this.btnCombatFlite_Click);
            // 
            // btnClipboard
            // 
            this.btnClipboard.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClipboard.Location = new System.Drawing.Point(237, 8);
            this.btnClipboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(225, 62);
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
            this.btnFile.Location = new System.Drawing.Point(8, 8);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(225, 62);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "File";
            this.btnFile.UseVisualStyleBackColor = false;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // pnlFile
            // 
            this.pnlFile.Controls.Add(this.groupBox3);
            this.pnlFile.Controls.Add(this.groupBox4);
            this.pnlFile.Location = new System.Drawing.Point(8, 87);
            this.pnlFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(704, 526);
            this.pnlFile.TabIndex = 5;
            this.pnlFile.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BorderColor = System.Drawing.Color.Black;
            this.groupBox3.BorderRadius = 5;
            this.groupBox3.BorderWidth = 2;
            this.groupBox3.Controls.Add(this.btnFileApply);
            this.groupBox3.Controls.Add(this.btnFileLoad);
            this.groupBox3.Controls.Add(this.chkFileLoadMFDs);
            this.groupBox3.Controls.Add(this.chkFileLoadRadios);
            this.groupBox3.Controls.Add(this.chkFileLoadCMS);
            this.groupBox3.Controls.Add(this.chkFileLoadWaypoints);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.LabelIndent = 10;
            this.groupBox3.Location = new System.Drawing.Point(24, 26);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(308, 471);
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
            this.btnFileApply.Location = new System.Drawing.Point(27, 380);
            this.btnFileApply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFileApply.Name = "btnFileApply";
            this.btnFileApply.Size = new System.Drawing.Size(225, 62);
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
            this.btnFileLoad.Location = new System.Drawing.Point(27, 55);
            this.btnFileLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFileLoad.Name = "btnFileLoad";
            this.btnFileLoad.Size = new System.Drawing.Size(225, 62);
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
            this.chkFileLoadMFDs.Location = new System.Drawing.Point(27, 277);
            this.chkFileLoadMFDs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFileLoadMFDs.Name = "chkFileLoadMFDs";
            this.chkFileLoadMFDs.Size = new System.Drawing.Size(103, 33);
            this.chkFileLoadMFDs.TabIndex = 0;
            this.chkFileLoadMFDs.Text = "MFDs";
            this.chkFileLoadMFDs.UseVisualStyleBackColor = true;
            // 
            // chkFileLoadRadios
            // 
            this.chkFileLoadRadios.AutoSize = true;
            this.chkFileLoadRadios.Enabled = false;
            this.chkFileLoadRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkFileLoadRadios.Location = new System.Drawing.Point(27, 232);
            this.chkFileLoadRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFileLoadRadios.Name = "chkFileLoadRadios";
            this.chkFileLoadRadios.Size = new System.Drawing.Size(115, 33);
            this.chkFileLoadRadios.TabIndex = 0;
            this.chkFileLoadRadios.Text = "Radios";
            this.chkFileLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkFileLoadCMS
            // 
            this.chkFileLoadCMS.AutoSize = true;
            this.chkFileLoadCMS.Enabled = false;
            this.chkFileLoadCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkFileLoadCMS.Location = new System.Drawing.Point(27, 188);
            this.chkFileLoadCMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFileLoadCMS.Name = "chkFileLoadCMS";
            this.chkFileLoadCMS.Size = new System.Drawing.Size(92, 33);
            this.chkFileLoadCMS.TabIndex = 0;
            this.chkFileLoadCMS.Text = "CMS";
            this.chkFileLoadCMS.UseVisualStyleBackColor = true;
            // 
            // chkFileLoadWaypoints
            // 
            this.chkFileLoadWaypoints.AutoSize = true;
            this.chkFileLoadWaypoints.Enabled = false;
            this.chkFileLoadWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkFileLoadWaypoints.Location = new System.Drawing.Point(27, 143);
            this.chkFileLoadWaypoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFileLoadWaypoints.Name = "chkFileLoadWaypoints";
            this.chkFileLoadWaypoints.Size = new System.Drawing.Size(150, 33);
            this.chkFileLoadWaypoints.TabIndex = 0;
            this.chkFileLoadWaypoints.Text = "Waypoints";
            this.chkFileLoadWaypoints.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BorderColor = System.Drawing.Color.Black;
            this.groupBox4.BorderRadius = 5;
            this.groupBox4.BorderWidth = 2;
            this.groupBox4.Controls.Add(this.btnFileSave);
            this.groupBox4.Controls.Add(this.chkFileSaveMFDs);
            this.groupBox4.Controls.Add(this.chkFileSaveRadios);
            this.groupBox4.Controls.Add(this.chkFileSaveCMS);
            this.groupBox4.Controls.Add(this.chkFileSaveWaypoints);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox4.LabelIndent = 10;
            this.groupBox4.Location = new System.Drawing.Point(364, 26);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(304, 471);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Save to File";
            // 
            // btnFileSave
            // 
            this.btnFileSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnFileSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFileSave.Location = new System.Drawing.Point(27, 380);
            this.btnFileSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFileSave.Name = "btnFileSave";
            this.btnFileSave.Size = new System.Drawing.Size(225, 62);
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
            this.chkFileSaveMFDs.Location = new System.Drawing.Point(27, 189);
            this.chkFileSaveMFDs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFileSaveMFDs.Name = "chkFileSaveMFDs";
            this.chkFileSaveMFDs.Size = new System.Drawing.Size(103, 33);
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
            this.chkFileSaveRadios.Location = new System.Drawing.Point(27, 145);
            this.chkFileSaveRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFileSaveRadios.Name = "chkFileSaveRadios";
            this.chkFileSaveRadios.Size = new System.Drawing.Size(115, 33);
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
            this.chkFileSaveCMS.Location = new System.Drawing.Point(27, 100);
            this.chkFileSaveCMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFileSaveCMS.Name = "chkFileSaveCMS";
            this.chkFileSaveCMS.Size = new System.Drawing.Size(92, 33);
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
            this.chkFileSaveWaypoints.Location = new System.Drawing.Point(27, 55);
            this.chkFileSaveWaypoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFileSaveWaypoints.Name = "chkFileSaveWaypoints";
            this.chkFileSaveWaypoints.Size = new System.Drawing.Size(150, 33);
            this.chkFileSaveWaypoints.TabIndex = 0;
            this.chkFileSaveWaypoints.Text = "Waypoints";
            this.chkFileSaveWaypoints.UseVisualStyleBackColor = true;
            // 
            // pnlClipboard
            // 
            this.pnlClipboard.Controls.Add(this.groupBox1);
            this.pnlClipboard.Controls.Add(this.groupBox2);
            this.pnlClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pnlClipboard.Location = new System.Drawing.Point(720, 87);
            this.pnlClipboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlClipboard.Name = "pnlClipboard";
            this.pnlClipboard.Size = new System.Drawing.Size(699, 526);
            this.pnlClipboard.TabIndex = 6;
            this.pnlClipboard.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.Black;
            this.groupBox1.BorderRadius = 5;
            this.groupBox1.BorderWidth = 2;
            this.groupBox1.Controls.Add(this.btnClipboardApply);
            this.groupBox1.Controls.Add(this.btnClipboardLoad);
            this.groupBox1.Controls.Add(this.chkClipLoadMFDs);
            this.groupBox1.Controls.Add(this.chkClipLoadRadios);
            this.groupBox1.Controls.Add(this.chkClipLoadCMS);
            this.groupBox1.Controls.Add(this.chkClipLoadWaypoints);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.LabelIndent = 10;
            this.groupBox1.Location = new System.Drawing.Point(24, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(308, 471);
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
            this.btnClipboardApply.Location = new System.Drawing.Point(27, 380);
            this.btnClipboardApply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClipboardApply.Name = "btnClipboardApply";
            this.btnClipboardApply.Size = new System.Drawing.Size(225, 62);
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
            this.btnClipboardLoad.Location = new System.Drawing.Point(27, 55);
            this.btnClipboardLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClipboardLoad.Name = "btnClipboardLoad";
            this.btnClipboardLoad.Size = new System.Drawing.Size(225, 62);
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
            this.chkClipLoadMFDs.Location = new System.Drawing.Point(27, 277);
            this.chkClipLoadMFDs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClipLoadMFDs.Name = "chkClipLoadMFDs";
            this.chkClipLoadMFDs.Size = new System.Drawing.Size(103, 33);
            this.chkClipLoadMFDs.TabIndex = 0;
            this.chkClipLoadMFDs.Text = "MFDs";
            this.chkClipLoadMFDs.UseVisualStyleBackColor = true;
            // 
            // chkClipLoadRadios
            // 
            this.chkClipLoadRadios.AutoSize = true;
            this.chkClipLoadRadios.Enabled = false;
            this.chkClipLoadRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkClipLoadRadios.Location = new System.Drawing.Point(27, 232);
            this.chkClipLoadRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClipLoadRadios.Name = "chkClipLoadRadios";
            this.chkClipLoadRadios.Size = new System.Drawing.Size(115, 33);
            this.chkClipLoadRadios.TabIndex = 0;
            this.chkClipLoadRadios.Text = "Radios";
            this.chkClipLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkClipLoadCMS
            // 
            this.chkClipLoadCMS.AutoSize = true;
            this.chkClipLoadCMS.Enabled = false;
            this.chkClipLoadCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkClipLoadCMS.Location = new System.Drawing.Point(27, 188);
            this.chkClipLoadCMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClipLoadCMS.Name = "chkClipLoadCMS";
            this.chkClipLoadCMS.Size = new System.Drawing.Size(92, 33);
            this.chkClipLoadCMS.TabIndex = 0;
            this.chkClipLoadCMS.Text = "CMS";
            this.chkClipLoadCMS.UseVisualStyleBackColor = true;
            // 
            // chkClipLoadWaypoints
            // 
            this.chkClipLoadWaypoints.AutoSize = true;
            this.chkClipLoadWaypoints.Enabled = false;
            this.chkClipLoadWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkClipLoadWaypoints.Location = new System.Drawing.Point(27, 143);
            this.chkClipLoadWaypoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClipLoadWaypoints.Name = "chkClipLoadWaypoints";
            this.chkClipLoadWaypoints.Size = new System.Drawing.Size(150, 33);
            this.chkClipLoadWaypoints.TabIndex = 0;
            this.chkClipLoadWaypoints.Text = "Waypoints";
            this.chkClipLoadWaypoints.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.Black;
            this.groupBox2.BorderRadius = 5;
            this.groupBox2.BorderWidth = 2;
            this.groupBox2.Controls.Add(this.btnClipboardSave);
            this.groupBox2.Controls.Add(this.chkClipSaveMFDs);
            this.groupBox2.Controls.Add(this.chkClipSaveRadios);
            this.groupBox2.Controls.Add(this.chkClipSaveCMS);
            this.groupBox2.Controls.Add(this.chkClipSaveWaypoints);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.LabelIndent = 10;
            this.groupBox2.Location = new System.Drawing.Point(364, 26);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(304, 471);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save to Clipboard";
            // 
            // btnClipboardSave
            // 
            this.btnClipboardSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnClipboardSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClipboardSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClipboardSave.Location = new System.Drawing.Point(27, 380);
            this.btnClipboardSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClipboardSave.Name = "btnClipboardSave";
            this.btnClipboardSave.Size = new System.Drawing.Size(225, 62);
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
            this.chkClipSaveMFDs.Location = new System.Drawing.Point(27, 189);
            this.chkClipSaveMFDs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClipSaveMFDs.Name = "chkClipSaveMFDs";
            this.chkClipSaveMFDs.Size = new System.Drawing.Size(103, 33);
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
            this.chkClipSaveRadios.Location = new System.Drawing.Point(27, 145);
            this.chkClipSaveRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClipSaveRadios.Name = "chkClipSaveRadios";
            this.chkClipSaveRadios.Size = new System.Drawing.Size(115, 33);
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
            this.chkClipSaveCMS.Location = new System.Drawing.Point(27, 100);
            this.chkClipSaveCMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClipSaveCMS.Name = "chkClipSaveCMS";
            this.chkClipSaveCMS.Size = new System.Drawing.Size(92, 33);
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
            this.chkClipSaveWaypoints.Location = new System.Drawing.Point(27, 55);
            this.chkClipSaveWaypoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkClipSaveWaypoints.Name = "chkClipSaveWaypoints";
            this.chkClipSaveWaypoints.Size = new System.Drawing.Size(150, 33);
            this.chkClipSaveWaypoints.TabIndex = 0;
            this.chkClipSaveWaypoints.Text = "Waypoints";
            this.chkClipSaveWaypoints.UseVisualStyleBackColor = true;
            // 
            // pnlCombatFlite
            // 
            this.pnlCombatFlite.Controls.Add(this.dtcGroupBox1);
            this.pnlCombatFlite.Controls.Add(this.dtcGroupBox2);
            this.pnlCombatFlite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pnlCombatFlite.Location = new System.Drawing.Point(13, 623);
            this.pnlCombatFlite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlCombatFlite.Name = "pnlCombatFlite";
            this.pnlCombatFlite.Size = new System.Drawing.Size(699, 526);
            this.pnlCombatFlite.TabIndex = 7;
            this.pnlCombatFlite.Visible = false;
            // 
            // dtcGroupBox1
            // 
            this.dtcGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.dtcGroupBox1.BorderRadius = 5;
            this.dtcGroupBox1.BorderWidth = 2;
            this.dtcGroupBox1.Controls.Add(this.lblCombatFliteXMLHelp);
            this.dtcGroupBox1.Controls.Add(this.btnCombatFliteApply);
            this.dtcGroupBox1.Controls.Add(this.dtcButton2);
            this.dtcGroupBox1.Controls.Add(this.chkCombatFliteLoadWpts);
            this.dtcGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtcGroupBox1.LabelIndent = 10;
            this.dtcGroupBox1.Location = new System.Drawing.Point(24, 26);
            this.dtcGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtcGroupBox1.Name = "dtcGroupBox1";
            this.dtcGroupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtcGroupBox1.Size = new System.Drawing.Size(308, 471);
            this.dtcGroupBox1.TabIndex = 3;
            this.dtcGroupBox1.TabStop = false;
            this.dtcGroupBox1.Text = "Load from CF XML";
            // 
            // btnCombatFliteApply
            // 
            this.btnCombatFliteApply.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCombatFliteApply.Enabled = false;
            this.btnCombatFliteApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCombatFliteApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCombatFliteApply.Location = new System.Drawing.Point(27, 380);
            this.btnCombatFliteApply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCombatFliteApply.Name = "btnCombatFliteApply";
            this.btnCombatFliteApply.Size = new System.Drawing.Size(225, 62);
            this.btnCombatFliteApply.TabIndex = 0;
            this.btnCombatFliteApply.Text = "Apply";
            this.btnCombatFliteApply.UseVisualStyleBackColor = false;
            this.btnCombatFliteApply.Click += new System.EventHandler(this.btnCombatFliteApply_Click);
            // 
            // dtcButton2
            // 
            this.dtcButton2.BackColor = System.Drawing.Color.DarkKhaki;
            this.dtcButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dtcButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtcButton2.Location = new System.Drawing.Point(27, 55);
            this.dtcButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtcButton2.Name = "dtcButton2";
            this.dtcButton2.Size = new System.Drawing.Size(225, 62);
            this.dtcButton2.TabIndex = 0;
            this.dtcButton2.Text = "Load";
            this.dtcButton2.UseVisualStyleBackColor = false;
            this.dtcButton2.Click += new System.EventHandler(this.btnCombatFliteLoad_Click);
            // 
            // chkCombatFliteLoadWpts
            // 
            this.chkCombatFliteLoadWpts.AutoSize = true;
            this.chkCombatFliteLoadWpts.Checked = true;
            this.chkCombatFliteLoadWpts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCombatFliteLoadWpts.Enabled = false;
            this.chkCombatFliteLoadWpts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkCombatFliteLoadWpts.Location = new System.Drawing.Point(27, 143);
            this.chkCombatFliteLoadWpts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCombatFliteLoadWpts.Name = "chkCombatFliteLoadWpts";
            this.chkCombatFliteLoadWpts.Size = new System.Drawing.Size(150, 33);
            this.chkCombatFliteLoadWpts.TabIndex = 0;
            this.chkCombatFliteLoadWpts.Text = "Waypoints";
            this.chkCombatFliteLoadWpts.UseVisualStyleBackColor = true;
            // 
            // dtcGroupBox2
            // 
            this.dtcGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.dtcGroupBox2.BorderRadius = 5;
            this.dtcGroupBox2.BorderWidth = 2;
            this.dtcGroupBox2.Controls.Add(this.btnCombatFliteSave);
            this.dtcGroupBox2.Controls.Add(this.chkCombatFliteMFDs);
            this.dtcGroupBox2.Controls.Add(this.chkCombatFliteRadios);
            this.dtcGroupBox2.Controls.Add(this.chkCombatFliteCMS);
            this.dtcGroupBox2.Controls.Add(this.chkCombatFliteWaypoints);
            this.dtcGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtcGroupBox2.LabelIndent = 10;
            this.dtcGroupBox2.Location = new System.Drawing.Point(364, 26);
            this.dtcGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtcGroupBox2.Name = "dtcGroupBox2";
            this.dtcGroupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtcGroupBox2.Size = new System.Drawing.Size(304, 471);
            this.dtcGroupBox2.TabIndex = 4;
            this.dtcGroupBox2.TabStop = false;
            this.dtcGroupBox2.Text = "Save to File";
            // 
            // btnCombatFliteSave
            // 
            this.btnCombatFliteSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCombatFliteSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCombatFliteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCombatFliteSave.Location = new System.Drawing.Point(22, 380);
            this.btnCombatFliteSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCombatFliteSave.Name = "btnCombatFliteSave";
            this.btnCombatFliteSave.Size = new System.Drawing.Size(225, 62);
            this.btnCombatFliteSave.TabIndex = 1;
            this.btnCombatFliteSave.Text = "Save";
            this.btnCombatFliteSave.UseVisualStyleBackColor = false;
            this.btnCombatFliteSave.Click += new System.EventHandler(this.btnCombatFliteSave_Click);
            // 
            // chkCombatFliteMFDs
            // 
            this.chkCombatFliteMFDs.AutoSize = true;
            this.chkCombatFliteMFDs.Checked = true;
            this.chkCombatFliteMFDs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCombatFliteMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkCombatFliteMFDs.Location = new System.Drawing.Point(27, 187);
            this.chkCombatFliteMFDs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCombatFliteMFDs.Name = "chkCombatFliteMFDs";
            this.chkCombatFliteMFDs.Size = new System.Drawing.Size(103, 33);
            this.chkCombatFliteMFDs.TabIndex = 1;
            this.chkCombatFliteMFDs.Text = "MFDs";
            this.chkCombatFliteMFDs.UseVisualStyleBackColor = true;
            // 
            // chkCombatFliteRadios
            // 
            this.chkCombatFliteRadios.AutoSize = true;
            this.chkCombatFliteRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkCombatFliteRadios.Location = new System.Drawing.Point(27, 143);
            this.chkCombatFliteRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCombatFliteRadios.Name = "chkCombatFliteRadios";
            this.chkCombatFliteRadios.Size = new System.Drawing.Size(115, 33);
            this.chkCombatFliteRadios.TabIndex = 2;
            this.chkCombatFliteRadios.Text = "Radios";
            this.chkCombatFliteRadios.UseVisualStyleBackColor = true;
            // 
            // chkCombatFliteCMS
            // 
            this.chkCombatFliteCMS.AutoSize = true;
            this.chkCombatFliteCMS.Checked = true;
            this.chkCombatFliteCMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCombatFliteCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkCombatFliteCMS.Location = new System.Drawing.Point(27, 98);
            this.chkCombatFliteCMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCombatFliteCMS.Name = "chkCombatFliteCMS";
            this.chkCombatFliteCMS.Size = new System.Drawing.Size(92, 33);
            this.chkCombatFliteCMS.TabIndex = 3;
            this.chkCombatFliteCMS.Text = "CMS";
            this.chkCombatFliteCMS.UseVisualStyleBackColor = true;
            // 
            // chkCombatFliteWaypoints
            // 
            this.chkCombatFliteWaypoints.AutoSize = true;
            this.chkCombatFliteWaypoints.Checked = true;
            this.chkCombatFliteWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCombatFliteWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkCombatFliteWaypoints.Location = new System.Drawing.Point(27, 55);
            this.chkCombatFliteWaypoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCombatFliteWaypoints.Name = "chkCombatFliteWaypoints";
            this.chkCombatFliteWaypoints.Size = new System.Drawing.Size(150, 33);
            this.chkCombatFliteWaypoints.TabIndex = 0;
            this.chkCombatFliteWaypoints.Text = "Waypoints";
            this.chkCombatFliteWaypoints.UseVisualStyleBackColor = true;
            // 
            // lblCombatFliteXMLHelp
            // 
            this.lblCombatFliteXMLHelp.AutoSize = true;
            this.lblCombatFliteXMLHelp.Location = new System.Drawing.Point(22, 191);
            this.lblCombatFliteXMLHelp.MaximumSize = new System.Drawing.Size(240, 0);
            this.lblCombatFliteXMLHelp.Name = "lblCombatFliteXMLHelp";
            this.lblCombatFliteXMLHelp.Size = new System.Drawing.Size(231, 145);
            this.lblCombatFliteXMLHelp.TabIndex = 1;
            this.lblCombatFliteXMLHelp.Text = "CF XML import only supports waypoints. Use File and Clipboard for other component" +
    "s.";
            // 
            // LoadSavePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.pnlCombatFlite);
            this.Controls.Add(this.pnlClipboard);
            this.Controls.Add(this.pnlFile);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoadSavePage";
            this.Size = new System.Drawing.Size(1730, 1163);
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
            this.pnlCombatFlite.ResumeLayout(false);
            this.dtcGroupBox1.ResumeLayout(false);
            this.dtcGroupBox1.PerformLayout();
            this.dtcGroupBox2.ResumeLayout(false);
            this.dtcGroupBox2.PerformLayout();
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
        private DTCButton btnCombatFlite;
        private System.Windows.Forms.Panel pnlCombatFlite;
        private Controls.DTCGroupBox dtcGroupBox1;
        private DTCButton btnCombatFliteApply;
        private DTCButton dtcButton2;
        private System.Windows.Forms.CheckBox chkCombatFliteLoadWpts;
        private Controls.DTCGroupBox dtcGroupBox2;
        private System.Windows.Forms.CheckBox chkCombatFliteWaypoints;
        private DTCButton btnCombatFliteSave;
        private System.Windows.Forms.CheckBox chkCombatFliteMFDs;
        private System.Windows.Forms.CheckBox chkCombatFliteRadios;
        private System.Windows.Forms.CheckBox chkCombatFliteCMS;
        private System.Windows.Forms.Label lblCombatFliteXMLHelp;
    }
}
