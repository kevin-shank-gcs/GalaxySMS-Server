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
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class TimeSchedulePutReq : PutRequestBase
    {
        public System.Guid TimeScheduleUid { get; set; }
        public System.Guid EntityId { get; set; }

        public string Display { get; set; }

        public string Description { get; set; }

        //public ICollection<Guid> EntityIds { get; set; }

        //public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }

        public ICollection<DayTypeTimePeriodsPutReq> DayTypesTimePeriods { get; set; }

        public ICollection<ClusterTimeScheduleItem> Clusters { get; set; }

    }
}
