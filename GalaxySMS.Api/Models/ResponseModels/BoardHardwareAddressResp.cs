using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
	public class BoardHardwareAddressResp : CpuHardwareAddressResp
	{
		private Int32 boardNumberValue;

		public enum BoardNumberLimits { MinimumBoardNumber = 0, MaximumBoardNumber = 32 }

		public BoardHardwareAddressResp()
		{}

		public BoardHardwareAddressResp(BoardHardwareAddressResp a):base(a)
		{
			BoardNumber = a.BoardNumber;
			BoardType = a.BoardType;
            BoardUid = a.BoardUid;
		}

		public BoardHardwareAddressResp(int clusterId, int panelId, short cpuId, int boardNumber, int clusterGroupId ):base(clusterId, panelId, cpuId, clusterGroupId)
		{
			if (boardNumber >= (Int32)BoardNumberLimits.MinimumBoardNumber && boardNumber <= (Int32)BoardNumberLimits.MaximumBoardNumber)
			{
				BoardNumber = boardNumber;
			}
		}

        public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}:{4:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber); } }
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
        public GalaxyInterfaceBoardType BoardType {get;set;}
        public Guid BoardUid { get; set; }

        public BoardHardwareAddressResp BoardAddress { get { return this; } }
		public override string ToString()
		{
			return UniqueId;
		}
	}
}
