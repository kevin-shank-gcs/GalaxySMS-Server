using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public class OtisDecIpAddress : EntityBase
	{
		[DataMember]
		public Byte Octet3 { get; set; }

		[DataMember]
		public Byte Octet4 { get; set; }

		public override string ToString()
		{
			return string.Format("192.168.{0}.{1}", Octet3, Octet4);
		}
	}
}
