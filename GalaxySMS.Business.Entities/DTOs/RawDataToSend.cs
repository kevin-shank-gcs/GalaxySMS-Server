using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public class RawDataToSend : EntityBase
	{
		public RawDataToSend()
		{
			Address = new BoardSectionNodeHardwareAddress();
			Route5xx = new Panel5xxRoute();
		}

		[DataMember]

		public CpuModel CpuModel { get; set; }
		[DataMember]
		public BoardSectionNodeHardwareAddress Address { get; set; }

		[DataMember]
		public Panel5xxRoute Route5xx { get; set; }

		[DataMember]
		public Byte[] Data { get; set; }

		[DataMember]
		public String StringData { get; set; }

	}
}
