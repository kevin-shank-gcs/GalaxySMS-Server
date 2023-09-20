
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class TimeSchedule
    {
        public TimeSchedule()
        {
            Initialize();
        }

        public TimeSchedule(TimeSchedule e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.TimeScheduleDayTypesTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriod>();
            this.TimeScheduleDayTypesGalaxyTimePeriods = new HashSet<TimeScheduleDayTypeGalaxyTimePeriod>();

            this.DayTypesTimePeriods = new HashSet<DayTypeTimePeriods>();

    }

    public void Initialize(TimeSchedule e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.EntityId = e.EntityId;
            this.Display = e.Display;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Description = e.Description;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            if (e.TimeScheduleDayTypesTimePeriods != null)
                this.TimeScheduleDayTypesTimePeriods = e.TimeScheduleDayTypesTimePeriods.ToCollection();
            if (e.TimeScheduleDayTypesGalaxyTimePeriods != null)
                this.TimeScheduleDayTypesGalaxyTimePeriods = e.TimeScheduleDayTypesGalaxyTimePeriods.ToCollection();
            if (e.DayTypesTimePeriods != null)
                this.DayTypesTimePeriods = e.DayTypesTimePeriods.ToCollection();
        }

        public TimeSchedule Clone(TimeSchedule e)
        {
            return new TimeSchedule(e);
        }

        public bool Equals(TimeSchedule other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeSchedule other)
        {
            if (other == null)
                return false;

            if (other.TimeScheduleUid != this.TimeScheduleUid)
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
