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

    public class BoardHardwareAddress : CpuHardwareAddress
    {
        private Int32 boardNumberValue;

        public enum BoardNumberLimits { MinimumBoardNumber = 0, MaximumBoardNumber = 32 }

        public BoardHardwareAddress()
        { }

        public BoardHardwareAddress(BoardHardwareAddress a) : base(a)
        {
            BoardNumber = a.BoardNumber;
            BoardType = a.BoardType;
            BoardUid = a.BoardUid;
        }

        public BoardHardwareAddress(int clusterId, int panelId, short cpuId, int boardNumber, int clusterGroupId) : base(clusterId, panelId, cpuId, clusterGroupId)
        {
            if (boardNumber >= (Int32)BoardNumberLimits.MinimumBoardNumber && boardNumber <= (Int32)BoardNumberLimits.MaximumBoardNumber)
            {
                BoardNumber = boardNumber;
            }
        }

        public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}:{4:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber); } }
#if NetCoreApi
#else
        [DataMember]
#endif
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
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyInterfaceBoardType BoardType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid BoardUid { get; set; }

        //public BoardHardwareAddress BoardAddress { get { return this; } }
        public override string ToString()
        {
            return UniqueId;
        }
    }
}
