using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
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

        [DataMember]
        public int ClusterGroupId { get; set; }

        [DataMember]
        public int ClusterNumber { get; set; }

        [DataMember]
        public int PanelNumber { get; set; }

        [DataMember]
        public short CpuId { get; set; }

        [DataMember]
        public CpuModel CpuModel { get; set; }

        [DataMember]
        public DateTimeOffset DateTimeOffset { get; set; }

        [DataMember]
        public DateTimeOffset StartedDateTime { get; set; }

        [DataMember]
        public Guid CpuUid { get; set; }

        [DataMember]
        public FlashingState CurrentState { get; set; }

        [DataMember]
        public FlashValidationResult ValidationResult { get; set; }


        [DataMember]
        public int PacketNumber { get; set; }

        [DataMember]
        public int TotalPacketCount { get; set; }

        public List<Guid> SessionIdsToSendTo { get; set; }

        public String UniqueCpuId { get { return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.GalaxyCpu, ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }
    }

}
