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
    public partial class CommandScriptBasic //: EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid CommandScriptUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CommandScriptName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Notes { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string InsertName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.DateTimeOffset InsertDate { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string UpdateName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<short> ConcurrencyValue { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//         public gcsEntity gcsEntity { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<Guid> EntityIds { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public AccessPortalGalaxyHardwareAddress GalaxyHardwareAddress { get; set; }

    }
}
