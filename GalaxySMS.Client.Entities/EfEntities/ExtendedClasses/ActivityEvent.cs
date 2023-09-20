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
    public partial class ActivityEvent
    {
        public ActivityEvent() : base()
        {
            Initialize();
        }

        public ActivityEvent(ActivityEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.ActivityEventAcknowledgements = new HashSet<ActivityEventAcknowledgement>();
        }

        public void Initialize(ActivityEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.ActivityEventUid = e.ActivityEventUid;
            this.ActivityDateTime = e.ActivityDateTime;
            this.ActivityDateTimeUTC = e.ActivityDateTimeUTC;
            this.EventTypeMessage = e.EventTypeMessage;
            this.ForeColor = e.ForeColor;
            this.ForeColorHex = e.ForeColorHex;
            this.DeviceName = e.DeviceName;
            this.SiteName = e.SiteName;
            this.EntityId = e.EntityId;
            this.DeviceUid = e.DeviceUid;
            this.EventTypeUid = e.EventTypeUid;
            this.DeviceType = e.DeviceType;
            this.LastName = e.LastName;
            this.FirstName = e.FirstName;
            this.IsTraced = e.IsTraced;
            this.CredentialDescription = e.CredentialDescription;
            this.PersonUid = e.PersonUid;
            this.CredentialUid = e.CredentialUid;
            this.ClusterUid = e.ClusterUid;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterName = e.ClusterName;
            this.ClusterGroupId = e.ClusterGroupId;
            this.PanelNumber = e.PanelNumber;
            this.InputOutputGroupName = e.InputOutputGroupName;
            this.InputOutputGroupNumber = e.InputOutputGroupNumber;
            this.CpuNumber = e.CpuNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.AlarmPriority = e.AlarmPriority;
            this.ResponseRequired = e.ResponseRequired;
            this.EntityName = e.EntityName;
            this.EntityType = e.EntityType;
            this.ActivityEventAcknowledgements = e.ActivityEventAcknowledgements.ToCollection();

        }

        public ActivityEvent Clone(ActivityEvent e)
        {
            return new ActivityEvent(e);
        }

        public bool Equals(ActivityEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ActivityEvent other)
        {
            if (other == null)
                return false;

            if (other.ActivityEventUid != this.ActivityEventUid)
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
