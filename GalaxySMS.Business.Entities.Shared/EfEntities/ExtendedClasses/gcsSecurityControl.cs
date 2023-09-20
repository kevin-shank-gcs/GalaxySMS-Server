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
	public partial class gcsSecurityControl
    {
        public gcsSecurityControl()
        {
            Initialize();
        }

        public gcsSecurityControl(gcsSecurityControl e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsSecurityControl e)
        {
            Initialize();
            if (e == null)
                return;
            this.SecurityControlId = e.SecurityControlId;
            this.ApplicationId = e.ApplicationId;
            this.PermissionId = e.PermissionId;
            this.FormPageName = e.FormPageName;
            this.ControlName = e.ControlName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsSecurityControl Clone(gcsSecurityControl e)
        {
            return new gcsSecurityControl(e);
        }

        public bool Equals(gcsSecurityControl other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsSecurityControl other)
        {
            if (other == null)
                return false;

            if (other.SecurityControlId != this.SecurityControlId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
