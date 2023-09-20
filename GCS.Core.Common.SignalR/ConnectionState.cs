////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ConnectionState.cs
//
// summary:	Implements the connection state class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.SignalR
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent connection states. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum ConnectionState
    {
        /// <summary>   An enum constant representing the connecting option. </summary>
        Connecting,
        /// <summary>   An enum constant representing the connected option. </summary>
        Connected,
        /// <summary>   An enum constant representing the reconnecting option. </summary>
        Reconnecting,
        /// <summary>   An enum constant representing the disconnected option. </summary>
        Disconnected,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A state change. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class StateChange
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Creates a new stance of <see cref="T:Microsoft.AspNet.SignalR.Client.StateChange" />.
        /// </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="oldState"> The old state of the connection. </param>
        /// <param name="newState"> The new state of the connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public StateChange(ConnectionState oldState, ConnectionState newState)
        {
            this.OldState = oldState;
            this.NewState = newState;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the old state of the connection. </summary>
        ///
        /// <value> The old state. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionState OldState { get; private set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the new state of the connection. </summary>
        ///
        /// <value> The new state. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionState NewState { get; private set; }
    }
}
