////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\WindowsUserIdentity.cs
//
// summary:	Implements the windows user identity class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Principal;
using GCS.Core.Common.Contracts;
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
    public class WindowsUserIdentity //: EntityBase
    {
        public WindowsUserIdentity()
        {
            Name = string.Empty;
            DomainName = string.Empty;
        }

        public WindowsUserIdentity(WindowsUserIdentity o)
        {
            Name = string.Empty;
            DomainName = string.Empty;
            if( o != null)
            {
                Name = o.Name;
                DomainName = o.DomainName;
                AuthenticationType = o.AuthenticationType;
                IsAuthenticated = o.IsAuthenticated;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string AuthenticationType { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAuthenticated { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DomainName { get; set; }
    }
}
