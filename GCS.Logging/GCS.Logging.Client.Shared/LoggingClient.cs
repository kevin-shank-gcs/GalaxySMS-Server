using GCS.Logging.Shared;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
#if NETCOREAPP3_1
using GCS.Logging.Core;
using System.Text.Json;
#endif
namespace GCS.Logging
{
    public class LoggingClient : ILoggingClient
    {
        private readonly HttpClient _httpClient;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggingClient()
        {
            _httpClient = null;
        }

        public LoggingClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task WriteInfo(LogDetail data)
        {
            if (_httpClient != null)
            {
#if NETCOREAPP3_1
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
#else
                var saveJson =
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
#endif
                var response = await _httpClient.PostAsync("info", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
#if NETCOREAPP3_1
                Logger.WriteInfo(data);
#endif
            }
        }

        public async Task WriteUsage(LogDetail data)
        {

            if (_httpClient != null)
            {
#if NETCOREAPP3_1
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
#else
                var saveJson =
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
#endif

                var response = await _httpClient.PostAsync("usage", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
#if NETCOREAPP3_1
                Logger.WriteUsage(data);
#endif
            }
        }

        public async Task WriteError(LogDetail data)
        {

            if (_httpClient != null)
            {
#if NETCOREAPP3_1
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
#else
                var saveJson =
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
#endif

                var response = await _httpClient.PostAsync("error", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
#if NETCOREAPP3_1
                Logger.WriteError(data);
#endif
            }
        }


        public async Task WriteDiagnostic(LogDetail data)
        {

            if (_httpClient != null)
            {
#if NETCOREAPP3_1
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
#else
                var saveJson =
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
#endif

                var response = await _httpClient.PostAsync("diagnostic", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
#if NETCOREAPP3_1
                Logger.WriteDiagnostic(data);
#endif
            }
        }


        public async Task WritePerformance(LogDetail data)
        {

            if (_httpClient != null)
            {
#if NETCOREAPP3_1
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
#else
                var saveJson =
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
#endif

                var response = await _httpClient.PostAsync("performance", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
#if NETCOREAPP3_1
                Logger.WritePerf(data);
#endif
            }
        }


    }
}
