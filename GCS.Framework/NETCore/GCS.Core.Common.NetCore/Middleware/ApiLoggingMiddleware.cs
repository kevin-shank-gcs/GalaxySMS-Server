﻿using GCS.Core.Common.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using GCS.Core.Common.Extensions;

namespace GCS.Core.Common.NetCore.Middleware
{

    public class ApiLoggingOptions
    {
        public long MaxRequestLength { get; set; }
        public long MaxResponseLength { get; set; }
    }

    public class ApiLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiLoggingMiddleware> _logger;
        private readonly long _maxLogRequestBodyLength;
        private readonly long _maxLogResponseBodyLength;

        public ApiLoggingMiddleware(RequestDelegate next, ILogger<ApiLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public ApiLoggingMiddleware(RequestDelegate next, ILogger<ApiLoggingMiddleware> logger, ApiLoggingOptions options)
        {
            _next = next;
            _logger = logger;
            if (options != null)
            {
                _maxLogRequestBodyLength = options.MaxRequestLength;
                _maxLogResponseBodyLength = options.MaxResponseLength;
            }
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {

                var request = httpContext.Request;
                if (request.Path.StartsWithSegments(new PathString("/api")))
                {
                    var stopWatch = Stopwatch.StartNew();
                    var requestTime = DateTimeOffset.UtcNow;
                    var requestBodyContent = await ReadRequestBody(request);
                    var originalBodyStream = httpContext.Response.Body;
                    using (var responseBody = new MemoryStream())
                    {
                        var response = httpContext.Response;
                        response.Body = responseBody;
                        await _next(httpContext);
                        stopWatch.Stop();

                        string responseBodyContent = null;
                        responseBodyContent = await ReadResponseBody(response);
                        await responseBody.CopyToAsync(originalBodyStream);

                        SafeLog(requestTime,
                            stopWatch.ElapsedMilliseconds,
                            response.StatusCode,
                            request.Method,
                            request.Path,
                            request.QueryString.ToString(),
                            requestBodyContent,
                            responseBodyContent);
                    }
                }
                else
                {
                    await _next(httpContext);
                }
            }
            catch (Exception ex)
            {
                await _next(httpContext);
            }
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            var maxLength = _maxLogRequestBodyLength;
            if (maxLength == 0 && request.ContentLength.HasValue)
            {
                maxLength = request.ContentLength.Value;
            }
   //         var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            var buffer = new byte[Convert.ToInt32(maxLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private void SafeLog(DateTimeOffset requestTime,
                            long responseMillis,
                            int statusCode,
                            string method,
                            string path,
                            string queryString,
                            string requestBody,
                            string responseBody)
        {
            if (path.ToLower().StartsWith("/api/login"))
            {
                requestBody = "(Request logging disabled for /api/login)";
                responseBody = "(Response logging disabled for /api/login)";
            }

            //if (requestBody.Length > 100)
            //{
            //    requestBody = $"(Truncated to 100 chars) {requestBody.Substring(0, 100)}";
            //}

            //if (responseBody.Length > 100)
            //{
            //    responseBody = $"(Truncated to 100 chars) {responseBody.Substring(0, 100)}";
            //}

            //if (queryString.Length > 100)
            //{
            //    queryString = $"(Truncated to 100 chars) {queryString.Substring(0, 100)}";
            //}


            _logger.LogInformation(new ApiLogItem
            {
                RequestTime = requestTime,
                ResponseMillis = responseMillis,
                StatusCode = statusCode,
                Method = method,
                Path = path,
                QueryString = queryString,
                RequestBody = requestBody,
                ResponseBody = responseBody
            }.ToJsonString());
        }
    }
}
