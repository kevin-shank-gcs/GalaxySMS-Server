//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif

{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
#if NetCoreApi
#else
        [DataContract]
#endif
    public partial class AccessGroupLoadToCpu : EntityBase, IIdentifiableEntity, IEquatable<AccessGroupLoadToCpu>
    {
#if NetCoreApi
#else
        [DataMember]
#endif
    	public System.Guid AccessGroupLoadToCpuUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
    	public System.Guid AccessGroupUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
    	public System.Guid CpuUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
    	public Nullable<System.DateTimeOffset> LastLoadedDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
    	public Nullable<System.DateTimeOffset> LastForceLoadDate { get; set; }
        
    }
}
