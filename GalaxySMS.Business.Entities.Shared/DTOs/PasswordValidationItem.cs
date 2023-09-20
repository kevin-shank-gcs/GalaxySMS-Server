using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Framework.Security;

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
    public partial class PasswordValidationItem
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public PasswordValidationResult Result { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Message { get; set; }
    }

}
