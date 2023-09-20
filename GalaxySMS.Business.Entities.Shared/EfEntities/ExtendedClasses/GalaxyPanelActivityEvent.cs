#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyPanelActivityEvent
    {
        public GalaxyPanelActivityEvent()
        {
            Initialize();
        }

        public GalaxyPanelActivityEvent(GalaxyPanelActivityEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyPanelActivityEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyPanelActivityEventUid = e.GalaxyPanelActivityEventUid;
            this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.CredentialUid = e.CredentialUid;
            this.PersonUid = e.PersonUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.ActivityDateTime = e.ActivityDateTime;
            this.CpuUid = e.CpuUid;
            this.CpuNumber = e.CpuNumber;
            this.BufferIndex = e.BufferIndex;
            this.InputOutputGroupNumber = e.InputOutputGroupNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.InsertDate = e.InsertDate;
            this.EventType = e.EventType;

            this.IsAlarmEvent = e.IsAlarmEvent;
            this.NoteUid = e.NoteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AlarmPriority = e.AlarmPriority;

            //this.CredentialBytes = e.CredentialBytes;
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

        public GalaxyPanelActivityEvent Clone(GalaxyPanelActivityEvent e)
        {
            return new GalaxyPanelActivityEvent(e);
        }

        public bool Equals(GalaxyPanelActivityEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelActivityEvent other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelActivityEventUid != this.GalaxyPanelActivityEventUid)
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
