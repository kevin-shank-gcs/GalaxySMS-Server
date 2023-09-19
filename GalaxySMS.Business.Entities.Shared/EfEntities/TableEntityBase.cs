using System;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;

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
    public abstract class TableEntityBase : ITableEntityBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short? ConcurrencyValue { get; set; }
    }

    public abstract class TableEntityBase<TId> : TableEntityBase, ITableEntityBase<TId>
    {
        public TId Id { get; set; }
    }
}
