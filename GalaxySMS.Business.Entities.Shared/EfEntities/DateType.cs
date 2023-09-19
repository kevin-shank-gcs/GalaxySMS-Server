////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\DateType.cs
//
// summary:	Implements the date type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

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
    public partial class DateType : EntityBase, IIdentifiableEntity, IEquatable<DateType>
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid DateTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid DayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTime Date { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Title { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

        //public DayType DayType { get; set; }

    }
}
