using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Caching
{
    public interface ICacheManager
    {
        bool IsInitialized { get; }
        bool Enabled { get; set; }
        bool Initialize(string parameters);
        Task<IEnumerable<string>> GetAllKeysAsync();
        IEnumerable<string> GetKeys(string search);
        IEnumerable<string> GetAllKeys();
        Task<IEnumerable<string>> GetKeysAsync(string search);
        T GetCachedItem<T>(string key);
        Task<T> GetCachedItemAsync<T>(string key);
        bool SetCachedItem<T>(string key, T item);
        Task<bool> SetCachedItemAsync<T>(string key, T item);
        bool DeleteCachedItem(string key);
        Task<bool> DeleteCachedItemAsync(string key);
    }
}
