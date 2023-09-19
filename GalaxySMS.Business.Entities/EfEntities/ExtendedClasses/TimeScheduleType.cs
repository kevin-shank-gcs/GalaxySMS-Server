using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class TimeScheduleType
    {
        public TimeScheduleType()
        {
            Initialize();
        }

        public TimeScheduleType(TimeScheduleType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(TimeScheduleType e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimeScheduleTypeUid = e.TimeScheduleTypeUid;
            this.ScheduleTypeCode = e.ScheduleTypeCode;

            // Common table properties
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            // IHasDisplayResource & IHasDescriptionResource members
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
        }

        public TimeScheduleType Clone(TimeScheduleType e)
        {
            return new TimeScheduleType(e);
        }

        public bool Equals(TimeScheduleType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeScheduleType other)
        {
            if (other == null)
                return false;

            if (other.TimeScheduleTypeUid != this.TimeScheduleTypeUid)
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
