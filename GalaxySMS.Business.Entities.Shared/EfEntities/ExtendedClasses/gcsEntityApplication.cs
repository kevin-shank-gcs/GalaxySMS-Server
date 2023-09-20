
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            this.ConcurrencyValue = 0;
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
