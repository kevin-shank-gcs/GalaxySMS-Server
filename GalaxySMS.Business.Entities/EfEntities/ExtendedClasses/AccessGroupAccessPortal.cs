using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessGroupAccessPortal
    {
        public AccessGroupAccessPortal()
        {
            Initialize();
        }

        public AccessGroupAccessPortal(AccessGroupAccessPortal e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessGroupAccessPortal e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessGroupAccessPortalUid = e.AccessGroupAccessPortalUid;
            this.AccessGroupUid = e.AccessGroupUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            this.AccessGroupName = e.AccessGroupName;
            this.AccessPortalName = e.AccessPortalName;
            this.TimeScheduleName = e.TimeScheduleName;
            this.IsSystemAccessGroup = e.IsSystemAccessGroup;
            this.AccessGroupNumber = e.AccessGroupNumber;
        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public AccessGroupAccessPortal Clone(AccessGroupAccessPortal e)
        {
            return new AccessGroupAccessPortal(e);
        }

        public bool Equals(AccessGroupAccessPortal other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroupAccessPortal other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupAccessPortalUid != this.AccessGroupAccessPortalUid)
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
