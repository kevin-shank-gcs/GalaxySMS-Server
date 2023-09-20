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
    public partial class InputDeviceAlarmEventAcknowledgment
    {
        public InputDeviceAlarmEventAcknowledgment() : base()
        {
            Initialize();
        }

        public InputDeviceAlarmEventAcknowledgment(InputDeviceAlarmEventAcknowledgment e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(InputDeviceAlarmEventAcknowledgment e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceAlarmEventAcknowledgmentUid = e.InputDeviceAlarmEventAcknowledgmentUid;
            this.InputDeviceActivityEventUid = e.InputDeviceActivityEventUid;
            this.UserId = e.UserId;
            this.Response = e.Response;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public InputDeviceAlarmEventAcknowledgment Clone(InputDeviceAlarmEventAcknowledgment e)
        {
            return new InputDeviceAlarmEventAcknowledgment(e);
        }

        public bool Equals(InputDeviceAlarmEventAcknowledgment other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceAlarmEventAcknowledgment other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceAlarmEventAcknowledgmentUid != this.InputDeviceAlarmEventAcknowledgmentUid)
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
