#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class AccessPortalActivityEvent
    {
        public AccessPortalActivityEvent()
        {
            Initialize();
        }

        public AccessPortalActivityEvent(AccessPortalActivityEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalActivityEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
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
            this.EventType = e.EventType;
            this.CredentialBytes = e.CredentialBytes;
            this.IsAlarmEvent = e.IsAlarmEvent;
            this.NoteUid = e.NoteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AlarmPriority = e.AlarmPriority;
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
