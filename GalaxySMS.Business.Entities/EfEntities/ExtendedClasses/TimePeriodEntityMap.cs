using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class TimePeriodEntityMap
    {
        public TimePeriodEntityMap()
        {
            Initialize();
        }

        public TimePeriodEntityMap(TimePeriodEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(TimePeriodEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimePeriodEntityMapUid = e.TimePeriodEntityMapUid;
            this.TimePeriodUid = e.TimePeriodUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public TimePeriodEntityMap Clone(TimePeriodEntityMap e)
        {
            return new TimePeriodEntityMap(e);
        }

        public bool Equals(TimePeriodEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimePeriodEntityMap other)
        {
            if (other == null)
                return false;

            if (other.TimePeriodEntityMapUid != this.TimePeriodEntityMapUid)
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
