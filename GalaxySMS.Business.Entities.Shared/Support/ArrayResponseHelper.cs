
using System.Collections.Generic;
using System.Linq;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public static class ArrayResponseHelpers
    {
        public static ArrayResponse<T> ToArrayResponse<T>(T[] data, int pageNumber, int pageSize, int totalItemCount)
        {
            if (data == null)
                return new ArrayResponse<T>();
            var totalPageCount = 1;
            if (pageNumber == 0)
                pageNumber = 1;
            if (pageSize > 0)
            {
                var fullPages = totalItemCount / pageSize;
                var partialPages = totalItemCount % pageSize;
                totalPageCount = fullPages;
                if (partialPages != 0)
                    totalPageCount += 1;
            }
            else
                pageSize = totalItemCount;

            return new ArrayResponse<T>()
            {
                Items = data,
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalItemCount = totalItemCount,
                PageItemCount = data.Length,
                TotalPageCount = totalPageCount
            };
        }

        public static ArrayResponse<T> ToArrayResponse<T>(IEnumerable<T> data, int pageNumber, int pageSize, int totalItemCount)
        {
            if (data == null)
                return new ArrayResponse<T>();
            var totalPageCount = 1;
            if (pageNumber == 0)
                pageNumber = 1;
            if (pageSize > 0)
            {
                var fullPages = totalItemCount / pageSize;
                var partialPages = totalItemCount % pageSize;
                totalPageCount = fullPages;
                if (partialPages != 0)
                    totalPageCount += 1;
            }
            else
                pageSize = totalItemCount;

            return new ArrayResponse<T>()
            {
                Items = data.ToArray(),
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalItemCount = totalItemCount,
                PageItemCount = data.Count(),
                TotalPageCount = totalPageCount
            };
        }
    }
}
