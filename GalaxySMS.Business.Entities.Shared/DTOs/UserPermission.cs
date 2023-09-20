////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserPermission.cs
//
// summary:	Implements the user permission class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Security;
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
    public class UserPermission //: EntityBase
    {
        public UserPermission()
        {
            Init();
        }

        public UserPermission(gcsPermission permission)
        {
            Init();
            if (permission != null)
            {
                PermissionId = permission.PermissionId;
                PermissionName = permission.PermissionName;
            }
        }

        private void Init()
        {
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PermissionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PermissionName { get; set; }



    }
}
