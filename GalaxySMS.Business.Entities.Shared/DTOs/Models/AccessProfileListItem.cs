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
    public class AccessProfileListItem
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessProfileUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessProfileCounts Counts { get; set; }
    }
}
