using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public partial class CardaxSettings : ObjectBase
	{
		public CardaxSettings()
		{
			Start = 0;
			End = 64;
		}
		[DataMember]
		public short Start;

		[DataMember]
		public short End;
	}
}
