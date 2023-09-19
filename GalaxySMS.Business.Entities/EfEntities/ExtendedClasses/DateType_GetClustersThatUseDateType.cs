using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class DateType_GetClustersThatUseDateType
    {
        public DateType_GetClustersThatUseDateType()
        {
            Initialize();
        }

        public DateType_GetClustersThatUseDateType(DateType_GetClustersThatUseDateType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(DateType_GetClustersThatUseDateType e)
        {
            Initialize();
            if (e == null)
                return;

            this.DateTypeUid = e.DateTypeUid;
            this.Date_x = e.Date_x;
            this.EntityName = e.EntityName;
            this.ClusterUid = e.ClusterUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterName = e.ClusterName;
            this.ScheduleTypeCode = e.ScheduleTypeCode;
            this.ScheduleTypeDisplay = e.ScheduleTypeDisplay;
            this.RETURNVALUE = e.RETURNVALUE;
        }

        public DateType_GetClustersThatUseDateType Clone(DateType_GetClustersThatUseDateType e)
        {
            return new DateType_GetClustersThatUseDateType(e);
        }

        public bool Equals(DateType_GetClustersThatUseDateType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DateType_GetClustersThatUseDateType other)
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