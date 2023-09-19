using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;


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
    public class SecurityHeader : EntityBase
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyUserSessionGuid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CurrentWindowsUserName { get; set; }

    }
}
