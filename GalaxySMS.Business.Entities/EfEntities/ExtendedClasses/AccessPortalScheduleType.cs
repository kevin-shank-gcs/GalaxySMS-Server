using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalScheduleType
    {
        public AccessPortalScheduleType()
        {
            Initialize();
        }

        public AccessPortalScheduleType(AccessPortalScheduleType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AccessPortalTimeSchedules = new HashSet<AccessPortalTimeSchedule>();
        }

        public void Initialize(AccessPortalScheduleType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalScheduleTypeUid = e.AccessPortalScheduleTypeUid;
            this.Tag = e.Tag;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AccessPortalTimeSchedules = e.AccessPortalTimeSchedules.ToCollection();

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

        public AccessPortalScheduleType Clone(AccessPortalScheduleType e)
        {
            return new AccessPortalScheduleType(e);
        }

        public bool Equals(AccessPortalScheduleType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalScheduleType other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalScheduleTypeUid != this.AccessPortalScheduleTypeUid)
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