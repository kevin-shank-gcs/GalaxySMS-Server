using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class BoardHardwareAddress : CpuHardwareAddress
	{
		private Int32 boardNumberValue;

		public enum BoardNumberLimits { MinimumBoardNumber = 0, MaximumBoardNumber = 32 }

		public BoardHardwareAddress()
		{}

		public BoardHardwareAddress(BoardHardwareAddress a):base(a)
		{
			BoardNumber = a.BoardNumber;
			BoardType = a.BoardType;
            BoardUid = a.BoardUid;
		}

		public BoardHardwareAddress(int clusterId, int panelId, short cpuId, int boardNumber, string accountCode ):base(clusterId, panelId, cpuId, accountCode)
		{
			if (boardNumber >= (Int32)BoardNumberLimits.MinimumBoardNumber && boardNumber <= (Int32)BoardNumberLimits.MaximumBoardNumber)
			{
				BoardNumber = boardNumber;
			}
		}

//		[DataMember]
		public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}:{4:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber); } }

		[DataMember]
		public Int32 BoardNumber
		{
			get { return boardNumberValue; }
			set
			{
				if (value >= (Int32)BoardNumberLimits.MinimumBoardNumber && value <= (Int32)BoardNumberLimits.MaximumBoardNumber)
					boardNumberValue = value;
				else
					throw new ArgumentOutOfRangeException("BoardNumber", value, string.Format("The BoardNumber value must be between {0} and {1}",
						BoardNumberLimits.MinimumBoardNumber, BoardNumberLimits.MaximumBoardNumber));
			}
		}

		[DataMember]
		public GalaxyInterfaceBoardType BoardType {get;set;}


	    [DataMember]
	    public Guid BoardUid { get; set; }

        //		[DataMember]
        public BoardHardwareAddress BoardAddress { get { return this; } }
		public override string ToString()
		{
			return UniqueId;
		}
	}
}
