namespace PRCOApp
{
    partial class ipPopup
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
            this.ipSubmit = new System.Windows.Forms.Button();
            this.iptxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipSubmit
            // 
            this.ipSubmit.Location = new System.Drawing.Point(59, 55);
            this.ipSubmit.Name = "ipSubmit";
            this.ipSubmit.Size = new System.Drawing.Size(75, 23);
            this.ipSubmit.TabIndex = 0;
            this.ipSubmit.Text = "Connect";
            this.ipSubmit.UseVisualStyleBackColor = true;
            this.ipSubmit.Click += new System.EventHandler(this.ipSubmit_Click);
            // 
            // iptxtBox
            // 
            this.iptxtBox.Location = new System.Drawing.Point(46, 29);
            this.iptxtBox.Name = "iptxtBox";
            this.iptxtBox.Size = new System.Drawing.Size(100, 20);
            this.iptxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Database IP:";
            // 
            // ipPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 98);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iptxtBox);
            this.Controls.Add(this.ipSubmit);
            this.Name = "ipPopup";
            this.Text = "Specify IP!";
            this.Load += new System.EventHandler(this.ipPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ipSubmit;
        private System.Windows.Forms.TextBox iptxtBox;
        private System.Windows.Forms.Label label1;
    }
}