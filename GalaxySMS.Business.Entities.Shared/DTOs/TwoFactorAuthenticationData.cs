////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\TwoFactorAuthenticationData.cs
//
// summary:	Implements the two factor authentication data class
///=================================================================================================

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

    public class TwoFactorAuthenticationData
    {
#if NetCoreApi
#else
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SessionId { get; set; }
#endif

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TwoFactorToken { get; set; }
    }
}
