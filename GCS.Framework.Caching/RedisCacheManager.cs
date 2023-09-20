using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace GCS.Framework.Caching
{
    [Export(typeof(ICacheManager))]
    [PartCreationPolicy(CreationPolicy.Any)]
    public class RedisCacheManager : ICacheManager
    {
        private IConnectionMultiplexer _redis;
        private IDatabase _redisDb => _redis?.GetDatabase();
        private IList<string> _allKeys;

        public bool Initialize(string parameters)
        {
            _redis = ConnectionMultiplexer.Connect($"{parameters}");
            IsInitialized = true;
            return IsInitialized;
        }

        public IEnumerable<string> GetAllKeys()
        {
            var endpoints = _redisDb.Multiplexer.GetEndPoints();
            var server = _redisDb.Multiplexer.GetServer(endpoints[0]);
            var keys = server.Keys();
            _allKeys = new List<string>();
            foreach (var k in keys)
                _allKeys.Add(k.ToString());
            return _allKeys;
        }

        public async Task<IEnumerable<string>> GetAllKeysAsync()
        {
            var endpoints = _redisDb.Multiplexer.GetEndPoints();
            var server = _redisDb.Multiplexer.GetServer(endpoints[0]);
            var keys = server.KeysAsync();
            _allKeys = new List<string>();
            foreach (var k in (IEnumerable)keys)
                _allKeys.Add(k.ToString());
            return _allKeys;
        }


        public IEnumerable<string> AllKeys => _allKeys;

        public IEnumerable<string> GetKeys(string search)
        {
            if (_allKeys == null)
                GetAllKeys();
            return AllKeys.Where(o => o.Contains(search));
        }

        public async Task<IEnumerable<string>> GetKeysAsync(string search)
        {
            if (_allKeys == null)
                await GetAllKeysAsync();
            return AllKeys.Where(o => o.Contains(search));
        }


        public bool IsInitialized { get; internal set; }
        public bool Enabled { get; set; }
        public T GetCachedItem<T>(string key)
        {
            if (Enabled && _redisDb != null)
            {
                var s = _redisDb.StringGet(key);
                if (!string.IsNullOrEmpty(s))
                {
                    var returnItem = JsonConvert.DeserializeObject<T>(s);
                    return returnItem;
                }
            }

            return default;
        }

        public async Task<T> GetCachedItemAsync<T>(string key)
        {
            if (Enabled && _redisDb != null)
            {
                var s = await _redisDb.StringGetAsync(key);
                if (!string.IsNullOrEmpty(s))
                {
                    var returnItem = JsonConvert.DeserializeObject<T>(s);
                    return returnItem;
                }
            }

            return default;
        }

        public bool SetCachedItem<T>(string key, T item)
        {
            if (Enabled && _redisDb != null)
            {
                var s = JsonConvert.SerializeObject(item);
                var bRet = _redisDb.StringSet(key, s);
                return bRet;
            }

            return false;
        }

        public async Task<bool> SetCachedItemAsync<T>(string key, T item)
        {
            if (Enabled && _redisDb != null)
            {
                var s = JsonConvert.SerializeObject(item);
                var bRet = await _redisDb.StringSetAsync(key, s);
                return bRet;
            }

            return false;
        }

        public bool DeleteCachedItem(string key)
        {
            if (Enabled && _redisDb != null)
            {
                if (string.IsNullOrEmpty(key))
                {
                    var endpoints = _redisDb.Multiplexer.GetEndPoints();
                    var server = _redisDb.Multiplexer.GetServer(endpoints[0]);
                    server.FlushDatabase();
                    return true;
                }
                else
                {
                    var result = _redisDb.KeyDelete(key);
                    return result;
                }
            }

            return false;
        }

        public async Task<bool> DeleteCachedItemAsync(string key)
        {
            if (Enabled && _redisDb != null)
            {
                if (string.IsNullOrEmpty(key))
                {
                    var endpoints = _redisDb.Multiplexer.GetEndPoints();
                    var server = _redisDb.Multiplexer.GetServer(endpoints[0]);
                    await server.FlushDatabaseAsync();
                    return true;
                }
                else
                {

                    var result = await _redisDb.KeyDeleteAsync(key);
                    return result;
                }
            }

            return false;
        }


    }
}
