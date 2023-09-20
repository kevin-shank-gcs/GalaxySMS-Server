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
        public partial class AccessProfileCluster : EntityBase, IIdentifiableEntity, IEquatable<AccessProfileCluster>, ITableEntityBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid AccessProfileClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid AccessProfileUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid ClusterUid { get; set; }

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
        //        public AccessProfile AccessProfile { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Cluster Cluster { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessProfileAccessGroup> AccessProfileAccessGroups{ get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessProfileInputOutputGroup> AccessProfileInputOutputGroups{ get; set; }

    }
}
