////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Connection6xx.cs
//
// summary:	Implements the connection 6xx class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using GCS.PanelEntities;
using GCS.PanelProtocols;
using GCS.PanelProtocols.Enums;
using GCS.PanelProtocols.Series6xx;
using GCS.PanelProtocols.Series6xx.Messages;
using GCS.Security;

namespace GCS.PanelCommunication.SocketServer
{
	/// <summary>	Connection 6xx. </summary>
	public class Connection6xx
	{
		#region Private enum and constants
		/// <summary>	Values that represent SignOnState. </summary>
		private enum SignOnState
		{
			/// <summary>	An enum constant representing the not authenticated option. </summary>
			NotAuthenticated,
			/// <summary>	An enum constant representing the sent sign on challange option. </summary>
			SentSignOnChallange,
			/// <summary>	An enum constant representing the sent date time synchronise option. </summary>
			SentDateTimeSync,
			/// <summary>	An enum constant representing the authenticated option. </summary>
			Authenticated
		}

		/// <summary>	The minimum send interval minimum value. </summary>
		private const int minimumSendIntervalMinimumValue = 0;
		/// <summary>	The minimum send interval maximum value. </summary>
		private const int minimumSendIntervalMaximumValue = 100;
		#endregion

		#region Private fields
		/// <summary>	The client. </summary>
		private TcpClient client;
		/// <summary>	The client stream. </summary>
		private NetworkStream clientStream;
		/// <summary>	The owner. </summary>
		private ConnectionManager owner;
		/// <summary>	The receiver. </summary>
		private GCS.PanelProtocols.SenderReceiver6xx receiver;
		/// <summary>	Number of last heartbeat received ticks. </summary>
		private int lastHeartbeatReceivedTickCount;
		/// <summary>	Number of last send ticks. </summary>
		private int lastSendTickCount;
		/// <summary>	The minimum send interval. </summary>
		private int minimumSendInterval = 50;
		/// <summary>	The transmit sequence. </summary>
		private UInt32 transmitSequence = 1;
		/// <summary>	Type of the crypto. </summary>
		private GCS.PanelProtocols.CryptoType cryptoType;
		/// <summary>	The phrase. </summary>
		private String phrase;
		/// <summary>	State of the sign on. </summary>
		private SignOnState signOnState;
		/// <summary>	The timer. </summary>
		private System.Threading.Timer timer;

		/// <summary>	Identifier for the cluster. </summary>
		private Byte clusterID;
		/// <summary>	Identifier for the unit. </summary>
		private Byte unitID;
		/// <summary>	Identifier for the CPU. </summary>
		private Byte cpuID;
		#endregion

