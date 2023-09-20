using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GCS.Core.Common.Core;

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

    public partial class ReaderLockoutSettings : ObjectBase
    {
		public ReaderLockoutSettings()
		{
			MaximumInvalidAttempts = 3;
			LockoutTimeInHundredthsOfSeconds = 500;
			CardTourManagerControllerNumber = 0;
		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short MaximumInvalidAttempts { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 LockoutTimeInHundredthsOfSeconds { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte CardTourManagerControllerNumber { get; set; }

	}
}
