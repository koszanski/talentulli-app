namespace PRCOApp
{
    partial class completesessionForm
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
            this.stattypeDropdown = new System.Windows.Forms.ComboBox();
            this.currentvalTxt = new System.Windows.Forms.Label();
            this.desiredvalTxt = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stattypeDropdown
            // 
            this.stattypeDropdown.FormattingEnabled = true;
            this.stattypeDropdown.Location = new System.Drawing.Point(120, 99);
            this.stattypeDropdown.Name = "stattypeDropdown";
            this.stattypeDropdown.Size = new System.Drawing.Size(174, 21);
            this.stattypeDropdown.TabIndex = 0;
            // 
            // currentvalTxt
            // 
            this.currentvalTxt.AutoSize = true;
            this.currentvalTxt.Location = new System.Drawing.Point(133, 134);
            this.currentvalTxt.Name = "currentvalTxt";
            this.currentvalTxt.Size = new System.Drawing.Size(104, 13);
            this.currentvalTxt.TabIndex = 1;
            this.currentvalTxt.Text = "Save to a value first!";
            // 
            // desiredvalTxt
            // 
            this.desiredvalTxt.Location = new System.Drawing.Point(120, 150);
            this.desiredvalTxt.Name = "desiredvalTxt";
            this.desiredvalTxt.Size = new System.Drawing.Size(174, 20);
            this.desiredvalTxt.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(120, 196);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(214, 196);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(80, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(120, 242);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(174, 23);
            this.submitBtn.TabIndex = 5;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // completesessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(431, 409);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.desiredvalTxt);
            this.Controls.Add(this.currentvalTxt);
            this.Controls.Add(this.stattypeDropdown);
            this.Name = "completesessionForm";
            this.Text = "Session Submission";
            this.Load += new System.EventHandler(this.completesessionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox stattypeDropdown;
        private System.Windows.Forms.Label currentvalTxt;
        private System.Windows.Forms.TextBox desiredvalTxt;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button submitBtn;
    }
}