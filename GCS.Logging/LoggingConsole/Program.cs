using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GCS.Logging.Shared;
using Microsoft.Extensions.Configuration;

namespace LoggingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var useApi = Convert.ToBoolean(configuration["UseApi"]);
            HttpClient httpClient = null;
            if (useApi == true)
            {
                httpClient = new HttpClient() {BaseAddress = new Uri(configuration["LoggingApi:Url"])};
            }

            var logger = new GCS.Logging.LoggingClient(httpClient);

            var logDetail = new LogDetail()
            {
                Hostname = Environment.MachineName,
                CorrelationId = "CorrelationId",
                CustomerId = 100,
                CustomerName = "CustomerName",
                ElapsedMilliseconds = 1021,
                Layer = "Layer",
                Location = "Location",
                Message = "Some usage message",
                Timestamp = DateTimeOffset.Now,
                Product = "Product name",
                UserId = "UserId",
                UserName = "User name",
            };

            Task.Run(async () =>
            {
                await logger.WriteUsage(logDetail);
            }).Wait();

            logDetail.Message = "Some diagnostic data";
            Task.Run(async () =>
            {
                await logger.WriteDiagnostic(logDetail);
            }).Wait();

            logDetail.Message = "Some performance data";
            Task.Run(async () =>
            {
                await logger.WritePerformance(logDetail);
            }).Wait();

            logDetail.Message = "Some informational data";
            Task.Run(async () =>
            {
                await logger.WriteInfo(logDetail);
            }).Wait();
                

            logDetail.Message = "Some error data";
            Task.Run(async () =>
            {
                logDetail.Exception = new Exception("sample exception data");
                await logger.WriteError(logDetail);
            }).Wait();
        }
    }
}
