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
	public partial class gcsUserOldPassword
    {
        public gcsUserOldPassword()
        {
            Initialize();
        }

        public gcsUserOldPassword(gcsUserOldPassword e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsUserOldPassword e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserOldPasswordId = e.UserOldPasswordId;
            this.UserId = e.UserId;
            this.Password = e.Password;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsUserOldPassword Clone(gcsUserOldPassword e)
        {
            return new gcsUserOldPassword(e);
        }

        public bool Equals(gcsUserOldPassword other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserOldPassword other)
        {
            if (other == null)
                return false;

            if (other.UserOldPasswordId != this.UserOldPasswordId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
