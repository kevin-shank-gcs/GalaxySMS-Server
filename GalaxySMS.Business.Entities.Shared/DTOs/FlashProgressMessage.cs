using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public class FlashProgressMessage
    {

        public FlashProgressMessage()
        {
            SessionIdsToSendTo = new List<Guid>();
            StartedDateTime = DateTimeOffset.MinValue;
        }

        public FlashProgressMessage(FlashProgressMessage msg)
        {
            SessionIdsToSendTo = new List<Guid>();

            ClusterGroupId = msg.ClusterGroupId;
            ClusterNumber = msg.ClusterNumber;
            PanelNumber = msg.PanelNumber;
            CpuId = msg.CpuId;
            CpuModel = msg.CpuModel;
            DateTimeOffset = msg.DateTimeOffset;
            CpuUid = msg.CpuUid;
            SessionIdsToSendTo = msg.SessionIdsToSendTo.ToList();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public short CpuId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuModel CpuModel { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset DateTimeOffset { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset StartedDateTime { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public FlashingState CurrentState { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public FlashValidationResult ValidationResult { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int PacketNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalPacketCount { get; set; }

        public List<Guid> SessionIdsToSendTo { get; set; }

        public String UniqueCpuId { get { return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.GalaxyCpu, ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }
    }

}
