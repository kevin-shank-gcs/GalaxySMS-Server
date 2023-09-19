using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
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

    public partial class CardaxSettings : ObjectBase
	{
		public CardaxSettings()
		{
			Start = 0;
			End = 64;
		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short Start;
#if NetCoreApi
#else
        [DataMember]
#endif
        public short End;
	}
}
