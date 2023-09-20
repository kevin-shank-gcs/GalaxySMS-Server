////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\BoardSectionHardwareAddress.cs
//
// summary:	Implements the board section hardware address class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A board section hardware address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class BoardSectionHardwareAddress : BoardHardwareAddress
    {
        /// <summary>   The section number value. </summary>
		private Int32 _sectionNumberValue;
        /// <summary>   The section node combined number. </summary>
	    private int _sectionNodeCombinedNumber;
        /// <summary>   Type of the section. </summary>
	    private PanelInterfaceBoardSectionType _sectionType;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent section number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum SectionNumberLimits { MinimumSectionNumber = 0, MaximumSectionNumber = 16 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BoardSectionHardwareAddress() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="a">    The BoardSectionHardwareAddress to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BoardSectionHardwareAddress(BoardSectionHardwareAddress a) : base(a)
        {
            SectionNumber = a.SectionNumber;
            SectionType = a.SectionType;
            BoardSectionUid = a.BoardSectionUid;
            SectionNodeCombinedNumber = a.SectionNodeCombinedNumber;
        }

        //		[DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public new String UniqueId { get { return string.Format("{0}:{1:D3}:{2:D3}:{3:D}:{4:D}:{5:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId, BoardNumber, SectionNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the section number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The section number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 SectionNumber
        {
            get { return _sectionNumberValue; }
            set
            {
                if (value >= (Int32)SectionNumberLimits.MinimumSectionNumber && value <= (Int32)SectionNumberLimits.MaximumSectionNumber)
                {
                    if (_sectionNumberValue != value)
                    {
                        _sectionNumberValue = value;
                        OnPropertyChanged(() => SectionNumber);
                    }
                }
                else
                    throw new ArgumentOutOfRangeException("SectionNumber", value, string.Format("The SectionNumber value must be between {0} and {1}",
                        SectionNumberLimits.MinimumSectionNumber, SectionNumberLimits.MaximumSectionNumber));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the section node combined number. </summary>
        ///
        /// <value> The section node combined number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 SectionNodeCombinedNumber
        {
            get { return _sectionNodeCombinedNumber; }
            set
            {
                if (_sectionNodeCombinedNumber != value)
                {
                    _sectionNodeCombinedNumber = value;
                    OnPropertyChanged(() => SectionNodeCombinedNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the section. </summary>
        ///
        /// <value> The type of the section. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PanelInterfaceBoardSectionType SectionType
        {
            get { return _sectionType; }
            set
            {
                if (_sectionType != value)
                {
                    _sectionType = value;
                    OnPropertyChanged(() => SectionType);
                }
            }
        }

        //	    [DataMember]

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets the board section address. </summary>
        /////
        ///// <value> The board section address. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public BoardSectionHardwareAddress BoardSectionAddress { get { return this; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board section UID. </summary>
        ///
        /// <value> The board section UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid BoardSectionUid { get; set; }

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
