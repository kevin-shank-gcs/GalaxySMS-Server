using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GCS.PanelProtocols.Series6xx;
using GCS.Security;

namespace GCS.PanelProtocols
{
	public class SenderReceiver6xx
	{
        private IDataPacket6xx packet;
		private byte[] rawBytes;
		private UInt32 index;
		private UInt16 length;
		private byte[] sessionKey;
		private GCS.PanelProtocols.CryptoType cryptoType = PanelProtocols.CryptoType.None;
		private string aesEncryptionPhrase = string.Empty;

		public SenderReceiver6xx()
		{
			cryptoType = CryptoType.None;
			aesEncryptionPhrase = string.Empty;
		    SohValue = (uint)SohCode.UInt8ClusterAndPanelIds; // default to the original 8 bit cluster & unit # format
			Init();
		}

		public SenderReceiver6xx(GCS.PanelProtocols.CryptoType cryptoType, String phrase)
		{

			this.cryptoType = cryptoType;
			aesEncryptionPhrase = phrase;
		    SohValue = (uint)SohCode.UInt8ClusterAndPanelIds; // default to the original 8 bit cluster & unit # format
			if (cryptoType == PanelProtocols.CryptoType.Aes)
			{
				InitializeAesEncryption(aesEncryptionPhrase);
			} 
			
			Init();
		}		
		
		public void Init()
		{
		    packet = new DataPacket6xx((SohCode)this.SohValue);

		    //rawBytes = new byte[ Marshal.SizeOf(packet) ];
		    rawBytes = new byte[ Marshal.SizeOf(packet.ExtendedPacket) ];
			index = 0;
			length = 0;
		}

		private void InitializeAesEncryption(String phrase)
		{
			sessionKey = ShaHash.CreateSHAHash(false, AesCrypto.KEY_SIZE, phrase, ShaHash.TextEncoding.ASCII);
		}

		public bool ReceiveByte(byte b)
		{
			if (index == 0 || index >= rawBytes.Length)
			{
				Init();
			}

			rawBytes[index++] = b;
			switch (index)
			{
				case sizeof(UInt32):
                    var v = BitConverter.ToUInt32(rawBytes, 0);
				    if ( v != (uint)SohCode.UInt8ClusterAndPanelIds && v != (uint)SohCode.UInt16ClusterAndPanelIds)
						index--;
                    else
                        SohValue = v;
					break;

			    case (uint)HeaderSize.UInt8ClusterAndPanelIds:
			        if( SohValue == (uint)SohCode.UInt8ClusterAndPanelIds)
			            length = (ushort)(BitConverter.ToUInt32(rawBytes, 4) + sizeof(UInt32) + sizeof(UInt16));
			        break;

			    case (uint)HeaderSize.UInt16ClusterAndPanelIds:
			        if( SohValue == (uint)SohCode.UInt16ClusterAndPanelIds)
			            length = (ushort)(BitConverter.ToUInt32(rawBytes, 4) + sizeof(UInt32) + sizeof(UInt16) + sizeof(byte) + sizeof(UInt16));
			        break;

				default:
					if (index == length)
					{	// we have now received the entire message
						GCHandle handle = GCHandle.Alloc(rawBytes, GCHandleType.Pinned);
						IntPtr iPtr = handle.AddrOfPinnedObject();
                        
					    if( SohValue == (uint)SohCode.UInt16ClusterAndPanelIds)
                        {
//                            var packetX = (sDataPacket6xxExtended)Marshal.PtrToStructure(iPtr, packetType);
                            var extendedPacket = (sDataPacket6xxExtended)Marshal.PtrToStructure(iPtr, typeof(sDataPacket6xxExtended));
                            packet = new DataPacket6xx(SohCode.UInt16ClusterAndPanelIds, extendedPacket);
                        }
                        else if(SohValue == (uint)SohCode.UInt8ClusterAndPanelIds)
                        {
//						    packet = (sDataPacket6xx)Marshal.PtrToStructure(iPtr, packetType);
                            var standardPacket = (sDataPacket6xx)Marshal.PtrToStructure(iPtr, typeof(sDataPacket6xx));
                            packet = new DataPacket6xx(SohCode.UInt8ClusterAndPanelIds,standardPacket);
                        }

						handle.Free();

						if (packet.IsHeaderValid == true)
						{
							switch (cryptoType)
							{
								case PanelProtocols.CryptoType.Aes:
									packet.Decrypt(sessionKey);
									break;

								case PanelProtocols.CryptoType.None:
									break;
							}
						}

						// The data buffer should always be on a 16 byte boundary.
						// trim the excess unused bytes at the end of the data array. The data length should be 16 bytes less than the packet.Length because 
						// the header bytes are included in this length. Therefore, we can subtract 16 bytes and then add 4 back in for the CRC which is appended
						// to the end of the real 16 byte data block. 
						int dataLength = packet.Length;// +16;

						int remainder = dataLength % 16;
						if (remainder != 0)
						{
							dataLength += (16 - remainder);
							if (dataLength > 32)
								dataLength -= 16;
						}

						if (dataLength > 16)
							dataLength -= 12;		// take away 12, not 16. This allows room for the 4 byte CRC which should appear at the end of the data
						//Array.Resize<Byte>(ref packet.Data, dataLength);
                        packet.ResizeData(dataLength);
						return true;
					}
					break;
			}

			return false;
		}

		public IDataPacket6xx Packet {
			get
			{
				return packet;
			}
		}

		public GCS.PanelProtocols.CryptoType CryptoType
		{
			get { return cryptoType; }
		}

		public byte[] AesEncryptionKey
		{
			get { return sessionKey; }
		}

	    public uint SohValue { get; internal set; }
	}
}
