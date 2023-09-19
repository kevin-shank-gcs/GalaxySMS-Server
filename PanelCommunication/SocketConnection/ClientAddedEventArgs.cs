using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace GCS.PanelCommunication.SocketServer
{
	class ClientAddedEventArgs : EventArgs
	{
		private TcpClient sock;
		public TcpClient clientSock
		{
			get { return sock; }
			set { sock = value; }
		}

		public ClientAddedEventArgs(TcpClient tcpClient)
		{
			sock = tcpClient;
		}
	}
}
