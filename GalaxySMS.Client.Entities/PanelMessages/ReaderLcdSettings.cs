////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\ReaderLcdSettings.cs
//
// summary:	Implements the reader LCD settings class
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
    /// <summary>   A reader LCD settings. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class ReaderLcdSettings : ObjectBase
	{
        /// <summary>   The LCD hardware address. </summary>
	    private BoardSectionNodeHardwareAddress _lcdHardwareAddress;
        /// <summary>   Describes the format to use. </summary>
	    private Lcd8By4Format _format;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent LCD 8 by 4 formats. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public enum Lcd8By4Format { Normal, LargeClock, TwelveSmallDigitsEightLargeDigits, EightSmallDigitsTwelveLargeDigits}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public ReaderLcdSettings()
		{
			LcdHardwareAddress = new BoardSectionNodeHardwareAddress();
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the LCD hardware address. </summary>
        ///
        /// <value> The LCD hardware address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public BoardSectionNodeHardwareAddress LcdHardwareAddress
	    {
	        get { return _lcdHardwareAddress; }
            set
            {
                if (_lcdHardwareAddress != value)
                {
                    _lcdHardwareAddress = value;
                    OnPropertyChanged(() => LcdHardwareAddress);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the format to use. </summary>
        ///
        /// <value> The format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Lcd8By4Format Format
	    {
	        get { return _format; }
            set
            {
                if (_format != value)
                {
                    _format = value;
                    OnPropertyChanged(() => Format);
                }
            }
        }
	}
}
