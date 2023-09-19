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
    public partial class RoleRegionPermission
    {
        public RoleRegionPermission() : base()
        {
            Initialize();
        }

        public RoleRegionPermission(RoleRegionPermission e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(RoleRegionPermission e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.RoleRegionPermissionUid = e.RoleRegionPermissionUid;
            this.RoleRegionUid = e.RoleRegionUid;
            this.PermissionId = e.PermissionId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public RoleRegionPermission Clone(RoleRegionPermission e)
        {
            return new RoleRegionPermission(e);
        }

        public bool Equals(RoleRegionPermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleRegionPermission other)
        {
            if (other == null)
                return false;

            if (other.RoleRegionPermissionUid != this.RoleRegionPermissionUid)
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