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
    public partial class OutputDeviceActivityEvent
    {
        public OutputDeviceActivityEvent() : base()
        {
            Initialize();
        }

        public OutputDeviceActivityEvent(OutputDeviceActivityEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(OutputDeviceActivityEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.OutputDeviceActivityEventUid = e.OutputDeviceActivityEventUid;
            this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.CpuUid = e.CpuUid;
            this.CpuNumber = e.CpuNumber;
            this.ActivityDateTime = e.ActivityDateTime;
            this.BufferIndex = e.BufferIndex;
            this.InsertDate = e.InsertDate;

        }

        public OutputDeviceActivityEvent Clone(OutputDeviceActivityEvent e)
        {
            return new OutputDeviceActivityEvent(e);
        }

        public bool Equals(OutputDeviceActivityEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(OutputDeviceActivityEvent other)
        {
            if (other == null)
                return false;

            if (other.OutputDeviceActivityEventUid != this.OutputDeviceActivityEventUid)
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
