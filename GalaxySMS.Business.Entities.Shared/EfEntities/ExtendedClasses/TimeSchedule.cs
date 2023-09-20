
using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            this.Clusters = new HashSet<ClusterTimeScheduleItem>();
            this.ConcurrencyValue = 0;
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
            if (e.Clusters != null)
                this.Clusters = e.Clusters.ToCollection();

            this.TotalRowCount = e.TotalRowCount;
            this.PanelScheduleNumber = e.PanelScheduleNumber;
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

        public TimeScheduleListItem ToListItem()
        {
            return new TimeScheduleListItem()
            {
                Uid = TimeScheduleUid,
                EntityId = EntityId,
                Name = this.Display,
                //KeyValue = this.TimeScheduleUid.ToString(),
                //Image = null
            };
        }


        // Returns Time Schedule Uid and Name(display)
        public TimeScheduleClusterItem ToTimeScheduleClusterItem()
        {
            return new TimeScheduleClusterItem()
            {
                Id = TimeScheduleUid,
                Name = Display,
                Number = PanelScheduleNumber
            };
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelScheduleNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterTimeScheduleItem> Clusters { get; set; }
    }
}
