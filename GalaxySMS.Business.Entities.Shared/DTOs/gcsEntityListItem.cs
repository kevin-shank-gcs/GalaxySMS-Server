﻿using System;
using System.Collections.Generic;
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
    public class gcsEntityListItem
    {
        public gcsEntityListItem()
        {
            EntityId = Guid.Empty;
            EntityName = string.Empty;
            Regions = new HashSet<RegionListItem>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Image { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif

        public ICollection<RegionListItem> Regions { get; set; }

    }
}
