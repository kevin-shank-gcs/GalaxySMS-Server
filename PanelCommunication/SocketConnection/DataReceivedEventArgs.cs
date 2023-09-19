using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCS.PanelCommunication.SocketServer
{
	public class DataReceivedEventArgs : EventArgs
	{
		public byte[] Data { get; set; }

		public DataReceivedEventArgs(ref byte[] data, Int32 len)
		{
			Data = new byte[len];
			Array.Copy(data, 0, Data, 0, len);
		}
	}
}
