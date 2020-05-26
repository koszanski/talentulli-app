namespace PRCOApp
{
    partial class mainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.startBtn = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.homeBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gamemodeDropdown = new System.Windows.Forms.ComboBox();
            this.sessionstartBtn = new System.Windows.Forms.Button();
            this.loginLbl = new System.Windows.Forms.Label();
            this.teamDropdown = new System.Windows.Forms.ComboBox();
            this.panelSidebar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.DarkRed;
            this.panelSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSidebar.Controls.Add(this.startBtn);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 768);
            this.panelSidebar.TabIndex = 0;
            // 
            // startBtn
            // 
            this.startBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.startBtn.FlatAppearance.BorderSize = 4;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.startBtn.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.startBtn.IconColor = System.Drawing.Color.Black;
            this.startBtn.IconSize = 64;
            this.startBtn.Location = new System.Drawing.Point(0, 194);
            this.startBtn.Name = "startBtn";
            this.startBtn.Rotation = 0D;
            this.startBtn.Size = new System.Drawing.Size(218, 87);
            this.startBtn.TabIndex = 1;
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.homeBtn);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(218, 194);
            this.panelLogo.TabIndex = 0;
            // 
            // homeBtn
            // 
            this.homeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeBtn.FlatAppearance.BorderSize = 4;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Image = global::PRCOApp.Properties.Resources.logo200x200;
            this.homeBtn.Location = new System.Drawing.Point(0, 0);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(218, 194);
            this.homeBtn.TabIndex = 0;
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PRCOApp.Properties.Resources.typefacelogo200px;
            this.pictureBox1.Location = new System.Drawing.Point(225, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 80);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // gamemodeDropdown
            // 
            this.gamemodeDropdown.FormattingEnabled = true;
            this.gamemodeDropdown.Location = new System.Drawing.Point(681, 287);
            this.gamemodeDropdown.Name = "gamemodeDropdown";
            this.gamemodeDropdown.Size = new System.Drawing.Size(247, 21);
            this.gamemodeDropdown.TabIndex = 3;
            // 
            // sessionstartBtn
            // 
            this.sessionstartBtn.Location = new System.Drawing.Point(768, 314);
            this.sessionstartBtn.Name = "sessionstartBtn";
            this.sessionstartBtn.Size = new System.Drawing.Size(75, 23);
            this.sessionstartBtn.TabIndex = 4;
            this.sessionstartBtn.Text = "Start";
            this.sessionstartBtn.UseVisualStyleBackColor = true;
            this.sessionstartBtn.Click += new System.EventHandler(this.sessionstartBtn_Click);
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Roboto Medium", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLbl.Location = new System.Drawing.Point(676, 25);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(66, 25);
            this.loginLbl.TabIndex = 5;
            this.loginLbl.Text = "NULL";
            // 
            // teamDropdown
            // 
            this.teamDropdown.FormattingEnabled = true;
            this.teamDropdown.Location = new System.Drawing.Point(681, 261);
            this.teamDropdown.Name = "teamDropdown";
            this.teamDropdown.Size = new System.Drawing.Size(247, 21);
            this.teamDropdown.TabIndex = 6;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.teamDropdown);
            this.Controls.Add(this.loginLbl);
            this.Controls.Add(this.sessionstartBtn);
            this.Controls.Add(this.gamemodeDropdown);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.Text = "talentulli";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton startBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox gamemodeDropdown;
        private System.Windows.Forms.Button sessionstartBtn;
        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.ComboBox teamDropdown;
    }
}