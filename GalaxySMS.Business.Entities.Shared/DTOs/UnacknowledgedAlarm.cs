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
    public class UnacknowledgedAlarm
    {
        #region Public Variables

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ActivityEventUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceEntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyActivityEventTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ActivityDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EventDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AlarmPriority { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ResponseRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Instructions { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Category { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ActivityEventText { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int Color { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ColorArgb { get; set; }


        #endregion
    }
}
