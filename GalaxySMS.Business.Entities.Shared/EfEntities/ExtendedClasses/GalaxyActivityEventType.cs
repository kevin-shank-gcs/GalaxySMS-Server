using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GalaxySMS.Common.Constants;
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
	public partial class GalaxyActivityEventType
    {
        public GalaxyActivityEventType()
        {
            Initialize();
        }

        public GalaxyActivityEventType(GalaxyActivityEventType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyActivityEventType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
            this.EventType = e.EventType;
            this.DeviceType = e.DeviceType;
            this.ForeColor = e.ForeColor;
            this.ForeColorHex = e.ForeColorHex;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;

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

        public GalaxyActivityEventType Clone(GalaxyActivityEventType e)
        {
            return new GalaxyActivityEventType(e);
        }

        public bool Equals(GalaxyActivityEventType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyActivityEventType other)
        {
            if (other == null)
                return false;

            if (other.GalaxyActivityEventTypeUid != this.GalaxyActivityEventTypeUid)
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAcknowledgeable {
            get
            {
                bool result = this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.DoorForcedOpen ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.DoorLeftOpen ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.AccessDenied ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.AccessDeniedAttemptPivCardExpired ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.PassbackViolation ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.DuressAuxiliaryFunction ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.DoorHeartbeartAlarm ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.DoorModuleAdapterTamperAlarm ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.ReaderTamperAlarm ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.ReaderHeartbeatStopped ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.PointAlarmArmed ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.EmergencyUnlockActive ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.CpuTamperAlarm ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.CpuAcFailureAlarm ||
                              this.GalaxyActivityEventTypeUid == PanelActivityLogMessageCodeIds.CpuLowBatteryAlarm;

                return result;
            }
            set { }
        }

        public GalaxyActivityEventTypeBasic ToGalaxyActivityEventTypeBasic()
        {
            return new GalaxyActivityEventTypeBasic()
            {
                EventTypeUid = GalaxyActivityEventTypeUid,
                DeviceType = DeviceType,
                ForeColorHex = ForeColorHex,
                Message = Display,
                IsAcknowledgeable = IsAcknowledgeable
            };
        }
    }
}
