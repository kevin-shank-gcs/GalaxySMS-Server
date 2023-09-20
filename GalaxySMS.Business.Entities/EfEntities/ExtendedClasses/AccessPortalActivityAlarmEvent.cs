
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalActivityAlarmEvent
    {
        public AccessPortalActivityAlarmEvent()
        {
            Initialize();
        }

        public AccessPortalActivityAlarmEvent(AccessPortalActivityAlarmEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AccessPortalAlarmEventAcknowledgments = new HashSet<AccessPortalAlarmEventAcknowledgment>();
        }

        public void Initialize(AccessPortalActivityAlarmEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalActivityEventUid = e.AccessPortalActivityEventUid;
            this.NoteUid = e.NoteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AlarmPriority = e.AlarmPriority;
            this.AccessPortalAlarmEventAcknowledgments = e.AccessPortalAlarmEventAcknowledgments.ToCollection();

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
