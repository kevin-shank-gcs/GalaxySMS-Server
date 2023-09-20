using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCS.Framework.Geography.DataClasses
{
    public class Country
    {

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("fipsCode")]
        public string FipsCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("isoNumeric")]
        public string IsoNumeric { get; set; }

        [JsonProperty("north")]
        public double North { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("continentName")]
        public string ContinentName { get; set; }

        [JsonProperty("areaInSqKm")]
        public string AreaInSqKm { get; set; }

        [JsonProperty("languages")]
        public string Languages { get; set; }

        [JsonProperty("isoAlpha3")]
        public string IsoAlpha3 { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("south")]
        public double South { get; set; }

        [JsonProperty("east")]
        public double East { get; set; }

        [JsonProperty("geonameId")]
        public int GeonameId { get; set; }

        [JsonProperty("west")]
        public double West { get; set; }

        [JsonProperty("population")]
        public string Population { get; set; }
    }

    public class CountryList
    {

        [JsonProperty("geonames")]
        public IList<Country> Countries { get; set; }
    }
}
