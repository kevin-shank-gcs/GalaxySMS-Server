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
	public partial class AssaDayPeriod
    {
        public AssaDayPeriod()
        {
            Initialize();
        }

        public AssaDayPeriod(AssaDayPeriod e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AssaDayPeriodTimePeriods = new HashSet<AssaDayPeriodTimePeriod>();
            this.AssaTimeScheduleDayPeriods = new HashSet<AssaTimeScheduleDayPeriod>();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.TimePeriods = new HashSet<TimePeriod>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AssaDayPeriod e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaDayPeriodUid = e.AssaDayPeriodUid;
            this.EntityId = e.EntityId;
            this.Name = e.Name;
            this.Sunday = e.Sunday;
            this.Monday = e.Monday;
            this.Tuesday = e.Tuesday;
            this.Wednesday = e.Wednesday;
            this.Thursday = e.Thursday;
            this.Friday = e.Friday;
            this.Saturday = e.Saturday;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AssaDsrDayPeriodId = e.AssaDsrDayPeriodId;
            this.AssaDayPeriodTimePeriods = e.AssaDayPeriodTimePeriods.ToCollection();
            this.AssaTimeScheduleDayPeriods = e.AssaTimeScheduleDayPeriods.ToCollection();
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if( e.TimePeriods != null)
                this.TimePeriods = e.TimePeriods.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

        }

        public AssaDayPeriod Clone(AssaDayPeriod e)
        {
            return new AssaDayPeriod(e);
        }

        public bool Equals(AssaDayPeriod other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AssaDayPeriod other)
        {
            if (other == null)
                return false;

            if (other.AssaDayPeriodUid != this.AssaDayPeriodUid)
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
