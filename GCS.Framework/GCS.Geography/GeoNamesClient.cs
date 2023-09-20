using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.WebApi;
using GCS.Framework.Geography.DataClasses;

namespace GCS.Framework.Geography
{
    public class GeoNamesClient : WebApiClientBase
    {
        private string _defaultServerUrl = "http://api.geonames.org";
        private string _defaultUserName = "galaxycontrolsystems";
        private string _pingAddress = "www.geonames.org";
        public GeoNamesClient() : base()
        {
            DefaultWebServiceCallProperties.ServerUrl = _defaultServerUrl;
        }

        public GeoNamesClient(string serverUrl)
            : base(serverUrl)
        {
        }

        public GeoNamesClient(string serverUrl, ContentType contentType)
            : base(serverUrl, contentType)
        {
        }

        public async Task<PingReply> Ping()
        {
            return await Task.Run(() =>
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                try
                {
                    PingReply reply = pingSender.Send(_pingAddress, timeout, buffer,
                        options);
                    return reply;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                    throw;
                }
            });
        }
        public async Task<PostalCodeList> LookupPostalCode(LookupPostalCodeParameters parameters, WebServiceCallProperties callProperties = null)
        {
            if (callProperties == null)
            {
                callProperties = DefaultWebServiceCallProperties;
                callProperties.ServerUrl = _defaultServerUrl;
            }

            if (parameters == null)
                return null;

            if (string.IsNullOrEmpty(parameters.UserName))
                parameters.UserName = _defaultUserName;

            callProperties.UrlSuffix = string.Format("postalCodeLookupJSON?formatted=true&postalcode={0}&country={1}&username={2}&style=full",
                parameters.PostalCode, parameters.CountryCode, parameters.UserName);
            var returnData = await GetAsync<PostalCodeList>(callProperties);
            return returnData;
        }

        public async Task<TimeZoneInformationForLocation> RequestTimeZoneInformationForLocation(RequestTimeZoneInformationForLocationParameters parameters, WebServiceCallProperties callProperties = null)
        {
            if (callProperties == null)
            {
                callProperties = DefaultWebServiceCallProperties;
                callProperties.ServerUrl = _defaultServerUrl;
            }

            if (parameters == null)
                return null;

            if (string.IsNullOrEmpty(parameters.UserName))
                parameters.UserName = _defaultUserName;

            callProperties.UrlSuffix = string.Format("timezoneJSON?lat={0}&lng={1}&username={2}",
                parameters.Latitude, parameters.Longitude, parameters.UserName);
            var returnData = await GetAsync<TimeZoneInformationForLocation>(callProperties);
            return returnData;
        }

        public async Task<CountryList> RequestCountryList(RequestCountryInformationParameters parameters, WebServiceCallProperties callProperties = null)
        {
            if (callProperties == null)
            {
                callProperties = DefaultWebServiceCallProperties;
                callProperties.ServerUrl = _defaultServerUrl;
            }

            if (parameters == null)
                return null;

            if (string.IsNullOrEmpty(parameters.UserName))
                parameters.UserName = _defaultUserName;

            callProperties.UrlSuffix = string.Format("countryInfoJSON?&username={0}",
                parameters.UserName);
            if (!string.IsNullOrEmpty(parameters.Language))
                callProperties.UrlSuffix += string.Format("&lang={0}", parameters.Language);
            if (!string.IsNullOrEmpty(parameters.Country))
                callProperties.UrlSuffix += string.Format("&country={0}", parameters.Country);

            var returnData = await GetAsync<CountryList>(callProperties);
            return returnData;
        }

        public async Task<CountryPostalCodeInformationList> RequestCountryPostalCodeInformationList(RequestCountryPostalCodeInformationParameters parameters, WebServiceCallProperties callProperties = null)
        {
            if (callProperties == null)
            {
                callProperties = DefaultWebServiceCallProperties;
                callProperties.ServerUrl = _defaultServerUrl;
            }

            if (parameters == null)
                return null;

            if (string.IsNullOrEmpty(parameters.UserName))
                parameters.UserName = _defaultUserName;

            callProperties.UrlSuffix = string.Format("postalCodeCountryInfoJSON?&username={0}",
                parameters.UserName);

            var returnData = await GetAsync<CountryPostalCodeInformationList>(callProperties);
            return returnData;
        }
    }
}
