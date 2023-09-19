using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class DateType
    {
        public DateType()
        {
            Initialize();
        }

        public DateType(DateType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(DateType e)
        {
            Initialize();
            if (e == null)
                return;
            this.DateTypeUid = e.DateTypeUid;
            this.EntityId = e.EntityId;
            this.DayTypeUid = e.DayTypeUid;
            this.Date = e.Date;
            this.Title = e.Title;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public DateType Clone(DateType e)
        {
            return new DateType(e);
        }

        public bool Equals(DateType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DateType other)
        {
            if (other == null)
                return false;

            if (other.DateTypeUid != this.DateTypeUid)
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
