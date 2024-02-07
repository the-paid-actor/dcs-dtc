namespace DTC.New.UI.Base.Pages;

partial class MainPage
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
        btnF16 = new Button();
        btnF18 = new Button();
        btnAH64 = new Button();
        btnF15E = new Button();
        btnWptDatabase = new Button();
        SuspendLayout();
        // 
        // btnF16
        // 
        btnF16.FlatStyle = FlatStyle.Flat;
        btnF16.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnF16.ForeColor = Color.Black;
        btnF16.Image = Properties.Resources.F16;
        btnF16.Location = new Point(23, 14);
        btnF16.Name = "btnF16";
        btnF16.Padding = new Padding(5);
        btnF16.Size = new Size(226, 150);
        btnF16.TabIndex = 3;
        btnF16.Text = "F-16CM Viper";
        btnF16.TextAlign = ContentAlignment.TopLeft;
        btnF16.UseVisualStyleBackColor = true;
        btnF16.Click += btnF16_Click;
        // 
        // btnF18
        // 
        btnF18.FlatStyle = FlatStyle.Flat;
        btnF18.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnF18.ForeColor = Color.Black;
        btnF18.Image = Properties.Resources.FA18;
        btnF18.Location = new Point(272, 14);
        btnF18.Name = "btnF18";
        btnF18.Padding = new Padding(5);
        btnF18.Size = new Size(226, 150);
        btnF18.TabIndex = 3;
        btnF18.Text = "F/A-18C Hornet";
        btnF18.TextAlign = ContentAlignment.TopLeft;
        btnF18.UseVisualStyleBackColor = true;
        btnF18.Click += btnF18_Click;
        // 
        // btnAH64
        // 
        btnAH64.FlatStyle = FlatStyle.Flat;
        btnAH64.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnAH64.ForeColor = Color.Black;
        btnAH64.Image = Properties.Resources.AH64;
        btnAH64.Location = new Point(23, 189);
        btnAH64.Name = "btnAH64";
        btnAH64.Padding = new Padding(5);
        btnAH64.Size = new Size(226, 150);
        btnAH64.TabIndex = 5;
        btnAH64.Text = "AH-64D Apache Longbow";
        btnAH64.TextAlign = ContentAlignment.TopLeft;
        btnAH64.UseVisualStyleBackColor = true;
        btnAH64.Click += btnAH64_Click;
        // 
        // btnF15E
        // 
        btnF15E.FlatStyle = FlatStyle.Flat;
        btnF15E.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnF15E.ForeColor = Color.Black;
        btnF15E.Image = Properties.Resources.F15E;
        btnF15E.Location = new Point(521, 14);
        btnF15E.Name = "btnF15E";
        btnF15E.Padding = new Padding(5);
        btnF15E.Size = new Size(226, 150);
        btnF15E.TabIndex = 5;
        btnF15E.Text = "F-15E Strike Eagle";
        btnF15E.TextAlign = ContentAlignment.TopLeft;
        btnF15E.UseVisualStyleBackColor = true;
        btnF15E.Click += btnF15E_Click;
        // 
        // btnWptDatabase
        // 
        btnWptDatabase.FlatStyle = FlatStyle.Flat;
        btnWptDatabase.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
        btnWptDatabase.ForeColor = Color.Black;
        btnWptDatabase.Image = Properties.Resources.Waypoints;
        btnWptDatabase.Location = new Point(510, 300);
        btnWptDatabase.Name = "btnWptDatabase";
        btnWptDatabase.Padding = new Padding(5);
        btnWptDatabase.Size = new Size(200, 100);
        btnWptDatabase.TabIndex = 4;
        btnWptDatabase.Text = "Waypoints Database";
        btnWptDatabase.TextAlign = ContentAlignment.TopLeft;
        btnWptDatabase.UseVisualStyleBackColor = true;
        btnWptDatabase.Visible = false;
        btnWptDatabase.Click += btnWptDatabase_Click;
        // 
        // MainPage
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScroll = true;
        BackColor = Color.PaleGoldenrod;
        Controls.Add(btnF16);
        Controls.Add(btnF18);
        Controls.Add(btnAH64);
        Controls.Add(btnF15E);
        Controls.Add(btnWptDatabase);
        Name = "MainPage";
        Size = new Size(770, 434);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button btnF16;
    private System.Windows.Forms.Button btnF18;
    private System.Windows.Forms.Button btnF15E;
    private System.Windows.Forms.Button btnWptDatabase;
    private System.Windows.Forms.Button btnAH64;
}