using GCS.Core.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<T> PostJsonCustomAsync<T>(this HttpClient sender, string requestUrl, object postData)
            where T : new()
        {
            sender.DefaultRequestHeaders.Add("Accept", "application/json");

            string stringPostData = JsonConvert.SerializeObject(postData);

            HttpContent body = new StringContent(stringPostData, Encoding.UTF8, "application/json");
            var response = await sender.PostAsync(requestUrl, body);

            string text = await response.Content.ReadAsStringAsync();

            T data = JsonConvert.DeserializeObject<T>(text);

            return data;
        }


        public static async Task<T> GetJsonCustomAsync<T>(this HttpClient sender, string requestUrl)
            where T : new()
        {
            sender.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await sender.GetAsync(requestUrl);

            string text = await response.Content.ReadAsStringAsync();

            T data = JsonConvert.DeserializeObject<T>(text);

            return data;
        }

        public static async Task<T> PutJsonCustomAsync<T>(this HttpClient sender, string requestUrl, object putData)
            where T : new()
        {
            sender.DefaultRequestHeaders.Add("Accept", "application/json");

            string stringPutData = JsonConvert.SerializeObject(putData);

            HttpContent body = new StringContent(stringPutData, Encoding.UTF8, "application/json");
            var response = await sender.PutAsync(requestUrl, body);

            string text = await response.Content.ReadAsStringAsync();

            T data = JsonConvert.DeserializeObject<T>(text);

            return data;
        }


        public static void SetBearerAuthorizationHeader(this HttpClient sender, string jwt)
        {
            sender.DefaultRequestHeaders.Remove(HttpRequestHeader.Authorization.ToString());
            sender.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), $"bearer {jwt}");
        }

        public static void SetBasicAuthorizationHeader(this HttpClient sender, string clientId, string clientSecret)
        {
            var encodedKey = $"{clientId}:{clientSecret}".Base64StringEncode();
            sender.DefaultRequestHeaders.Remove(HttpRequestHeader.Authorization.ToString());
            sender.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), $"basic {encodedKey}");
        }
    }

}
