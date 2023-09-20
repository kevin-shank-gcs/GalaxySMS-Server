using GalaxySMS.Common.Enums;
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

    public class BoardSectionHardwareAddress : BoardHardwareAddress
    {
        private Int32 sectionNumberValue;
        private Int32 sectionNodeCombinedNumberValue;

        public enum SectionNumberLimits { MinimumSectionNumber = 0, MaximumSectionNumber = 16 }

        public BoardSectionHardwareAddress() { }
        public BoardSectionHardwareAddress(BoardSectionHardwareAddress a) : base(a)
        {
            SectionNumber = a.SectionNumber;
            SectionType = a.SectionType;
            BoardSectionUid = a.BoardSectionUid;
            SectionNodeCombinedNumber = a.SectionNodeCombinedNumber;
        }

        public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber, SectionNumber); } }

#if NetCoreApi
#else
        [DataMember]
#endif
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
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 SectionNodeCombinedNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelInterfaceBoardSectionType SectionType { get; set; }


        //public BoardSectionHardwareAddress BoardSectionAddress { get { return this; } }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid BoardSectionUid { get; set; }

        public override string ToString()
        {
            return UniqueId;
        }
    }
}
