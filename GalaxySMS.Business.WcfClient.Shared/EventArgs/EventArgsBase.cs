////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EventArgs\EventArgsBase.cs
//
// summary:	Implements the event arguments base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using GalaxySMS.Client.SDK.DataClasses;

namespace GalaxySMS.Client.SDK
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An event arguments base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class EventArgsBase : EventArgs
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EventArgsBase()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="requestInvokedAt">     The request invoked at. </param>
        /// <param name="requestCompletedAt">   The request completed at. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EventArgsBase(DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
        {
            RequestInvokedAt = requestInvokedAt;
            RequestCompletedAt = requestCompletedAt;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="requestInvokedAt">         The request invoked at. </param>
        /// <param name="requestCompletedAt">       The request completed at. </param>
        /// <param name="serverConnectionSettings"> The server connection settings. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EventArgsBase(DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt,
            IGalaxySiteServerConnectionSettings serverConnectionSettings)
        {
            RequestInvokedAt = requestInvokedAt;
            RequestCompletedAt = requestCompletedAt;
            ServerConnectionSettings = serverConnectionSettings;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the request invoked at. </summary>
        ///
        /// <value> The request invoked at. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset RequestInvokedAt { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the request completed at. </summary>
        ///
        /// <value> The request completed at. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset RequestCompletedAt { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the server connection settings. </summary>
        ///
        /// <value> The server connection settings. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IGalaxySiteServerConnectionSettings ServerConnectionSettings { get; internal set; }
    }
}