using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalAuxiliaryOutputTriggeringEvent
    {
        public AccessPortalAuxiliaryOutputTriggeringEvent()
        {
            Initialize();
        }

        public AccessPortalAuxiliaryOutputTriggeringEvent(AccessPortalAuxiliaryOutputTriggeringEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalAuxiliaryOutputTriggeringEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalAuxiliaryOutputTriggeringEventUid = e.AccessPortalAuxiliaryOutputTriggeringEventUid;
            this.AccessPortalAuxiliaryOutputUid = e.AccessPortalAuxiliaryOutputUid;
            this.AccessPortalAlertEventTypeUid = e.AccessPortalAlertEventTypeUid;
            this.Selected = e.Selected;
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

        public AccessPortalAuxiliaryOutputTriggeringEvent Clone(AccessPortalAuxiliaryOutputTriggeringEvent e)
        {
            return new AccessPortalAuxiliaryOutputTriggeringEvent(e);
        }

        public bool Equals(AccessPortalAuxiliaryOutputTriggeringEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalAuxiliaryOutputTriggeringEvent other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAuxiliaryOutputTriggeringEventUid !=
                this.AccessPortalAuxiliaryOutputTriggeringEventUid)
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