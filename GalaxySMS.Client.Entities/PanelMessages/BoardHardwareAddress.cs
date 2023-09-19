////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\BoardHardwareAddress.cs
//
// summary:	Implements the board hardware address class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A board hardware address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class BoardHardwareAddress : CpuHardwareAddress
    {
        /// <summary>   The board number value. </summary>
        private Int32 _boardNumberValue;
        /// <summary>   Type of the board. </summary>
        private GalaxyInterfaceBoardType _boardType;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent board number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum BoardNumberLimits { MinimumBoardNumber = 0, MaximumBoardNumber = 32 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BoardHardwareAddress()
        { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="a">    The BoardHardwareAddress to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BoardHardwareAddress(BoardHardwareAddress a) : base(a)
        {
            BoardNumber = a.BoardNumber;
            BoardType = a.BoardType;
            BoardUid = a.BoardUid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="clusterId">    Identifier for the cluster. </param>
        /// <param name="panelId">      Identifier for the panel. </param>
        /// <param name="cpuId">        Identifier for the CPU. </param>
        /// <param name="boardNumber">  The board number. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BoardHardwareAddress(Int32 clusterId, Int32 panelId, Int32 cpuId, int boardNumber) : base(clusterId, panelId, cpuId)
        {
            if (boardNumber >= (Int32)BoardNumberLimits.MinimumBoardNumber && boardNumber <= (Int32)BoardNumberLimits.MaximumBoardNumber)
            {
                BoardNumber = boardNumber;
            }
        }

        //		[DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public new String UniqueId { get { return string.Format("{0}:{1:D3}:{2:D3}:{3:D}:{4:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The board number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 BoardNumber
        {
            get { return _boardNumberValue; }
            set
            {
                if (value >= (Int32)BoardNumberLimits.MinimumBoardNumber && value <= (Int32)BoardNumberLimits.MaximumBoardNumber)
                {
                    if (_boardNumberValue != value)
                    {
                        _boardNumberValue = value;
                        OnPropertyChanged(() => BoardNumber);
                    }
                }
                else
                    throw new ArgumentOutOfRangeException("BoardNumber", value, string.Format("The BoardNumber value must be between {0} and {1}",
                        BoardNumberLimits.MinimumBoardNumber, BoardNumberLimits.MaximumBoardNumber));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the board. </summary>
        ///
        /// <value> The type of the board. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyInterfaceBoardType BoardType
        {
            get { return _boardType; }
            set
            {
                if (_boardType != value)
                {
                    _boardType = value;
                    OnPropertyChanged(() => BoardType);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board UID. </summary>
        ///
        /// <value> The board UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid BoardUid { get; set; }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets the board address. </summary>
        /////
        ///// <value> The board address. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public BoardHardwareAddress BoardAddress { get { return this; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return UniqueId;
        }
    }
}
