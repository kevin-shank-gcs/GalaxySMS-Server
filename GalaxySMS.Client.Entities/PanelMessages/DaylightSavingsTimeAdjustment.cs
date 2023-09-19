////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\DaylightSavingsTimeAdjustment.cs
//
// summary:	Implements the daylight savings time adjustment class
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
    /// <summary>   A daylight savings time adjustment. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class DaylightSavingsTimeAdjustment : ObjectBase
	{
        /// <summary>   The when to change Date/Time. </summary>
	    private DateTimeOffset _whenToChange;
        /// <summary>   The new date time. </summary>
	    private DateTimeOffset _newDateTime;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public DaylightSavingsTimeAdjustment()
		{

		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the when to change. </summary>
        ///
        /// <value> The when to change. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
	    public DateTimeOffset WhenToChange
	    {
	        get { return _whenToChange; }
            set
            {
                if (_whenToChange != value)
                {
                    _whenToChange = value;
                    OnPropertyChanged(() => WhenToChange);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the new date time. </summary>
        ///
        /// <value> The new date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public DateTimeOffset NewDateTime
	    {
	        get { return _newDateTime; }
            set
            {
                if (_newDateTime != value)
                {
                    _newDateTime = value;
                    OnPropertyChanged(() => NewDateTime);
                }
            }
	    }
	}
}
