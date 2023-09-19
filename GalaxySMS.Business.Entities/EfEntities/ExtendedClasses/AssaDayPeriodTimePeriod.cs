using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AssaDayPeriodTimePeriod
    {
        public AssaDayPeriodTimePeriod()
        {
            Initialize();
        }

        public AssaDayPeriodTimePeriod(AssaDayPeriodTimePeriod e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AssaDayPeriodTimePeriod e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaDayPeriodTimePeriodUid = e.AssaDayPeriodTimePeriodUid;
            this.AssaDayPeriodUid = e.AssaDayPeriodUid;
            this.TimePeriodUid = e.TimePeriodUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AssaDayPeriodTimePeriod Clone(AssaDayPeriodTimePeriod e)
        {
            return new AssaDayPeriodTimePeriod(e);
        }

        public bool Equals(AssaDayPeriodTimePeriod other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AssaDayPeriodTimePeriod other)
        {
            if (other == null)
                return false;

            if (other.AssaDayPeriodTimePeriodUid != this.AssaDayPeriodTimePeriodUid)
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
