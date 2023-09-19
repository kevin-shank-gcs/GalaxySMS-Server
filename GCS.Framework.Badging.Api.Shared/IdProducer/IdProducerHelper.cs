using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using GCS.Framework.Badging.IdProducer.Entities;

namespace GCS.Framework.Badging.IdProducer
{
    public static class IdProducerHelper
    {
        public static idProducerAPI GetIdProducerApi(string url, string devUrl, string username, string password)
        {
            return new idProducerAPI(url, username, password, devUrl, string.Empty);
        }
        public static idProducerAPI GetLicenseBotApi(string url, string devUrl)
        {
            return IdProducerHelper.GetIdProducerApi(url, devUrl, "licensebot@specsid.com", "p@$$30Rd");
        }

        private static SubscriptionData GetRootSubscription(string url, string devUrl, string username, string password, int rootSubId)
        {
            try
            {
                SubscriptionData rootSub = null;
                var idpApi = IdProducerHelper.GetIdProducerApi(url, devUrl, username, password);
                var subscriptions = idpApi.GetAllSubscriptionsResponse();
                SubscriptionData result = null;
                if (subscriptions.IsSuccessful)
                {
                    rootSub = subscriptions.Subscriptions.FirstOrDefault(o => o.ID == rootSubId);
                }

                return rootSub;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"IdProducerHelper.EnsureIsLicensed exception: {ex.ToString()}");
            }

            return null;
        }

        public static bool EnsureIsLicensed(string url, string devUrl, string username, string password, SaveMasterLicenseParameters parameters)
        {
            try
            {
                var isLicensed = false;
                var rootSub = IdProducerHelper.GetRootSubscription(url, devUrl, username, password, parameters.ID);
                if (rootSub != null)
                {
                    return true;
                }

                var idpLicenseApi = IdProducerHelper.GetLicenseBotApi(url, devUrl);
                var sanitizedCompanyName = idpLicenseApi.SanitizeString(parameters.CompanyName);
                parameters.CompanyName = sanitizedCompanyName;

                var license = new SetMasterLicenseData
                {
                    ID = 1000,
                    CompanyName = parameters.CompanyName
                };
                license.FriendlyLicenseDetails.SubscriptionID = license.ID;
                license.FriendlyLicenseDetails.OEMLicenseCode = "Z4FEUayvbDwBvwzftI74LQ==";
                license.FriendlyLicenseDetails.IsLicensePeriodUnlimited = parameters.IsLicensePeriodUnlimited;
                license.FriendlyLicenseDetails.IsTrialPeriod = parameters.IsTrialPeriod;
                license.FriendlyLicenseDetails.LicensedMaxPrinterCount = parameters.LicensedMaxPrinterCount;
                license.FriendlyLicenseDetails.SupportsMultiplePrinters = parameters.SupportsMultiplePrinters;
                license.FriendlyLicenseDetails.MaxCustomerCount = parameters.MaxCustomerCount;
                if (!string.IsNullOrEmpty(parameters.DefaultTimeZone))
                    license.DefaultTimeZone = parameters.DefaultTimeZone;
                license.Email = parameters.Email;
                license.IsInactive = parameters.IsInactive;
                //license.ContactFirstName = parameters.ContactFirstName;
                //license.ContactLastName = parameters.ContactLastName;
                //license.ContactMiddleName = parameters.ContactMiddleName;
                //license.Address = parameters.Address;
                //license.City = parameters.City;
                //license.State = parameters.State;
                //license.ZipCode = parameters.ZipCode;
                //license.Telephone = parameters.Telephone;
                //license.CustomerNb = parameters.CustomerNb;
                //license.Notes = parameters.Notes;
                dynamic ret = idpLicenseApi.SetMasterLicense(license);
                if (ret["IsSuccessful"].Value)
                {
                    isLicensed = true;
                    rootSub = IdProducerHelper.GetRootSubscription(url, devUrl, username, password, parameters.ID);
                }

                idpLicenseApi = GetIdProducerApi(url, devUrl, username, password);
                var allUsers = idpLicenseApi.GetAllUsersResponse();
                if (allUsers?.Users?.FirstOrDefault(u => u.UserName == parameters.MasterUserName) == null)
                {
                    var addUserResult = idpLicenseApi.AddUser(new User()
                    {
                        UserName = parameters.MasterUserName,
                        FirstName = "Galaxy API",
                        LastName = "Root User",
                        Password = parameters.MasterPassword,
                        RoleID = 10,
                        SubscriptionID = license.ID
                    });

                }

                return rootSub != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
