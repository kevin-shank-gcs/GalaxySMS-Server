////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\ReaderLockoutSettings.cs
//
// summary:	Implements the reader lockout settings class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A reader lockout settings. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class ReaderLockoutSettings : ObjectBase
	{
        /// <summary>   The maximum invalid attempts. </summary>
	    private byte _maximumInvalidAttempts;
        /// <summary>   The lockout time in hundredths of in seconds. </summary>
	    private ushort _lockoutTimeInHundredthsOfSeconds;
        /// <summary>   The card tour manager controller number. </summary>
	    private byte _cardTourManagerControllerNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public ReaderLockoutSettings()
		{
			MaximumInvalidAttempts = 3;
			LockoutTimeInHundredthsOfSeconds = 500;
			CardTourManagerControllerNumber = 0;
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the maximum invalid attempts. </summary>
        ///
        /// <value> The maximum invalid attempts. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte MaximumInvalidAttempts
	    {
	        get { return _maximumInvalidAttempts; }
            set
            {
                if (_maximumInvalidAttempts != value)
                {
                    _maximumInvalidAttempts = value;
                    OnPropertyChanged(() => MaximumInvalidAttempts);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the lockout time in hundredths of seconds. </summary>
        ///
        /// <value> The lockout time in hundredths of seconds. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 LockoutTimeInHundredthsOfSeconds
	    {
	        get { return _lockoutTimeInHundredthsOfSeconds; }
            set
            {
                if (_lockoutTimeInHundredthsOfSeconds != value)
                {
                    _lockoutTimeInHundredthsOfSeconds = value;
                    OnPropertyChanged(() => LockoutTimeInHundredthsOfSeconds);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card tour manager controller number. </summary>
        ///
        /// <value> The card tour manager controller number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte CardTourManagerControllerNumber
	    {
	        get { return _cardTourManagerControllerNumber; }
            set
            {
                if (_cardTourManagerControllerNumber != value)
                {
                    _cardTourManagerControllerNumber = value;
                    OnPropertyChanged(() => CardTourManagerControllerNumber);
                }
            }
        }
	}
}
