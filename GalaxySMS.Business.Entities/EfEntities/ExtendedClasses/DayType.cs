using System;
using System.Collections.Generic;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class DayType
    {

        public DayType()
        {
            Initialize();
        }

        public DayType(DayType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.DateTypes = new HashSet<DateType>();
            this.DayTypeFifteenMinuteTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriod>();
            //this.DayTypeOneMinuteTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriod>();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(DayType e)
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
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.DateTypes = e.DateTypes.ToCollection();
            this.DayTypeFifteenMinuteTimePeriods = e.DayTypeFifteenMinuteTimePeriods.ToCollection();
            //this.DayTypeOneMinuteTimePeriods = e.DayTypeOneMinuteTimePeriods.ToCollection();

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
        }

        public DayType Clone(DayType e)
        {
            return new DayType(e);
        }

        public bool Equals(DayType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DayType other)
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
