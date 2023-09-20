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
    public partial class RoleRegion
    {
        public RoleRegion() : base()
        {
            Initialize();
        }

        public RoleRegion(RoleRegion e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.RoleRegionPermissions = new HashSet<RoleRegionPermission>();
            this.Sites = new HashSet<RoleSite>();
        }

        public void Initialize(RoleRegion e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.RoleRegionUid = e.RoleRegionUid;
            this.RoleId = e.RoleId;
            this.RegionUid = e.RegionUid;
            this.IncludeAllSites = e.IncludeAllSites;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleRegionPermissions = e.RoleRegionPermissions.ToCollection();
            if (e.Sites != null)
                this.Sites = e.Sites.ToCollection();

        }

        public RoleRegion Clone(RoleRegion e)
        {
            return new RoleRegion(e);
        }

        public bool Equals(RoleRegion other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleRegion other)
        {
            if (other == null)
                return false;

            if (other.RoleRegionUid != this.RoleRegionUid)
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
