using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public partial class ReaderLockoutSettings : ObjectBase
    {
		public ReaderLockoutSettings()
		{
			MaximumInvalidAttempts = 3;
			LockoutTimeInHundredthsOfSeconds = 500;
			CardTourManagerControllerNumber = 0;
		}
		[DataMember]
		public short MaximumInvalidAttempts { get; set; }

		[DataMember]
		public UInt16 LockoutTimeInHundredthsOfSeconds { get; set; }

		[DataMember]
		public Byte CardTourManagerControllerNumber { get; set; }

	}
}
