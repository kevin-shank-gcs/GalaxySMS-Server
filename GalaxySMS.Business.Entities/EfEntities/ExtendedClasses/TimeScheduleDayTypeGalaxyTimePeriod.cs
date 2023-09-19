using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class TimeScheduleDayTypeGalaxyTimePeriod
    {
        public TimeScheduleDayTypeGalaxyTimePeriod()
        {
            Initialize();
        }

        public TimeScheduleDayTypeGalaxyTimePeriod(TimeScheduleDayTypeGalaxyTimePeriod e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(TimeScheduleDayTypeGalaxyTimePeriod e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.TimeScheduleDayTypeGalaxyTimePeriodUid = e.TimeScheduleDayTypeGalaxyTimePeriodUid;
            this.DayTypeUid = e.DayTypeUid;
            this.GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.DayType = e.DayType;
            this.GalaxyTimePeriod = e.GalaxyTimePeriod;
        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public TimeScheduleDayTypeGalaxyTimePeriod Clone(TimeScheduleDayTypeGalaxyTimePeriod e)
        {
            return new TimeScheduleDayTypeGalaxyTimePeriod(e);
        }

        public bool Equals(TimeScheduleDayTypeGalaxyTimePeriod other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeScheduleDayTypeGalaxyTimePeriod other)
        {
            if (other == null)
                return false;

            if (other.TimeScheduleDayTypeGalaxyTimePeriodUid != this.TimeScheduleDayTypeGalaxyTimePeriodUid)
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
