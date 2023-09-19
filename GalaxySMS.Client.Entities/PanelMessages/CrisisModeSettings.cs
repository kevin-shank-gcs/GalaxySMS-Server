////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\CrisisModeSettings.cs
//
// summary:	Implements the crisis mode settings class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The crisis mode settings. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class CrisisModeSettings : ObjectBase
	{
        /// <summary>   The input output group number. </summary>
	    private InputOutputGroupNumber _inputOutputGroupNumber;
        /// <summary>   True to automatically reset. </summary>
	    private bool _autoReset;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public CrisisModeSettings()
		{
			InputOutputGroupNumber = new InputOutputGroupNumber();
			AutoReset = false;
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group number. </summary>
        ///
        /// <value> The input output group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupNumber InputOutputGroupNumber
	    {
	        get { return _inputOutputGroupNumber; }
            set
            {
                if (_inputOutputGroupNumber != value)
                {
                    _inputOutputGroupNumber = value;
                    OnPropertyChanged(() => InputOutputGroupNumber);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the automatic reset. </summary>
        ///
        /// <value> True if automatic reset, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public bool AutoReset
	    {
	        get { return _autoReset; }
            set
            {
                if (_autoReset != value)
                {
                    _autoReset = value;
                    OnPropertyChanged(() => AutoReset);
                }
            }
	    }
	}
}
