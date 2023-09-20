//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
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
    public partial class PersonPersonalAccessGroupBasic : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PersonClusterPermissionUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid TimeScheduleUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PersonalAccessGroupNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public PersonClusterPermission PersonClusterPermission { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> AccessPortalUids { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> DynamicAccessGroupUids { get; set; }

    }
}
