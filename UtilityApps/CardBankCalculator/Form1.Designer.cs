namespace CardBankCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumberOfBuckets = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCardsPerBucket = new System.Windows.Forms.TextBox();
            this.chkExtendedCardMode = new System.Windows.Forms.CheckBox();
            this.btnCalculateBucket = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBucketAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBucketNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkHalfCardCapacity = new System.Windows.Forms.CheckBox();
            this.txtDumpCommand = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Card #";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(12, 91);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(159, 23);
            this.txtCardNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "# of Buckets";
            // 
            // txtNumberOfBuckets
            // 
            this.txtNumberOfBuckets.Location = new System.Drawing.Point(14, 31);
            this.txtNumberOfBuckets.MaxLength = 5;
            this.txtNumberOfBuckets.Name = "txtNumberOfBuckets";
            this.txtNumberOfBuckets.ReadOnly = true;
            this.txtNumberOfBuckets.Size = new System.Drawing.Size(40, 23);
            this.txtNumberOfBuckets.TabIndex = 3;
            this.txtNumberOfBuckets.Text = "128";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cards per Bucket";
            // 
            // txtCardsPerBucket
            // 
            this.txtCardsPerBucket.Location = new System.Drawing.Point(102, 31);
            this.txtCardsPerBucket.Name = "txtCardsPerBucket";
            this.txtCardsPerBucket.ReadOnly = true;
            this.txtCardsPerBucket.Size = new System.Drawing.Size(66, 23);
            this.txtCardsPerBucket.TabIndex = 5;
            this.txtCardsPerBucket.Text = "512";
            // 
            // chkExtendedCardMode
            // 
            this.chkExtendedCardMode.AutoSize = true;
            this.chkExtendedCardMode.Location = new System.Drawing.Point(220, 22);
            this.chkExtendedCardMode.Name = "chkExtendedCardMode";
            this.chkExtendedCardMode.Size = new System.Drawing.Size(137, 19);
            this.chkExtendedCardMode.TabIndex = 6;
            this.chkExtendedCardMode.Text = "Extended Card Mode";
            this.chkExtendedCardMode.UseVisualStyleBackColor = true;
            this.chkExtendedCardMode.CheckedChanged += new System.EventHandler(this.chkExtendedCardMode_CheckedChanged);
            // 
            // btnCalculateBucket
            // 
            this.btnCalculateBucket.Location = new System.Drawing.Point(191, 91);
            this.btnCalculateBucket.Name = "btnCalculateBucket";
            this.btnCalculateBucket.Size = new System.Drawing.Size(137, 23);
            this.btnCalculateBucket.TabIndex = 7;
            this.btnCalculateBucket.Text = "Calculate Bucket Address";
            this.btnCalculateBucket.UseVisualStyleBackColor = true;
            this.btnCalculateBucket.Click += new System.EventHandler(this.btnCalculateBucket_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDumpCommand);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBucketAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBucketNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 149);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results:";
            // 
            // txtBucketAddress
            // 
            this.txtBucketAddress.Location = new System.Drawing.Point(90, 46);
            this.txtBucketAddress.Name = "txtBucketAddress";
            this.txtBucketAddress.ReadOnly = true;
            this.txtBucketAddress.Size = new System.Drawing.Size(95, 23);
            this.txtBucketAddress.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Bucket Address";
            // 
            // txtBucketNumber
            // 
            this.txtBucketNumber.Location = new System.Drawing.Point(7, 46);
            this.txtBucketNumber.Name = "txtBucketNumber";
            this.txtBucketNumber.ReadOnly = true;
            this.txtBucketNumber.Size = new System.Drawing.Size(66, 23);
            this.txtBucketNumber.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bucket #";
            // 
            // chkHalfCardCapacity
            // 
            this.chkHalfCardCapacity.AutoSize = true;
            this.chkHalfCardCapacity.Location = new System.Drawing.Point(220, 47);
            this.chkHalfCardCapacity.Name = "chkHalfCardCapacity";
            this.chkHalfCardCapacity.Size = new System.Drawing.Size(125, 19);
            this.chkHalfCardCapacity.TabIndex = 9;
            this.chkHalfCardCapacity.Text = "Half Card Capacity";
            this.chkHalfCardCapacity.UseVisualStyleBackColor = true;
            this.chkHalfCardCapacity.CheckedChanged += new System.EventHandler(this.chkHalfCardCapacity_CheckedChanged);
            // 
            // txtDumpCommand
            // 
            this.txtDumpCommand.Location = new System.Drawing.Point(8, 101);
            this.txtDumpCommand.Name = "txtDumpCommand";
            this.txtDumpCommand.ReadOnly = true;
            this.txtDumpCommand.Size = new System.Drawing.Size(177, 23);
            this.txtDumpCommand.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Dump Command";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 288);
            this.Controls.Add(this.chkHalfCardCapacity);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCalculateBucket);
            this.Controls.Add(this.chkExtendedCardMode);
            this.Controls.Add(this.txtCardsPerBucket);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumberOfBuckets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "635 Card Bucket Calculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtCardNumber;
        private Label label2;
        private TextBox txtNumberOfBuckets;
        private Label label3;
        private TextBox txtCardsPerBucket;
        private CheckBox chkExtendedCardMode;
        private Button btnCalculateBucket;
        private GroupBox groupBox1;
        private TextBox txtBucketNumber;
        private Label label4;
        private TextBox txtBucketAddress;
        private Label label5;
        private CheckBox chkHalfCardCapacity;
        private TextBox txtDumpCommand;
        private Label label6;
    }
}