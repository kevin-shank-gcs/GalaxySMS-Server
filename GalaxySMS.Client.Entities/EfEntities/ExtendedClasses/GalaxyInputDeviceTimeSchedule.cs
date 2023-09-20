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
    public partial class GalaxyInputDeviceTimeSchedule
    {
        public GalaxyInputDeviceTimeSchedule() : base()
        {
            Initialize();
        }

        public GalaxyInputDeviceTimeSchedule(GalaxyInputDeviceTimeSchedule e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(GalaxyInputDeviceTimeSchedule e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyInputDeviceScheduleUid = e.GalaxyInputDeviceScheduleUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.Tag = e.Tag;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyInputDeviceTimeSchedule Clone(GalaxyInputDeviceTimeSchedule e)
        {
            return new GalaxyInputDeviceTimeSchedule(e);
        }

        public bool Equals(GalaxyInputDeviceTimeSchedule other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInputDeviceTimeSchedule other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInputDeviceScheduleUid != this.GalaxyInputDeviceScheduleUid)
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
