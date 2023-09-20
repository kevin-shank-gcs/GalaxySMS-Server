namespace GCS.AssaAbloyTestApp
{
    partial class ucDayExceptionViewControl
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
            this.ucTimePeriodListViewControl = new GCS.AssaAbloyTestApp.ucTimePeriodListViewControl();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucTimePeriodListViewControl
            // 
            this.ucTimePeriodListViewControl.Location = new System.Drawing.Point(6, 75);
            this.ucTimePeriodListViewControl.Name = "ucTimePeriodListViewControl";
            this.ucTimePeriodListViewControl.Size = new System.Drawing.Size(164, 115);
            this.ucTimePeriodListViewControl.TabIndex = 0;
            this.ucTimePeriodListViewControl.TimePeriods = new GCS.AssaAbloyDSR.DSRAccessControlService.TimePeriod[0];
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(3, 24);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(109, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time Periods";
            // 
            // ucDayExceptionViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.ucTimePeriodListViewControl);
            this.Name = "ucDayExceptionViewControl";
            this.Size = new System.Drawing.Size(175, 199);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTimePeriodListViewControl ucTimePeriodListViewControl;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
