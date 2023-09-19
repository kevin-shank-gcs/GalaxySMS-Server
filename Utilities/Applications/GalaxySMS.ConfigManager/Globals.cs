using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Media.Effects;
using GalaxySMS.ConfigManager.Properties;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Licensing.Extensions;
using Portable.Licensing;
using Portable.Licensing.Validation;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace GalaxySMS.ConfigManager
{
    public class Globals : ViewModelBase
    {
        #region Private fields
        private static Globals _instance;
        private Effect _backgroundSubduedEffect;
        private double _backgroundSubduedOpacity;
        private License _license;
        private IEnumerable<IValidationFailure> _licenseValidationFailures;
        private bool _isLicenseValid;
        private bool _ignoreBadCertificates;

        #endregion

        #region Constructor
        [ImportingConstructor]
        private Globals()
        {
            _backgroundSubduedOpacity = Settings.Default.BackgroundSubduedOpacity;
            if (Settings.Default.BackgroundSubduedBlur == true)
                _backgroundSubduedEffect = new BlurEffect();
            CustomerName = Settings.Default.CustomerName;
            CustomerEmail = Settings.Default.CustomerEmail;
            Messenger = new Messenger();
        }
        #endregion

        #region Public Properties
        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Globals();
                }
                return _instance;
            }
        }

        public GCS.Framework.Utilities.AssemblyAttributes MyAssemblyAtrributes
        {
            get
            {
                System.Reflection.Assembly myAssembly = this.
                    GetType().Assembly;
                return GCS.Framework.Utilities.SystemUtilities.
                    GetAssemblyAttributes(ref myAssembly);
            }
        }

        public String CustomerName { get; set; }
        public String CustomerEmail { get; set; }

        public Boolean IsLicenseValid
        {
            get { return _isLicenseValid; }
            internal set { _isLicenseValid = value; }
        }

        public License MyLicense
        {
            get { return _license; }
        }

        public String LicensedCustomerName
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Name;
            }
        }

        public String LicensedCustomerCompany
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Company;
            }
        }

        public String LicensedCustomerEmail
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Email;
            }
        }

        public DateTimeOffset LicenseExpiration
        {
            get
            {
                if (_license == null)
                    return DateTimeOffset.MinValue;
                return _license.Expiration;
            }
        }

        public LicenseType LicenseType
        {
            get
            {
                if (_license == null)
                    return LicenseType.Trial;
                return _license.Type;
            }
        }

        public string LicenseTypeDescription
        {
            get
            {
                if (_license == null)
                    return Properties.Resources.AboutView_LicenseTypeNone;
                switch (LicenseType)
                {
                    case LicenseType.Standard:
                        return Properties.Resources.AboutView_LicenseTypeStandard;
                    case LicenseType.Trial:
                        return Properties.Resources.AboutView_LicenseTypeTrial;
                }
                return Properties.Resources.AboutView_LicenseTypeNone;
            }
        }
        public Guid LicenseId
        {
            get
            {
                if (_license == null)
                    return Guid.Empty;
                return _license.Id;
            }
        }

        public IEnumerable<IValidationFailure> LicenseValidationFailures
        {
            get { return _licenseValidationFailures; }
            internal set { _licenseValidationFailures = value; }
        }

        public Messenger Messenger { get; internal set; }

        public ContentControl MainWindow { get; set; }

        #endregion

        #region Public methods
        public bool Init()
        {
            string myProcessName = GCS.Framework.Utilities.SystemUtilities.MyProcessName;

            if (myProcessName.EndsWith(".vshost"))
                myProcessName = myProcessName.Replace(".vshost", string.Empty);
            string licenseFilename = string.Format("{0}\\{1}.license",
                GCS.Framework.Utilities.SystemUtilities.MyFolderLocation,
                myProcessName);

            LoadLicense(GCS.Framework.Licensing.Constants.PublicKey, licenseFilename);
            return true;
        }

        public bool LoadLicense(string publicKey, string licenseFilename)
        {
                    IsLicenseValid = true;
            //try
            //{
            //    if (File.Exists(licenseFilename) == false)
            //    {
            //        CustomErrors.Add(new CustomError(string.Format(Properties.Resources.LicenseFileDoesNotExist, licenseFilename)));
            //        return false;
            //    }

            //    using (var streamReader = new StreamReader(licenseFilename))
            //    {
            //        _license = License.Load(streamReader);
            //    }

            //    var validationFailures = _license.Validate()
            //                                  .IsLicensedTo(CustomerName.Trim(), CustomerEmail.Trim())
            //                                  .And()
            //                                  .Signature(publicKey)
            //                                  .AssertValidLicense();

            //    _licenseValidationFailures = validationFailures as IValidationFailure[] ?? validationFailures.ToArray();

            //    foreach (var validationFailure in _licenseValidationFailures)
            //    {
            //        CustomErrors.Add(new CustomError(string.Format("{0}: {1}", validationFailure.Message, validationFailure.HowToResolve)));
            //    }

            //    if (!_licenseValidationFailures.Any())
            //        IsLicenseValid = true;
            //    else
            //        IsLicenseValid = false;
            //}
            //catch (Exception ex)
            //{
            //    CustomErrors.Add(new CustomError(ex.Message));
            //}
            return IsLicenseValid;
        }

        #endregion

        #region Private methods
        private string LoadPublicKeyFile(string filename)
        {
            string sReturn = string.Empty;
            using (var streamReader = new StreamReader(filename))
            {
                sReturn = streamReader.ReadToEnd();
            }
            return sReturn;
        }
        #endregion
    }
}
