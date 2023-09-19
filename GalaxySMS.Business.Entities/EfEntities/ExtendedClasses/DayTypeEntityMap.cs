using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class DayTypeEntityMap
    {
        public DayTypeEntityMap()
        {
            Initialize();
        }

        public DayTypeEntityMap(DayTypeEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(DayTypeEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.DayTypeEntityMapUid = e.DayTypeEntityMapUid;
            this.EntityId = e.EntityId;
            this.DayTypeUid = e.DayTypeUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public DayTypeEntityMap Clone(DayTypeEntityMap e)
        {
            return new DayTypeEntityMap(e);
        }

        public bool Equals(DayTypeEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DayTypeEntityMap other)
        {
            if (other == null)
                return false;

            if (other.DayTypeEntityMapUid != this.DayTypeEntityMapUid)
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
