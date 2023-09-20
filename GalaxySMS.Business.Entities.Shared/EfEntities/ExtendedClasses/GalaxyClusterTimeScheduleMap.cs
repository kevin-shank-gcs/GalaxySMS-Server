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
	public partial class GalaxyClusterTimeScheduleMap
    {
        public GalaxyClusterTimeScheduleMap()
        {
            Initialize();
        }

        public GalaxyClusterTimeScheduleMap(GalaxyClusterTimeScheduleMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyClusterTimeScheduleMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyClusterTimeScheduleMapUid = e.GalaxyClusterTimeScheduleMapUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.ClusterUid = e.ClusterUid;
            this.PanelScheduleNumber = e.PanelScheduleNumber;
            this.FifteenMinuteFormatUsesHolidays = e.FifteenMinuteFormatUsesHolidays;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.ClusterName = e.ClusterName;
            this.TimeScheduleName = e.TimeScheduleName;

        }

        public GalaxyClusterTimeScheduleMap Clone(GalaxyClusterTimeScheduleMap e)
        {
            return new GalaxyClusterTimeScheduleMap(e);
        }

        public bool Equals(GalaxyClusterTimeScheduleMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyClusterTimeScheduleMap other)
        {
            if (other == null)
                return false;

            if (other.GalaxyClusterTimeScheduleMapUid != this.GalaxyClusterTimeScheduleMapUid)
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