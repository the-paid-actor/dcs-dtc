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
        btnC130 = new Button();
        btnA10 = new Button();
        btnCH47F = new Button();
        btnAV8B = new Button();
        SuspendLayout();
        // 
        // btnF16
        // 
        btnF16.BackgroundImage = Properties.Resources.F16;
        btnF16.BackgroundImageLayout = ImageLayout.Zoom;
        btnF16.FlatStyle = FlatStyle.Flat;
        btnF16.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnF16.ForeColor = Color.Black;
        btnF16.Location = new Point(23, 14);
        btnF16.Name = "btnF16";
        btnF16.Padding = new Padding(5);
        btnF16.Size = new Size(175, 112);
        btnF16.TabIndex = 3;
        btnF16.Text = "F-16CM Viper";
        btnF16.TextAlign = ContentAlignment.TopLeft;
        btnF16.UseVisualStyleBackColor = true;
        btnF16.Click += btnF16_Click;
        // 
        // btnF18
        // 
        btnF18.BackgroundImage = Properties.Resources.FA18;
        btnF18.BackgroundImageLayout = ImageLayout.Zoom;
        btnF18.FlatStyle = FlatStyle.Flat;
        btnF18.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnF18.ForeColor = Color.Black;
        btnF18.Location = new Point(204, 14);
        btnF18.Name = "btnF18";
        btnF18.Padding = new Padding(5);
        btnF18.Size = new Size(175, 112);
        btnF18.TabIndex = 3;
        btnF18.Text = "F/A-18C Hornet";
        btnF18.TextAlign = ContentAlignment.TopLeft;
        btnF18.UseVisualStyleBackColor = true;
        btnF18.Click += btnF18_Click;
        // 
        // btnAH64
        // 
        btnAH64.BackgroundImage = Properties.Resources.AH64;
        btnAH64.BackgroundImageLayout = ImageLayout.Zoom;
        btnAH64.FlatStyle = FlatStyle.Flat;
        btnAH64.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnAH64.ForeColor = Color.Black;
        btnAH64.Location = new Point(566, 14);
        btnAH64.Name = "btnAH64";
        btnAH64.Padding = new Padding(5);
        btnAH64.Size = new Size(175, 112);
        btnAH64.TabIndex = 5;
        btnAH64.Text = "AH-64D Apache Longbow";
        btnAH64.TextAlign = ContentAlignment.TopLeft;
        btnAH64.UseVisualStyleBackColor = true;
        btnAH64.Click += btnAH64_Click;
        // 
        // btnF15E
        // 
        btnF15E.BackgroundImage = Properties.Resources.F15E;
        btnF15E.BackgroundImageLayout = ImageLayout.Zoom;
        btnF15E.FlatStyle = FlatStyle.Flat;
        btnF15E.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnF15E.ForeColor = Color.Black;
        btnF15E.Location = new Point(385, 14);
        btnF15E.Name = "btnF15E";
        btnF15E.Padding = new Padding(5);
        btnF15E.Size = new Size(175, 112);
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
        btnWptDatabase.Location = new Point(109, 363);
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
        // btnC130
        // 
        btnC130.BackgroundImage = Properties.Resources.C130J;
        btnC130.BackgroundImageLayout = ImageLayout.Stretch;
        btnC130.FlatStyle = FlatStyle.Flat;
        btnC130.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnC130.ForeColor = Color.Black;
        btnC130.Location = new Point(23, 132);
        btnC130.Name = "btnC130";
        btnC130.Padding = new Padding(5);
        btnC130.Size = new Size(175, 112);
        btnC130.TabIndex = 6;
        btnC130.Text = "C-130J Hercules";
        btnC130.TextAlign = ContentAlignment.TopLeft;
        btnC130.UseVisualStyleBackColor = true;
        btnC130.Click += btnC130_Click;
        // 
        // btnA10
        // 
        btnA10.BackgroundImage = Properties.Resources.A10;
        btnA10.BackgroundImageLayout = ImageLayout.Stretch;
        btnA10.FlatStyle = FlatStyle.Flat;
        btnA10.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnA10.ForeColor = Color.Black;
        btnA10.Location = new Point(204, 132);
        btnA10.Name = "btnA10";
        btnA10.Padding = new Padding(5);
        btnA10.Size = new Size(175, 112);
        btnA10.TabIndex = 7;
        btnA10.Text = "A-10C II Tank Killer";
        btnA10.TextAlign = ContentAlignment.TopLeft;
        btnA10.UseVisualStyleBackColor = true;
        btnA10.Click += btnA10_Click;
        // 
        // btnCH47F
        // 
        btnCH47F.BackgroundImage = Properties.Resources.CH_47F_2;
        btnCH47F.BackgroundImageLayout = ImageLayout.Stretch;
        btnCH47F.FlatStyle = FlatStyle.Flat;
        btnCH47F.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnCH47F.ForeColor = Color.Black;
        btnCH47F.Location = new Point(385, 132);
        btnCH47F.Name = "btnCH47F";
        btnCH47F.Padding = new Padding(5);
        btnCH47F.Size = new Size(175, 112);
        btnCH47F.TabIndex = 8;
        btnCH47F.Text = "CH-47F Chinook";
        btnCH47F.TextAlign = ContentAlignment.TopLeft;
        btnCH47F.UseVisualStyleBackColor = true;
        btnCH47F.Click += btnCH47F_Click;
        // 
        // btnAV8B
        // 
        btnAV8B.BackgroundImage = Properties.Resources.harrier3;
        btnAV8B.BackgroundImageLayout = ImageLayout.Stretch;
        btnAV8B.FlatStyle = FlatStyle.Flat;
        btnAV8B.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnAV8B.ForeColor = Color.Black;
        btnAV8B.Location = new Point(566, 132);
        btnAV8B.Name = "btnAV8B";
        btnAV8B.Padding = new Padding(5);
        btnAV8B.Size = new Size(175, 112);
        btnAV8B.TabIndex = 9;
        btnAV8B.Text = "AV-8B N/A Harrier";
        btnAV8B.TextAlign = ContentAlignment.TopLeft;
        btnAV8B.UseVisualStyleBackColor = true;
        btnAV8B.Click += btnAV8B_Click;
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
        Controls.Add(btnC130);
        Controls.Add(btnA10);
        Controls.Add(btnCH47F);
        Controls.Add(btnAV8B);
        Controls.Add(btnWptDatabase);
        Name = "MainPage";
        Size = new Size(795, 403);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button btnF16;
    private System.Windows.Forms.Button btnF18;
    private System.Windows.Forms.Button btnF15E;
    private System.Windows.Forms.Button btnWptDatabase;
    private System.Windows.Forms.Button btnAH64;
    private System.Windows.Forms.Button btnC130;
    private System.Windows.Forms.Button btnA10;
    private System.Windows.Forms.Button btnCH47F;
    private System.Windows.Forms.Button btnAV8B;
}