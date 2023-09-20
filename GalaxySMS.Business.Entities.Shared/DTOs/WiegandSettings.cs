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

    public partial class WiegandSettings : ObjectBase
	{
		public WiegandSettings()
		{
			Start = 0;
			End = 255;
		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short Start { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public short End { get; set; }
	}
}
