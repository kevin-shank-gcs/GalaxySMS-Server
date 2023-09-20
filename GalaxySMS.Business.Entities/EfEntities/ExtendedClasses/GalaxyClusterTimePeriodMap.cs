using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyClusterTimePeriodMap
    {
        public GalaxyClusterTimePeriodMap()
        {
            Initialize();
        }

        public GalaxyClusterTimePeriodMap(GalaxyClusterTimePeriodMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyClusterTimePeriodMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyClusterTimePeriodMapUid = e.GalaxyClusterTimePeriodMapUid;
            this.TimePeriodUid = e.TimePeriodUid;
            this.ClusterUid = e.ClusterUid;
            this.PanelPeriodNumber = e.PanelPeriodNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyClusterTimePeriodMap Clone(GalaxyClusterTimePeriodMap e)
        {
            return new GalaxyClusterTimePeriodMap(e);
        }

        public bool Equals(GalaxyClusterTimePeriodMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyClusterTimePeriodMap other)
        {
            if (other == null)
                return false;

            if (other.GalaxyClusterTimePeriodMapUid != this.GalaxyClusterTimePeriodMapUid)
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