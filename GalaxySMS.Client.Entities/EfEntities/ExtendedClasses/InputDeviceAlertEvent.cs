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
    public partial class InputDeviceAlertEvent
    {
        public InputDeviceAlertEvent() : base()
        {
            Initialize();
        }

        public InputDeviceAlertEvent(InputDeviceAlertEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(InputDeviceAlertEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceAlertEventUid = e.InputDeviceAlertEventUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
            this.Tag = e.Tag;
            this.AcknowledgePriority = e.AcknowledgePriority;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.InputDeviceAlertEventTypeUid = e.InputDeviceAlertEventTypeUid;
            this.InputOutputGroupNumber = e.InputOutputGroupNumber;
            this.InputOutputGroupName = e.InputOutputGroupName;
            this.ResponseRequired = e.ResponseRequired;

        }

        public InputDeviceAlertEvent Clone(InputDeviceAlertEvent e)
        {
            return new InputDeviceAlertEvent(e);
        }

        public bool Equals(InputDeviceAlertEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceAlertEvent other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceAlertEventUid != this.InputDeviceAlertEventUid)
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
        
        private int _inputOutputGroupNumber;

        [DataMember]
        public int InputOutputGroupNumber
        {
            get { return _inputOutputGroupNumber; }
            set
            {
                if (_inputOutputGroupNumber != value)
                {
                    _inputOutputGroupNumber = value;
                    OnPropertyChanged(() => InputOutputGroupNumber, true);
                }
            }
        }


        private string _inputOutputGroupName;

        [DataMember]
        public string InputOutputGroupName
        {
            get { return _inputOutputGroupName; }
            set
            {
                if (_inputOutputGroupName != value)
                {
                    _inputOutputGroupName = value;
                    OnPropertyChanged(() => InputOutputGroupName, true);
                }
            }
        }
    }
}
