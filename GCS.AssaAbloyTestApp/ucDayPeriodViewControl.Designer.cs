namespace GCS.AssaAbloyTestApp
{
    partial class DayPeriodViewControl
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
            this.WeekDayCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ucTimePeriodListViewControl = new GCS.AssaAbloyTestApp.ucTimePeriodListViewControl();
            this.SuspendLayout();
            // 
            // WeekDayCheckBoxList
            // 
            this.WeekDayCheckBoxList.Enabled = false;
            this.WeekDayCheckBoxList.FormattingEnabled = true;
            this.WeekDayCheckBoxList.Location = new System.Drawing.Point(3, 6);
            this.WeekDayCheckBoxList.Name = "WeekDayCheckBoxList";
            this.WeekDayCheckBoxList.Size = new System.Drawing.Size(141, 109);
            this.WeekDayCheckBoxList.TabIndex = 44;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(92, 96);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 46;
            // 
            // ucTimePeriodListViewControl
            // 
            this.ucTimePeriodListViewControl.Location = new System.Drawing.Point(151, 6);
            this.ucTimePeriodListViewControl.Name = "ucTimePeriodListViewControl";
            this.ucTimePeriodListViewControl.Size = new System.Drawing.Size(164, 115);
            this.ucTimePeriodListViewControl.TabIndex = 47;
            this.ucTimePeriodListViewControl.TimePeriods = new GCS.AssaAbloyDSR.DSRAccessControlService.TimePeriod[0];
            // 
            // DayPeriodViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucTimePeriodListViewControl);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.WeekDayCheckBoxList);
            this.Name = "DayPeriodViewControl";
            this.Size = new System.Drawing.Size(321, 118);
            this.Load += new System.EventHandler(this.clbDayPeriodControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckedListBox WeekDayCheckBoxList;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private ucTimePeriodListViewControl ucTimePeriodListViewControl;
    }
}
