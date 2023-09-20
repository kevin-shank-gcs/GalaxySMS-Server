using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalTimeSchedule
    {
        public AccessPortalTimeSchedule()
        {
            Initialize();
        }

        public AccessPortalTimeSchedule(AccessPortalTimeSchedule e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalTimeSchedule e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalTimeScheduleUid = e.AccessPortalTimeScheduleUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.AccessPortalScheduleTypeUid = e.AccessPortalScheduleTypeUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
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

        public AccessPortalTimeSchedule Clone(AccessPortalTimeSchedule e)
        {
            return new AccessPortalTimeSchedule(e);
        }

        public bool Equals(AccessPortalTimeSchedule other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalTimeSchedule other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalTimeScheduleUid != this.AccessPortalTimeScheduleUid)
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