using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public partial class LoopTransmitDelaySettings : ObjectBase
    {
		public LoopTransmitDelaySettings()
		{
			Delay = 6;
		}
		[DataMember]
		public UInt16 Delay { get; set; }

	}
}
