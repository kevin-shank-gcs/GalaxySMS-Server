using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
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

    public class Panel5xxRoute : EntityBase
	{
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 ClusterId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 FromPanelId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 ToPanelId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 FromPortBoard { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 ToPortBoard { get; set; }
	}
}
