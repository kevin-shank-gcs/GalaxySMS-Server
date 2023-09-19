using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AssaDayPeriodEntityMap
    {
        public AssaDayPeriodEntityMap()
        {
            Initialize();
        }

        public AssaDayPeriodEntityMap(AssaDayPeriodEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AssaDayPeriodEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaDayPeriodEntityMapUid = e.AssaDayPeriodEntityMapUid;
            this.AssaDayPeriodUid = e.AssaDayPeriodUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AssaDayPeriodEntityMap Clone(AssaDayPeriodEntityMap e)
        {
            return new AssaDayPeriodEntityMap(e);
        }

        public bool Equals(AssaDayPeriodEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AssaDayPeriodEntityMap other)
        {
            if (other == null)
                return false;

            if (other.AssaDayPeriodEntityMapUid != this.AssaDayPeriodEntityMapUid)
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
