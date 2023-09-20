using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyPanelAlertEvent
    {
        public GalaxyPanelAlertEvent()
        {
            Initialize();
        }

        public GalaxyPanelAlertEvent(GalaxyPanelAlertEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyPanelAlertEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyPanelAlertEventUid = e.GalaxyPanelAlertEventUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.GalaxyPanelAlertEventTypeUid = e.GalaxyPanelAlertEventTypeUid;
            this.AcknowledgeTimeScheduleUid = e.AcknowledgeTimeScheduleUid;
            this.AudioBinaryResourceUid = e.AudioBinaryResourceUid;
            this.UserInstructionsNoteUid = e.UserInstructionsNoteUid;
            this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.AcknowledgePriority = e.AcknowledgePriority;
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

        public GalaxyPanelAlertEvent Clone(GalaxyPanelAlertEvent e)
        {
            return new GalaxyPanelAlertEvent(e);
        }

        public bool Equals(GalaxyPanelAlertEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelAlertEvent other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelAlertEventUid != this.GalaxyPanelAlertEventUid)
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
