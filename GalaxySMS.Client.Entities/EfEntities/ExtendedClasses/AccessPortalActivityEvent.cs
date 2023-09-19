using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class AccessPortalActivityEvent
    {
        public AccessPortalActivityEvent() : base()
        {
            Initialize();
        }

        public AccessPortalActivityEvent(AccessPortalActivityEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(AccessPortalActivityEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessPortalActivityEventUid = e.AccessPortalActivityEventUid;
            this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.CredentialUid = e.CredentialUid;
            this.PersonUid = e.PersonUid;
            this.CpuUid = e.CpuUid;
            this.CpuNumber = e.CpuNumber;
            this.ActivityDateTime = e.ActivityDateTime;
            this.BufferIndex = e.BufferIndex;
            this.InsertDate = e.InsertDate;
            this.CredentialBytes = e.CredentialBytes;
            this.IsAlarmEvent = e.IsAlarmEvent;
            this.AlarmPriority = e.AlarmPriority;
            this.NoteUid = e.NoteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
        }

        public AccessPortalActivityEvent Clone(AccessPortalActivityEvent e)
        {
            return new AccessPortalActivityEvent(e);
        }

        public bool Equals(AccessPortalActivityEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalActivityEvent other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalActivityEventUid != this.AccessPortalActivityEventUid)
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
