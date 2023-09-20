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
	public partial class TimeScheduleDayTypeTimePeriod
    {
        public TimeScheduleDayTypeTimePeriod()
        {
            Initialize();
        }

        public TimeScheduleDayTypeTimePeriod(TimeScheduleDayTypeTimePeriod e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(TimeScheduleDayTypeTimePeriod e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimeScheduleDayTypeTimePeriodUid = e.TimeScheduleDayTypeTimePeriodUid;
            this.DayTypeUid = e.DayTypeUid;
            this.TimePeriodUid = e.TimePeriodUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            this.DayType = e.DayType;
            this.TimePeriod = e.TimePeriod;
        }

        public TimeScheduleDayTypeTimePeriod Clone(TimeScheduleDayTypeTimePeriod e)
        {
            return new TimeScheduleDayTypeTimePeriod(e);
        }

        public bool Equals(TimeScheduleDayTypeTimePeriod other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeScheduleDayTypeTimePeriod other)
        {
            if (other == null)
                return false;

            if (other.TimeScheduleDayTypeTimePeriodUid != this.TimeScheduleDayTypeTimePeriodUid)
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
