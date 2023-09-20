using System.Linq;
using GCS.Framework.Badging.IdProducer;

namespace IdProducerLicenseGenerator
{
    internal static class IdProducerHelpers
    {
        internal static idProducerAPI GetLicenseBotApi(string url, string devUrl, string signalRUrl)
        {
            return GetIdProducerApi(url, devUrl, "licensebot@specsid.com", "p@$$30Rd", signalRUrl);
        }

        internal static idProducerAPI GetIdProducerApi(string url, string devUrl, string username, string password, string signalRUrl)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(url))
            {
                if (string.IsNullOrEmpty(devUrl))
                    devUrl = url;
                if (string.IsNullOrEmpty(signalRUrl))
                {
                    var masterServiceIndex = url.IndexOf("MasterService");
                    if(masterServiceIndex != -1)
                        signalRUrl = url.Substring(0, masterServiceIndex);
                }

                return new idProducerAPI(url, username, password, devUrl, signalRUrl);
            }

            return null;
        }
    }
}
