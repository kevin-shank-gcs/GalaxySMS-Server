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
    public partial class UserRequestPasswordChangeToken
    {
        public UserRequestPasswordChangeToken()
        {
        }


//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public SignInUsing IdentifyUserBy { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SendViaEmail { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SendViaSms { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ChangePasswordResponseUrl { get; set; }
    }
}
