using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public partial class WiegandSettings : ObjectBase
	{
		public WiegandSettings()
		{
			Start = 0;
			End = 255;
		}
		[DataMember]
		public short Start { get; set; }

		[DataMember]
		public short End { get; set; }
	}
}
