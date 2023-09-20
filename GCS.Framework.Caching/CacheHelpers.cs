using System;
using System.Collections.Generic;
using System.Text;
using GCS.Core.Common.Contracts;
using StackExchange.Redis;

namespace GCS.Framework.Caching
{
    public static class CacheHelpers
    {
        public static string GetCacheKey(Type t, Guid id, bool isIEnumerable = false, string suffix = null)
        {
            if (string.IsNullOrEmpty(suffix))
                suffix = "";
            else
            {
                suffix = $":{suffix}";
            }

            if (isIEnumerable)
                return $"Array<{t.Name}>[{id}]{suffix}";
            return $"{t.Name}[{id}]{suffix}";
        }

        public static string GetCacheKey(Type t, Guid id, Guid id2, bool isIEnumerable = false, string suffix = null)
        {
            if (string.IsNullOrEmpty(suffix))
                suffix = "";
            else
            {
                suffix = $":{suffix}";
            }

            if (isIEnumerable)
                return $"Array<{t.Name}>[{id}].[{id2}]{suffix}";
            return $"{t.Name}[{id}].[{id2}]{suffix}";
        }

        //public static string GetCacheKey<T>(T t, Guid id, bool isIEnumerable = false, string prefix = null)
        //{
        //    if (string.IsNullOrEmpty(prefix))
        //        prefix = "";
        //    else
        //    {
        //        prefix = $"{prefix}:";
        //    }

        //    var type = t.GetType();
        //    if (isIEnumerable)
        //        return $"{prefix}Array<{type.Name}>[{id}]";
        //    return $"{prefix}{type.Name}[{id}]";
        //}

        public static bool IsCacheInitialized(ICacheManager cacheManager)
        {
            if (cacheManager == null || !cacheManager.Enabled || !cacheManager.IsInitialized)
                return false;
            return true;
        }

        public static bool ShouldReadFromCache(ICacheManager cacheManager, IGetParametersBase parameters)
        {
            if (parameters == null || parameters.RefreshCache || !IsCacheInitialized(cacheManager))
                return false;

            return !parameters.RefreshCache;
        }

        public static bool ShouldCacheBeUpdated(ICacheManager cacheManager, IGetParametersBase parameters)
        {
            if (parameters == null || !parameters.RefreshCache || !IsCacheInitialized(cacheManager))
                return false;

            return parameters.RefreshCache;
        }


    }
}
