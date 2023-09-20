namespace GCS.AssaAbloyTestApp
{
    partial class ucTimePeriodListViewControl
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
            this.lbTimePeriods = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbTimePeriods
            // 
            this.lbTimePeriods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTimePeriods.FormattingEnabled = true;
            this.lbTimePeriods.Location = new System.Drawing.Point(0, 0);
            this.lbTimePeriods.Name = "lbTimePeriods";
            this.lbTimePeriods.Size = new System.Drawing.Size(164, 115);
            this.lbTimePeriods.TabIndex = 46;
            // 
            // ucTimePeriodListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTimePeriods);
            this.Name = "ucTimePeriodListViewControl";
            this.Size = new System.Drawing.Size(164, 115);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTimePeriods;
    }
}
