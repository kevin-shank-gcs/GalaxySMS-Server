using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

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
    public partial class AbaSettings : ObjectBase
    {
		public AbaSettings()
		{
			Start = 1;
			End = 60;
			Folding = AbaFold.Off;
			Clipping = AbaClip.None;
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
#if NetCoreApi
#else
        [DataMember]
#endif
        public AbaFold Folding { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AbaClip Clipping { get; set; }
	}
}
