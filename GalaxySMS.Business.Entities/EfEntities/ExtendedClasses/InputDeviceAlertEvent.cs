using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class InputDeviceAlertEvent
    {
        public InputDeviceAlertEvent()
        {
            Initialize();
        }

        public InputDeviceAlertEvent(InputDeviceAlertEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(InputDeviceAlertEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceAlertEventUid = e.InputDeviceAlertEventUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
            this.Tag = e.Tag;
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
    }
}
