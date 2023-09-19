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
	public partial class gcsMenuItem
    {
        public gcsMenuItem()
        {
            Initialize();
        }

        public gcsMenuItem(gcsMenuItem e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsMenuItem e)
        {
            Initialize();
            if (e == null)
                return;
            this.MenuItemId = e.MenuItemId;
            this.ApplicationId = e.ApplicationId;
            this.PermissionId = e.PermissionId;
            this.ParentMenuItemId = e.ParentMenuItemId;
            this.MenuTitleResourceId = e.MenuTitleResourceId;
            this.TipTextResourceId = e.TipTextResourceId;
            this.MenuTitle = e.MenuTitle;
            this.TipText = e.TipText;
            this.DisplayOrder = e.DisplayOrder;
            this.IsActive = e.IsActive;
            this.MenuAction = e.MenuAction;
            this.ActiveImage = e.ActiveImage;
            this.InactiveImage = e.InactiveImage;
            this.DisabledImage = e.DisabledImage;
            this.MenuSize = e.MenuSize;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsMenuItem Clone(gcsMenuItem e)
        {
            return new gcsMenuItem(e);
        }

        public bool Equals(gcsMenuItem other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsMenuItem other)
        {
            if (other == null)
                return false;

            if (other.MenuItemId != this.MenuItemId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
