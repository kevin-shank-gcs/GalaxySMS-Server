namespace IdProducerLicenseGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdProdUrl = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpIdProducerInfo = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaxPrinters = new System.Windows.Forms.TextBox();
            this.txtMaxCustomers = new System.Windows.Forms.TextBox();
            this.btnCancelLicenseChanges = new System.Windows.Forms.Button();
            this.btnSaveLicense = new System.Windows.Forms.Button();
            this.btnEditLicense = new System.Windows.Forms.Button();
            this.lblMaxPrinters = new System.Windows.Forms.Label();
            this.lblMaxCustomers = new System.Windows.Forms.Label();
            this.lblMaxPrintersTitle = new System.Windows.Forms.Label();
            this.lblMaxCustomerTitle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.swLicenseType = new JCS.ToggleSwitch();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblServerVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpIdProducerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "idPRODUCER Url:";
            // 
            // txtIdProdUrl
            // 
            this.txtIdProdUrl.Location = new System.Drawing.Point(23, 42);
            this.txtIdProdUrl.Name = "txtIdProdUrl";
            this.txtIdProdUrl.Size = new System.Drawing.Size(264, 20);
            this.txtIdProdUrl.TabIndex = 1;
            this.txtIdProdUrl.TextChanged += new System.EventHandler(this.txtIdProdUrl_TextChanged);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(23, 128);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(263, 23);
            this.btnTestConnection.TabIndex = 2;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(25, 93);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(164, 20);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(195, 92);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(91, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTestConnection);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtIdProdUrl);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 167);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Information:";
            // 
            // grpIdProducerInfo
            // 
            this.grpIdProducerInfo.Controls.Add(this.label10);
            this.grpIdProducerInfo.Controls.Add(this.label9);
            this.grpIdProducerInfo.Controls.Add(this.txtMaxPrinters);
            this.grpIdProducerInfo.Controls.Add(this.txtMaxCustomers);
            this.grpIdProducerInfo.Controls.Add(this.btnCancelLicenseChanges);
            this.grpIdProducerInfo.Controls.Add(this.btnSaveLicense);
            this.grpIdProducerInfo.Controls.Add(this.btnEditLicense);
            this.grpIdProducerInfo.Controls.Add(this.lblMaxPrinters);
            this.grpIdProducerInfo.Controls.Add(this.lblMaxCustomers);
            this.grpIdProducerInfo.Controls.Add(this.lblMaxPrintersTitle);
            this.grpIdProducerInfo.Controls.Add(this.lblMaxCustomerTitle);
            this.grpIdProducerInfo.Controls.Add(this.label6);
            this.grpIdProducerInfo.Controls.Add(this.swLicenseType);
            this.grpIdProducerInfo.Controls.Add(this.lblCompanyName);
            this.grpIdProducerInfo.Controls.Add(this.label5);
            this.grpIdProducerInfo.Controls.Add(this.lblServerVersion);
            this.grpIdProducerInfo.Controls.Add(this.label4);
            this.grpIdProducerInfo.Enabled = false;
            this.grpIdProducerInfo.Location = new System.Drawing.Point(12, 202);
            this.grpIdProducerInfo.Name = "grpIdProducerInfo";
            this.grpIdProducerInfo.Size = new System.Drawing.Size(308, 241);
            this.grpIdProducerInfo.TabIndex = 8;
            this.grpIdProducerInfo.TabStop = false;
            this.grpIdProducerInfo.Text = "idPRODUCER Information:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(183, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "(-1 = Unlimited)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "(-1 = Unlimited)";
            // 
            // txtMaxPrinters
            // 
            this.txtMaxPrinters.Location = new System.Drawing.Point(105, 126);
            this.txtMaxPrinters.Name = "txtMaxPrinters";
            this.txtMaxPrinters.ReadOnly = true;
            this.txtMaxPrinters.Size = new System.Drawing.Size(73, 20);
            this.txtMaxPrinters.TabIndex = 13;
            // 
            // txtMaxCustomers
            // 
            this.txtMaxCustomers.Location = new System.Drawing.Point(105, 101);
            this.txtMaxCustomers.Name = "txtMaxCustomers";
            this.txtMaxCustomers.ReadOnly = true;
            this.txtMaxCustomers.Size = new System.Drawing.Size(73, 20);
            this.txtMaxCustomers.TabIndex = 12;
            this.txtMaxCustomers.TextChanged += new System.EventHandler(this.txtMaxCustomers_TextChanged);
            // 
            // btnCancelLicenseChanges
            // 
            this.btnCancelLicenseChanges.Location = new System.Drawing.Point(23, 212);
            this.btnCancelLicenseChanges.Name = "btnCancelLicenseChanges";
            this.btnCancelLicenseChanges.Size = new System.Drawing.Size(263, 23);
            this.btnCancelLicenseChanges.TabIndex = 11;
            this.btnCancelLicenseChanges.Text = "Cancel Changes";
            this.btnCancelLicenseChanges.UseVisualStyleBackColor = true;
            this.btnCancelLicenseChanges.Click += new System.EventHandler(this.btnCancelLicenseChanges_Click);
            // 
            // btnSaveLicense
            // 
            this.btnSaveLicense.Location = new System.Drawing.Point(23, 185);
            this.btnSaveLicense.Name = "btnSaveLicense";
            this.btnSaveLicense.Size = new System.Drawing.Size(263, 23);
            this.btnSaveLicense.TabIndex = 10;
            this.btnSaveLicense.Text = "Save License";
            this.btnSaveLicense.UseVisualStyleBackColor = true;
            this.btnSaveLicense.Click += new System.EventHandler(this.btnSaveLicense_Click);
            // 
            // btnEditLicense
            // 
            this.btnEditLicense.Location = new System.Drawing.Point(23, 156);
            this.btnEditLicense.Name = "btnEditLicense";
            this.btnEditLicense.Size = new System.Drawing.Size(263, 23);
            this.btnEditLicense.TabIndex = 7;
            this.btnEditLicense.Text = "Edit License";
            this.btnEditLicense.UseVisualStyleBackColor = true;
            this.btnEditLicense.Click += new System.EventHandler(this.btnEditLicense_Click);
            // 
            // lblMaxPrinters
            // 
            this.lblMaxPrinters.AutoSize = true;
            this.lblMaxPrinters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxPrinters.Location = new System.Drawing.Point(105, 130);
            this.lblMaxPrinters.Name = "lblMaxPrinters";
            this.lblMaxPrinters.Size = new System.Drawing.Size(49, 13);
            this.lblMaxPrinters.TabIndex = 9;
            this.lblMaxPrinters.Text = "printers";
            // 
            // lblMaxCustomers
            // 
            this.lblMaxCustomers.AutoSize = true;
            this.lblMaxCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCustomers.Location = new System.Drawing.Point(105, 105);
            this.lblMaxCustomers.Name = "lblMaxCustomers";
            this.lblMaxCustomers.Size = new System.Drawing.Size(64, 13);
            this.lblMaxCustomers.TabIndex = 8;
            this.lblMaxCustomers.Text = "customers";
            // 
            // lblMaxPrintersTitle
            // 
            this.lblMaxPrintersTitle.AutoSize = true;
            this.lblMaxPrintersTitle.Location = new System.Drawing.Point(28, 130);
            this.lblMaxPrintersTitle.Name = "lblMaxPrintersTitle";
            this.lblMaxPrintersTitle.Size = new System.Drawing.Size(68, 13);
            this.lblMaxPrintersTitle.TabIndex = 7;
            this.lblMaxPrintersTitle.Text = "Max Printers:";
            // 
            // lblMaxCustomerTitle
            // 
            this.lblMaxCustomerTitle.AutoSize = true;
            this.lblMaxCustomerTitle.Location = new System.Drawing.Point(14, 105);
            this.lblMaxCustomerTitle.Name = "lblMaxCustomerTitle";
            this.lblMaxCustomerTitle.Size = new System.Drawing.Size(82, 13);
            this.lblMaxCustomerTitle.TabIndex = 6;
            this.lblMaxCustomerTitle.Text = "Max Customers:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "License Type:";
            // 
            // swLicenseType
            // 
            this.swLicenseType.Location = new System.Drawing.Point(105, 75);
            this.swLicenseType.Name = "swLicenseType";
            this.swLicenseType.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swLicenseType.OffText = "Basic";
            this.swLicenseType.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swLicenseType.OnText = "Advanced";
            this.swLicenseType.Size = new System.Drawing.Size(100, 22);
            this.swLicenseType.Style = JCS.ToggleSwitch.ToggleSwitchStyle.Iphone;
            this.swLicenseType.TabIndex = 4;
            this.swLicenseType.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.swLicenseType_CheckedChanged);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(105, 55);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(57, 13);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "company";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Company Name:";
            // 
            // lblServerVersion
            // 
            this.lblServerVersion.AutoSize = true;
            this.lblServerVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerVersion.Location = new System.Drawing.Point(105, 30);
            this.lblServerVersion.Name = "lblServerVersion";
            this.lblServerVersion.Size = new System.Drawing.Size(48, 13);
            this.lblServerVersion.TabIndex = 1;
            this.lblServerVersion.Text = "version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Version:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 455);
            this.Controls.Add(this.grpIdProducerInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpIdProducerInfo.ResumeLayout(false);
            this.grpIdProducerInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdProdUrl;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpIdProducerInfo;
        private System.Windows.Forms.Label lblServerVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private JCS.ToggleSwitch swLicenseType;
        private System.Windows.Forms.Label lblMaxPrinters;
        private System.Windows.Forms.Label lblMaxCustomers;
        private System.Windows.Forms.Label lblMaxPrintersTitle;
        private System.Windows.Forms.Label lblMaxCustomerTitle;
        private System.Windows.Forms.Button btnEditLicense;
        private System.Windows.Forms.Button btnCancelLicenseChanges;
        private System.Windows.Forms.Button btnSaveLicense;
        private System.Windows.Forms.TextBox txtMaxPrinters;
        private System.Windows.Forms.TextBox txtMaxCustomers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}

