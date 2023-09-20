using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public class Panel5xxRoute : EntityBase
	{
		[DataMember]
		public Int32 ClusterId { get; set; }
		[DataMember]
		public UInt16 FromPanelId { get; set; }
		[DataMember]
		public UInt16 ToPanelId { get; set; }
		[DataMember]
		public UInt16 FromPortBoard { get; set; }
		[DataMember]
		public UInt16 ToPortBoard { get; set; }
	}
}
