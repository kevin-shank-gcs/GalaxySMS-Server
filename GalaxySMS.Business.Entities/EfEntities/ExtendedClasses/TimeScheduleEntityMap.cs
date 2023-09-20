
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class TimeScheduleEntityMap
    {
        public TimeScheduleEntityMap()
        {
            Initialize();
        }

        public TimeScheduleEntityMap(TimeScheduleEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(TimeScheduleEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimeScheduleEntityMapUid = e.TimeScheduleEntityMapUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public TimeScheduleEntityMap Clone(TimeScheduleEntityMap e)
        {
            return new TimeScheduleEntityMap(e);
        }

        public bool Equals(TimeScheduleEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeScheduleEntityMap other)
        {
            if (other == null)
                return false;

            if (other.TimeScheduleEntityMapUid != this.TimeScheduleEntityMapUid)
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
