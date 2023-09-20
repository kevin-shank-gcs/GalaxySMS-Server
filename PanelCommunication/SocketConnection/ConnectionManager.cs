using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GCS.PanelCommunication.SocketServer
{
	public class ConnectionManager
	{
		private TcpListener tcpServer;
		private TcpClient tcpClient;
		private Thread listenerThread;
		private List<Connection6xx> clientList = new List<Connection6xx>();
		private List<Thread> threadList = new List<Thread>();

		#region Public Properties
		public delegate void ChangedEventHandler(object sender, EventArgs e);
		public event ChangedEventHandler Changed;
		public Int32 ListenPort { get; set; }
		#endregion
		public bool EncryptionEnabled
		{
			get;
			set;
		}

		public ConnectionManager()
		{
			ListenPort = 3001;
			Changed += new ChangedEventHandler(ClientAdded);
		}

		#region Server Start/Stop

		/// <summary>
		/// This function spawns new thread for TCP communication
		/// </summary>
		public void StartServer(Int32 listenPort)
		{
			try
			{
				System.Diagnostics.Trace.WriteLine(string.Format("ConnectionManager.StartServer() executing on thread ID 0x{0:X}",
					System.Threading.Thread.CurrentThread.ManagedThreadId));

				StopServer();	// stop it first, just in case it is running
				ListenPort = listenPort;
				listenerThread = new Thread(new ThreadStart(StartListen));
				listenerThread.Name = "Listening thread";
				listenerThread.Start();
			}
			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine(string.Format("StartServer exception. {0}", ex.Message));
			}
		}

		/// <summary>
		/// Server listens on the given port and accepts the connection from Client.
		/// As soon as the connection id made a dialog box opens up for Chatting.
		/// </summary>
		private void StartListen()
		{
			System.Diagnostics.Trace.WriteLine(string.Format("StartListen() running on thread ID 0x{0:X}",
				System.Threading.Thread.CurrentThread.ManagedThreadId));
			try
			{
				tcpServer = new TcpListener(IPAddress.Any, ListenPort);
				tcpServer.Start();

				// Keep on accepting Client Connection
				while (true)
				{

					// New Client connected, call Event to handle it.
					Thread t = new Thread(new ParameterizedThreadStart(NewClient));
					tcpClient = tcpServer.AcceptTcpClient();
					t.Name = string.Format("Client connection: {0}", ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString());
					t.Start(tcpClient);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine(string.Format("StartServer exception. {0}", ex.Message));
			}

			System.Diagnostics.Trace.WriteLine(string.Format("StartListen() stopping on thread ID 0x{0:X}",
				System.Threading.Thread.CurrentThread.ManagedThreadId));
		}

		/// <summary>
		/// Function to stop the TCP communication. It kills the thread and closes client connection
		/// </summary>
		public void StopServer()
		{
			System.Diagnostics.Trace.WriteLine(string.Format("ConnectionManager.StopServer() executing on thread ID 0x{0:X}",
				System.Threading.Thread.CurrentThread.ManagedThreadId));

			if (tcpServer != null)
			{

				// Close all Socket connection
				foreach (Connection6xx c in clientList)
				{
					c.ConnectedClient.Client.Close();
				}

				// Abort All Running Threads
				foreach (Thread t in threadList)
				{
					t.Abort();
				}

				// Clear all ArrayList
				clientList.Clear();
				threadList.Clear();

				// Abort Listening Thread and Stop listening
				listenerThread.Abort();
				tcpServer.Stop();
			}
		}
		#endregion

		#region Add/remove Clients
		/// <summary>
		/// 
		/// </summary>
		public void NewClient(Object obj)
		{
			ClientAdded(this, new ClientAddedEventArgs((TcpClient)obj));
		}

		/// <summary>
		/// Event Fired when a Client gets connected. Following actions are performed
		/// 1. Update Tree view
		/// 2. Open a chat box to chat with client.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ClientAdded(object sender, EventArgs e)
		{
			tcpClient = ((ClientAddedEventArgs)e).clientSock;
			String remoteIP = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
			String remotePort = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port.ToString();
			String localPort = ((IPEndPoint)tcpClient.Client.LocalEndPoint).Port.ToString();

			// delete any previous connection from the same port and ip 
			DisconnectClient(remoteIP, remotePort);

			// Call Delegate Function to update Tree View
//			UpdateClientList(remoteIP + " : " + remotePort, "Add");
			// Create Client connection for communicating
			Connection6xx clientConnection;
			if (EncryptionEnabled == true)
				clientConnection = new Connection6xx(this, tcpClient, PanelProtocols.CryptoType.Aes, "choose a phrase now");
			else
				clientConnection = new Connection6xx(this, tcpClient, PanelProtocols.CryptoType.None, "");

			clientConnection.DataReceivedEvent += clientConnection_DataReceivedEvent;
			clientConnection.PanelToPanelPacketReceivedEvent += clientConnection_PanelToPanelPacketReceivedEvent;
			// Add Dialog Box Object to Array List
			clientList.Add(clientConnection);
			threadList.Add(Thread.CurrentThread);
			System.Diagnostics.Trace.WriteLine(string.Format("Client added. {0}", clientList.Count));
		}

		private void clientConnection_PanelToPanelPacketReceivedEvent(object sender, PanelProtocols.Series6xx.PanelDataPacketEventArgs e)
		{	// these packets must be sent to other panels based on the packet.dist value

			System.Diagnostics.Trace.WriteLine(string.Format("clientConnection_PanelToPanelPacketReceivedEvent on Thread 0x{0:X} - packet for distribution to other panels", 
				System.Threading.Thread.CurrentThread.ManagedThreadId));
		}

		void clientConnection_DataReceivedEvent(object sender, DataReceivedEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(string.Format("clientConnection_DataReceivedEvent on Thread 0x{0:X}",
				System.Threading.Thread.CurrentThread.ManagedThreadId));

		}

		public void DisconnectClient(String remoteIP, String remotePort)
		{
			System.Diagnostics.Trace.WriteLine(string.Format("DisconnectClient called."));
			// Delete Client from Tree View
//			UpdateClientList(remoteIP + " : " + remotePort, "Delete");

			// Find Client Chat Dialog box corresponding to this Socket
			int counter = 0;
			foreach (Connection6xx c in clientList)
			{
				String remoteIP1 = ((IPEndPoint)c.ConnectedClient.Client.RemoteEndPoint).Address.ToString();
				String remotePort1 = ((IPEndPoint)c.ConnectedClient.Client.RemoteEndPoint).Port.ToString();

				if (remoteIP1.Equals(remoteIP) && remotePort1.Equals(remotePort))
				{
					clientList.RemoveAt(counter);
					threadList[counter].Abort();
					threadList.RemoveAt(counter);
					System.Diagnostics.Trace.WriteLine(string.Format("Client deleted. {0}", clientList.Count));
					break;
				}
				counter++;
			}
		}	

		public void DisconnectClient(Connection6xx client)
		{
			// Delete Client from Tree View
//			UpdateClientList(remoteIP + " : " + remotePort, "Delete");

			System.Diagnostics.Trace.WriteLine(string.Format("DisconnectClient called."));
			// Find Client Chat Dialog box corresponding to this Socket
			int counter = 0;
			foreach (Connection6xx c in clientList)
			{
				if(c.Equals(client))
				{
					clientList.RemoveAt(counter);
					threadList[counter].Abort();
					threadList.RemoveAt(counter);
					System.Diagnostics.Trace.WriteLine(string.Format("Client deleted. {0}", clientList.Count));
					break;
				}
				counter++;
			}	
		}
		#endregion
	}
}
