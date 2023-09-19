namespace CommunicationServerWinForm
{
    partial class Form1
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
            this.chkCommunicationEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkCommunicationEnabled
            // 
            this.chkCommunicationEnabled.AutoSize = true;
            this.chkCommunicationEnabled.Location = new System.Drawing.Point(81, 26);
            this.chkCommunicationEnabled.Name = "chkCommunicationEnabled";
            this.chkCommunicationEnabled.Size = new System.Drawing.Size(140, 17);
            this.chkCommunicationEnabled.TabIndex = 0;
            this.chkCommunicationEnabled.Text = "Communication Enabled";
            this.chkCommunicationEnabled.UseVisualStyleBackColor = true;
            this.chkCommunicationEnabled.CheckedChanged += new System.EventHandler(this.chkCommunicationEnabled_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 515);
            this.Controls.Add(this.chkCommunicationEnabled);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCommunicationEnabled;
    }
}

