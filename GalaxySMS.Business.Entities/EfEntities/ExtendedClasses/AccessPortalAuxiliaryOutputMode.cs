using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalAuxiliaryOutputMode
    {
        public AccessPortalAuxiliaryOutputMode()
        {
            Initialize();
        }

        public AccessPortalAuxiliaryOutputMode(AccessPortalAuxiliaryOutputMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalAuxiliaryOutputMode e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalAuxiliaryOutputModeUid = e.AccessPortalAuxiliaryOutputModeUid;
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

        public AccessPortalAuxiliaryOutputMode Clone(AccessPortalAuxiliaryOutputMode e)
        {
            return new AccessPortalAuxiliaryOutputMode(e);
        }

        public bool Equals(AccessPortalAuxiliaryOutputMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalAuxiliaryOutputMode other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAuxiliaryOutputModeUid != this.AccessPortalAuxiliaryOutputModeUid)
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
