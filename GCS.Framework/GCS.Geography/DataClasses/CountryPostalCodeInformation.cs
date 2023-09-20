using System.Collections.Generic;
using Newtonsoft.Json;

namespace GCS.Framework.Geography.DataClasses
{
    public class CountryPostalCodeInformation
    {
        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("numPostalCodes")]
        public int NumPostalCodes { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("maxPostalCode")]
        public string MaxPostalCode { get; set; }

        [JsonProperty("minPostalCode")]
        public string MinPostalCode { get; set; }
    }

    public class CountryPostalCodeInformationList
    {
        [JsonProperty("geonames")]
        public IList<CountryPostalCodeInformation> PostalCodeInformationList { get; set; }
    }
}