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

    public partial class gcsApplicationRoleBasic
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid RoleId { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid ApplicationId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RoleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RoleDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsDefault { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAdministratorRole { get; set; }

////#if NetCoreApi
////#else
////        [DataMember]
////#endif
////        public string InsertName { get; set; }

////#if NetCoreApi
////#else
////        [DataMember]
////#endif
////        public System.DateTimeOffset InsertDate { get; set; }

////#if NetCoreApi
////#else
////        [DataMember]
////#endif
////        public string UpdateName { get; set; }

////#if NetCoreApi
////#else
////        [DataMember]
////#endif
////        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

////#if NetCoreApi
////#else
////        [DataMember]
////#endif
////        public Nullable<short> ConcurrencyValue { get; set; }

////#if NetCoreApi
////#else
////        [DataMember]
////#endif
////        public ICollection<gcsEntityApplicationRole> gcsEntityApplicationRoles { get; set; }

////#if NetCoreApi
////#else
////        [DataMember]
////#endif
////        public ICollection<gcsRolePermission> gcsRolePermissions { get; set; }

    }
}
