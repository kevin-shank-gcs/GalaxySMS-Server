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
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class SignalREnvelope<T>
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public T Payload { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> SignalRGroupUids { get; set; }
    }
}
