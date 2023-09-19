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
    public partial class RoleSite
    {
        public RoleSite() : base()
        {
            Initialize();
        }

        public RoleSite(RoleSite e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.RoleSitePermissions = new HashSet<RoleSitePermission>();
            this.Clusters = new HashSet<RoleCluster>();
        }

        public void Initialize(RoleSite e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.RoleSiteUid = e.RoleSiteUid;
            this.RoleId = e.RoleId;
            this.SiteUid = e.SiteUid;
            this.IncludeAllClusters = e.IncludeAllClusters;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleSitePermissions = e.RoleSitePermissions.ToCollection();
            if (e.Clusters != null)
                this.Clusters = e.Clusters.ToCollection();

        }

        public RoleSite Clone(RoleSite e)
        {
            return new RoleSite(e);
        }

        public bool Equals(RoleSite other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleSite other)
        {
            if (other == null)
                return false;

            if (other.RoleSiteUid != this.RoleSiteUid)
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
