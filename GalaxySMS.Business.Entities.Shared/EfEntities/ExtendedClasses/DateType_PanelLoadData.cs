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

    public partial class DateType_PanelLoadData
    {
        public DateType_PanelLoadData()
        {
            Initialize();
        }

        public DateType_PanelLoadData(DateType_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(DateType_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.DateTypeUid = e.DateTypeUid;
            this.Date_x = e.Date_x;
            this.DayTypeName = e.DayTypeName;
            this.PanelDayTypeNumber = e.PanelDayTypeNumber;
            this.EntityName = e.EntityName;
            this.EntityId = e.EntityId;
            this.ClusterUid = e.ClusterUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterName = e.ClusterName;
            this.ScheduleTypeCode = e.ScheduleTypeCode;
            this.ScheduleTypeDisplay = e.ScheduleTypeDisplay;
        }

        public DateType_PanelLoadData Clone(DateType_PanelLoadData e)
        {
            return new DateType_PanelLoadData(e);
        }

        public bool Equals(DateType_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DateType_PanelLoadData other)
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