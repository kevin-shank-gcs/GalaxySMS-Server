using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

	public class Panel5xxDataPacket : Panel5xxRoute
	{
		private Byte[] data;
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 Length { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PacketDataType DataType { get { return (PacketDataType)Data[0]; } }
#if NetCoreApi
#else
        [DataMember]
#endif
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
