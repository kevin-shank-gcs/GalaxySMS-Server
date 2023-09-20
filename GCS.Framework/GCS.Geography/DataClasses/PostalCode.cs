using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCS.Framework.Geography.DataClasses
{
    public class PostalCode
    {

        [JsonProperty("adminName2")]
        public string AdminName2 { get; set; }

        [JsonProperty("adminCode2")]
        public string AdminCode2 { get; set; }

        [JsonProperty("postalcode")]
        public string Postalcode { get; set; }

        [JsonProperty("adminCode1")]
        public string AdminCode1 { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

        [JsonProperty("placeName")]
        public string PlaceName { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("adminName1")]
        public string AdminName1 { get; set; }
    }

    public class PostalCodeList
    {

        [JsonProperty("postalcodes")]
        public IList<PostalCode> PostalCodes { get; set; }
    }

}
