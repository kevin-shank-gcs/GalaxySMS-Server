using GCS.Core.Common.Contracts;
using System.Runtime.Serialization;
using System.Threading;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class ArrayResponse<T> : PagedResultBase, IArrayResponse<T>
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public T[] Items { get; set; } = new T[0];
    }

}
