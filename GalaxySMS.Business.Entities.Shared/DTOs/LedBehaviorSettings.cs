using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using GalaxySMS.Common.Enums;
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

    public partial class LedBehaviorSettings : ObjectBase
    {
		public LedBehaviorSettings()
		{
		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode BothOff;
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode GreenSolid;
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode RedSolid;
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode BothSolid;
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode GreenBlink;
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode GreenBlinkFast;
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode BothBlinkFast;
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode RedBlinkSlow;
	}
}
