
using System;
using System.Collections.Generic;
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
	public partial class TimeScheduleBasic
    {
        public TimeScheduleBasic()
        {
            Initialize();
        }

        public TimeScheduleBasic(TimeScheduleBasic e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.TimeScheduleDayTypesTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriodBasic>();
            this.TimeScheduleDayTypesGalaxyTimePeriods = new HashSet<TimeScheduleDayTypeGalaxyTimePeriodBasic>();

            this.DayTypesTimePeriods = new HashSet<DayTypeTimePeriods>();

    }

    public void Initialize(TimeScheduleBasic e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimeScheduleUid = e.TimeScheduleUid;
  //          this.EntityId = e.EntityId;
            this.Display = e.Display;
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

        public TimeScheduleBasic Clone(TimeScheduleBasic e)
        {
            return new TimeScheduleBasic(e);
        }

        public bool Equals(TimeScheduleBasic other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeScheduleBasic other)
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
