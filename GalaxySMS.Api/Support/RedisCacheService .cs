using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace GalaxySMS.Api.Support
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _cache.GetStringAsync(key);

            if (value != null)
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }
        public async Task<T> SetAsync<T>(string key, T value)
        {
            var timeOut = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = null, //TimeSpan.FromDays(365),
                SlidingExpiration = null//TimeSpan.FromMinutes(60)
            };

            await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), timeOut);

            return value;
        }
    }
}
