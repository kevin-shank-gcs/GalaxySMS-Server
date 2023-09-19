using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Licensing.Entities;
using GCS.Core.Common.WebApi;

namespace GalaxySMS.Client.SDK.WebApiClients
{
    public class GalaxyLicenceManagerClient : WebApiClientBase
    {
        private string _defaultServerUrl = "https://localhost:5003/";
        public GalaxyLicenceManagerClient() : base()
        {
            DefaultWebServiceCallProperties.ServerUrl = _defaultServerUrl;
        }

        public GalaxyLicenceManagerClient(string serverUrl)
            : base(serverUrl)
        {
        }

        public GalaxyLicenceManagerClient(string serverUrl, ContentType contentType)
            : base(serverUrl, contentType)
        {
        }

        public async Task<ActivateSystemLicenseEditorDataModel> GetActivateLicenseEditorData(string licenseKey, WebServiceCallProperties callProperties = null)
        {
            if (callProperties == null)
            {
                callProperties = DefaultWebServiceCallProperties;
                callProperties.ServerUrl = _defaultServerUrl;
            }

            if (string.IsNullOrEmpty(licenseKey))
                callProperties.UrlSuffix = $"api/license/activateeditordata";
            else
                callProperties.UrlSuffix = $"api/license/activateeditordata/{licenseKey}";
            var returnData = await GetAsync<ActivateSystemLicenseEditorDataModel>(callProperties);
            return returnData;
        }


        public async Task<ActivatedLicenseModel> ActiveSystemLicense(ActivateSystemLicenseModel data, WebServiceCallProperties callProperties = null)
        {
            if (callProperties == null)
            {
                callProperties = DefaultWebServiceCallProperties;
                callProperties.ServerUrl = _defaultServerUrl;
            }
            callProperties.UrlSuffix = string.Format("api/license/activate");
            var returnData = await DoUploadDataTaskAsync<ActivateSystemLicenseModel, ActivatedLicenseModel>(data, callProperties);
            return returnData;

        }

        //public async Task<string> CreateJwtToken(AuthenticationCredentialModel data, WebServiceCallProperties callProperties = null)
        //{
        //    if (callProperties == null)
        //    {
        //        callProperties = DefaultWebServiceCallProperties;
        //        callProperties.ServerUrl = _defaultServerUrl;
        //    }
        //    callProperties.UrlSuffix = string.Format("api/auth/token");
        //    var returnData = await DoUploadDataTaskAsync<AuthenticationCredentialModel, string>(data, callProperties);
        //    return returnData;

        //}
    }
}
