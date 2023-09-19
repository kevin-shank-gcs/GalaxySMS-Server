////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\BoardSectionNodeHardwareAddress.cs
//
// summary:	Implements the board section node hardware address class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A board section node hardware address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public class BoardSectionNodeHardwareAddress : BoardSectionHardwareAddress
	{
        /// <summary>   The node number value. </summary>
        private Int32 _nodeNumberValue;
        private Int32 _moduleNumberValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent node number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum NodeNumberLimits { MinimumNodeNumber = 0, MaximumNodeNumber = 120 }
        public enum ModuleNumberLimits { MinimumModuleNumber = 0, MaximumModuleNumber = 16 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public BoardSectionNodeHardwareAddress()
		{}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="a">    The BoardSectionNodeHardwareAddress to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public BoardSectionNodeHardwareAddress(BoardSectionNodeHardwareAddress a):base(a)
		{
            ModuleNumber = a.ModuleNumber;
			NodeNumber = a.NodeNumber;
            BoardSectionNodeUid = a.BoardSectionNodeUid;
		}

//		[DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public new String UniqueId { get { return string.Format("{0}:{1:D3}:{2:D3}:{3:D}:{4:D}:{5:D}:{6:D}:{7:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber, SectionNumber, ModuleNumber, NodeNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the node number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The node number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Int32 NodeNumber
		{
			get { return _nodeNumberValue; }
			set
			{
				if (value >= (Int32)NodeNumberLimits.MinimumNodeNumber && value <= (Int32)NodeNumberLimits.MaximumNodeNumber)
				{
				    _nodeNumberValue = value;
                    if (_nodeNumberValue != value)
                    {
                        _nodeNumberValue = value;
                        OnPropertyChanged(() => NodeNumber);
                    }
                }
				else
					throw new ArgumentOutOfRangeException("NodeNumber", value, string.Format("The NodeNumber value must be between {0} and {1}",
						NodeNumberLimits.MinimumNodeNumber, NodeNumberLimits.MaximumNodeNumber));
			}
		}


        
        [DataMember]
        public Int32 ModuleNumber
        {
            get { return _moduleNumberValue; }
            set
            {
                if (value >= (Int32)ModuleNumberLimits.MinimumModuleNumber && value <= (Int32)ModuleNumberLimits.MaximumModuleNumber)
                {
                    _moduleNumberValue = value;
                    if (_moduleNumberValue != value)
                    {
                        _moduleNumberValue = value;
                        OnPropertyChanged(() => ModuleNumber);
                    }
                }
                else
                    throw new ArgumentOutOfRangeException("ModuleNumber", value, string.Format("The ModuleNumber value must be between {0} and {1}",
                        ModuleNumberLimits.MinimumModuleNumber, ModuleNumberLimits.MaximumModuleNumber));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board section node UID. </summary>
        ///
        /// <value> The board section node UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Guid BoardSectionNodeUid { get; set; }

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