		#region Public Properties

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Gets or sets the connected client. </summary>
		///
		/// <value>	The connected client. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public TcpClient ConnectedClient
		{
			get { return client; }
			set { client = value; }
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Gets or sets a value indicating whether this object is authenticated. </summary>
		///
		/// <value>	true if this object is authenticated, false if not. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public bool IsAuthenticated
		{
			get
			{
				if (signOnState == SignOnState.Authenticated)
					return true;
				return false;
			}
		}
			

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Gets or sets the minimum send interval. </summary>
		///
		/// <value>	The minimum send interval. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public int MinimumSendInterval
		{
			get
			{
				return minimumSendInterval;
			}
			set
			{
				if (value < minimumSendIntervalMinimumValue || value > minimumSendIntervalMaximumValue)
				{
					throw new ArgumentOutOfRangeException("MinimumSendInterval", value, string.Format("The value must be between {0} and {1}", minimumSendIntervalMinimumValue, minimumSendIntervalMaximumValue));
				}
				else
				{
					minimumSendInterval = value;
				}
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Gets the identifier of the cluster. </summary>
		///
		/// <value>	The identifier of the cluster. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public int ClusterId
		{
			get { return clusterID; }
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Gets the identifier of the panel. </summary>
		///
		/// <value>	The identifier of the panel. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public int PanelId
		{
			get { return unitID; }
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Gets the identifier of the CPU. </summary>
		///
		/// <value>	The identifier of the CPU. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public int CpuId
		{
			get { return cpuID; }
		}

		#endregion

		#region Public Events

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Delegate for handling DataReceived events. </summary>
		///
		/// <param name="sender">	Source of the event. </param>
		/// <param name="e">		 	Data received event information. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);
		/// <summary>	Event queue for all listeners interested in dataReceived events. </summary>
		public event DataReceivedEventHandler DataReceivedEvent;

		public delegate void DataPacketReceivedEventHandler(object sender, PanelDataPacketEventArgs e);
		public event DataPacketReceivedEventHandler PanelToPanelPacketReceivedEvent;	// the only events raised via this event are packets that must be sent to one or more other panels in the cluster 
		#endregion

		#region Constructor
		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Constructor. </summary>
		///
		/// <param name="parent">	  	The parent. </param>
		/// <param name="tcpClient"> 	The TCP client. </param>
		/// <param name="cryptoType">	Type of the crypto. </param>
		/// <param name="phrase">	  	The phrase. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////
		public Connection6xx(ConnectionManager parent, TcpClient tcpClient, GCS.PanelProtocols.CryptoType cryptoType, String phrase)
		{
			this.owner = parent;
			// Get Stream Object
			ConnectedClient = tcpClient;
			clientStream = tcpClient.GetStream();

			System.Diagnostics.Trace.WriteLine("Connection6xx constructor. Setting signOnState = SignOnState.NotAuthenticated");
			signOnState = SignOnState.NotAuthenticated;

			// Create the state object.
			StateObject state = new StateObject();
			state.workSocket = ConnectedClient.Client;

			this.cryptoType = cryptoType;
			this.phrase = phrase;

			receiver = new PanelProtocols.SenderReceiver6xx(cryptoType, phrase);

			transmitSequence = 1;
			//Call Asynchronous Receive Function
			ConnectedClient.Client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
					  new AsyncCallback(OnReceive), state);

			SendSignOnChallenge();
			timer = new System.Threading.Timer(TimerCallback, null, 5000, 1000);
		}
		#endregion

		#region Public Methods
		#endregion

		#region Send/Receive Data From Sockets

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Send this message. </summary>
		///
		/// <param name="data">	The data. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void Send(byte[] data)
		{
			try
			{
				int ticksSinceLastSend = System.Environment.TickCount - lastSendTickCount;

				if (ticksSinceLastSend < MinimumSendInterval)
				{
					int sleepTime = MinimumSendInterval - ticksSinceLastSend;
					System.Diagnostics.Trace.WriteLine(string.Format("sleeping for {0} ms", sleepTime));

					System.Threading.Thread.Sleep(MinimumSendInterval - ticksSinceLastSend);
				}

				System.Diagnostics.Trace.WriteLine(string.Format("{0} - Sending {1} bytes: ", DateTimeOffset.Now.ToLongTimeString(), data.Length));
				string dbg = string.Empty;
				for( int x = 0; x < data.Length; x++)
					dbg += string.Format("{0:x2}", data[x]);
				System.Diagnostics.Trace.WriteLine(dbg);

				lastSendTickCount = System.Environment.TickCount;

				ConnectedClient.Client.Send(data);
			}
			catch (SocketException socketException)
			{
				//if (socketException.ErrorCode == 10054 || ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
				{
					System.Diagnostics.Trace.WriteLine(string.Format("Send() SocketException.ErrorCode: {0}", socketException.ErrorCode));
					if (ConnectedClient.Connected == true)
					{
						// Complete the disconnect request.
						String remoteIP = ((IPEndPoint)ConnectedClient.Client.RemoteEndPoint).Address.ToString();
						String remotePort = ((IPEndPoint)ConnectedClient.Client.RemoteEndPoint).Port.ToString();
						this.owner.DisconnectClient(this);

						ConnectedClient.Client.Close();
					}
				}
			}

		  // Eat up exception....Hmmmm I'm loving eat!!!
			catch (Exception exception)
			{
				System.Diagnostics.Trace.Write(exception.Message + "\n" + exception.StackTrace);
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Executes the receive action. </summary>
		///
		/// <param name="ar">	The archive. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void OnReceive(IAsyncResult ar)
		{
			// Retrieve the state object and the handler socket
			// from the asynchronous state object.

//			System.Diagnostics.Trace.WriteLine(string.Format("{0} OnReceive entered", DateTimeOffset.Now.ToLongTimeString()));

			StateObject state = (StateObject)ar.AsyncState;
			Socket handler = state.workSocket;
			int bytesRead;

			if (handler.Connected)
			{
				// Read data from the client socket. 
				try
				{
					bytesRead = handler.EndReceive(ar);
					if (bytesRead > 0)
					{
						// There  might be more data, so store the data received so far.
						UInt32 index = 0;
						int len = bytesRead;
						while((len--) > 0)
						{
							if (receiver.ReceiveByte(state.buffer[index++]) == true)
							{	// A COMPLETE MESSAGE HAS BEEN RECEIVED
								DataPacket6xx packet = receiver.Packet;
								receiver.Init();
								bool bValid = packet.IsValid();
								lastHeartbeatReceivedTickCount = System.Environment.TickCount;
								if (bValid == true)
									ProcessPacket(ref packet);
								else
								{
									if (IsAuthenticated == false )
									{	// if the connection is not authenticated, drop the connection
										System.Diagnostics.Trace.WriteLine("Dropping connection. Not Authenticated!!!\n");
										this.owner.DisconnectClient(this);

										handler.Close();
										handler = null;
										timer.Dispose();
									}
								}
							}
						}
						
						var eventHandler = DataReceivedEvent;
						if (eventHandler != null)
						{
							System.Diagnostics.Trace.WriteLine(string.Format("DataReceivedEvent raised from Thread 0x{0:X}",
								System.Threading.Thread.CurrentThread.ManagedThreadId));

							eventHandler(this, new DataReceivedEventArgs(ref state.buffer, bytesRead));
						}

						handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
							 new AsyncCallback(OnReceive), state);

					}
				}

				catch (SocketException socketException)
				{
					//WSAECONNRESET, the other side closed impolitely
//					if (socketException.ErrorCode == 10054 || ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
					{
						// Complete the disconnect request.
						System.Diagnostics.Trace.WriteLine(string.Format("OnReceive() SocketException.ErrorCode: {0}", socketException.ErrorCode));
						String remoteIP = ((IPEndPoint)handler.RemoteEndPoint).Address.ToString();
						String remotePort = ((IPEndPoint)handler.RemoteEndPoint).Port.ToString();
						this.owner.DisconnectClient(this);

						handler.Close();
						handler = null;
						timer.Dispose();
					}

				}

		  // Eat up exception....Hmmmm I'm loving eat!!!
				catch (Exception exception)
				{
					System.Diagnostics.Trace.Write(exception.Message + "\n" + exception.StackTrace);
				}
			}
//			System.Diagnostics.Trace.WriteLine(string.Format("{0} OnReceive exited", DateTimeOffset.Now.ToLongTimeString()));
		}
		#endregion

		#region Private methods

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Process the packet described by pkt. </summary>
		///
		/// <param name="pkt">	[in,out] The packet. </param>
		///
		/// <returns>	true if it succeeds, false if it fails. </returns>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private bool ProcessPacket(ref GCS.PanelProtocols.Series6xx.DataPacket6xx pkt)
		{
			switch ((PacketDataCode6xx)pkt.Data[0])
			{
				case PacketDataCode6xx.CpuHeartbeat:
					System.Diagnostics.Trace.WriteLine(string.Format("{0}, Cluster:{1}, Panel:{2}, CPU:{3} - heartbeat received", DateTimeOffset.Now.ToLongTimeString(), ClusterId, PanelId, CpuId));
					break;

				case PacketDataCode6xx.ResponseSignOnChallenge:
					System.Diagnostics.Trace.WriteLine(string.Format("{0} - ResponseSignOnChallenge received", DateTimeOffset.Now.ToLongTimeString()));
					if (this.signOnState == SignOnState.SentSignOnChallange)
					{
						AcceptSignOnChallengeResponse(ref pkt);
					}
					else
					{
						this.owner.DisconnectClient(this);
						timer.Dispose();
						return false;
					}
					break;

				case PacketDataCode6xx.ResponseAck:
					System.Diagnostics.Trace.WriteLine(string.Format("{0} - Ack received - {1}", DateTimeOffset.Now.ToLongTimeString(), ((PacketDataCode6xx)pkt.Data[1]).ToString()));
					if (pkt.Data[1] == (byte)PacketDataCode6xx.CommandSetDateTime &&
						signOnState == SignOnState.SentDateTimeSync)
					{
						System.Diagnostics.Trace.WriteLine("Connection6xx constructor. Setting signOnState = SignOnState.Authenticated");
						signOnState = SignOnState.Authenticated;
						HandleSetDateTimeChallenge(ref pkt);
						SetLoggingState(ActivityLoggingState.Off);
						SendGetLoggingInfo();
						SendGetCardCount();
						SendGetControllerInfo();
					}
					break;

				case PacketDataCode6xx.ResponseNack:
					System.Diagnostics.Trace.WriteLine(string.Format("{0} - Nack received - {1}", DateTimeOffset.Now.ToLongTimeString(), ((PacketDataCode6xx)pkt.Data[1]).ToString()));
					if (pkt.Data[1] == (byte)PacketDataCode6xx.CommandSetDateTime &&
						signOnState == SignOnState.SentDateTimeSync)
					{
						HandleSetDateTimeChallenge(ref pkt);
					}
					break;

				default:
					System.Diagnostics.Trace.WriteLine(string.Format("{0} - Received - {1}", DateTimeOffset.Now.ToLongTimeString(), ((PacketDataCode6xx)pkt.Data[0]).ToString()));
					if (signOnState != SignOnState.Authenticated)
					{	// if the connection is not authenticated, drop the connection
						if (pkt.Data[0] != (byte)PacketDataCode6xx.NotificationEventIOLevel)
						{
							timer.Dispose();
							// Complete the disconnect request.
							String remoteIP = ((IPEndPoint)ConnectedClient.Client.RemoteEndPoint).Address.ToString();
							String remotePort = ((IPEndPoint)ConnectedClient.Client.RemoteEndPoint).Port.ToString();
							this.owner.DisconnectClient(this);

							ConnectedClient.Client.Close();							
						}
						return false;
					}
					break;

			}

			if (IsAuthenticated == true)
			{
				//		COleDateTime dt;
				//		BOOL bNotifyCommServiceOfNewConnection = FALSE;
				switch (pkt.Distribute)
				{
					case GCS.PanelProtocols.Series6xx.PacketDistribution.FromPanelToAllPanels:
					case GCS.PanelProtocols.Series6xx.PacketDistribution.FromPanelToSpecificPanel:
						// This packet must be distributed to other panels. 
						var handler = PanelToPanelPacketReceivedEvent;
						if (handler != null) 
						{
							System.Diagnostics.Trace.WriteLine(string.Format("PanelToPanelPacketReceivedEvent raised from Thread 0x{0:X} - packet for distribution to other panels",
								System.Threading.Thread.CurrentThread.ManagedThreadId));

							handler(this, new PanelDataPacketEventArgs(ref pkt)); 
						}
						break;

					case GCS.PanelProtocols.Series6xx.PacketDistribution.FromPanelToServer:
						break;

				}
			}
			//	if( m_AuthenticateMode == AUTHENTICATED )
			//	{
			//		COleDateTime dt;
			//		BOOL bNotifyCommServiceOfNewConnection = FALSE;
			//		switch( pPkt->pkt.dist )
			//		{
			//			case PACKET_EVENT_SERVER_DIST_PANEL_TO_ALL_PANELS:
			//			case PACKET_EVENT_SERVER_DIST_PANEL_TO_SPECIFIC_PANEL:
			//				packet_event_server*	pDbg;
			//				pDbg = new packet_event_server;
			//				memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//				::PostThreadMessage( m_hCoreThread, UWM_DISTRIBUTE_600_EVENT, (WPARAM)this->m_nThreadID, (LPARAM)pDbg );	
			//				break;

			//			case PACKET_EVENT_SERVER_DIST_PANEL_TO_PC:	// send this up to the GCS_Comm service
			//				BOOL	bSendToSSPIClients = TRUE;

			//				switch( pPkt->pkt.data[0] )
			//				{
			//					case TCP_IP_HEARTBEAT:
			//						if( globals.bPassHeartbeatsToSSPIClients == FALSE )
			//							bSendToSSPIClients = FALSE;
			//						break;

			//					case CARD_NOT_IN_MEMORY_REQUEST:
			//						p = new packet_event_server;
			//						memcpy( p, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//						::PostThreadMessage( m_hCoreThread, UWM_HANDLE_CARD_NOT_IN_MEMORY, (WPARAM)this->m_nThreadID, (LPARAM)p );	
			//						break;

			//					case CARD_HAS_BEEN_READ:
			//						p = new packet_event_server;
			//						memcpy( p, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//						::PostThreadMessage( m_hCoreThread, UWM_HANDLE_CARD_HAS_BEEN_READ, (WPARAM)this->m_nThreadID, (LPARAM)p );	
			//						break;

			//					case CARD_REMOTE_ACCESS_RULE_OVERRIDE:						
			//						p = new packet_event_server;
			//						memcpy( p, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//						::PostThreadMessage( m_hCoreThread, UWM_HANDLE_CARD_REMOTE_ACCESS_RULE_OVERRIDE, (WPARAM)this->m_nThreadID, (LPARAM)p );	
			//						break;

			//					case RESP_UNIT_INQUIRE:
			//						if( m_ControllerInfo.serial_number[0] == 0 )
			//							bNotifyCommServiceOfNewConnection = TRUE;

			//						memcpy(&m_ControllerInfo, pPkt->pkt.data, sizeof(m_ControllerInfo));
			//						m_ConnectionStatus.m_CPU_MODEL	= m_ControllerInfo.cpu_model_number;
			//						m_ConnectionStatus.m_LogsNotAckedCount = m_ControllerInfo.unacked_log_count;
			//						if( bNotifyCommServiceOfNewConnection == TRUE )
			//							NotifyCommServerOfNewConnection(1);

			//						ReportStatus();
			//						break;

			//					case RESP_TOTAL_CARD_COUNT:
			//						memcpy( &m_ConnectionStatus.m_CardCount, &pPkt->pkt.data[1], sizeof( m_CardCount ) );
			//						if( m_ConnectionStatus.m_CardCount < 0 || m_ConnectionStatus.m_CardCount > MAXWORD )
			//							OutputDebugString(_T("Card count looks to be bogus. Possible cold start needed.\n"));
			//						break;

			//					case RESP_GET_LOGGING_INFO:
			//						m_ConnectionStatus.m_LogsNotAckedCount	= MAKEWORD( pPkt->pkt.data[2], pPkt->pkt.data[3] );
			//						m_ConnectionStatus.m_LogsNotSentCount	= MAKEWORD( pPkt->pkt.data[4], pPkt->pkt.data[5] );
			//						if( m_ConnectionStatus.m_LogsNotAckedCount < 0 || m_ConnectionStatus.m_LogsNotAckedCount > 11000 ||
			//							m_ConnectionStatus.m_LogsNotSentCount < 0 || m_ConnectionStatus.m_LogsNotSentCount > 11000)
			//						{
			//							OutputDebugString(_T("Log buffer counts appear to be bogus. Possible cold start needed.\n"));
			//						}
			//						break;

			//					case LOG_MESSAGE:
			//						if( m_ControllerInfo.code == RESP_UNIT_INQUIRE && m_ControllerInfo.jumbo_card_format != 0 )
			//						{
			//							bSendToSSPIClients = FALSE;
			//							switch( pPkt->pkt.data[3])
			//							{
			//								case NOT_IN_SYS:
			//								case NOT_IN_SYS_REV:
			//								case PIV_CARD_EXPIRED:
			//								case INVALID_ATTEMPT_X:
			//								case VALID_ACCESS_X:
			//								case DURESS_X:
			//								case PASSBACK_VIOLATION_X:
			//								case BAD_PIN_X:
			//								case MANUAL_ARM_X:
			//								case MANUAL_DISARM_X:
			//								case ACCESS_DENIED_KEYS_X:	// added with key control features
			//								case VALID_ACCESS_W_PIN_DATA:	// VALID ACCESS WITH PIN INFO (2 bytes at the end) - Flash Version 1.12 and higher
			//								case OTIS_AUDIT_DATA:
			//								case CARD_TOUR_STARTING:
			//								case CARD_TOUR_CONTINUING:
			//								case CARD_TOUR_COMPLETED:
			//								case CARD_TOUR_OVERDUE:
			//								case CARD_TOUR_INCORRECT_START_READER:
			//								case CARD_TOUR_NON_EXISTENT_TOUR:
			//									log_event_600 logStart;
			//									memcpy(&logStart, &pPkt->pkt.data[3], sizeof( logStart));
			//									dt.SetDateTime(COleDateTime::GetCurrentTime().GetYear(), logStart.month, logStart.day, logStart.hour, logStart.minute, logStart.second);
			//									if( dt.GetStatus() != COleDateTime::DateTimeStatus::valid )
			//									{
			//										OutputDebugString(_T("Bogus LOG_MESSAGE. Discarding\n"));
			//										bSendToSSPIClients = FALSE;
			//										break;
			//									}
			//									if( m_JumboCard.HandleLogStart(&logStart) == FALSE )
			//										OutputDebugString(_T("HandleLogStart returned false\n"));
			//									break;

			//								case JUMBO_CARD_MID:
			//								case JUMBO_CARD_END:
			//									card_event_code_ex logEx;
			//									memcpy(&logEx, &pPkt->pkt.data[3], sizeof( logEx));
			//									if( m_JumboCard.HandleCardExLog(&logEx) == FALSE )
			//										OutputDebugString(_T("HandleCardExLog returned false\n"));
			//									else
			//									{
			//										if( pPkt->pkt.data[3] == JUMBO_CARD_END)
			//										{
			//											jumbo_log_event jumboEvent;
			//											m_JumboCard.GetJumboLogEvent(&jumboEvent);
			//											packet_event_server*	pDbg = new packet_event_server;
			//											memset(pDbg, 0, sizeof(packet_event_server));
			//											memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//											memcpy( &pDbg->pkt.data[3], &jumboEvent, sizeof( jumboEvent));
			//											pDbg->pkt.length += sizeof(jumboEvent.card_data);
			//											::PostThreadMessage( m_hCoreThread, UWM_SEND_EVENT_SERVER_PACKET_TO_SSPI_CLIENTS, (WPARAM)this->m_nThreadID, (LPARAM)pDbg );				
			//										}
			//									}
			//									break;

			//								default:
			//									log_event_600 logTemp;
			//									memcpy(&logTemp, &pPkt->pkt.data[3], sizeof( logTemp));
			//									dt.SetDateTime(COleDateTime::GetCurrentTime().GetYear(), logTemp.month, logTemp.day, logTemp.hour, logTemp.minute, logTemp.second);
			//									if( dt.GetStatus() != COleDateTime::DateTimeStatus::valid )
			//									{
			//										OutputDebugString(_T("Bogus LOG_MESSAGE. Discarding\n"));
			//										bSendToSSPIClients = FALSE;
			//										break;
			//									}
			//									bSendToSSPIClients = TRUE;
			//									break;
			//							}
			//						}
			//						else if( m_ControllerInfo.code == RESP_UNIT_INQUIRE && m_ControllerInfo.jumbo_card_format == 0 )
			//						{
			//							switch( pPkt->pkt.data[3])
			//							{
			//								case NOT_IN_SYS:
			//								case NOT_IN_SYS_REV:
			//								case PIV_CARD_EXPIRED:
			//								case INVALID_ATTEMPT_X:
			//								case VALID_ACCESS_X:
			//								case DURESS_X:
			//								case PASSBACK_VIOLATION_X:
			//								case BAD_PIN_X:
			//								case MANUAL_ARM_X:
			//								case MANUAL_DISARM_X:
			//								case ACCESS_DENIED_KEYS_X:	// added with key control features
			//								case VALID_ACCESS_W_PIN_DATA:	// VALID ACCESS WITH PIN INFO (2 bytes at the end) - Flash Version 1.12 and higher
			//								case OTIS_AUDIT_DATA:
			//								case CARD_TOUR_STARTING:
			//								case CARD_TOUR_CONTINUING:
			//								case CARD_TOUR_COMPLETED:
			//								case CARD_TOUR_OVERDUE:
			//								case CARD_TOUR_INCORRECT_START_READER:
			//								case CARD_TOUR_NON_EXISTENT_TOUR:
			//									log_event_600 logStart;
			//									memcpy(&logStart, &pPkt->pkt.data[3], sizeof( logStart));
			//									dt.SetDateTime(COleDateTime::GetCurrentTime().GetYear(), logStart.month, logStart.day, logStart.hour, logStart.minute, logStart.second);
			//									if( dt.GetStatus() != COleDateTime::DateTimeStatus::valid )
			//									{
			//										OutputDebugString(_T("Bogus LOG_MESSAGE. Discarding\n"));
			//										bSendToSSPIClients = FALSE;
			//										break;
			//									}

			//									if( m_JumboCard.HandleLogStart(&logStart) == FALSE )
			//										OutputDebugString(_T("HandleLogStart returned false\n"));
			//									else
			//									{
			//										bSendToSSPIClients = FALSE;
			//										jumbo_log_event jumboEvent;
			//										m_JumboCard.GetJumboLogEvent(&jumboEvent);
			//										packet_event_server*	pDbg = new packet_event_server;
			//										memset(pDbg, 0, sizeof(packet_event_server));
			//										memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//										memcpy( &pDbg->pkt.data[3], &jumboEvent, sizeof( jumboEvent));
			//										pDbg->pkt.length += sizeof(jumboEvent.card_data);
			//										::PostThreadMessage( m_hCoreThread, UWM_SEND_EVENT_SERVER_PACKET_TO_SSPI_CLIENTS, (WPARAM)this->m_nThreadID, (LPARAM)pDbg );				
			//									}
			//									break;

			//								case JUMBO_CARD_MID:
			//								case JUMBO_CARD_END:
			//									bSendToSSPIClients = FALSE;
			//									break;

			//								default:
			//									log_event_600 logTemp;
			//									memcpy(&logTemp, &pPkt->pkt.data[3], sizeof( logTemp));
			//									dt.SetDateTime(COleDateTime::GetCurrentTime().GetYear(), logTemp.month, logTemp.day, logTemp.hour, logTemp.minute, logTemp.second);
			//									if( dt.GetStatus() != COleDateTime::DateTimeStatus::valid )
			//									{
			//										OutputDebugString(_T("Bogus LOG_MESSAGE. Discarding\n"));
			//										bSendToSSPIClients = FALSE;
			//										break;
			//									}
			//									break;
			//							}
			//						}
			//						break;

			//					//case RESP_ACK_500:
			//					//case RESP_NACK_500:
			//						//if( pPkt->pkt.data[1] == TCP_IP_HEARTBEAT )
			//						//	break;	// only if this is a heartbeat, do I break and not notify the clients

			//					default:
			//						break;
			//				}
			//				if( bSendToSSPIClients == TRUE )
			//				{
			//					packet_event_server*	pDbg = new packet_event_server;
			//					memset( pDbg, 0, sizeof( packet_event_server) );
			//					memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//					::PostThreadMessage( m_hCoreThread, UWM_SEND_EVENT_SERVER_PACKET_TO_SSPI_CLIENTS, (WPARAM)this->m_nThreadID, (LPARAM)pDbg );				
			//				}
			//				break;
			//		}

			//		switch( pPkt->pkt.data[0] )
			//		{
			//			case EVENT_AREA_500:
			//				if( globals.bRecordAreaPackets)
			//				{
			//					packet_event_server*	p1 = new packet_event_server;
			//					memcpy( p1, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//					::PostThreadMessage( m_hCoreThread, UWM_RECORD_AREA_EVENT_RECEIVED, 0, (LPARAM)p1 );
			//				}

			//				///*************************************************************************
			//				// *                                                                       *
			//				// *   Process Area Event Messages (called by TASK4)                       *
			//				// *                                                                       *
			//				// *      str format:                                                      *
			//				// *            str[0] - str[5] = card code                                *
			//				// *            str[6] = area entered (if any, 255 means none)             *
			//				// *            str[7] = passback forgive code                             *
			//				// *************************************************************************/
			//				//void AreaEventProcess(unsigned char* str)
			//				//{
			//				//	static struct USER_SAV slot;
			//				//	if(UserFind( &slot, &str[0] ) )
			//				//	{          // if this user is in our database
			//				//		if( str[6] != 255)
			//				//		{                             /* if an area was entered */
			//				//			slot.ptr->common.area = str[6];              /* copy in new area code */
			//				//			slot.ptr->common.flags[1] &= ~7;
			//				//			slot.ptr->common.flags[1] |= str[7] & 7;     /* copy in new passback forgive code */
			//				//		}
			//				//		if( slot.ptr->common.expire == 0 ) return;         /* only if expire counter is != 0 */
			//				//		if( slot.ptr->common.flags[1] & 0x20 )  return;    /* only if swiped limited card (not date limited) */
			//				//		if(str[7] & 0x80)   return;                 /* only if expire is #swipes is not supressed on this door */
			//				//		slot.ptr->common.expire--;       /* then decrement it */
			//				//		if( !slot.ptr->common.expire )   /* if it now becomes zero */
			//				//			slot.ptr->common.flags[0] &= ~0x20;   /* then disable the card */
			//				//	} // if(UserFind(&slot, &str[0]))



			//				break;

			//			default:
			//				break;
			//		}
			//	}

			//	if( m_hDebugWnd )
			//	{
			//		switch( pPkt->pkt.data[0] )
			//		{
			//			case TCP_IP_HEARTBEAT:
			//				if( globals.bShowHeartbeatsInDebugWindow == FALSE )
			//					break;

			//			case RESP_ACK_500:
			//			case RESP_NACK_500:
			//				if( pPkt->pkt.data[1] == TCP_IP_HEARTBEAT )
			//					if( globals.bShowHeartbeatsInDebugWindow == FALSE )
			//						break;	// only if this is a heartbeat, do I break and not notify the clients

			//			default:
			//	//			if( ::IsWindow( m_hDebugWnd ) )
			//				{
			//					packet_event_server*	pDbg = new packet_event_server;
			//					memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
			//					::PostMessage( m_hDebugWnd, UWM_PROCESS_600_PACKET, 0, (LPARAM)pDbg );
			//				}
			//				break;
			//		}
			//	}
			//	return true;
			//}
			return true;

		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Callback, called when the timer. </summary>
		///
		/// <param name="state">	The state. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void TimerCallback(object state)
		{
			if (IsAuthenticated == false)
			{
				System.Diagnostics.Trace.WriteLine(string.Format("{0}, Cluster:{1}, Panel:{2}, CPU:{3} - TimerCallback called before Authenticated", DateTimeOffset.Now.ToLongTimeString(), ClusterId, PanelId, CpuId, (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount)));
				return;
			}

			if(System.Environment.TickCount < this.lastSendTickCount ||
				(System.Environment.TickCount - this.lastSendTickCount) > 14000)
				SendHeartbeat();

			if (System.Environment.TickCount < this.lastHeartbeatReceivedTickCount)
				this.lastHeartbeatReceivedTickCount = System.Environment.TickCount;

			int ticksSinceLastHeartbeatReceived = (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount);
			if (ticksSinceLastHeartbeatReceived > 17000)
			{
				System.Diagnostics.Trace.WriteLine(string.Format("{0}, Cluster:{1}, Panel:{2}, CPU:{3} - lastHeartbeat received {4} ms ago", DateTimeOffset.Now.ToLongTimeString(), ClusterId, PanelId, CpuId, (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount)));
			}

			if (ticksSinceLastHeartbeatReceived > 20000)
			{
				System.Diagnostics.Trace.WriteLine(string.Format("{0}, Cluster:{1}, Panel:{2}, CPU:{3} - closing connection, last heartbeat received {4} ms ago", DateTimeOffset.Now.ToLongTimeString(), ClusterId, PanelId, CpuId, (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount)));
				this.owner.DisconnectClient(this);
				timer.Dispose();
			}

			return;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Gets new packet to send. </summary>
		///
		/// <returns>	The new packet to send. </returns>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private DataPacket6xx GetNewPacketToSend()
		{
			DataPacket6xx p = new DataPacket6xx(transmitSequence++);
			p.ClusterId = clusterID;
			p.PanelId = unitID;
			p.Cpu = cpuID;

			return p;
		}

		/// <summary>	Sends the heartbeat. </summary>
		private void SendHeartbeat()
		{
			DataPacket6xx p = GetNewPacketToSend();
			Heatbeat c = new Heatbeat();

			c.Cmd = (byte)PacketDataCode6xx.CpuHeartbeat;

			p.FillData(c);
			p.PrepareForTransmission(false, true);
			switch (receiver.CryptoType)
			{
				case PanelProtocols.CryptoType.Aes:
					p.Encrypt(receiver.AesEncryptionKey);
					break;

				case PanelProtocols.CryptoType.None:
					break;
			}
			byte[] msgToSend = p.GetBytes();
			System.Diagnostics.Trace.WriteLine(string.Format("{0} - Sending heartbeat", DateTimeOffset.Now.ToLongTimeString()));
			Send(msgToSend);
		}

		/// <summary>	Sends the sign on challenge. </summary>
		private void SendSignOnChallenge()
		{
			DataPacket6xx p = GetNewPacketToSend();
			SignOnChallenge c = new SignOnChallenge();
			System.Random rand = new System.Random();

			DateTimeOffset now = DateTimeOffset.Now;

			c.Cmd = (byte)PacketDataCode6xx.CommandSignOnChallenge;
			c.Year = (ushort)now.Year;
			c.Month = (ushort)now.Month;
			c.Day = (ushort)now.Day;
			c.Hour = (ushort)now.Hour;
			c.Minute = (ushort)now.Minute;
			c.Second = (ushort)now.Second;
			c.Random = (ushort)rand.Next();
			c.Sum = (Byte)(c.Cmd +
						c.Year +
						c.Month +
						c.Day +
						c.Hour +
						c.Minute +
						c.Second +
						c.Random);

			p.FillData(c);//, Marshal.SizeOf(c));
			p.PrepareForTransmission(false, true);
			switch(receiver.CryptoType)
			{
				case PanelProtocols.CryptoType.Aes:
					p.Encrypt(receiver.AesEncryptionKey);
					break;

				case PanelProtocols.CryptoType.None:
					break;
			}
			byte[] msgToSend = p.GetBytes();
			System.Diagnostics.Trace.WriteLine("Connection6xx constructor. Setting signOnState = SignOnState.SentSignOnChallange");
			signOnState = SignOnState.SentSignOnChallange;
			Send(msgToSend);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Accept sign on challenge response. </summary>
		///
		/// <param name="pkt">	[in,out] The packet. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void AcceptSignOnChallengeResponse(ref DataPacket6xx pkt)
		{
			clusterID	= pkt.ClusterId;
			unitID	= pkt.PanelId;
			cpuID 	= pkt.Cpu;

			System.Diagnostics.Trace.WriteLine("Connection6xx constructor. Setting signOnState = SignOnState.SentDateTimeSync");
			signOnState = SignOnState.SentDateTimeSync;
			LoadDateTime();
		//	NotifyCommServerOfNewConnection();
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Handles the set date time challenge described by pkt. </summary>
		///
		/// <param name="pkt">	[in,out] The packet. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void HandleSetDateTimeChallenge(ref DataPacket6xx pkt)
		{
			DataPacket6xx p = GetNewPacketToSend();
			p.When = pkt.When;
			SetPanelDateTime data = new SetPanelDateTime();
			DateTimeOffset now = DateTimeOffset.Now;

			UInt32 offset = 0;

			data.Cmd = (byte)PacketDataCode6xx.CommandSetDateTime;
			data.hour = (byte)now.Hour;			// 0-23
			data.minute = (byte)now.Minute;		// 0-59
			data.second = (byte)now.Second;		// 0-59
			data.month = (byte)now.Month;			// 1-12
			data.day = (byte)now.Day;			// 1-31
			data.year = (byte)(now.Year % 100);	// year - 1900 
			data.century = (byte)(now.Year / 100);	// century
			data.seconds_from_universal_time = offset;

			p.FillData(data);//, Marshal.SizeOf(c));

			p.PrepareForTransmission(false, false);
			switch (receiver.CryptoType)
			{
				case PanelProtocols.CryptoType.Aes:
					p.Encrypt(receiver.AesEncryptionKey);
					break;

				case PanelProtocols.CryptoType.None:
					break;
			}
			byte[] msgToSend = p.GetBytes();
			Send(msgToSend);
		}

		/// <summary>	Loads date time. </summary>
		private void LoadDateTime()
		{
			DataPacket6xx p = GetNewPacketToSend();
			SetPanelDateTime data = new SetPanelDateTime();
			DateTimeOffset now = DateTimeOffset.Now;

			UInt32 offset = 0;
 
			data.Cmd = (byte)PacketDataCode6xx.CommandSetDateTime;
			data.hour = (byte)now.Hour;			// 0-23
			data.minute = (byte)now.Minute;		// 0-59
			data.second = (byte)now.Second;		// 0-59
			data.month = (byte)now.Month;			// 1-12
			data.day = (byte)now.Day;			// 1-31
			data.year = (byte)(now.Year % 100);	// year - 1900 
			data.century = (byte)(now.Year / 100);	// century
			data.seconds_from_universal_time = offset;

			p.FillData(data);//, Marshal.SizeOf(c));
			p.PrepareForTransmission(false, true);
			switch (receiver.CryptoType)
			{
				case PanelProtocols.CryptoType.Aes:
					p.Encrypt(receiver.AesEncryptionKey);
					break;

				case PanelProtocols.CryptoType.None:
					break;
			}
			byte[] msgToSend = p.GetBytes();
			Send(msgToSend);
		
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Sets logging state. </summary>
		///
		/// <param name="state">	The state. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void SetLoggingState(ActivityLoggingState state)
		{	
			DataPacket6xx p = GetNewPacketToSend();
			SetLoggingState c = new SetLoggingState();
			System.Random rand = new System.Random();

			DateTimeOffset now = DateTimeOffset.Now;

			c.Cmd = (byte)PacketDataCode6xx.CommandLoggingSetOnOff;
			switch(state)
			{
				case ActivityLoggingState.Off:
					c.State = 0;
					break;

				case ActivityLoggingState.On:
					c.State = 1;
					break;
			}

			p.FillData(c);//, Marshal.SizeOf(c));
			p.PrepareForTransmission(false, true);
			switch(receiver.CryptoType)
			{
				case PanelProtocols.CryptoType.Aes:
					p.Encrypt(receiver.AesEncryptionKey);
					break;

				case PanelProtocols.CryptoType.None:
					break;
			}
			byte[] msgToSend = p.GetBytes();
			Send(msgToSend);		
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Sends a single byte command. </summary>
		///
		/// <param name="cmd">	The command. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void SendSingleByteCommand(PacketDataCode6xx cmd)
		{
			DataPacket6xx p = GetNewPacketToSend();
			SingleByteCommand c = new SingleByteCommand();
			c.Cmd = (Byte)cmd;
			p.FillData(c);//, Marshal.SizeOf(c));
			p.PrepareForTransmission(false, true);
			switch (receiver.CryptoType)
			{
				case PanelProtocols.CryptoType.Aes:
					p.Encrypt(receiver.AesEncryptionKey);
					break;

				case PanelProtocols.CryptoType.None:
					break;
			}
			byte[] msgToSend = p.GetBytes();
			Send(msgToSend);				

		}

		/// <summary>	Sends the get logging information. </summary>
		private void SendGetLoggingInfo()
		{
			SendSingleByteCommand(PacketDataCode6xx.CommandRequestLoggingInformation);
		}

		/// <summary>	Sends the get card count. </summary>
		private void SendGetCardCount()
		{
			SendSingleByteCommand(PacketDataCode6xx.CommandRequestTotalCardCount);
		}

		/// <summary>	Sends the get controller information. </summary>
		private void SendGetControllerInfo()
		{
			SendSingleByteCommand(PacketDataCode6xx.CommandPanelInquire);
		}
		#endregion

	}
}
