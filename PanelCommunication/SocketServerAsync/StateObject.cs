////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	StateObject.cs
//
// summary:	Implements the state object class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   StateObject Class to read data from Client. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public class StateObject
	{
        /// <summary>   Client  socket. </summary>
		public Socket workSocket = null;
        /// <summary>   Size of receive buffer. </summary>
		public const int BufferSize = 4096;
        /// <summary>   Receive buffer. </summary>
		public byte[] buffer = new byte[BufferSize];
        /// <summary>   Received data string. </summary>
		public StringBuilder sb = new StringBuilder();
	}
}
