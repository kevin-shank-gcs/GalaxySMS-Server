using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class Panel5xxDataPacket : Panel5xxRoute
	{
		private Byte[] data;

		[DataMember]
		public UInt16 Length { get; set; }

		[DataMember]
		public PacketDataType DataType { get { return (PacketDataType)Data[0]; } }

		[DataMember]
		public Byte[] Data
		{
			get
			{
				return data;
			}
			set{ 
				data = value;
				}
		}

		public void TrimData()
		{
			if (Data != null)
				Array.Resize(ref data, Length );
		}
	}
}
