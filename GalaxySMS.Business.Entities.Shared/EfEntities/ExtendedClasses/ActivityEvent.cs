using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

using System.Runtime.Serialization;

#if NetCoreApi
    namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class ActivityEvent
    {
        public ActivityEvent()
        {
            Initialize();
        }

        public ActivityEvent(ActivityEvent e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ActivityEventAcknowledgements = new HashSet<ActivityEventAcknowledgement>();
        }

        public void Initialize(ActivityEvent e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
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
            this.BufferIndex = e.BufferIndex;
            this.CredentialBytes = e.CredentialBytes;
            this.IsActive = e.IsActive;
            this.IsAlarmEvent = e.IsAlarmEvent;
            this.UsageCount = e.UsageCount;
            this.PersonExpirationModeUid = e.PersonExpirationModeUid;
            this.PersonCredentialUid = e.PersonCredentialUid;
            this.InsertDate = e.InsertDate;
            
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
