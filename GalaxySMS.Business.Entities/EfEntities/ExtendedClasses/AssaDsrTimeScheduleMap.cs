
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AssaDsrTimeScheduleMap
    {
        public AssaDsrTimeScheduleMap()
        {
            Initialize();
        }

        public AssaDsrTimeScheduleMap(AssaDsrTimeScheduleMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AssaDsrTimeScheduleMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaDsrTimeScheduleMapUid = e.AssaDsrTimeScheduleMapUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.AssaDsrUid = e.AssaDsrUid;
            this.AssaDsrScheduleId = e.AssaDsrScheduleId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AssaDsrTimeScheduleMap Clone(AssaDsrTimeScheduleMap e)
        {
            return new AssaDsrTimeScheduleMap(e);
        }

        public bool Equals(AssaDsrTimeScheduleMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AssaDsrTimeScheduleMap other)
        {
            if (other == null)
                return false;

            if (other.AssaDsrTimeScheduleMapUid != this.AssaDsrTimeScheduleMapUid)
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
