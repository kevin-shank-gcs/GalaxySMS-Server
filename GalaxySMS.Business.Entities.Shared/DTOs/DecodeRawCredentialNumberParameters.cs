using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
	public class DecodeCredentialNumberParameters : EntityBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public short BitCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid { get; set; }
    }


}
