////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserRole.cs
//
// summary:	Implements the user role class
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
    public class UserRole //: EntityBase
    {
        public UserRole()
        {
            Init();
        }

        public UserRole(gcsRole role)
        {
            Init();
            if (role != null)
            {
                RoleId = role.RoleId;
                RoleName = role.RoleName;
                IsActive = role.IsActive;
                IsAdministratorRole = role.IsAdministratorRole;
            }
        }


        private void Init()
        {
            UserPermissions = new HashSet<UserPermission>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid RoleId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string RoleName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserPermission> UserPermissions { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAdministratorRole { get; set; }
        
    }
}
