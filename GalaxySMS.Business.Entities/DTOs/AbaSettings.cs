using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public partial class AbaSettings : ObjectBase
    {
		public AbaSettings()
		{
			Start = 1;
			End = 60;
			Folding = AbaFold.Off;
			Clipping = AbaClip.None;
		}

		[DataMember]
		public short Start { get; set; }

		[DataMember]
		public short End { get; set; }

		[DataMember]
		public AbaFold Folding { get; set; }

		[DataMember]
		public AbaClip Clipping { get; set; }
	}
}
