using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyInputDevice
    {
        public GalaxyInputDevice()
        {
            Initialize();
        }

        public GalaxyInputDevice(GalaxyInputDevice e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyInputDevice e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceUid = e.InputDeviceUid;
            this.InputDeviceSupervisionTypeUid = e.InputDeviceSupervisionTypeUid;
            this.GalaxyInputModeUid = e.GalaxyInputModeUid;
            this.DelayDuration = e.DelayDuration;
            this.GalaxyInputDelayTypeUid = e.GalaxyInputDelayTypeUid;
            this.DisableDisarmedOnOffLogEvents = e.DisableDisarmedOnOffLogEvents;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
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

        public GalaxyInputDevice Clone(GalaxyInputDevice e)
        {
            return new GalaxyInputDevice(e);
        }

        public bool Equals(GalaxyInputDevice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInputDevice other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceUid != this.InputDeviceUid)
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