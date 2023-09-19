using System;
using System.Collections.Generic;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class DayTypeBasic
    {

        public DayTypeBasic()
        {
            Initialize();
        }

        public DayTypeBasic(DayTypeBasic e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.Dates = new HashSet<DateTypeBasic>();
            this.DayTypeFifteenMinuteTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriodBasic>();
            //this.DayTypeOneMinuteTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriod>();
            //this.EntityIds = new HashSet<Guid>();
            //this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(DayTypeBasic e)
        {
            Initialize();
            if (e == null)
                return;
            this.DayTypeUid = e.DayTypeUid;
            this.EntityId = e.EntityId;
            this.Name = e.Name;
            this.Notes = e.Notes;
            this.HighlightColor = e.HighlightColor;
            this.DayTypeCode = e.DayTypeCode;
            this.IsActive = e.IsActive;
            this.Dates = e.Dates.ToCollection();
            this.DayTypeFifteenMinuteTimePeriods = e.DayTypeFifteenMinuteTimePeriods.ToCollection();
            //this.DayTypeOneMinuteTimePeriods = e.DayTypeOneMinuteTimePeriods.ToCollection();

            //if (e.EntityIds != null)
            //    this.EntityIds = e.EntityIds.ToCollection();
            //if (e.MappedEntitiesPermissionLevels != null)
            //    this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
        }

        public DayTypeBasic Clone(DayTypeBasic e)
        {
            return new DayTypeBasic(e);
        }

        public bool Equals(DayTypeBasic other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DayTypeBasic other)
        {
            if (other == null)
                return false;

            if (other.DayTypeUid != this.DayTypeUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
