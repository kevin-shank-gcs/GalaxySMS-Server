using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using GCS.Core.Common.Config;
using GCS.Framework.Security;
using GCS.Framework.Utilities;
using SetupSSLUtility.Properties;

namespace SetupSSLUtility
{
    public partial class Form1 : Form
    {
        private AssemblyAttributes _assemblyAttributes;
        private X509Certificate2 _certificate;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseCertificate_Click(object sender, EventArgs e)
        {
            if (openCertificateFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _certificate = X509CertificatesHelpers.FromFile(openCertificateFileDialog.FileName);
                    lblCertificateFilename.Text = openCertificateFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    Trace.Write(ex.ToString());
                }
            }
            UpdateCertificateControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCertificateFilename.Text = string.Empty;
            lblExeFilename.Text = string.Empty;
            UpdateCertificateControls();
        }

        private void UpdateCertificateControls()
        {
            btnViewCertificate.Enabled = _certificate != null;
            lvCertificateProperties.Items.Clear();
            if (_certificate != null)
            {
                var lvi = new ListViewItem();
                lvi.Text = Resources.Certificate_Issuer;
                lvi.SubItems.Add(_certificate.Issuer);
                lvCertificateProperties.Items.Add(lvi);

                lvi = new ListViewItem();
                lvi.Text = Resources.Certificate_Not_Valid_Before;
                lvi.SubItems.Add(string.Format("{0} {1}",
                    _certificate.NotBefore.ToLongDateString(),
                    _certificate.NotBefore.ToLongTimeString()));
                lvCertificateProperties.Items.Add(lvi);

                lvi = new ListViewItem();
                lvi.Text = Resources.Certificate_Not_Valid_After;
                lvi.SubItems.Add(string.Format("{0} {1}",
                    _certificate.NotAfter.ToLongDateString(),
                    _certificate.NotAfter.ToLongTimeString()));
                lvCertificateProperties.Items.Add(lvi);

                lvi = new ListViewItem();
                lvi.Text = Resources.Certificate_Thumbprint;
                lvi.SubItems.Add(_certificate.Thumbprint);
                lvCertificateProperties.Items.Add(lvi);

                lvi = new ListViewItem();
                lvi.Text = Resources.Certificate_Serial_Number;
                lvi.SubItems.Add(_certificate.SerialNumber);
                lvCertificateProperties.Items.Add(lvi);
            }
        }

        private void btnViewCertificate_Click(object sender, EventArgs e)
        {
            X509Certificate2UI.DisplayCertificate(_certificate);
        }

        private void btnChooseExeFile_Click(object sender, EventArgs e)
        {
            if (openExeFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lblExeFilename.Text = openExeFileDialog.FileName;
                    var assembly = Assembly.LoadFrom(openExeFileDialog.FileName);
                    _assemblyAttributes = SystemUtilities.GetAssemblyAttributes(ref assembly);
                    var configFilename = lblExeFilename.Text + ".config";
                    var httpPort = ConfigurationUtilities.GetAppSetting(configFilename,
                        "appSettings", "HTTPPort", 0, false);
                    var httpsPort = ConfigurationUtilities.GetAppSetting(configFilename,
                        "appSettings", "HTTPSPort", 0, false);
                    txtHTTPPort.Text = string.Format("{0}", httpPort);
                    txtHTTPSPort.Text = string.Format("{0}", httpsPort);
                }
                catch (Exception ex)
                {
                    Trace.Write(ex.ToString());
                }
            }
            UpdateExeControls();
        }

        private void UpdateExeControls()
        {
            lvExeProperties.Items.Clear();
            btnMakeBatchFile.Enabled = false;
            if (_assemblyAttributes != null)
            {
                var lvi = new ListViewItem();
                lvi.Text = Resources.Application_AppId;
                lvi.SubItems.Add(_assemblyAttributes.Guid.ToString());
                lvExeProperties.Items.Add(lvi);

                lvi = new ListViewItem();
                lvi.Text = Resources.Application_Company;
                lvi.SubItems.Add(_assemblyAttributes.Company);
                lvExeProperties.Items.Add(lvi);

                lvi = new ListViewItem();
                lvi.Text = Resources.Application_Description;
                lvi.SubItems.Add(_assemblyAttributes.Description);
                lvExeProperties.Items.Add(lvi);

                lvi = new ListViewItem();
                lvi.Text = Resources.Application_Version;
                lvi.SubItems.Add(_assemblyAttributes.MajorMinorVersion);
                lvExeProperties.Items.Add(lvi);

                lvi = new ListViewItem();
                lvi.Text = Resources.Application_Product;
                lvi.SubItems.Add(_assemblyAttributes.Product);
                lvExeProperties.Items.Add(lvi);

                if (!string.IsNullOrWhiteSpace(txtHTTPPort.Text) ||
                    !string.IsNullOrWhiteSpace(txtHTTPSPort.Text))
                    btnMakeBatchFile.Enabled = true;
            }
        }

        private void btnMakeBatchFile_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(txtHTTPPort.Text))
                {
                    sb.AppendLine(string.Format("netsh http add urlacl url=http://+:{0}/ user=Everyone",
                        txtHTTPPort.Text));
                }
                if (!string.IsNullOrWhiteSpace(txtHTTPSPort.Text))
                {
                    sb.AppendLine(string.Format("netsh http add urlacl url=https://+:{0}/ user=Everyone",
                        txtHTTPSPort.Text));
                }

                sb.AppendLine(string.Format(
                    "netsh http add sslcert ipport = 0.0.0.0:{0} certhash = {1} appid = {{{2}}}",
                    txtHTTPSPort.Text, _certificate.Thumbprint, _assemblyAttributes.Guid));
                sb.AppendLine("pause");
                Trace.Write(sb.ToString());
                if (saveBatchFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //File.Create(saveBatchFileDialog.FileName);
                    File.WriteAllText(saveBatchFileDialog.FileName, sb.ToString());
                    var directoryName = Path.GetDirectoryName(saveBatchFileDialog.FileName);
                    Process.Start("explorer.exe", directoryName);

                    Process.Start("notepad.exe", saveBatchFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message);
            }
        }

        private void saveBatchFileDialog_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}