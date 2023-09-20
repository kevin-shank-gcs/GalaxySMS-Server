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
    public partial class InputDeviceAlertEventType
    {
        public InputDeviceAlertEventType() : base()
        {
            Initialize();
        }

        public InputDeviceAlertEventType(InputDeviceAlertEventType e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            //this.InputDeviceAlertEvents = new HashSet<InputDeviceAlertEvent>();
            //this.InputDeviceEventProperties = new HashSet<InputDeviceEventProperty>();
        }

        public void Initialize(InputDeviceAlertEventType e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceAlertEventTypeUid = e.InputDeviceAlertEventTypeUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptiorResourceKey = e.DescriptiorResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
            this.Tag = e.Tag;
            this.CanAcknowledge = e.CanAcknowledge;
            this.CanHaveInputOutputGroupOffset = e.CanHaveInputOutputGroupOffset;
            this.CanHaveSchedule = e.CanHaveSchedule;
            this.CanHaveAudio = e.CanHaveAudio;
            this.CanHaveInstructions = e.CanHaveInstructions;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.InputDeviceAlertEvents = e.InputDeviceAlertEvents.ToCollection();
            //this.InputDeviceEventProperties = e.InputDeviceEventProperties.ToCollection();
        }

        public InputDeviceAlertEventType Clone(InputDeviceAlertEventType e)
        {
            return new InputDeviceAlertEventType(e);
        }

        public bool Equals(InputDeviceAlertEventType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceAlertEventType other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceAlertEventTypeUid != this.InputDeviceAlertEventTypeUid)
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
