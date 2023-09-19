using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GCS.Framework.Farpointe.Conekt.Entities;
using Newtonsoft.Json;

namespace GCS.Framework.Farpointe.Conekt
{
    public class FpConektApi
    {
        public string ApiUrl { get; internal set; } = "https://test.cloudconekt.com/api/v1/";
        public string ApiKey { get; internal set; } = "kdHI0JHA1i5rpVasDtB5W7vRJ8uL9B34aIct3Nt0";
        public string ConfigurationId { get; internal set; } = "ad60a9bb-9b31-4688-b8f9-be1dbd173448";

        public FpConektApi()
        {
            
        }

        public FpConektApi(string apiUrl = "", string apiKey = "", string configurationId = "")
        {
            if( !string.IsNullOrEmpty(apiUrl) )
                ApiUrl = apiUrl;
            if (!string.IsNullOrEmpty(apiKey))
                ApiKey = apiKey;
            if (!string.IsNullOrEmpty(configurationId))
                ConfigurationId = configurationId;
        }

        private WebClient GetWebClient(string apiKey)
        {
            var client = new WebClient();
            client.Headers["x-api-key"] = apiKey;
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            return client;
        }

        public OrderStatus GetOrderStatus(string orderNumber)
        {
            try
            {
                using (var wc = GetWebClient(ApiKey))
                {
                    var url = $"{ApiUrl}orders/{orderNumber}";
                    string s = wc.DownloadString(url);
                    return JsonConvert.DeserializeObject<OrderStatus>(s);
                }
            }
            catch (WebException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (NotSupportedException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return null;
        }

        public async Task<OrderStatus> GetOrderStatusAsync(string orderNumber)
        {
            try
            {
                using (var wc = GetWebClient(ApiKey))
                {
                    var url = $"{ApiUrl}orders/{orderNumber}";
                    string s = await wc.DownloadStringTaskAsync(url);
                    return JsonConvert.DeserializeObject<OrderStatus>(s);
                }
            }
            catch (WebException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (NotSupportedException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return null;
        }
  
        public NewOrderResponse SaveOrder(NewOrder data)
        {
            try
            {
                using (var wc = GetWebClient(ApiKey))
                {
                    var url = $"{ApiUrl}orders";

                    string s = wc.UploadString(url, JsonConvert.SerializeObject(data));
                    return JsonConvert.DeserializeObject<NewOrderResponse>(s);
                }
            }
            catch (WebException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (NotSupportedException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return null;
        }


        public async Task<NewOrderResponse> SaveOrderAsync(NewOrder data)
        {
            try
            {
                using (var wc = GetWebClient(ApiKey))
                {
                    var url = $"{ApiUrl}orders";

                    var json = JsonConvert.SerializeObject(data);
                    string s = await wc.UploadStringTaskAsync(url, json);
                    return JsonConvert.DeserializeObject<NewOrderResponse>(s);
                }
            }
            catch (WebException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (NotSupportedException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return null;
        }


        public async Task<OrderStatus> PlaceOrderAsync(NewOrder order, TimeSpan timeout)
        {
            try
            {
                var start = DateTime.Now;
                if (string.IsNullOrEmpty(order.configurationSettingsId))
                    order.configurationSettingsId = ConfigurationId;
                if( order.credentialCount < 1)
                    order.credentialCount = 1;

                var placeOrderResult = await SaveOrderAsync(order);
                OrderStatus orderStatus = null;
                if (placeOrderResult != null)
                {
                    orderStatus = await GetOrderStatusAsync(placeOrderResult.orderId.ToString());
                    if (orderStatus != null)
                    {
                        var inProgress = orderStatus.status.ToLower() == "in_progress";

                        while(orderStatus.StatusCode == StatusCode.IN_PROGRESS && DateTime.Now < orderStatus.createdAt + timeout)
                        {
                            await Task.Delay(1000);
                            orderStatus = await GetOrderStatusAsync(placeOrderResult.orderId.ToString());
                        }
                    }
                }

                return orderStatus;
            }
            catch (WebException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (ArgumentNullException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (NotSupportedException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return null;
        }
    }
}
