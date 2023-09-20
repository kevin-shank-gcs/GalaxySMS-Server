using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalAuxiliaryOutput
    {
        public AccessPortalAuxiliaryOutput()
        {
            Initialize();
        }

        public AccessPortalAuxiliaryOutput(AccessPortalAuxiliaryOutput e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AccessPortalAuxiliaryOutputTriggeringEvents = new HashSet<AccessPortalAuxiliaryOutputTriggeringEvent>();
        }

        public void Initialize(AccessPortalAuxiliaryOutput e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalAuxiliaryOutputUid = e.AccessPortalAuxiliaryOutputUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.AccessPortalAuxiliaryOutputModeUid = e.AccessPortalAuxiliaryOutputModeUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.Description = e.Description;
            this.Tag = e.Tag;
            this.ActivationDelay = e.ActivationDelay;
            this.ActivationDuration = e.ActivationDuration;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AccessPortalAuxiliaryOutputTriggeringEvents =
                e.AccessPortalAuxiliaryOutputTriggeringEvents.ToCollection();
            this.IllegalOpen = e.IllegalOpen;
            this.OpenTooLong = e.OpenTooLong;
            this.InvalidAttempt = e.InvalidAttempt;
            this.AccessGranted = e.AccessGranted;
            this.Duress = e.Duress;
            this.PassbackViolation = e.PassbackViolation;
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

        public AccessPortalAuxiliaryOutput Clone(AccessPortalAuxiliaryOutput e)
        {
            return new AccessPortalAuxiliaryOutput(e);
        }

        public bool Equals(AccessPortalAuxiliaryOutput other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalAuxiliaryOutput other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAuxiliaryOutputUid != this.AccessPortalAuxiliaryOutputUid)
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