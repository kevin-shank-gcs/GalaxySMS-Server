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
    public partial class gcsUserGroupEntityRole
    {
        public gcsUserGroupEntityRole() : base()
        {
            Initialize();
        }

        public gcsUserGroupEntityRole(gcsUserGroupEntityRole e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(gcsUserGroupEntityRole e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.UserGroupEntityRoleId = e.UserGroupEntityRoleId;
            this.UserGroupEntityId = e.UserGroupEntityId;
            this.RoleId = e.RoleId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserGroupEntityRole Clone(gcsUserGroupEntityRole e)
        {
            return new gcsUserGroupEntityRole(e);
        }

        public bool Equals(gcsUserGroupEntityRole other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserGroupEntityRole other)
        {
            if (other == null)
                return false;

            if (other.UserGroupEntityRoleId != this.UserGroupEntityRoleId)
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
