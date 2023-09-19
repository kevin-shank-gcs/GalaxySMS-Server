using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GCS.PanelProtocols.Series5xx;

namespace GCS.PanelProtocols
{
	public class SenderReceiver5xx
	{
		private DataPacket5xx packet;
		private byte[] rawBytes;
		private UInt32 index;
		private UInt16 lengthRemaining;

		const UInt16 MessageOverhead = 5;	// sizeof(DataPacket5xx.Length) + sizeof(DataPacket5xx.Route)
		
		public SenderReceiver5xx()
		{
			Init();
		}
		
		public void Init()
		{
			packet = new DataPacket5xx();
			rawBytes = new byte[ Marshal.SizeOf(packet) ];
			index = 0;
			lengthRemaining = 0;
		}

		public bool ReceiveByte(byte b)
		{
			if (index == 0 )
			{	// the first byte in the packet specifies the length
				Init();
				rawBytes[index++] = b;
				lengthRemaining = (ushort)((ushort)b + (ushort)MessageOverhead - (ushort)1);
				return false;
			}

			rawBytes[index++] = b;
			if (--lengthRemaining == 0)
			{
				GCHandle handle = GCHandle.Alloc(rawBytes, GCHandleType.Pinned);
				IntPtr iPtr = handle.AddrOfPinnedObject();
				Type packetType = typeof(DataPacket5xx);
				packet = (DataPacket5xx)Marshal.PtrToStructure(iPtr, packetType);
				handle.Free();

				index = 0;	
				return true;	// MESSAGE AVAILABLE
			}
			return false;
		}

		public DataPacket5xx Packet
		{
			get
			{
				return packet;
			}
		}
	}
}
