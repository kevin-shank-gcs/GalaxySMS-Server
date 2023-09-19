using GCS.Framework.Security;
using Portable.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Licensing.Generator
{
    public class GenerateLicenseRequestData
    {
        private string _defaultCustomerName = "Acme Corporation";
        private string _defaultEmailAddress = "roadrunner@acmecorp.com";

        public GenerateLicenseRequestData()
        {
            CustomerName = _defaultCustomerName;
            EmailAddress = _defaultEmailAddress;
            ExpiresAt = DateTime.Today;
            LicenseType = LicenseType.Trial;
            Features = new Dictionary<string, string>();
            Attributes = new Dictionary<string, string>();
        }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public LicenseType LicenseType { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int MaximumUtilizations { get; set; }
        public Dictionary<string, string> Features { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
    public class LicenseGenerator
    {
        class Keys
        {
            public string PublicKey { get; set; }
            public string PrivateKey { get; set; }
            public string Password { get; set; }
        }
        private static Keys CreateKeys(string password)
        {
            var returnData = new Keys();
            password = password?.Trim();
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(password))
            {
                var pwdGen = new PasswordGeneratorValidator();
                password = pwdGen.GeneratePassword(new GeneratePasswordParameters()
                {
                    MinimumLength = 16,
                    MaximumLength = 16,
                    IncludeLowerCaseCharacterCount = 2,
                    IncludeUpperCaseCharacterCount = 2,
                    IncludeNumericDigitCount = 2,
                    IncludeSpecialCharacterCount = 2,
                });
            }

            returnData.Password = password;

            // The key generator with the ECDSA method.
            var keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create();

            // The key par which holds both keys.
            var keyPair = keyGenerator.GenerateKeyPair();

            // The private key. Created by use of the entered password.
            returnData.PrivateKey = keyPair.ToEncryptedPrivateKeyString(password);

            // The public key. Just extracted out of the key pair.
            returnData.PublicKey = keyPair.ToPublicKeyString();
            return returnData;

        }

        public static LicenseData GenerateLicense(GenerateLicenseRequestData data)
        {
            if (data == null)
                return null;

            var keys = CreateKeys(string.Empty);

            var license = License.New()
                .WithUniqueIdentifier(Guid.NewGuid())
                .As(data.LicenseType)
                .ExpiresAt(data.ExpiresAt)
                .WithMaximumUtilization(data.MaximumUtilizations)
                .LicensedTo(data.CustomerName.Trim(), data.EmailAddress.Trim())
                .WithProductFeatures(data.Features)
                .WithAdditionalAttributes(data.Attributes)
                .CreateAndSignWithPrivateKey(keys.PrivateKey, keys.Password.Trim());

            var returnData = new LicenseData();
            returnData.InitializeFromXmlString(keys.PublicKey, license.ToString());

            return returnData;
        }

        public static void ValidateLicense(string publicKey, string license, string licenseKeyInvalidMessage, string licenseInvalidMessage)
        {
            if (string.IsNullOrEmpty(license) == false)
            {
                if (string.IsNullOrEmpty(publicKey))
                    throw new ApplicationException(licenseKeyInvalidMessage);
                var licenseData = new LicenseData();
                if (licenseData.InitializeFromXmlString(publicKey, license) == false)
                {
                    var validationMessages = new StringBuilder();
                    foreach (var validationError in licenseData.LicenseValidationFailures)
                    {
                        validationMessages.Append(validationError.Message);
                        validationMessages.Append(validationError.HowToResolve);
                    }
                    var innerEx = new ApplicationException(validationMessages.ToString());
                    var ex = new ApplicationException(licenseInvalidMessage, innerEx);
                    throw ex;
                }
            }
        }
    }

}
