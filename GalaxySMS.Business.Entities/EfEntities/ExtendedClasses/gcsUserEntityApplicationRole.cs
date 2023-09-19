using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsUserEntityApplicationRole
    {
        public gcsUserEntityApplicationRole()
        {
            Initialize();
        }

        public gcsUserEntityApplicationRole(gcsUserEntityApplicationRole e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsUserEntityApplicationRole e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserEntityApplicationRoleId = e.UserEntityApplicationRoleId;
            this.UserEntityId = e.UserEntityId;
            this.EntityApplicationRoleId = e.EntityApplicationRoleId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserEntityApplicationRole Clone(gcsUserEntityApplicationRole e)
        {
            return new gcsUserEntityApplicationRole(e);
        }

        public bool Equals(gcsUserEntityApplicationRole other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserEntityApplicationRole other)
        {
            if (other == null)
                return false;

            if (other.UserEntityApplicationRoleId != this.UserEntityApplicationRoleId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
