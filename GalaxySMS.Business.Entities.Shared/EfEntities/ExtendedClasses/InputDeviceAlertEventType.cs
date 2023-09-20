using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class InputDeviceAlertEventType
    {
        public InputDeviceAlertEventType()
        {
            Initialize();
        }

        public InputDeviceAlertEventType(InputDeviceAlertEventType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.InputDeviceAlertEvents = new HashSet<InputDeviceAlertEvent>();
            //this.InputDeviceEventProperties = new HashSet<InputDeviceEventProperty>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InputDeviceAlertEventType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceAlertEventTypeUid = e.InputDeviceAlertEventTypeUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
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
