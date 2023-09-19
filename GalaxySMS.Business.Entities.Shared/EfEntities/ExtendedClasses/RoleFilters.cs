using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

using System.Runtime.Serialization;

#if NetCoreApi
    namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class RoleFilters
    {
        public RoleFilters()
        {
            Initialize();
        }

        public RoleFilters(RoleFilters e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.Clusters = new HashSet<RoleCluster>();
            this.Regions = new HashSet<RoleRegion>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleFilters e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleId = e.RoleId;
            this.IncludeAllRegions = e.IncludeAllRegions;
            this.IncludeAllSites = e.IncludeAllSites;
            this.IncludeAllClusters = e.IncludeAllClusters;
            this.IncludeAllAccessPortals = e.IncludeAllAccessPortals;
            this.IncludeAllInputDevices = e.IncludeAllInputDevices;
            this.IncludeAllOutputDevices = e.IncludeAllOutputDevices;
            this.IncludeAllInputOutputGroups = e.IncludeAllInputOutputGroups;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //if (e.Clusters != null)
            //    this.Clusters = e.Clusters.ToCollection();
            if (e.Regions != null)
                this.Regions = e.Regions.ToCollection();

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

        public RoleFilters Clone(RoleFilters e)
        {
            return new RoleFilters(e);
        }

        public bool Equals(RoleFilters other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleFilters other)
        {
            if (other == null)
                return false;

            if (other.RoleId != this.RoleId)
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
