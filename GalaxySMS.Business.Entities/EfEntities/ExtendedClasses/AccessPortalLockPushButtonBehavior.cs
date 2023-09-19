using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalLockPushButtonBehavior
    {
        public AccessPortalLockPushButtonBehavior()
        {
            Initialize();
        }

        public AccessPortalLockPushButtonBehavior(AccessPortalLockPushButtonBehavior e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalLockPushButtonBehavior e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalLockPushButtonBehaviorUid = e.AccessPortalLockPushButtonBehaviorUid;
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

        public AccessPortalLockPushButtonBehavior Clone(AccessPortalLockPushButtonBehavior e)
        {
            return new AccessPortalLockPushButtonBehavior(e);
        }

        public bool Equals(AccessPortalLockPushButtonBehavior other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalLockPushButtonBehavior other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalLockPushButtonBehaviorUid != this.AccessPortalLockPushButtonBehaviorUid)
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
