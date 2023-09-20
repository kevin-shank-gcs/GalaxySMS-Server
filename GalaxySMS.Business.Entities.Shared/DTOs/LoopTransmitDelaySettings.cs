using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

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

    public partial class LoopTransmitDelaySettings : ObjectBase
    {
		public LoopTransmitDelaySettings()
		{
			Delay = 6;
		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 Delay { get; set; }

	}
}
