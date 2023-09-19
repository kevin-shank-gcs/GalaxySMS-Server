using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
    public class EventFilterDataSelectionParameters
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OutputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> EventTypeUIds { get; set; }

    }
}
