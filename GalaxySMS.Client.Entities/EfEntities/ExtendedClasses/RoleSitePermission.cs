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
    public partial class RoleSitePermission
    {
        public RoleSitePermission() : base()
        {
            Initialize();
        }

        public RoleSitePermission(RoleSitePermission e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(RoleSitePermission e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.RoleSitePermissionUid = e.RoleSitePermissionUid;
            this.RoleSiteUid = e.RoleSiteUid;
            this.PermissionId = e.PermissionId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public RoleSitePermission Clone(RoleSitePermission e)
        {
            return new RoleSitePermission(e);
        }

        public bool Equals(RoleSitePermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleSitePermission other)
        {
            if (other == null)
                return false;

            if (other.RoleSitePermissionUid != this.RoleSitePermissionUid)
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
