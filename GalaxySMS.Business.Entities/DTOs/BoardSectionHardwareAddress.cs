using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{

	[DataContract]
	public class BoardSectionHardwareAddress : BoardHardwareAddress
	{
		private Int32 sectionNumberValue;
        private Int32 sectionNodeCombinedNumberValue;

		public enum SectionNumberLimits { MinimumSectionNumber = 0, MaximumSectionNumber = 16 }

		public BoardSectionHardwareAddress(){}
		public BoardSectionHardwareAddress(BoardSectionHardwareAddress a) : base(a)
		{
			SectionNumber = a.SectionNumber;
			SectionType = a.SectionType;
            BoardSectionUid = a.BoardSectionUid;
            SectionNodeCombinedNumber= a.SectionNodeCombinedNumber;
		}

//		[DataMember]
		public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber, SectionNumber); } }

		[DataMember]
		public Int32 SectionNumber {
			get { return sectionNumberValue; }
			set { 
				if( value >= (Int32)SectionNumberLimits.MinimumSectionNumber && value <= (Int32)SectionNumberLimits.MaximumSectionNumber)
						sectionNumberValue = value;
				else
					throw new ArgumentOutOfRangeException("SectionNumber", value, string.Format("The SectionNumber value must be between {0} and {1}",
						SectionNumberLimits.MinimumSectionNumber, SectionNumberLimits.MaximumSectionNumber));
			}
		}
        
        [DataMember]
        public Int32 SectionNodeCombinedNumber { get; set; }

		[DataMember]
		public PanelInterfaceBoardSectionType SectionType { get; set; }

//		[DataMember]
		public BoardSectionHardwareAddress BoardSectionAddress { get { return this; } }

        [DataMember]
	    public Guid BoardSectionUid { get; set; }

        public override string ToString()
		{
			return UniqueId;
		}
	}
}
