using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalAlertEvent
    {
        public AccessPortalAlertEvent()
        {
            Initialize();
        }

        public AccessPortalAlertEvent(AccessPortalAlertEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            Note = new Note() { Category = GalaxySMS.Common.Constants.NoteCategories.AccessPortalAlertEventInstructions };
        }

        public void Initialize(AccessPortalAlertEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalAlertEventUid = e.AccessPortalAlertEventUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.AcknowledgeTimeScheduleUid = e.AcknowledgeTimeScheduleUid;
            this.AudioBinaryResourceUid = e.AudioBinaryResourceUid;
            this.ResponseInstructionsUid = e.ResponseInstructionsUid;
            this.AccessPortalAlertEventTypeUid = e.AccessPortalAlertEventTypeUid;
            this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
            this.AcknowledgePriority = e.AcknowledgePriority;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            if (e.gcsBinaryResource != null)
                this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            if (e.AccessPortalAlertEventType != null)
                this.AccessPortalAlertEventType = new AccessPortalAlertEventType(e.AccessPortalAlertEventType);
            if (e.Note != null)
                this.Note = new Note(e.Note);
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
                if (this.Note != null)
                    if( Note.IsAnythingDirty)
                        return true;
                return IsDirty;
            }
        }

        public AccessPortalAlertEvent Clone(AccessPortalAlertEvent e)
        {
            return new AccessPortalAlertEvent(e);
        }

        public bool Equals(AccessPortalAlertEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalAlertEvent other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAlertEventUid != this.AccessPortalAlertEventUid)
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