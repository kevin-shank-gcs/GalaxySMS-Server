////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\InitializeBoardSectionSettings.cs
//
// summary:	Implements the initialize board section settings class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An initialize board section settings. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class InitializeBoardSectionSettings : ObjectBase
	{
        /// <summary>   The address. </summary>
	    private BoardSectionHardwareAddress _address;
        /// <summary>   Type of the section. </summary>
	    private PanelInterfaceBoardSectionType _sectionType;
        /// <summary>   Number of relays. </summary>
	    private ushort _relayCount;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the address. </summary>
        ///
        /// <value> The address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public BoardSectionHardwareAddress Address
	    {
	        get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(() => Address);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of relays. </summary>
        ///
        /// <value> The number of relays. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 RelayCount
	    {
	        get { return _relayCount; }
            set
            {
                if (_relayCount != value)
                {
                    _relayCount = value;
                    OnPropertyChanged(() => RelayCount);
                }
            }
	    }
	}
}
