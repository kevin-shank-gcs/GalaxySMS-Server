using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
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

    public class RawDataToSend : EntityBase
    {
        public RawDataToSend()
        {
            Address = new BoardSectionNodeHardwareAddress();
            Route5xx = new Panel5xxRoute();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuModel CpuModel { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public BoardSectionNodeHardwareAddress Address { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Panel5xxRoute Route5xx { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte[] Data { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String StringData { get; set; }

    }
}
