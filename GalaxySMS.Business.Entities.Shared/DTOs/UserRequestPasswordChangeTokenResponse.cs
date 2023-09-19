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
    public partial class UserRequestPasswordChangeTokenResponse
    {
        public UserRequestPasswordChangeTokenResponse()
        {
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Token { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset TokenExpiration { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool UnknownUser { get; set; }
    }
}
