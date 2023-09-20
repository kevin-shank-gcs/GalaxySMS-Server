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
    public partial class UserPasswordResetInformation
    {
        public UserPasswordResetInformation()
        {
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid UserId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PrimaryEntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ResetPasswordFlag { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? LastPasswordResetDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PasswordResetToken { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? PasswordResetTokenExpiration { get; set; }
    }
}
