using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{

    [DataContract]
    public class BoardSectionNodeHardwareAddress : BoardSectionHardwareAddress
    {
        private Int32 nodeNumberValue;

        public enum NodeNumberLimits { MinimumNodeNumber = 0, MaximumNodeNumber = 16 }

        public BoardSectionNodeHardwareAddress()
        { }

        public BoardSectionNodeHardwareAddress(BoardSectionNodeHardwareAddress a) : base(a)
        {
            NodeNumber = a.NodeNumber;
            BoardSectionNodeUid = a.BoardSectionNodeUid;
        }

        //		[DataMember]
        public new String UniqueId { get { return string.Format("{0}:{1:D3}:{2:D3}:{3:D}:{4:D}:{5:D}:{6:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber, SectionNumber, NodeNumber); } }

        public String UniqueIdAsAccessPortal
            {
            get
            {
                return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.AccessPortal, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber);
            }
        }

        [DataMember]
        public Int32 NodeNumber
        {
            get { return nodeNumberValue; }
            set
            {
                if (value >= (Int32)NodeNumberLimits.MinimumNodeNumber && value <= (Int32)NodeNumberLimits.MaximumNodeNumber)
                    nodeNumberValue = value;
                else
                    throw new ArgumentOutOfRangeException("NodeNumber", value, string.Format("The NodeNumber value must be between {0} and {1}",
                        NodeNumberLimits.MinimumNodeNumber, NodeNumberLimits.MaximumNodeNumber));
            }
        }

        [DataMember]
        public Guid BoardSectionNodeUid { get; set; }
        public override string ToString()
        {
            return UniqueId;
        }
    }
}
