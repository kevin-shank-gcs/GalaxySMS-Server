using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{

    public class BoardSectionNodeHardwareAddressResp : BoardSectionHardwareAddressResp
    {
        private Int32 nodeNumberValue;
        private Int32 moduleNumberValue;

        public enum NodeNumberLimits { MinimumNodeNumber = 0, MaximumNodeNumber = 120 }
        public enum ModuleNumberLimits { MinimumModuleNumber = 0, MaximumModuleNumber = 16 }

        public BoardSectionNodeHardwareAddressResp()
        { }

        public BoardSectionNodeHardwareAddressResp(BoardSectionNodeHardwareAddressResp a) : base(a)
        {
            ModuleNumber = a.ModuleNumber;
            NodeNumber = a.NodeNumber;
            BoardSectionNodeUid = a.BoardSectionNodeUid;
        }


        public new String UniqueId { get { return string.Format("{0}:{1:D3}:{2:D3}:{3:D}:{4:D}:{5:D}:{6:D}:{7:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber, SectionNumber, ModuleNumber, NodeNumber); } }

        public String UniqueIdAsAccessPortal
        {
            get
            {
                return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.AccessPortal, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber);
            }
        }

        public String UniqueIdAsInputDevice
        {
            get
            {
                return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.InputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, ModuleNumber, NodeNumber);
            }
        }

        public String UniqueIdAsOutputDevice
        {
            get
            {
                return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.OutputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber);
            }
        }

        public Int32 ModuleNumber
        {
            get { return moduleNumberValue; }
            set
            {
                if (value >= (Int32)ModuleNumberLimits.MinimumModuleNumber && value <= (Int32)ModuleNumberLimits.MaximumModuleNumber)
                    moduleNumberValue = value;
                else
                    throw new ArgumentOutOfRangeException("ModuleNumber", value, string.Format("The ModuleNumber value must be between {0} and {1}",
                        ModuleNumberLimits.MinimumModuleNumber, ModuleNumberLimits.MaximumModuleNumber));
            }
        }
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
        public Guid BoardSectionNodeUid { get; set; }
        public override string ToString()
        {
            return UniqueId;
        }
    }
}
