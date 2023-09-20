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
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class TimeScheduleDayTypeTimePeriodReq
    {
        public System.Guid TimeScheduleDayTypeTimePeriodUid { get; set; }

        [Required]
        public System.Guid DayTypeUid { get; set; }
        
        [Required]
        public System.Guid TimePeriodUid { get; set; }

        [Required]
        public System.Guid TimeScheduleUid { get; set; }

    }
}
