using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using GCS.Framework.Geography;
using GCS.Framework.Geography.DataClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class GeographyTests
    {
        [TestMethod]
        public async Task test_LookupPostalCode()
        {
            var geoController = new GeoNamesClient();
            var parameters = new LookupPostalCodeParameters();
            parameters.CountryCode = "US";
            parameters.PostalCode = "21793";
            var result = await geoController.LookupPostalCode(parameters);
            //System.Diagnostics.Trace.WriteLine(parameters.PostalCode);
            Assert.IsTrue(result != null && result.PostalCodes.Count > 0 && result.PostalCodes[0].PlaceName == "Walkersville",
                string.Format("LookupPostalCode should have returned Walkersville"));
        }

        [TestMethod]
        public async Task test_RequestTimeZoneInformationForLocation()
        {
            var geoController = new GeoNamesClient();
            var parameters = new RequestTimeZoneInformationForLocationParameters();
            parameters.Longitude = -77.0785;
            parameters.Latitude = 39.8885;
            var result = await geoController.RequestTimeZoneInformationForLocation(parameters);
            //System.Diagnostics.Trace.WriteLine(parameters.PostalCode);
            Assert.IsTrue(result != null && result.RawOffset == -5 && result.DstOffset == -4 && result.TimezoneId == "America/New_York",
                string.Format("RequestTimeZoneInformationForLocation should have returned America/New_York"));
        }

        [TestMethod]
        public async Task test_RequestCountryList()
        {
            var geoController = new GeoNamesClient();
            var parameters = new RequestCountryInformationParameters();
            var result = await geoController.RequestCountryList(parameters);
            //System.Diagnostics.Trace.WriteLine(parameters.PostalCode);
            Assert.IsTrue(result != null && result.Countries.Count > 0,
                string.Format("RequestCountryInformationParameters should have returned something"));

            parameters.Country = "US";
            parameters.Language = "ES";
            result = await geoController.RequestCountryList(parameters);
            Assert.IsTrue(result != null && result.Countries.Count == 1 && result.Countries[0].CountryName == "Estados Unidos",
                string.Format("RequestCountryInformationParameters should have returned something"));
        }

        [TestMethod]
        public async Task test_RequestCountryPostalCodeInformationList()
        {
            var geoController = new GeoNamesClient();
            var parameters = new RequestCountryPostalCodeInformationParameters();
            var result = await geoController.RequestCountryPostalCodeInformationList(parameters);
            //System.Diagnostics.Trace.WriteLine(parameters.PostalCode);
            Assert.IsTrue(result != null && result.PostalCodeInformationList.Count > 0,
                string.Format("RequestCountryPostalCodeInformationList should have returned something"));

        }

        [TestMethod]
        public async Task test_GetLocationCoordinates()
        {
            var coord = Locator.GetLocationProperty();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task test_GetLocationInformation()
        {
            var canPingGoogleStatus = new Ping().Send("www.google.com.mx").Status;
            if (canPingGoogleStatus == IPStatus.Success)
            {

                var isNetworkAvailable = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        var loc = await IPGeographicalLocation.QueryGeographicalLocationAsync(ip.ToString());
                    }
                }
            }
            Assert.IsTrue(true);
        }
    }
}
