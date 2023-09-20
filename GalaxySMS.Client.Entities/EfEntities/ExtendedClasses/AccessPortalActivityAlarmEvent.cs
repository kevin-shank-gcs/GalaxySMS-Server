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
    public partial class AccessPortalActivityAlarmEvent
    {
        public AccessPortalActivityAlarmEvent() : base()
        {
            Initialize();
        }

        public AccessPortalActivityAlarmEvent(AccessPortalActivityAlarmEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.AccessPortalAlarmEventAcknowledgments = new HashSet<AccessPortalAlarmEventAcknowledgment>();
        }

        public void Initialize(AccessPortalActivityAlarmEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessPortalActivityEventUid = e.AccessPortalActivityEventUid;
            this.NoteUid = e.NoteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AlarmPriority = e.AlarmPriority;
            this.AccessPortalAlarmEventAcknowledgments = e.AccessPortalAlarmEventAcknowledgments.ToCollection();

        }

        public AccessPortalActivityAlarmEvent Clone(AccessPortalActivityAlarmEvent e)
        {
            return new AccessPortalActivityAlarmEvent(e);
        }

        public bool Equals(AccessPortalActivityAlarmEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalActivityAlarmEvent other)
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
