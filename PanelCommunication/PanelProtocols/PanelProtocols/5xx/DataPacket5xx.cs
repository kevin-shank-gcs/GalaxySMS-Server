using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelProtocols.Series5xx
{
	public enum PanelNumber : byte {Primary = 0, AllPanels = 255};

	public class PacketConstants
	{
		public const UInt16 DataSize = 256;
		public const UInt16 LengthWithoutData = 5;
	};
	
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Route
	{
		byte rFromPortBoard;
		byte rFromController;
		byte rToPortBoard;
		byte rToController;

		public byte FromPortBoard
		{
			get { return rFromPortBoard; }
			set { rFromPortBoard = value; }
		}
		public byte FromController
		{
			get { return rFromController; }
			set { rFromController = value; }
		}
		public byte ToPortBoard
		{
			get { return rToPortBoard; }
			set { rToPortBoard = value; }
		}
		public byte ToController
		{
			get { return rToController; }
			set { rToController = value; }
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct DataPacket5xx
	{
		public Byte Length;
		public Route Route;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = PacketConstants.DataSize)]
		public Byte[] Data;	// byte 0 is a message type code

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Constructor. </summary>
		///
		/// <param name="bytes">	The bytes. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public DataPacket5xx(Byte[] bytes)
		{
			Length = 0;
			Route = new Series5xx.Route();
			Data = new Byte[PacketConstants.DataSize];

			if (bytes.Length >= PacketConstants.LengthWithoutData &&
				bytes.Length <= (PacketConstants.LengthWithoutData + PacketConstants.DataSize))
			{
				int x = 0;
				Length = bytes[x++];
				Route.FromPortBoard = bytes[x++];
				Route.FromController = bytes[x++];
				Route.ToPortBoard = bytes[x++];
				Route.ToController = bytes[x++];

				int y = 0;

				while (x < bytes.Length)
				{
					Data[y++] = bytes[x++];
				}
			}
		}

		public DataPacket5xx(byte fromController, byte fromPortBoard, byte toController, byte toPortBoard)
		{
			Length = 0;
			Route = new Series5xx.Route();
			Route.FromController = fromController;
			Route.FromPortBoard = fromPortBoard;
			Route.ToController = toController;
			Route.ToPortBoard = toPortBoard;
			Data = new Byte[PacketConstants.DataSize];
		}

		public String GetDataHexString()
		{
			String sDebug = string.Empty;
			for (int x = 0; x < this.Length; x++)
				sDebug += string.Format("{0:x2}", Data[x]);

			return sDebug;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Converts the entire packet to a byte array </summary>
		///
		/// <returns>	The bytes. </returns>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public Byte[] GetBytes()
		{
			Int32 buf_len = Length + PacketConstants.LengthWithoutData;

			Byte[] ba = new Byte[buf_len];
			Int32 x = 0;

			ba[x++] = Length;
			ba[x++] = Route.FromPortBoard;
			ba[x++] = Route.FromController;
			ba[x++] = Route.ToPortBoard;
			ba[x++] = Route.ToController;

			if (Data == null)
				Data = new Byte[PacketConstants.DataSize];
			for (int y = 0; y < Data.Length; y++)
			{
				ba[x++] = Data[y];
				if (x >= buf_len)
					break;
			}
			return ba;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Fill data byte array with the object. This object must be a structure. </summary>
		///
		/// <param name="o">	The object to process. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////
		public void FillData(object o)
		{
			int size = Marshal.SizeOf(o);
			if (size > PacketConstants.DataSize )
				return;

			Data = new Byte[size];
			IntPtr ptr = Marshal.AllocHGlobal(size);

			Marshal.StructureToPtr(o, ptr, true);
			Marshal.Copy(ptr, this.Data, 0, size);
			Marshal.FreeHGlobal(ptr);

			Length = (Byte)size;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Fill data byte array with the object. This object must be a structure. </summary>
		///
		/// <param name="o">	The object to process. </param>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public void FillData(Byte[] data)
		{
			if (data != null)
			{
				Data = new Byte[data.Length];
				if (data.Length <= Data.Length && data.Length <= (Byte.MaxValue - PacketConstants.LengthWithoutData))
				{
					Buffer.BlockCopy(data, 0, Data, 0, data.Length);
					Length = (Byte)(data.Length);
				}
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>	Determines if the object is a valid packet. </summary>
		///
		/// <returns>	true if valid, false if not. </returns>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		public bool IsValid()
		{
			return true;
		}
	}
}
