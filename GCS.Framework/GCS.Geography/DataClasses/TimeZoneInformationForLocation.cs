using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCS.Framework.Geography.DataClasses
{
    public class TimeZoneInformationForLocation
    {

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("gmtOffset")]
        public int GmtOffset { get; set; }

        [JsonProperty("rawOffset")]
        public int RawOffset { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("timezoneId")]
        public string TimezoneId { get; set; }

        [JsonProperty("dstOffset")]
        public int DstOffset { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
