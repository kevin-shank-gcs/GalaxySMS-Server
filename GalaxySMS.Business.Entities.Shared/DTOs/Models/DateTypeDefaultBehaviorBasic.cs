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
    public partial class DateTypeDefaultBehaviorBasic : EntityBaseSimple
    {

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid DateTypeDefaultBehaviorUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid SundayDayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid MondayDayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid TuesdayDayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid WednesdayDayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid ThursdayDayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid FridayDayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid SaturdayDayTypeUid { get; set; }

    }
}
