////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\TimeScheduleDayTypeTimePeriod.cs
//
// summary:	Implements the time schedule day type time period class
////////////////////////////////////////////////////////////////////////////////////////////////////

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
    public partial class TimeScheduleDayTypeTimePeriodBasic : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid TimeScheduleDayTypeTimePeriodUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid DayTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid TimePeriodUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid TimeScheduleUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public DayTypeBasic DayType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public TimePeriodBasic TimePeriod { get; set; }

    }
}
