////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\FromPanel\LoggingStatusReply.cs
//
// summary:	Implements the logging status reply class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A logging status reply. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class LoggingStatusReply : PanelMessageBase
    {
        /// <summary>   State of the enabled. </summary>
        private ActivityLoggingEnabledState _enabledState;
        /// <summary>   Number of unacknowledged activity logs. </summary>
        private uint _unacknowledgedActivityLogCount;
        /// <summary>   Number of buffered activity logs. </summary>
        private uint _bufferedActivityLogCount;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public LoggingStatusReply() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="b">    The PanelMessageBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public LoggingStatusReply(PanelMessageBase b)
            : base(b)
        {
            EnabledState = new ActivityLoggingEnabledState();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The LoggingStatusReply to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public LoggingStatusReply(LoggingStatusReply o)
            : base(o)
        {
            if (o != null)
            {
                EnabledState = o.EnabledState;
                UnacknowledgedActivityLogCount = o.UnacknowledgedActivityLogCount;
                BufferedActivityLogCount = o.BufferedActivityLogCount;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state of the enabled. </summary>
        ///
        /// <value> The enabled state. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ActivityLoggingEnabledState EnabledState
        {
            get { return _enabledState; }
            set
            {
                if (_enabledState != value)
                {
                    _enabledState = value;
                    OnPropertyChanged(() => EnabledState);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of unacknowledged activity logs. </summary>
        ///
        /// <value> The number of unacknowledged activity logs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt32 UnacknowledgedActivityLogCount
        {
            get { return _unacknowledgedActivityLogCount; }
            set
            {
                if (_unacknowledgedActivityLogCount != value)
                {
                    _unacknowledgedActivityLogCount = value;
                    OnPropertyChanged(() => UnacknowledgedActivityLogCount);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of buffered activity logs. </summary>
        ///
        /// <value> The number of buffered activity logs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt32 BufferedActivityLogCount
        {
            get { return _bufferedActivityLogCount; }
            set
            {
                if (_bufferedActivityLogCount != value)
                {
                    _bufferedActivityLogCount = value;
                    OnPropertyChanged(() => BufferedActivityLogCount);
                }
            }
        }
    }
}
