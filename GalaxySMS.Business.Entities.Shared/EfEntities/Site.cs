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
    public partial class Site : EntityBase, IIdentifiableEntity, IEquatable<Site>, IHasAddress, IHasEntityMappingList, IHasRoleMappingList, ITableEntityBase
#if NetCoreApi
#else
, IHasBinaryResource
#endif
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid SiteUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid RegionUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SiteName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> RoleIds { get; set; }

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

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SiteId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> BinaryResourceUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<double> Longitude { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<double> Latitude { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> AddressUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
        public string Name { get { return SiteName; } set { SiteName = value; } }
#endif

#if NetCoreApi
#else
        [DataMember]
#endif
        public gcsBinaryResource gcsBinaryResource { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Address Address { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Region Region { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> EntityIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<Cluster> Clusters { get; set; }
    }
}
