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
    public partial class gcsSecurityControl : EntityBase, IIdentifiableEntity, IEquatable<gcsSecurityControl>
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid SecurityControlId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid ApplicationId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PermissionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FormPageName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ControlName { get; set; }

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

    }
}
