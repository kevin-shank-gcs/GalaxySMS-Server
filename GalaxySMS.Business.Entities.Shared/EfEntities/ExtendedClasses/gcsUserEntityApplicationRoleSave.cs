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
    public partial class gcsUserEntityApplicationRoleSave
    {
        public gcsUserEntityApplicationRoleSave()
        {
            Initialize();
        }

        public gcsUserEntityApplicationRoleSave(gcsUserEntityApplicationRoleSave e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsUserEntityApplicationRoleSave e)
        {
            Initialize();
            if (e == null)
                return;
            this.EntityApplicationRoleId = e.EntityApplicationRoleId;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserEntityApplicationRoleSave Clone(gcsUserEntityApplicationRoleSave e)
        {
            return new gcsUserEntityApplicationRoleSave(e);
        }

        public bool Equals(gcsUserEntityApplicationRoleSave other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserEntityApplicationRoleSave other)
        {
            if (other == null)
                return false;

            if (other.EntityApplicationRoleId != this.EntityApplicationRoleId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
