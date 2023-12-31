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
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GCS.Core.Common.Extensions;

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
    public partial class InputOutputGroupMinimal //: EntityBaseSimple
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid InputOutputGroupUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid ClusterUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid TimeScheduleUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid EntityId { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
        public int IOGroupNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool LocalIOGroup { get; set; }

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
        public ICollection<InputOutputGroupAssignmentBasic> InputOutputGroupAssignments { get; set; }

        public ICollection<InputOutputGroupAssignmentBasic> AvailableInputOutputGroupAssignments { get => InputOutputGroupAssignments.Where(o=>o.IsAvailable == true).ToCollection(); }

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
//        public ICollection<InputOutputGroupCommandBasic> Commands { get; set; }

    }
}
