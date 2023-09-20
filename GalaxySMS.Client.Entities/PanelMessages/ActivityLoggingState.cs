////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\ActivityLoggingState.cs
//
// summary:	Implements the activity logging state class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.CodeDom;
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
    /// <summary>   Information about the activity logging. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public class ActivityLoggingInformation : ObjectBase
	{
        /// <summary>   Number of activity log not acknowledged. </summary>
	    private uint _activityLogNotAcknowledgedCount;
        /// <summary>   Number of activity log buffers. </summary>
	    private uint _activityLogBufferCount;
        /// <summary>   State of the activity logging enabled. </summary>
	    private ActivityLoggingEnabledState _activityLoggingEnabledState;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public ActivityLoggingInformation()
	    {
	        ActivityLoggingEnabledState = new ActivityLoggingEnabledState();
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of activity log not acknowledged. </summary>
        ///
        /// <value> The number of activity log not acknowledged. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt32 ActivityLogNotAcknowledgedCount
	    {
	        get { return _activityLogNotAcknowledgedCount; }
            set
            {
                if (_activityLogNotAcknowledgedCount != value)
                {
                    _activityLogNotAcknowledgedCount = value;
                    OnPropertyChanged(() => ActivityLogNotAcknowledgedCount);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of activity log buffers. </summary>
        ///
        /// <value> The number of activity log buffers. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt32 ActivityLogBufferCount
	    {
	        get { return _activityLogBufferCount; }
            set
            {
                if (_activityLogBufferCount != value)
                {
                    _activityLogBufferCount = value;
                    OnPropertyChanged(() => ActivityLogBufferCount);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state of the activity logging enabled. </summary>
        ///
        /// <value> The activity logging enabled state. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ActivityLoggingEnabledState ActivityLoggingEnabledState
	    {
	        get { return _activityLoggingEnabledState; }
            set
            {
                if (_activityLoggingEnabledState != value)
                {
                    _activityLoggingEnabledState = value;
                    OnPropertyChanged(() => ActivityLoggingEnabledState);
                }
            }
	    }
	}
}
