
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsEntityApplication
    {
        public gcsEntityApplication()
        {
            Initialize();
        }

        public gcsEntityApplication(gcsEntityApplication e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsEntityApplicationRoles = new HashSet<gcsEntityApplicationRole>();
        }

        public void Initialize(gcsEntityApplication e)
        {
            Initialize();
            if (e == null)
                return;
            this.EntityApplicationId = e.EntityApplicationId;
            this.EntityId = e.EntityId;
            this.ApplicationId = e.ApplicationId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsEntityApplicationRoles = e.gcsEntityApplicationRoles.ToCollection();

        }

        public gcsEntityApplication Clone(gcsEntityApplication e)
        {
            return new gcsEntityApplication(e);
        }

        public bool Equals(gcsEntityApplication other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsEntityApplication other)
        {
            if (other == null)
                return false;

            if (other.EntityApplicationId != this.EntityApplicationId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
