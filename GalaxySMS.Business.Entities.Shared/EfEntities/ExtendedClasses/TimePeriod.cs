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
    public partial class TimePeriod
    {
        public TimePeriod()
        {
            Initialize();
        }

        public TimePeriod(TimePeriod e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(TimePeriod e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimePeriodUid = e.TimePeriodUid;
            this.GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
            this.EntityId = e.EntityId;
            this.Name = e.Name;
            this.StartTime = e.StartTime;
            this.EndTime = e.EndTime;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

        }

        public TimePeriod Clone(TimePeriod e)
        {
            return new TimePeriod(e);
        }

        public bool Equals(TimePeriod other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimePeriod other)
        {
            if (other == null)
                return false;

            if (other.TimePeriodUid != this.TimePeriodUid)
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

        public ListItemBase ToListItemBase()
        {
            return new ListItemBase()
            {
                Uid = TimePeriodUid,
                EntityId = EntityId,
                Name = this.Name,
                KeyValue = this.TimePeriodUid.ToString(),
                Image = null
            };
        }

    }
}
