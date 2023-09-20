using System;
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
    public class GalaxyCpuSaveInformationData
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string SerialNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string IpAddress { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int Model { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Version { get; set; }

    }
}
