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
	public partial class AccessPortalNoServerReplyBehavior
    {
        public AccessPortalNoServerReplyBehavior()
        {
            Initialize();
        }

        public AccessPortalNoServerReplyBehavior(AccessPortalNoServerReplyBehavior e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AccessPortalNoServerReplyBehavior e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalNoServerReplyBehaviorUid = e.AccessPortalNoServerReplyBehaviorUid;
            this.Code = e.Code;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            // IHasDisplayResource & IHasDescriptionResource members
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
        }

        public AccessPortalNoServerReplyBehavior Clone(AccessPortalNoServerReplyBehavior e)
        {
            return new AccessPortalNoServerReplyBehavior(e);
        }

        public bool Equals(AccessPortalNoServerReplyBehavior other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalNoServerReplyBehavior other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalNoServerReplyBehaviorUid != this.AccessPortalNoServerReplyBehaviorUid)
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
