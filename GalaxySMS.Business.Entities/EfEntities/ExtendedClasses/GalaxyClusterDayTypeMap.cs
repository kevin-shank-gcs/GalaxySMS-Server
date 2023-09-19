using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyClusterDayTypeMap
    {
        public GalaxyClusterDayTypeMap()
        {
            Initialize();
        }

        public GalaxyClusterDayTypeMap(GalaxyClusterDayTypeMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyClusterDayTypeMap e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyClusterDayTypeMapUid = e.GalaxyClusterDayTypeMapUid;
            this.DayTypeUid = e.DayTypeUid;
            this.ClusterUid = e.ClusterUid;
            this.PanelDayTypeNumber = e.PanelDayTypeNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public GalaxyClusterDayTypeMap Clone(GalaxyClusterDayTypeMap e)
        {
            return new GalaxyClusterDayTypeMap(e);
        }

        public bool Equals(GalaxyClusterDayTypeMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyClusterDayTypeMap other)
        {
            if (other == null)
                return false;

            if (other.GalaxyClusterDayTypeMapUid != this.GalaxyClusterDayTypeMapUid)
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
