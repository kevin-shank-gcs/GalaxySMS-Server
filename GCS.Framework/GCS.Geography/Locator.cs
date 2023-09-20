using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Geography
{

    public class IPGeographicalLocation 
    { 
        [JsonProperty("ip")] 
        public string IP { get; set; } 
 
        [JsonProperty("country_code")] 
 
        public string CountryCode { get; set; } 
 
        [JsonProperty("country_name")] 
 
        public string CountryName { get; set; } 
 
        [JsonProperty("region_code")] 
 
        public string RegionCode { get; set; } 
 
        [JsonProperty("region_name")] 
 
        public string RegionName { get; set; } 
 
        [JsonProperty("city")] 
 
        public string City { get; set; } 
 
        [JsonProperty("zip_code")] 
 
        public string ZipCode { get; set; } 
 
        [JsonProperty("time_zone")] 
 
        public string TimeZone { get; set; } 
 
        [JsonProperty("latitude")] 
 
        public float Latitude { get; set; } 
 
        [JsonProperty("longitude")] 
 
        public float Longitude { get; set; } 
 
        [JsonProperty("metro_code")] 
 
        public int MetroCode { get; set; } 
 
        private IPGeographicalLocation() { } 
 
        public static async Task<IPGeographicalLocation> QueryGeographicalLocationAsync(string ipAddress) 
        { 
            HttpClient client = new HttpClient(); 
            string result = await client.GetStringAsync("http://freegeoip.net/json/" + ipAddress); 
 
            return JsonConvert.DeserializeObject<IPGeographicalLocation>(result); 
        } 
    } 

    public class Locator
    {
        static public GeoCoordinate GetLocationProperty()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            
            watcher.TryStart(true, TimeSpan.FromMilliseconds(5000));

            GeoCoordinate coord = watcher.Position.Location;

            //if (coord.IsUnknown != true)
            //{
            //    Console.WriteLine("Lat: {0}, Long: {1}",
            //        coord.Latitude,
            //        coord.Longitude);
            //}
            //else
            //{
            //    Console.WriteLine("Unknown latitude and longitude.");
            //}
            return coord;
        }
    }
}
