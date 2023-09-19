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
    public partial class InputDeviceActivityAlarmEvent
    {
        public InputDeviceActivityAlarmEvent() : base()
        {
            Initialize();
        }

        public InputDeviceActivityAlarmEvent(InputDeviceActivityAlarmEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.InputDeviceAlarmEventAcknowledgments = new HashSet<InputDeviceAlarmEventAcknowledgment>();
        }

        public void Initialize(InputDeviceActivityAlarmEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceActivityEventUid = e.InputDeviceActivityEventUid;
            this.NoteUid = e.NoteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AlarmPriority = e.AlarmPriority;
            this.InputDeviceAlarmEventAcknowledgments = e.InputDeviceAlarmEventAcknowledgments.ToCollection();

        }

        public InputDeviceActivityAlarmEvent Clone(InputDeviceActivityAlarmEvent e)
        {
            return new InputDeviceActivityAlarmEvent(e);
        }

        public bool Equals(InputDeviceActivityAlarmEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceActivityAlarmEvent other)
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
