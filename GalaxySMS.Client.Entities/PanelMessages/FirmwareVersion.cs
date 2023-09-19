////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\FirmwareVersion.cs
//
// summary:	Implements the firmware version class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A firmware version. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class FirmwareVersion : ObjectBase
	{
        /// <summary>   The major. </summary>
	    private ushort _major;
        /// <summary>   The minor. </summary>
	    private ushort _minor;
        /// <summary>   The letter code. </summary>
	    private ushort _letterCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the major. </summary>
        ///
        /// <value> The major. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 Major
	    {
	        get { return _major; }
            set
            {
                if (_major != value)
                {
                    _major = value;
                    OnPropertyChanged(() => Major);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the minor. </summary>
        ///
        /// <value> The minor. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 Minor
	    {
	        get { return _minor; }
            set
            {
                if (_minor != value)
                {
                    _minor = value;
                    OnPropertyChanged(() => Minor);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the letter code. </summary>
        ///
        /// <value> The letter code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 LetterCode
	    {
	        get { return _letterCode; }
	        set
	        {
	            if (_letterCode != value)
	            {
	                _letterCode = value;
	                OnPropertyChanged(() => LetterCode);
	            }
	        }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public override string ToString()
		{
		    var subVersion = LetterCode;
		    if( LetterCode >= 0x40)
		        subVersion = (UInt16)(LetterCode - 0x40);
		    return string.Format("{0}.{1}.{2}", Major, Minor, subVersion);
		}
	}
}
