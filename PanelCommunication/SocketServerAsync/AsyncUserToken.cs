////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	AsyncUserToken.cs
//
// summary:	Implements the asynchronous user token class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Net.Sockets;
using GCS.PanelCommunicationServerAsync.Entities;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class is designed for use as the object to be assigned to the
    /// SocketAsyncEventArgs.UserToken property.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	class AsyncUserToken
	{
        /// <summary>   The socket. </summary>
		Socket _socket;
        /// <summary>   Options for controlling the cluster connection. </summary>
		ClusterConnectionParameters _clusterConnectionParameters;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public AsyncUserToken() : this(null, null) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="socket">                       The socket. </param>
        /// <param name="clusterConnectionParameters">  Options that control the cluster connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public AsyncUserToken(Socket socket, ClusterConnectionParameters clusterConnectionParameters)
		{
			_socket = socket;
			_clusterConnectionParameters = clusterConnectionParameters;
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the socket. </summary>
        ///
        /// <value> The socket. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public Socket Socket
		{
			get { return _socket; }
			set { _socket = value; }
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets options for controlling the cluster connection. </summary>
        ///
        /// <value> Options that control the cluster connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public ClusterConnectionParameters ClusterConnectionParameters
		{
			get { return _clusterConnectionParameters; }
			set { _clusterConnectionParameters = value; }
		}

	}
}
