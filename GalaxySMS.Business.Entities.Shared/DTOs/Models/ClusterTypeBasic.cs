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
    public partial class ClusterTypeBasic : EntityBaseSimple
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid ClusterTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Display { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<bool> IsDefault { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<bool> IsActive { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<Cluster> Clusters { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<ClusterTypeClusterCommand> ClusterTypeClusterCommands { get; set; }
    }
}
