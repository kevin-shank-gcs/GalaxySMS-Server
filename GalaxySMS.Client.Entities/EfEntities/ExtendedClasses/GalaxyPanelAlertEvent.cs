using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    public partial class GalaxyPanelAlertEvent
    {
        public GalaxyPanelAlertEvent() : base()
        {
            Initialize();
        }

        public GalaxyPanelAlertEvent(GalaxyPanelAlertEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(GalaxyPanelAlertEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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
            this.OffsetIndex = e.OffsetIndex;
            if (e.GalaxyPanelAlertEventType != null)
                this.GalaxyPanelAlertEventType = new GalaxyPanelAlertEventType(e.GalaxyPanelAlertEventType);

            if (e.Note != null)
                this.Note = new Note(e.Note);
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
        private short _OffsetIndex;

        [DataMember]
        public short OffsetIndex
        {
            get { return _OffsetIndex; }
            set
            {
                if (_OffsetIndex != value)
                {
                    _OffsetIndex = value;
                    OnPropertyChanged(() => OffsetIndex, false);
                }
            }
        }

    }
}
