using GCS.Framework.Badging.IdProducer;
using GCS.Framework.Badging.IdProducer.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace IdProducerLicenseGenerator
{
    public partial class Form1 : Form
    {
        private idProducerAPI _idpApi;
        private GetServerVersionNumberResponse _idProdVersion;
        private GetAllSubscriptionsResponse _subscriptions;
        private SubscriptionData _rootSub;
        private bool _bInEditMode;
        private string _devUrl;
        private string _url;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearServerInfo();
            txtIdProdUrl.Text = Properties.Settings.Default.IdProducerUrl;
            txtUserName.Text = Properties.Settings.Default.UserName;
            txtPassword.Text = Properties.Settings.Default.Password;
            SetEditMode(false);
        }

        private void txtIdProdUrl_TextChanged(object sender, EventArgs e)
        {
            btnTestConnection.Enabled = AreConnectionParametersFilled();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            btnTestConnection.Enabled = AreConnectionParametersFilled();

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnTestConnection.Enabled = AreConnectionParametersFilled();
        }

        private bool AreConnectionParametersFilled()
        {
            var urlOk = Uri.IsWellFormedUriString(txtIdProdUrl.Text, UriKind.Absolute);
            var userNameOk = !string.IsNullOrEmpty(txtUserName.Text);
            var passwordOk = !string.IsNullOrEmpty(txtPassword.Text);
            return urlOk & passwordOk & userNameOk;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                ClearServerInfo();
                _url = $"{txtIdProdUrl.Text}{Properties.Settings.Default.urlSuffix}";
                _devUrl = $"{txtIdProdUrl.Text}{Properties.Settings.Default.devUrlSuffix}";
                _idpApi = IdProducerHelpers.GetIdProducerApi(_url, _devUrl, txtUserName.Text, txtPassword.Text, string.Empty);
                _idProdVersion = _idpApi.GetServerVersionNumber();
                _subscriptions = _idpApi.GetAllSubscriptionsResponse();
                _rootSub = _subscriptions?.Subscriptions.FirstOrDefault(o => o.ID == 1000);
                lblServerVersion.Text = _idProdVersion?.Data;
                lblCompanyName.Text = _rootSub?.CompanyName;
                lblMaxCustomers.Text = _rootSub?.FriendlyLicenseDetails?.MaxCustomerCount.ToString();
                lblMaxPrinters.Text = _rootSub?.FriendlyLicenseDetails?.LicensedMaxPrinterCount.ToString();
                swLicenseType.Checked = _rootSub?.FriendlyLicenseDetails?.MaxCustomerCount != null && _rootSub?.FriendlyLicenseDetails?.MaxCustomerCount != 0;
                txtMaxCustomers.Text = lblMaxCustomers.Text;
                txtMaxPrinters.Text = lblMaxPrinters.Text;
                swLicenseType.Enabled = false;
                SetEditMode(false);
                grpIdProducerInfo.Enabled = true;
            }
            catch (Exception ex)
            {
                ClearServerInfo();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void ClearServerInfo()
        {
            grpIdProducerInfo.Enabled = false;
            lblServerVersion.Text = string.Empty;
            lblCompanyName.Text = string.Empty;
            lblMaxCustomers.Text = string.Empty;
            lblMaxPrinters.Text = string.Empty;
            txtMaxCustomers.Text = string.Empty;
            txtMaxPrinters.Text = string.Empty;
        }

        private void btnEditLicense_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
        }

        private void SetEditMode(bool bEditMode)
        {
            _bInEditMode = bEditMode;
            btnTestConnection.Enabled = !bEditMode;
            swLicenseType.Enabled = _bInEditMode;
            btnSaveLicense.Enabled = _bInEditMode;
            btnCancelLicenseChanges.Enabled = _bInEditMode;
            btnEditLicense.Enabled = !_bInEditMode;
            txtMaxPrinters.ReadOnly = !_bInEditMode;
            txtMaxCustomers.ReadOnly = !_bInEditMode;

            txtMaxCustomers.Visible = _bInEditMode;
            txtMaxPrinters.Visible = _bInEditMode;
            lblMaxCustomers.Visible = !txtMaxCustomers.Visible;
            lblMaxPrinters.Visible = !txtMaxPrinters.Visible;

            if (_bInEditMode)
            {
                txtMaxCustomers.ReadOnly = !swLicenseType.Checked;
            }
        }

        private void btnSaveLicense_Click(object sender, EventArgs e)
        {
            try
            {
                var customerCount = 0;
                var printerCount = 0;
                if (!int.TryParse(txtMaxCustomers.Text, out customerCount))
                {
                    MessageBox.Show($"The '{lblMaxCustomerTitle.Text.Replace(':', ' ')}' value is invalid. A number must be specified.", "Validation Error", MessageBoxButtons.OK);
                    return;
                }

                if (!int.TryParse(txtMaxPrinters.Text, out printerCount))
                {
                    MessageBox.Show($"The '{lblMaxPrintersTitle.Text.Replace(':', ' ')}' value is invalid. A number must be specified.", "Validation Error", MessageBoxButtons.OK);
                    return;
                }

                var licenseApi = IdProducerHelpers.GetLicenseBotApi(_url, _devUrl, string.Empty);
                var updatedSubscription = _rootSub;
                updatedSubscription.FriendlyLicenseDetails.MaxCustomerCount = customerCount;
                updatedSubscription.FriendlyLicenseDetails.LicensedMaxPrinterCount = printerCount;
                var updatedSub = licenseApi.UpdateSubscriptionProfile(updatedSubscription);

                SetEditMode(false);
                btnTestConnection_Click(null, null);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void btnCancelLicenseChanges_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
            btnTestConnection_Click(null, null);
        }

        private void swLicenseType_CheckedChanged(object sender, EventArgs e)
        {
            if (_bInEditMode)
            {
                txtMaxCustomers.ReadOnly = !swLicenseType.Checked;
                if (!swLicenseType.Checked)
                {
                    txtMaxCustomers.Text = "0";
                }
                else
                {
                    if (_rootSub?.FriendlyLicenseDetails.MaxCustomerCount != null && _rootSub?.FriendlyLicenseDetails.MaxCustomerCount != 0)
                        txtMaxCustomers.Text = $"{_rootSub?.FriendlyLicenseDetails.MaxCustomerCount}";
                    else
                    {
                        txtMaxCustomers.Text = "-1";
                    }
                }
            }
        }

        private void txtMaxCustomers_TextChanged(object sender, EventArgs e)
        {
            var value = 0;
            if (int.TryParse(txtMaxCustomers.Text, out value))
            {
                swLicenseType.Checked = value != 0;
            }
        }
    }
}
