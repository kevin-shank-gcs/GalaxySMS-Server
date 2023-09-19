using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class BoardSectionHardwareAddressResp : BoardHardwareAddressResp
    {
        private Int32 sectionNumberValue;
        private Int32 sectionNodeCombinedNumberValue;

        public enum SectionNumberLimits { MinimumSectionNumber = 0, MaximumSectionNumber = 16 }

        public BoardSectionHardwareAddressResp() { }
        public BoardSectionHardwareAddressResp(BoardSectionHardwareAddressResp a) : base(a)
        {
            SectionNumber = a.SectionNumber;
            SectionType = a.SectionType;
            BoardSectionUid = a.BoardSectionUid;
            SectionNodeCombinedNumber = a.SectionNodeCombinedNumber;
        }

        public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber, SectionNumber); } }

        public Int32 SectionNumber
        {
            get { return sectionNumberValue; }
            set
            {
                if (value >= (Int32)SectionNumberLimits.MinimumSectionNumber && value <= (Int32)SectionNumberLimits.MaximumSectionNumber)
                    sectionNumberValue = value;
                else
                    throw new ArgumentOutOfRangeException("SectionNumber", value, string.Format("The SectionNumber value must be between {0} and {1}",
                        SectionNumberLimits.MinimumSectionNumber, SectionNumberLimits.MaximumSectionNumber));
            }
        }
        public Int32 SectionNodeCombinedNumber { get; set; }
        public PanelInterfaceBoardSectionType SectionType { get; set; }

        
        public BoardSectionHardwareAddressResp BoardSectionAddress { get { return this; } }
        public Guid BoardSectionUid { get; set; }

        public override string ToString()
        {
            return UniqueId;
        }
    }
}
