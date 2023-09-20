using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
            this.ActivityDateTime = e.ActivityDateTime;
            this.CpuUid = e.CpuUid;
            this.CpuNumber = e.CpuNumber;
            this.BufferIndex = e.BufferIndex;
            this.InputOutputGroupNumber = e.InputOutputGroupNumber;
            this.BoardNumber = e.BoardNumber;
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
