using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            this.ConcurrencyValue = 0;
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
            this.ResponseRequired = e.ResponseRequired;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.Note = e.Note;
            this.OffsetIndex = e.OffsetIndex;
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
                if (Note != null && Note.IsAnythingDirty)
                    return Note.IsAnythingDirty;
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public short OffsetIndex { get; set; }

    }
}
