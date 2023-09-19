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
    public partial class RoleMercScpGroupPermission
    {
        public RoleMercScpGroupPermission() : base()
        {
            Initialize();
        }

        public RoleMercScpGroupPermission(RoleMercScpGroupPermission e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(RoleMercScpGroupPermission e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.RoleMercScpGroupPermissionUid = e.RoleMercScpGroupPermissionUid;
            this.RoleMercScpGroupUid = e.RoleMercScpGroupUid;
            this.PermissionId = e.PermissionId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public RoleMercScpGroupPermission Clone(RoleMercScpGroupPermission e)
        {
            return new RoleMercScpGroupPermission(e);
        }

        public bool Equals(RoleMercScpGroupPermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleMercScpGroupPermission other)
        {
            if (other == null)
                return false;

            if (other.RoleMercScpGroupPermissionUid != this.RoleMercScpGroupPermissionUid)
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
