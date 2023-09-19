using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GCS.Logging.Core;
using GCS.Logging.Shared;
using Microsoft.AspNetCore.Http;

namespace GCS.Logging
{
    public class LoggingClient
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
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("info", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
                Logger.WriteInfo(data);
            }
        }

        public async Task WriteUsage(LogDetail data)
        {

            if (_httpClient != null)
            {
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("usage", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
                Logger.WriteUsage(data);
            }
        }

        public async Task WriteError(LogDetail data)
        {

            if (_httpClient != null)
            {
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("error", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
                Logger.WriteError(data);
            }
        }


        public async Task WriteDiagnostic(LogDetail data)
        {

            if (_httpClient != null)
            {
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("diagnostic", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
                Logger.WriteDiagnostic(data);
            }
        }


        public async Task WritePerformance(LogDetail data)
        {

            if (_httpClient != null)
            {
                var saveJson =
                    new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("performance", saveJson);

                if (response.IsSuccessStatusCode)
                {
                }
            }
            else
            {
                Logger.WritePerf(data);
            }
        }


    }
}
