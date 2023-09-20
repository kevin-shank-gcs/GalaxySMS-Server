////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\UserDefinedDatePropertyRule.cs
//
// summary:	Implements the user defined date property rule class
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
    public partial class UserDefinedDatePropertyRule : EntityBase, IIdentifiableEntity, IEquatable<UserDefinedDatePropertyRule>, ITableEntityBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid UserDefinedPropertyUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AllowNull { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset DefaultOffsetFromNow { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EmptyContent { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ValidationErrorMessage { get; set; }

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

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserDefinedProperty UserDefinedProperty { get; set; }

    }
}
