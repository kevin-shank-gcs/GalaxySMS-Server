using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class RoleFilters
    {
        public RoleFilters() : base()
        {
            Initialize();
        }

        public RoleFilters(RoleFilters e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            //this.Clusters = new HashSet<RoleCluster>();
            this.Regions = new HashSet<RoleRegion>();
        }

        public void Initialize(RoleFilters e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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
            //this.Clusters = e.Clusters.ToCollection();
            this.Regions = e.Regions.ToCollection();
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