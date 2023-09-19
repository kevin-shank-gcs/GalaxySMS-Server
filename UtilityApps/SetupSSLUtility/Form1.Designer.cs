namespace SetupSSLUtility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpWebServicePorts = new System.Windows.Forms.GroupBox();
            this.grpExeProperties = new System.Windows.Forms.GroupBox();
            this.txtHTTPSPort = new System.Windows.Forms.MaskedTextBox();
            this.lvExeProperties = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblHTTPSPort = new System.Windows.Forms.Label();
            this.lblExeFilename = new System.Windows.Forms.Label();
            this.txtHTTPPort = new System.Windows.Forms.MaskedTextBox();
            this.lblHTTPPort = new System.Windows.Forms.Label();
            this.btnChooseExeFile = new System.Windows.Forms.Button();
            this.grpCertificateProperties = new System.Windows.Forms.GroupBox();
            this.lvCertificateProperties = new System.Windows.Forms.ListView();
            this.property = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCertificateFilename = new System.Windows.Forms.Label();
            this.btnChooseCertificate = new System.Windows.Forms.Button();
            this.btnViewCertificate = new System.Windows.Forms.Button();
            this.openCertificateFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openExeFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnMakeBatchFile = new System.Windows.Forms.Button();
            this.saveBatchFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpWebServicePorts.SuspendLayout();
            this.grpExeProperties.SuspendLayout();
            this.grpCertificateProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1047, 344);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpExeProperties);
            this.tabPage1.Controls.Add(this.grpCertificateProperties);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1039, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Galaxy Web Services SSL Setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpWebServicePorts
            // 
            this.grpWebServicePorts.Controls.Add(this.btnMakeBatchFile);
            this.grpWebServicePorts.Controls.Add(this.txtHTTPSPort);
            this.grpWebServicePorts.Controls.Add(this.lblHTTPPort);
            this.grpWebServicePorts.Controls.Add(this.lblHTTPSPort);
            this.grpWebServicePorts.Controls.Add(this.txtHTTPPort);
            this.grpWebServicePorts.Location = new System.Drawing.Point(9, 215);
            this.grpWebServicePorts.Name = "grpWebServicePorts";
            this.grpWebServicePorts.Size = new System.Drawing.Size(479, 63);
            this.grpWebServicePorts.TabIndex = 8;
            this.grpWebServicePorts.TabStop = false;
            this.grpWebServicePorts.Text = "Web Service Ports:";
            // 
            // grpExeProperties
            // 
            this.grpExeProperties.Controls.Add(this.grpWebServicePorts);
            this.grpExeProperties.Controls.Add(this.lvExeProperties);
            this.grpExeProperties.Controls.Add(this.lblExeFilename);
            this.grpExeProperties.Controls.Add(this.btnChooseExeFile);
            this.grpExeProperties.Location = new System.Drawing.Point(527, 15);
            this.grpExeProperties.Name = "grpExeProperties";
            this.grpExeProperties.Size = new System.Drawing.Size(503, 289);
            this.grpExeProperties.TabIndex = 6;
            this.grpExeProperties.TabStop = false;
            this.grpExeProperties.Text = "Application:";
            // 
            // txtHTTPSPort
            // 
            this.txtHTTPSPort.Location = new System.Drawing.Point(256, 24);
            this.txtHTTPSPort.Mask = "00000";
            this.txtHTTPSPort.Name = "txtHTTPSPort";
            this.txtHTTPSPort.Size = new System.Drawing.Size(34, 20);
            this.txtHTTPSPort.TabIndex = 11;
            this.txtHTTPSPort.ValidatingType = typeof(int);
            // 
            // lvExeProperties
            // 
            this.lvExeProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvExeProperties.GridLines = true;
            this.lvExeProperties.Location = new System.Drawing.Point(11, 77);
            this.lvExeProperties.Name = "lvExeProperties";
            this.lvExeProperties.Size = new System.Drawing.Size(482, 129);
            this.lvExeProperties.TabIndex = 0;
            this.lvExeProperties.UseCompatibleStateImageBehavior = false;
            this.lvExeProperties.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 378;
            // 
            // lblHTTPSPort
            // 
            this.lblHTTPSPort.AutoSize = true;
            this.lblHTTPSPort.Location = new System.Drawing.Point(153, 27);
            this.lblHTTPSPort.Name = "lblHTTPSPort";
            this.lblHTTPSPort.Size = new System.Drawing.Size(97, 13);
            this.lblHTTPSPort.TabIndex = 10;
            this.lblHTTPSPort.Text = "HTTPS (SSL) Port:";
            this.lblHTTPSPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblExeFilename
            // 
            this.lblExeFilename.AutoSize = true;
            this.lblExeFilename.Location = new System.Drawing.Point(8, 21);
            this.lblExeFilename.Name = "lblExeFilename";
            this.lblExeFilename.Size = new System.Drawing.Size(66, 13);
            this.lblExeFilename.TabIndex = 5;
            this.lblExeFilename.Text = "exe filename";
            // 
            // txtHTTPPort
            // 
            this.txtHTTPPort.Location = new System.Drawing.Point(85, 21);
            this.txtHTTPPort.Mask = "00000";
            this.txtHTTPPort.Name = "txtHTTPPort";
            this.txtHTTPPort.Size = new System.Drawing.Size(34, 20);
            this.txtHTTPPort.TabIndex = 9;
            this.txtHTTPPort.ValidatingType = typeof(int);
            // 
            // lblHTTPPort
            // 
            this.lblHTTPPort.AutoSize = true;
            this.lblHTTPPort.Location = new System.Drawing.Point(18, 24);
            this.lblHTTPPort.Name = "lblHTTPPort";
            this.lblHTTPPort.Size = new System.Drawing.Size(61, 13);
            this.lblHTTPPort.TabIndex = 7;
            this.lblHTTPPort.Text = "HTTP Port:";
            this.lblHTTPPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnChooseExeFile
            // 
            this.btnChooseExeFile.Location = new System.Drawing.Point(11, 40);
            this.btnChooseExeFile.Name = "btnChooseExeFile";
            this.btnChooseExeFile.Size = new System.Drawing.Size(267, 23);
            this.btnChooseExeFile.TabIndex = 4;
            this.btnChooseExeFile.Text = "Select Application to associate certificate with ...";
            this.btnChooseExeFile.UseVisualStyleBackColor = true;
            this.btnChooseExeFile.Click += new System.EventHandler(this.btnChooseExeFile_Click);
            // 
            // grpCertificateProperties
            // 
            this.grpCertificateProperties.Controls.Add(this.lvCertificateProperties);
            this.grpCertificateProperties.Controls.Add(this.lblCertificateFilename);
            this.grpCertificateProperties.Controls.Add(this.btnChooseCertificate);
            this.grpCertificateProperties.Controls.Add(this.btnViewCertificate);
            this.grpCertificateProperties.Location = new System.Drawing.Point(8, 15);
            this.grpCertificateProperties.Name = "grpCertificateProperties";
            this.grpCertificateProperties.Size = new System.Drawing.Size(499, 289);
            this.grpCertificateProperties.TabIndex = 3;
            this.grpCertificateProperties.TabStop = false;
            this.grpCertificateProperties.Text = "Certificate Selection:";
            // 
            // lvCertificateProperties
            // 
            this.lvCertificateProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.property,
            this.value});
            this.lvCertificateProperties.FullRowSelect = true;
            this.lvCertificateProperties.GridLines = true;
            this.lvCertificateProperties.Location = new System.Drawing.Point(6, 77);
            this.lvCertificateProperties.Name = "lvCertificateProperties";
            this.lvCertificateProperties.Size = new System.Drawing.Size(482, 201);
            this.lvCertificateProperties.TabIndex = 0;
            this.lvCertificateProperties.UseCompatibleStateImageBehavior = false;
            this.lvCertificateProperties.View = System.Windows.Forms.View.Details;
            // 
            // property
            // 
            this.property.Text = "Property";
            this.property.Width = 100;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 377;
            // 
            // lblCertificateFilename
            // 
            this.lblCertificateFilename.AutoSize = true;
            this.lblCertificateFilename.Location = new System.Drawing.Point(6, 21);
            this.lblCertificateFilename.Name = "lblCertificateFilename";
            this.lblCertificateFilename.Size = new System.Drawing.Size(93, 13);
            this.lblCertificateFilename.TabIndex = 1;
            this.lblCertificateFilename.Text = "certficate filename";
            // 
            // btnChooseCertificate
            // 
            this.btnChooseCertificate.Location = new System.Drawing.Point(6, 40);
            this.btnChooseCertificate.Name = "btnChooseCertificate";
            this.btnChooseCertificate.Size = new System.Drawing.Size(145, 23);
            this.btnChooseCertificate.TabIndex = 0;
            this.btnChooseCertificate.Text = "Select Certificate File ...";
            this.btnChooseCertificate.UseVisualStyleBackColor = true;
            this.btnChooseCertificate.Click += new System.EventHandler(this.btnChooseCertificate_Click);
            // 
            // btnViewCertificate
            // 
            this.btnViewCertificate.Enabled = false;
            this.btnViewCertificate.Location = new System.Drawing.Point(157, 40);
            this.btnViewCertificate.Name = "btnViewCertificate";
            this.btnViewCertificate.Size = new System.Drawing.Size(142, 23);
            this.btnViewCertificate.TabIndex = 2;
            this.btnViewCertificate.Text = "View Certificate ...";
            this.btnViewCertificate.UseVisualStyleBackColor = true;
            this.btnViewCertificate.Click += new System.EventHandler(this.btnViewCertificate_Click);
            // 
            // openCertificateFileDialog
            // 
            this.openCertificateFileDialog.DefaultExt = "cer";
            this.openCertificateFileDialog.Filter = "Certfiicate files|*.cer";
            // 
            // openExeFileDialog
            // 
            this.openExeFileDialog.FileName = "GCS.WebApi.WindowsService.exe";
            this.openExeFileDialog.Filter = "Executable files|*.exe";
            this.openExeFileDialog.InitialDirectory = "c:\\GCS\\System Galaxy\\OptionalServices\\WebServices";
            // 
            // btnMakeBatchFile
            // 
            this.btnMakeBatchFile.Enabled = false;
            this.btnMakeBatchFile.Location = new System.Drawing.Point(309, 21);
            this.btnMakeBatchFile.Name = "btnMakeBatchFile";
            this.btnMakeBatchFile.Size = new System.Drawing.Size(142, 23);
            this.btnMakeBatchFile.TabIndex = 12;
            this.btnMakeBatchFile.Text = "Make Batch File";
            this.btnMakeBatchFile.UseVisualStyleBackColor = true;
            this.btnMakeBatchFile.Click += new System.EventHandler(this.btnMakeBatchFile_Click);
            // 
            // saveBatchFileDialog
            // 
            this.saveBatchFileDialog.FileName = "SetupSSL.bat";
            this.saveBatchFileDialog.Filter = "Batch files|*.bat";
            this.saveBatchFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveBatchFileDialog_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 344);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Security Utilities";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpWebServicePorts.ResumeLayout(false);
            this.grpWebServicePorts.PerformLayout();
            this.grpExeProperties.ResumeLayout(false);
            this.grpExeProperties.PerformLayout();
            this.grpCertificateProperties.ResumeLayout(false);
            this.grpCertificateProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnChooseCertificate;
        private System.Windows.Forms.OpenFileDialog openCertificateFileDialog;
        private System.Windows.Forms.Label lblCertificateFilename;
        private System.Windows.Forms.Button btnViewCertificate;
        private System.Windows.Forms.GroupBox grpCertificateProperties;
        private System.Windows.Forms.ListView lvCertificateProperties;
        private System.Windows.Forms.ColumnHeader property;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Button btnChooseExeFile;
        private System.Windows.Forms.OpenFileDialog openExeFileDialog;
        private System.Windows.Forms.Label lblExeFilename;
        private System.Windows.Forms.GroupBox grpExeProperties;
        private System.Windows.Forms.ListView lvExeProperties;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox grpWebServicePorts;
        private System.Windows.Forms.Label lblHTTPPort;
        private System.Windows.Forms.MaskedTextBox txtHTTPSPort;
        private System.Windows.Forms.Label lblHTTPSPort;
        private System.Windows.Forms.MaskedTextBox txtHTTPPort;
        private System.Windows.Forms.Button btnMakeBatchFile;
        private System.Windows.Forms.SaveFileDialog saveBatchFileDialog;
    }
}

