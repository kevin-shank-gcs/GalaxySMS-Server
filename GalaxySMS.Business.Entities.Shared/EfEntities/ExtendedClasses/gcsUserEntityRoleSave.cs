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
    public partial class gcsUserEntityRoleSave
    {
        public gcsUserEntityRoleSave()
        {
            Initialize();
        }

        public gcsUserEntityRoleSave(gcsUserEntityRoleSave e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsUserEntityRoleSave e)
        {
            Initialize();
            if (e == null)
                return;
            this.RoleId = e.RoleId;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserEntityRoleSave Clone(gcsUserEntityRoleSave e)
        {
            return new gcsUserEntityRoleSave(e);
        }

        public bool Equals(gcsUserEntityRoleSave other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserEntityRoleSave other)
        {
            if (other == null)
                return false;

            if (other.RoleId != this.RoleId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
