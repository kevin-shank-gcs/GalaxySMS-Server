using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Xml;
using GCS.Framework.Badging.Api.IdProducer.Entities;
using GCS.Framework.Badging.IdProducer.Entities;
using TimeZoneNames;
using System.Diagnostics;
using GCS.Core.Common.Extensions;

namespace GCS.Framework.Badging.IdProducer
{
    /// <summary>
    /// Wrapper class for idProducer JSON API calls
    /// </summary>
    public class idProducerAPI
    {
        private string webBaseUrl;
        private string webBaseDevUrl;
        private string webUser;
        private string webPassword;
        private readonly string _invalidCompanyNameCharacters  = string.Format("!%^&*+=[]{{}}\\|\"<>,?/");

        public enum FieldType
        {
            Text = 1,       // Text field
            Photograph = 2, // Photograph field
            Signature = 3,  // Signature field
            Numeric = 4,    // Numeric field
            Date = 5,       // Date field
            IssuanceNumber = 6  // Issuance number field
        }

        public idProducerAPI(string url, string user, string password, string devUrl)
        {
            this.webBaseUrl = url;
            this.webUser = user;
            this.webPassword = password;
            this.webBaseDevUrl = devUrl;
        }

        private WebClient GetWebClient()
        {
            WebClient client = new WebClient();
            string userName = webUser;
            string password = webPassword;
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + password));
            client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            return client;
        }


        public string SanitizeString(string sanitizeThis)
        {
            return sanitizeThis.RemoveSpecialCharacters(_invalidCompanyNameCharacters);
        }
        //--- API Methods
        //public object GetServerVersionNumber()
        //{
        //    using (WebClient wc = GetWebClient())
        //    {
        //        string s = wc.DownloadString(webBaseUrl + "jsGetServerVersionNumber");
        //        return JsonConvert.DeserializeObject(s);
        //    }
        //}

        public GetServerVersionNumberResponse GetServerVersionNumber()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetServerVersionNumber");
                return JsonConvert.DeserializeObject<GetServerVersionNumberResponse>(s);
            }

        }

        public object GetSubscriptionBranch()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseDevUrl + "jsGetSubscriptionBranch");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public SubscriptionBranchData GetSubscriptionBranchData()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseDevUrl + "jsGetSubscriptionBranch");
                return JsonConvert.DeserializeObject<SubscriptionBranchData>(s);
            }
        }

        public object GetAllCardTemplatesLite()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllCardTemplatesLite");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public GetAllCardTemplatesLiteResponse GetAllCardTemplatesLiteResponse()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllCardTemplatesLite");
                return JsonConvert.DeserializeObject<GetAllCardTemplatesLiteResponse>(s);
            }
        }

        public object GetCardTemplateByName(string templateName)
        {
            using (WebClient wc = GetWebClient())
            {
                wc.QueryString.Add("cardTemplateName", templateName);
                string s = wc.DownloadString(webBaseUrl + "jsGetCardTemplateByName");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public CardTemplateResponse GetCardTemplateByNameReponse(string templateName)
        {
            using (WebClient wc = GetWebClient())
            {
                wc.QueryString.Add("cardTemplateName", templateName);
                string s = wc.DownloadString(webBaseUrl + "jsGetCardTemplateByName");
                return JsonConvert.DeserializeObject<CardTemplateResponse>(s);
            }
        }

        public object GetCardTemplateLiteByName(string templateName)
        {
            using (WebClient wc = GetWebClient())
            {
                wc.QueryString.Add("cardTemplateName", templateName);
                string s = wc.DownloadString(webBaseUrl + "jsGetCardTemplateLiteByName");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public GetCardTemplateLiteResponse GetCardTemplateLiteByNameResponse(string templateName)
        {
            using (WebClient wc = GetWebClient())
            {
                wc.QueryString.Add("cardTemplateName", templateName);
                string s = wc.DownloadString(webBaseUrl + "jsGetCardTemplateLiteByName");
                return JsonConvert.DeserializeObject<GetCardTemplateLiteResponse>(s);
            }
        }

        public object LoadTemplate(string cardTemplateID)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    cardTemplateID = cardTemplateID,
                    action = 1
                };

                string s = wc.UploadString(webBaseUrl + "jsCardTemplateAction", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }

        public LoadTemplateResponse LoadTemplateResponse(string cardTemplateID)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    cardTemplateID = cardTemplateID,
                    action = 1
                };

                string s = wc.UploadString(webBaseUrl + "jsCardTemplateAction", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject<LoadTemplateResponse>(s);
            }
        }

        public object SaveTemplate(string cardTemplateID, string data)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    cardTemplateID = cardTemplateID,
                    action = 2,
                    data = new List<String>() { data, "", "false", "" },
                };

                string s = wc.UploadString(webBaseUrl + "jsCardTemplateAction", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }

        public MethodResponse DeleteCardTemplate(string cardTemplateID)
        {
            var requestsClosed = CloseAllPrintRequestsForCardTemplate(cardTemplateID, "Template deleted");

            using (WebClient wc = GetWebClient())
            {
                wc.QueryString.Add("cardTemplateID", cardTemplateID);
                string s = wc.DownloadString(webBaseUrl + "jsDeleteCardTemplate");
                return JsonConvert.DeserializeObject<MethodResponse>(s);
            }
        }

        public object AddCardTemplate(object cardTemplate)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    cardTemplate = cardTemplate,
                };

                string s = wc.UploadString(webBaseUrl + "jsAddCardTemplate", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }


        public object GetAllSubscriptions()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllSubscriptions");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public GetAllSubscriptionsResponse GetAllSubscriptionsResponse()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllSubscriptions");
                return JsonConvert.DeserializeObject<GetAllSubscriptionsResponse>(s);
            }
        }

        public SubscriptionData AddSubscriptionProfile(SubscriptionData subscription)
        {
            using (WebClient wc = GetWebClient())
            {
                var sanitizedCompanyName = SanitizeString(subscription.CompanyName);
                subscription.CompanyName = sanitizedCompanyName;

                var existingSubs = GetAllSubscriptionsResponse();

                var args = new
                {
                    subscription = new
                    {
                        ParentSubscriptionID = subscription.ParentSubscriptionID,
                        CompanyName = subscription.CompanyName,
                        FriendlyLicenseDetails = new
                        {
                            IsReseller = subscription.FriendlyLicenseDetails.IsReseller,
                            IsLicensePeriodUnlimited = subscription.FriendlyLicenseDetails.IsLicensePeriodUnlimited,
                            IsTrialPeriod = subscription.FriendlyLicenseDetails.IsTrialPeriod,
                            LicensedMaxPrinterCount = subscription.FriendlyLicenseDetails.LicensedMaxPrinterCount,
                            SupportsMultiplePrinters = subscription.FriendlyLicenseDetails.SupportsMultiplePrinters
                        },
                        ContactFirstName = subscription.ContactFirstName,
                        ContactLastName = subscription.ContactLastName,
                        ContactMiddleName = subscription.ContactMiddleName,
                        Email = subscription.Email,
                        Address = subscription.Address,
                        City = subscription.City,
                        State = subscription.State,
                        ZipCode = subscription.ZipCode,
                        Country = subscription.Country,
                        Telephone = subscription.Telephone,
                        CustomerNb = subscription.CustomerNb,
                        IsInactive = subscription.IsInactive,
                        DefaultTimeZone = subscription.DefaultTimeZone,
                        Notes = subscription.Notes,
                        SubscriptionConfig = new { }
                    },
                    masterUserName = subscription.MasterUserName,
                    masterPassword = subscription.MasterPassword

                };

                var sData = JsonConvert.SerializeObject(args);

                string s = wc.UploadString(webBaseDevUrl + "jsAddSubscriptionProfile", sData);

                dynamic ret = JsonConvert.DeserializeObject(s);
                if (ret["IsSuccessful"].Value)
                {
                    var sValue = ret["RecordID"].Value.ToString();
                    int subId = 0;
                    if (int.TryParse(sValue, out subId))
                    {
                        var subs = GetAllSubscriptionsResponse();
                        if (subs?.Subscriptions != null)
                        {
                            var theSub = subs.Subscriptions.FirstOrDefault(o => o.CompanyName == subscription.CompanyName);
                            if (theSub == null)
                            {
                                var newSub = subs.Subscriptions.Where(p => existingSubs.Subscriptions.All(p2 => p2.ID != p.ID));
                                theSub = newSub.FirstOrDefault();
                            }
                            return theSub;
                        }
                    }
                }

                return null;
            }
        }

        public SubscriptionData UpdateSubscriptionProfile(SubscriptionData subscription)
        {
            using (WebClient wc = GetWebClient())
            {
                var sanitizedCompanyName = SanitizeString(subscription.CompanyName);
                subscription.CompanyName = sanitizedCompanyName;

                var args = new
                {
                    subscription = new
                    {
                        ID = subscription.ID,
                        ParentSubscriptionID = subscription.ParentSubscriptionID,
                        CompanyName = subscription.CompanyName,
                        FriendlyLicenseDetails = new
                        {
                            SubscriptionID = subscription.ID,
                            OEMLicenseCode = subscription.FriendlyLicenseDetails.OEMLicenseCode,
                            MachineLockCode = subscription.FriendlyLicenseDetails.MachineLockCode,
                            IsReseller = subscription.FriendlyLicenseDetails.IsReseller,
                            IsLicensePeriodUnlimited = subscription.FriendlyLicenseDetails.IsLicensePeriodUnlimited,
                            IsTrialPeriod = subscription.FriendlyLicenseDetails.IsTrialPeriod,
                            LicensedMaxPrinterCount = subscription.FriendlyLicenseDetails.LicensedMaxPrinterCount,
                            SupportsMultiplePrinters = subscription.FriendlyLicenseDetails.SupportsMultiplePrinters,
                            IsProductionServer = subscription.FriendlyLicenseDetails.IsProductionServer,
                            LicensedMaxIssuanceCount = subscription.FriendlyLicenseDetails.LicensedMaxIssuanceCount,
                            LicensePeriodString = subscription.FriendlyLicenseDetails.LicensePeriodString,
                            LicenseState = subscription.FriendlyLicenseDetails.LicenseState,
                            MaxCustomerCount = subscription.FriendlyLicenseDetails.MaxCustomerCount,
                            MaxPrintDispatchersCount = subscription.FriendlyLicenseDetails.MaxPrintDispatchersCount,
                            MaxIndividualsCount = subscription.FriendlyLicenseDetails.MaxIndividualsCount,
                            MaxTemplatesCount = subscription.FriendlyLicenseDetails.MaxTemplatesCount,
                            MaxEnrollmentFormsCount = subscription.FriendlyLicenseDetails.MaxEnrollmentFormsCount,
                            MaxRemotePrintsCount = subscription.FriendlyLicenseDetails.MaxRemotePrintsCount,
                            MaxCaptureHandlersCount = subscription.FriendlyLicenseDetails.MaxCaptureHandlersCount,
                            SupportsMultipleResellers = subscription.FriendlyLicenseDetails.SupportsMultipleResellers,
                            CanResellerCreateResellers = subscription.FriendlyLicenseDetails.CanResellerCreateResellers
                        },
                        ContactFirstName = subscription.ContactFirstName,
                        ContactLastName = subscription.ContactLastName,
                        ContactMiddleName = subscription.ContactMiddleName,
                        Email = subscription.Email,
                        Address = subscription.Address,
                        City = subscription.City,
                        State = subscription.State,
                        ZipCode = subscription.ZipCode,
                        Country = subscription.Country,
                        Telephone = subscription.Telephone,
                        CustomerNb = subscription.CustomerNb,
                        IsInactive = subscription.IsInactive,
                        DefaultTimeZone = subscription.DefaultTimeZone,
                        Notes = subscription.Notes,
                        SubscriptionConfig = new { }
                    },
                    //masterUserName = subscription.MasterUserName,
                    //masterPassword = subscription.MasterPassword

                };

                var sData = JsonConvert.SerializeObject(args);

                string s = wc.UploadString(webBaseDevUrl + "jsUpdateSubscriptionProfile", sData);
                dynamic ret = JsonConvert.DeserializeObject(s);

                if (ret["IsSuccessful"].Value)
                {
                    var sValue = ret["RecordID"].Value.ToString();
                    int subId = 0;
                    if (int.TryParse(sValue, out subId))
                    {
                        var subs = GetAllSubscriptionsResponse();
                        if (subs?.Subscriptions != null)
                        {
                            var theSub = subs.Subscriptions.FirstOrDefault(o => o.CompanyName == subscription.CompanyName);
                            if (theSub == null)
                            {
                                theSub = subs.Subscriptions.FirstOrDefault(o => o.ID == subscription.ID);
                            }
                            return theSub;
                        }
                    }
                }
                else
                    Trace.WriteLine($"ret is not successful");
                return null;
            }
        }

        public object SetMasterLicense(SetMasterLicenseData lic)
        {
            using (WebClient wc = GetWebClient())
            {
                var sanitizedCompanyName = SanitizeString(lic.CompanyName);
                lic.CompanyName = sanitizedCompanyName;

                var args = new
                {
                    subscription = new
                    {
                        ID = 1000,
                        CompanyName = lic.CompanyName,
                        FriendlyLicenseDetails = new
                        {
                            SubscriptionID = 1000,
                            OEMLicenseCode = "Z4FEUayvbDwBvwzftI74LQ==",
                            IsLicensePeriodUnlimited = lic.FriendlyLicenseDetails.IsLicensePeriodUnlimited,
                            IsTrialPeriod = lic.FriendlyLicenseDetails.IsTrialPeriod,
                            LicensedMaxPrinterCount = lic.FriendlyLicenseDetails.LicensedMaxPrinterCount,
                            SupportsMultiplePrinters = lic.FriendlyLicenseDetails.SupportsMultiplePrinters
                        },
                        ContactFirstName = lic.ContactFirstName,
                        ContactLastName = lic.ContactLastName,
                        Email = lic.Email,
                        IsInactive = lic.IsInactive,
                        DefaultTimeZone = lic.DefaultTimeZone,
                        ContactMiddleName = lic.ContactMiddleName,
                        Address = lic.Address,
                        City = lic.City,
                        State = lic.State,
                        ZipCode = lic.ZipCode,
                        Telephone = lic.Telephone,
                        CustomerNb = lic.CustomerNb,
                        Notes = lic.Notes
                    }
                };

                //var sData = JsonConvert.SerializeObject(args);
                string s = wc.UploadString(webBaseDevUrl + "jsUpdateSubscriptionProfile", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }

        public IEnumerable<TZ> GetTimeZones()
        {
            var timeZones = System.TimeZoneInfo.GetSystemTimeZones();
            var arr = new List<TZ>();
            foreach (TimeZoneInfo t in timeZones)
            {
                var tzv = TZNames.GetNamesForTimeZone(t.DisplayName,
                    System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
                // t.Id (unique id of time zone, what we're using)  tzv.Generic (localized name of time zone)
                arr.Add(new TZ() { ID = t.Id, DisplayName = tzv.Generic });
            }
            return arr;
        }

        public object AddUser(User user)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    user = new
                    {
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password,
                        RoleID = user.RoleID,
                        SubscriptionID = user.SubscriptionID,
                    },
                    permissionIDs = new { }
                };

                var sData = JsonConvert.SerializeObject(args);
                string s = wc.UploadString(webBaseDevUrl + "jsAddUser", sData);
                return JsonConvert.DeserializeObject(s);
            }
        }
        //public object UpdateSubscription(object subscription)
        //{
        //    using (WebClient wc = GetWebClient())
        //    {
        //        var args = new
        //        {
        //            subscription = subscription,
        //        };

        //        string s = wc.UploadString(webBaseUrl + "jsUpdateSubscription", JsonConvert.SerializeObject(args));
        //        return JsonConvert.DeserializeObject(s);
        //    }
        //}

        public object GetAllSubscriptionTemplateFieldsByTemplateName(string templateName)
        {
            using (WebClient wc = GetWebClient())
            {
                wc.QueryString.Add("templateName", templateName);
                string s = wc.DownloadString(webBaseUrl + "jsGetAllSubscriptionTemplateFieldsByTemplateName");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public SubscriptionTemplateFieldsResponse GetAllSubscriptionTemplateFieldsByTemplateNameResponse(string templateName)
        {
            using (WebClient wc = GetWebClient())
            {
                wc.QueryString.Add("templateName", templateName);
                string s = wc.DownloadString(webBaseUrl + "jsGetAllSubscriptionTemplateFieldsByTemplateName");
                return JsonConvert.DeserializeObject<SubscriptionTemplateFieldsResponse>(s);
            }
        }

        //public object GetAllSubscriptionTemplateFields()
        //{
        //    using (WebClient wc = GetWebClient())
        //    {
        //        string s = wc.DownloadString(webBaseUrl + "jsGetAllSubscriptionTemplateFields");
        //        return JsonConvert.DeserializeObject(s);
        //    }
        //}
        public SubscriptionTemplateFieldsResponse GetAllSubscriptionTemplateFields()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllSubscriptionTemplateFields");
                return JsonConvert.DeserializeObject<SubscriptionTemplateFieldsResponse>(s);
            }
        }



        public string GetAllSubscriptionTemplateFieldsString()
        {
            using (WebClient wc = GetWebClient())
            {
                var results = string.Empty;
                string s = wc.DownloadString(webBaseUrl + "jsGetAllSubscriptionTemplateFields");
                dynamic ret = JsonConvert.DeserializeObject(s);
                if (ret["IsSuccessful"].Value)
                {
                    results = ret["SubscriptionTemplateFields"].ToString();
                }

                return results;
            }
        }

        public SubscriptionTemplateFieldsResponse GetAllSubscriptionTemplateFieldsResponse()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllSubscriptionTemplateFields");
                return JsonConvert.DeserializeObject<SubscriptionTemplateFieldsResponse>(s);
            }
        }

        public object GetAllTemplateFieldFormats()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllTemplateFieldFormats");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public string GetAllTemplateFieldFormatsString()
        {
            using (WebClient wc = GetWebClient())
            {
                var results = string.Empty;
                string s = wc.DownloadString(webBaseUrl + "jsGetAllTemplateFieldFormats");
                dynamic ret = JsonConvert.DeserializeObject(s);
                if (ret["IsSuccessful"].Value)
                {
                    results = ret["TemplateFieldFormats"].ToString();
                }

                return results;
            }
        }


        public TemplateFieldFormatResponse GetAllTemplateFieldFormatsResponse()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllTemplateFieldFormats");
                return JsonConvert.DeserializeObject<TemplateFieldFormatResponse>(s);
            }
        }

        public object GetAllTemplateFieldTypes()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = string.Empty;
                if (!string.IsNullOrEmpty(webBaseDevUrl))
                    s = wc.DownloadString(webBaseDevUrl + "jsGetAllTemplateFieldTypes");
                else s = wc.DownloadString(webBaseUrl + "jsGetAllTemplateFieldTypes");
                return JsonConvert.DeserializeObject(s);
            }
        }


        public object AddSubscriptionTemplateField(object subscriptionTemplateField)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    subscriptionTemplateField = subscriptionTemplateField,
                };

                string s = wc.UploadString(webBaseUrl + "jsAddSubscriptionTemplateField", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }

        public object UpdateSubscriptionTemplateField(object subscriptionTemplateField)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    subscriptionTemplateField = subscriptionTemplateField,
                };

                string s = wc.UploadString(webBaseUrl + "jsUpdateSubscriptionTemplateField", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }

        public object DeleteSubscriptionTemplateField(int subscriptionTemplateFieldID)
        {
            using (WebClient wc = GetWebClient())
            {
                wc.QueryString.Add("subscriptionTemplateFieldID", subscriptionTemplateFieldID.ToString());
                string s = wc.DownloadString(webBaseUrl + "jsDeleteSubscriptionTemplateField");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public object GetCardPreviewImgs(string payload, string templateName, bool bothSides)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    payload = payload,
                    templateName = templateName,
                    bothSides = bothSides
                };

                string s = wc.UploadString(webBaseUrl + "jsGetCardPreviewImgs", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }


        public PreviewDataResponse GetCardPreviewImgsResponse(string payload, string templateName, bool bothSides)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    payload = payload,
                    templateName = templateName,
                    bothSides = bothSides
                };

                string s = wc.UploadString(webBaseUrl + "jsGetCardPreviewImgs", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject<PreviewDataResponse>(s);
            }
        }

        public object GetAllPrinters()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllPrinters");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public PrintersResponse GetAllPrintersResponse()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllPrinters");
                return JsonConvert.DeserializeObject<PrintersResponse>(s);
            }
        }

        public object GetAllPrintDispatchers()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllPrintDispatchers");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public PrinterDispatchersResponse GetAllPrintDispatchersResponse()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllPrintDispatchers");
                return JsonConvert.DeserializeObject<PrinterDispatchersResponse>(s);
            }
        }


        // Version 1.3.6 signature
        //public object CreateDirectPrintRequests(string externalUserId, string printerName, string templateName, string payload, bool failIfDispatcherStopped)
        //{
        //    using (WebClient wc = GetWebClient())
        //    {
        //        var args = new
        //        {
        //            externalUserID = externalUserId,
        //            printerName = printerName,
        //            templateName = templateName,
        //            payload = payload,
        //            failIfDispatcherStopped = failIfDispatcherStopped,
        //        };

        //        string s = wc.UploadString(webBaseUrl + "jsCreateDirectPrintRequests", JsonConvert.SerializeObject(args));
        //        return JsonConvert.DeserializeObject(s);
        //    }
        //}

        // Version 1.5.6638.27796
        public object CreateDirectPrintRequests(string externalUserID, int printerID, int templateID, string payload, bool failIfDispatcherStopped)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    externalUserID = externalUserID,
                    printerID = printerID,
                    templateID = templateID,
                    payload = payload,
                    failIfDispatcherStopped = failIfDispatcherStopped,
                };

                string s = wc.UploadString(webBaseUrl + "jsCreateDirectPrintRequests", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }
        public CreatedPrintRequestResponse CreateDirectPrintRequestsResponse(string externalUserID, int printerID, int templateID, string payload, bool failIfDispatcherStopped)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    externalUserID = externalUserID,
                    printerID = printerID,
                    templateID = templateID,
                    payload = payload,
                    failIfDispatcherStopped = failIfDispatcherStopped,
                };

                string s = wc.UploadString(webBaseUrl + "jsCreateDirectPrintRequests", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject<CreatedPrintRequestResponse>(s);
            }
        }

        // Version 1.3.6 signature
        //public object CreateQueuedPrintRequests(string externalUserId, string printDispatcherName, string templateName, string payload)
        //{
        //    using (WebClient wc = GetWebClient())
        //    {
        //        var args = new
        //        {
        //            externalUserID = externalUserId,
        //            printDispatcherName = printDispatcherName,
        //            templateName = templateName,
        //            payload = payload,
        //        };

        //        string s = wc.UploadString(webBaseUrl + "jsCreateQueuedPrintRequests", JsonConvert.SerializeObject(args));
        //        return JsonConvert.DeserializeObject(s);
        //    }
        //}

        // Version 1.5.6638.27796
        public object CreateQueuedPrintRequests(string externalUserID, int printDispatcherID, int templateID, string payload)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    externalUserID = externalUserID,
                    printDispatcherID = printDispatcherID,
                    templateID = templateID,
                    payload = payload,
                };

                string s = wc.UploadString(webBaseUrl + "jsCreateQueuedPrintRequests", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject(s);
            }
        }


        public CreatedPrintRequestResponse CreateQueuedPrintRequestsResponse(string externalUserID, int printDispatcherID, int templateID, string payload)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    externalUserID = externalUserID,
                    printDispatcherID = printDispatcherID,
                    templateID = templateID,
                    payload = payload,
                };

                string s = wc.UploadString(webBaseUrl + "jsCreateQueuedPrintRequests", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject<CreatedPrintRequestResponse>(s);
            }
        }
        //--- Utility methods

        /// <summary>
        /// Generate XML document payload from supplied values (for one record)
        /// </summary>
        /// <param name="identifier">Unique ID for individual print request</param>
        /// <param name="label">Not currently used</param>
        /// <param name="payloadFields">FieldName-Value pairs</param>
        /// <returns></returns>
        public string CreateXmlPayload(string identifier, string label, dynamic payloadFields)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode recordsNode = doc.CreateElement("Records");
            doc.AppendChild(recordsNode);

            // This example creates a single record
            XmlNode recordNode = doc.CreateElement("Record");
            XmlAttribute recordAttribute = doc.CreateAttribute("id");
            recordAttribute.Value = identifier;
            recordNode.Attributes.Append(recordAttribute);

            recordAttribute = doc.CreateAttribute("label");
            recordAttribute.Value = label;
            recordNode.Attributes.Append(recordAttribute);

            recordAttribute = doc.CreateAttribute("card");
            recordAttribute.Value = "";
            recordNode.Attributes.Append(recordAttribute);

            recordsNode.AppendChild(recordNode);

            foreach (dynamic payloadField in payloadFields)
            {
                if (payloadField["Value"] != null)
                {
                    XmlNode recordField = doc.CreateElement(payloadField["FieldName"].Value);
                    recordNode.AppendChild(recordField);
                    recordField.AppendChild(doc.CreateTextNode(payloadField["Value"].Value));
                }
            }

            return doc.InnerXml;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Generate XML document payload from supplied values (for one record) </summary>
        ///
        /// <remarks>   Kevin, 2/20/2018. </remarks>
        ///
        /// <param name="identifier">       Unique ID for individual print request. </param>
        /// <param name="label">            Not currently used. </param>
        /// <param name="payloadFields">    FieldName-Value pairs. </param>
        ///
        /// <returns>   The new XML payload. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CreateXmlPayloadFromKVP(string identifier, string label, List<KeyValuePair<string, string>> payloadFields)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode recordsNode = doc.CreateElement("Records");
            doc.AppendChild(recordsNode);

            // This example creates a single record
            XmlNode recordNode = doc.CreateElement("Record");
            XmlAttribute recordAttribute = doc.CreateAttribute("id");
            recordAttribute.Value = identifier;
            recordNode.Attributes.Append(recordAttribute);

            recordAttribute = doc.CreateAttribute("label");
            recordAttribute.Value = label;
            recordNode.Attributes.Append(recordAttribute);

            recordAttribute = doc.CreateAttribute("card");
            recordAttribute.Value = "";
            recordNode.Attributes.Append(recordAttribute);

            recordsNode.AppendChild(recordNode);

            foreach (var payloadField in payloadFields)
            {
                if (!string.IsNullOrEmpty(payloadField.Value))
                {
                    XmlNode recordField = doc.CreateElement(payloadField.Key);
                    recordNode.AppendChild(recordField);
                    recordField.AppendChild(doc.CreateTextNode(payloadField.Value));
                }
            }

            return doc.InnerXml;
        }


        public object GetAllUsers()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllUsers");
                return JsonConvert.DeserializeObject(s);
            }
        }

        public UsersResponse GetAllUsersResponse()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllUsers");
                return JsonConvert.DeserializeObject<UsersResponse>(s);
            }
        }

        public PrintRequestsResponse GetAllPrintRequests()
        {
            using (WebClient wc = GetWebClient())
            {
                string s = wc.DownloadString(webBaseUrl + "jsGetAllPrintRequests");
                return JsonConvert.DeserializeObject<PrintRequestsResponse>(s);
            }
        }


        public CloseRequestsResponse CloseRequests(List<int> requestIds, string reason)
        {
            using (WebClient wc = GetWebClient())
            {
                var args = new
                {
                    requestIDs = requestIds,
                    reason = reason
                };

                string s = wc.UploadString(webBaseUrl + "jsCloseRequests", JsonConvert.SerializeObject(args));
                return JsonConvert.DeserializeObject<CloseRequestsResponse>(s);
            }
        }

        public bool CloseAllPrintRequestsForCardTemplate(string cardTemplateID, string reason)
        {
            var printRequests = GetAllPrintRequests();
            if (printRequests.IsSuccessful == true)
            {
                int id = 0;
                if (int.TryParse(cardTemplateID, out id))
                {
                    var requestsForTemplate = printRequests.PrintRequests.Where(o => o.CardTemplateID == id).ToList();
                    var printRequestIds = requestsForTemplate.Select(o => o.ID).ToList();
                    var closeRequestsResponse = CloseRequests(printRequestIds, reason);
                    return closeRequestsResponse.IsSuccessful;
                }
            }
            return false;
        }
    }
}
