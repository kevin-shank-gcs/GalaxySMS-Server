////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserApplication.cs
//
// summary:	Implements the user application class
///=================================================================================================

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

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
    public class UserApplication //: EntityBase
    {
        public UserApplication()
        {
            Init();
        }

        public UserApplication(gcsApplication application)
        {
            Init();
            if( application != null )
            {
                ApplicationId = application.ApplicationId;
                ApplicationName = application.ApplicationName;
            }
        }


        private void Init()
        {
            UserRoles = new HashSet<UserRole>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ApplicationId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string ApplicationName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserRole> UserRoles { get; set; }
        
    }
}
