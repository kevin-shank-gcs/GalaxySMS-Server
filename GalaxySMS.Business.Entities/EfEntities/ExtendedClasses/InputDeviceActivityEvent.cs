using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class InputDeviceActivityEvent
    {
        public InputDeviceActivityEvent()
        {
            Initialize();
        }

        public InputDeviceActivityEvent(InputDeviceActivityEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(InputDeviceActivityEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceActivityEventUid = e.InputDeviceActivityEventUid;
            this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.CpuUid = e.CpuUid;
            this.CpuNumber = e.CpuNumber;
            this.ActivityDateTime = e.ActivityDateTime;
            this.BufferIndex = e.BufferIndex;
            this.InsertDate = e.InsertDate;
            this.EventType = e.EventType;
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

        public InputDeviceActivityEvent Clone(InputDeviceActivityEvent e)
        {
            return new InputDeviceActivityEvent(e);
        }

        public bool Equals(InputDeviceActivityEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceActivityEvent other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceActivityEventUid != this.InputDeviceActivityEventUid)
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
