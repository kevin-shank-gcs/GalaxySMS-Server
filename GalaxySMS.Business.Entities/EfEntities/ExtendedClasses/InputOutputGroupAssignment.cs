using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class InputOutputGroupAssignment
    {
        public InputOutputGroupAssignment()
        {
            Initialize();
        }

        public InputOutputGroupAssignment(InputOutputGroupAssignment e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(InputOutputGroupAssignment e)
        {
            Initialize();
            if (e == null)
                return;
            this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.AccessPortalAlertEventUid = e.AccessPortalAlertEventUid;
            this.InputDeviceAlertEventUid = e.InputDeviceAlertEventUid;
            this.GalaxyPanelAlertEventUid = e.GalaxyPanelAlertEventUid;
            this.OffsetIndex = e.OffsetIndex;
            this.Tag = e.Tag;
            this.IsDirty = e.IsDirty;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.InputOutputGroup != null)
                this.InputOutputGroup = new InputOutputGroup(e.InputOutputGroup);

        }

        public bool IsAnythingDirty
        {
            get
            {
                return IsDirty;
            }
        }

        public InputOutputGroupAssignment Clone(InputOutputGroupAssignment e)
        {
            return new InputOutputGroupAssignment(e);
        }

        public bool Equals(InputOutputGroupAssignment other)
        {
            if (other == null)
                return false;

            if (this.InputOutputGroupAssignmentUid != other.InputOutputGroupAssignmentUid ||
                this.AccessPortalAlertEventUid != other.AccessPortalAlertEventUid ||
                this.InputDeviceAlertEventUid != other.InputDeviceAlertEventUid ||
                this.GalaxyPanelAlertEventUid != other.GalaxyPanelAlertEventUid ||
                this.InputOutputGroupUid != other.InputOutputGroupUid ||
                this.OffsetIndex != other.OffsetIndex ||
                this.Tag != other.Tag)
                return false;
             
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputOutputGroupAssignment other)
        {
            if (other == null)
                return false;

            if (other.InputOutputGroupAssignmentUid != this.InputOutputGroupAssignmentUid)
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
