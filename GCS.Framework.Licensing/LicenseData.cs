using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.IO;
using System.Linq;
using GCS.Framework.Licensing.Properties;
using Portable.Licensing;
using Portable.Licensing.Prime;
using Portable.Licensing.Prime.Validation;

namespace GCS.Framework.Licensing
{
    public class LicenseData
    {
        #region Private fields

        #endregion

        #region Constructors

        public LicenseData()
        {

        }
        #endregion

        #region Public properties

        public bool IsLicenseValid { get; internal set; }

        public License License { get; private set; }

        public string LicensedCustomerName
        {
            get
            {
                if (License == null)
                    return string.Empty;
                return License.Customer.Name;
            }
        }

        public string LicensedCustomerCompany
        {
            get
            {
                if (License == null)
                    return string.Empty;
                return License.Customer.Company;
            }
        }

        public string LicensedCustomerEmail
        {
            get
            {
                if (License == null)
                    return string.Empty;
                return License.Customer.Email;
            }
        }

        public DateTimeOffset LicenseExpiration
        {
            get
            {
                if (License == null)
                    return DateTimeOffset.MinValue;
                return License.Expiration;
            }
        }

        public LicenseType LicenseType
        {
            get
            {
                if (License == null)
                    return LicenseType.Trial;
                return License.Type;
            }
        }

        public string LicenseTypeDescription
        {
            get
            {
                if (License == null)
                    return Resources.LicenseTypeNone;
                switch (LicenseType)
                {
                    case LicenseType.Standard:
                        return Resources.LicenseTypeStandard;
                    case LicenseType.Trial:
                        return Resources.LicenseTypeTrial;
                }
                return Resources.LicenseTypeNone;
            }
        }

        public Guid LicenseId
        {
            get
            {
                if (License == null)
                    return Guid.Empty;
                return License.Id;
            }
        }

        public int Quantity
        {
            get
            {
                if (License == null)
                    return 0;
                return License.Quantity;
            }
        }

        public string PublicKey { get; internal set; }

        public IDictionary<string, string> ProductFeatures
        {
            get
            {
                if (License == null)
                    return null;
                return License.ProductFeatures.GetAll();
            }
        }

        public IEnumerable<IValidationFailure> LicenseValidationFailures { get; internal set; }

        #endregion

        #region Public Methods

        public bool LoadFromFile(string publicKey, string filename)
        {
            if (File.Exists(filename) == false)
            {
                throw new FileNotFoundException(Resources.LicenseFileDoesNotExist, filename);
            }

            using (var streamReader = new StreamReader(filename))
            {
                License = License.Load(streamReader);
            }

            var validationFailures = License.Validate()
                .Signature(publicKey)
                .AssertValidLicense();

            //var validationFailures = _license.Validate()
            //                              .IsLicensedTo(customerName.Trim(), customerEmail.Trim())
            //                              .And()
            //                              .Signature(publicKey)
            //                              .AssertValidLicense();

            LicenseValidationFailures = validationFailures as IValidationFailure[] ?? validationFailures.ToArray();

            if (!LicenseValidationFailures.Any())
            {
                IsLicenseValid = true;
                PublicKey = publicKey;
            }
            else
                IsLicenseValid = false;
            return IsLicenseValid;
        }

        public bool InitializeFromXmlString(string publicKey, string xmlString)
        {
            if (string.IsNullOrEmpty(xmlString))
                throw new ArgumentNullException(xmlString, Resources.LicenseDataDoesNotExist);
            License = License.Load(xmlString);

            var validationFailures = License.Validate()
                .Signature(publicKey)
                .AssertValidLicense();

            //var validationFailures = _license.Validate()
            //                              .IsLicensedTo(customerName.Trim(), customerEmail.Trim())
            //                              .And()
            //                              .Signature(publicKey)
            //                              .AssertValidLicense();

            LicenseValidationFailures = validationFailures as IValidationFailure[] ?? validationFailures.ToArray();

            if (!LicenseValidationFailures.Any())
            {
                IsLicenseValid = true;
                PublicKey = publicKey;
            }
            else
                IsLicenseValid = false;
            return IsLicenseValid;
        }

        public override string ToString()
        {
            if (IsLicenseValid)
                return License.ToString();
            return string.Empty;
        }

        public T GetFeatureValue<T>(string feature)
        {
            T returnValue = default(T);
            if (License.ProductFeatures.Contains(feature))
            {
                var value = License.ProductFeatures.Get(feature);
                returnValue = (T)Convert.ChangeType(value, typeof(T));
            }
            return returnValue;
        }
        #endregion


    }
}