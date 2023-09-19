using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyTimePeriod_GetPanelLoadData
    {
        public GalaxyTimePeriod_GetPanelLoadData()
        {
            Initialize();
        }

        public GalaxyTimePeriod_GetPanelLoadData(GalaxyTimePeriod_GetPanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyTimePeriod_GetPanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
            this.TimePeriodName = e.TimePeriodName;
            this.PanelTimePeriodNumber = e.PanelTimePeriodNumber;
            this.StartTime = e.StartTime;
            this.EndTime = e.EndTime;
            this.EntityName = e.EntityName;
            this.EntityId = e.EntityId;
            this.ClusterUid = e.ClusterUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterName = e.ClusterName;
            this.ScheduleTypeCode = e.ScheduleTypeCode;
            this.ScheduleTypeDisplay = e.ScheduleTypeDisplay;
        }

        public GalaxyTimePeriod_GetPanelLoadData Clone(GalaxyTimePeriod_GetPanelLoadData e)
        {
            return new GalaxyTimePeriod_GetPanelLoadData(e);
        }

        public bool Equals(GalaxyTimePeriod_GetPanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyTimePeriod_GetPanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.GalaxyTimePeriodUid != this.GalaxyTimePeriodUid)
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
