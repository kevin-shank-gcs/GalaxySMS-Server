using System;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Support
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task<T> SetAsync<T>(string key, T value);
    }
}
