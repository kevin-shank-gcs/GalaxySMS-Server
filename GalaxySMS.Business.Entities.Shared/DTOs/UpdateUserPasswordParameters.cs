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
    public partial class UpdateUserPasswordParameters
    {
        public UpdateUserPasswordParameters()
        {
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid UserId { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string EncryptedText { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string CurrentPassword { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string NewPassword { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string Token { get; set; }

    }
}
