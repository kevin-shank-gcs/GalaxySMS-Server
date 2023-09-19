using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalProperties
    {
        public AccessPortalProperties()
        {
            Initialize();
        }

        public AccessPortalProperties(AccessPortalProperties e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AutomaticForgivePassbackFrequencyUid =
                GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.Never;
            this.PinRequiredModeUid = Common.Constants.PinRequiredModeIds.RequiredForAccessDecision;
            this.AccessPortalContactSupervisionTypeUid = Common.Constants.AccessPortalContactSupervisionTypeIds.None;
            this.AccessPortalDeferToServerBehaviorUid = Common.Constants.AccessPortalDeferToServerBehaviorIds.Never;
            this.AccessPortalNoServerReplyBehaviorUid =
                Common.Constants.AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision;
            this.AccessPortalLockPushButtonBehaviorUid = Common.Constants.AccessPortalLockPushButtonBehaviorIds.None;
            this.AccessPortalElevatorControlTypeUid = Common.Constants.AccessPortalElevatorControlTypeIds.None;
            this.AccessPortalMultiFactorModeUid = Common.Constants.AccessPortalMultiFactorModeIds.SingleFactor;
            this.UnlockDelay = 0;
            this.UnlockDuration = 500;
            this.RecloseDuration = 1500;
            this.UnlockOnREX = true;
        }

        public void Initialize(AccessPortalProperties e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalPropertiesUid = e.AccessPortalPropertiesUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.AutomaticForgivePassbackFrequencyUid = e.AutomaticForgivePassbackFrequencyUid;
            this.PinRequiredModeUid = e.PinRequiredModeUid;
            this.AccessPortalContactSupervisionTypeUid = e.AccessPortalContactSupervisionTypeUid;
            this.AccessPortalDeferToServerBehaviorUid = e.AccessPortalDeferToServerBehaviorUid;
            this.AccessPortalNoServerReplyBehaviorUid = e.AccessPortalNoServerReplyBehaviorUid;
            this.AccessPortalLockPushButtonBehaviorUid = e.AccessPortalLockPushButtonBehaviorUid;
            this.LiquidCrystalDisplayUid = e.LiquidCrystalDisplayUid;
            this.AccessPortalElevatorControlTypeUid = e.AccessPortalElevatorControlTypeUid;
            this.OtisElevatorDecUid = e.OtisElevatorDecUid;
            this.ElevatorRelayInterfaceBoardSectionUid = e.ElevatorRelayInterfaceBoardSectionUid;
            this.AccessPortalMultiFactorModeUid = e.AccessPortalMultiFactorModeUid;
            this.UnlockDelay = e.UnlockDelay;
            this.UnlockDuration = e.UnlockDuration;
            this.RecloseDuration = e.RecloseDuration;
            this.AllowPassbackAccess = e.AllowPassbackAccess;
            this.RequireTwoValidCredentials = e.RequireTwoValidCredentials;
            this.UnlockOnREX = e.UnlockOnREX;
            this.SuppressIllegalOpenLog = e.SuppressIllegalOpenLog;
            this.SuppressOpenTooLongLog = e.SuppressOpenTooLongLog;
            this.SuppressClosedLog = e.SuppressClosedLog;
            this.SuppressREXLog = e.SuppressREXLog;
            this.GenerateDoorContactChangeLogs = e.GenerateDoorContactChangeLogs;
            this.LockWhenDoorCloses = e.LockWhenDoorCloses;
            this.EnableDuress = e.EnableDuress;
            this.DoorGroupNotify = e.DoorGroupNotify;
            this.DoorGroupCanDisable = e.DoorGroupCanDisable;
            this.RelayOneOnDuringArmDelay = e.RelayOneOnDuringArmDelay;
            this.RequireValidAccessForAutoUnlock = e.RequireValidAccessForAutoUnlock;
            this.PINSpecifiesRecloseDuration = e.PINSpecifiesRecloseDuration;
            this.ValidAccessRequiresDoorOpen = e.ValidAccessRequiresDoorOpen;
            this.DontDecrementLimitedSwipeExpireCount = e.DontDecrementLimitedSwipeExpireCount;
            this.IgnoreNotInSystem = e.IgnoreNotInSystem;
            this.ReaderSendsHeartbeat = e.ReaderSendsHeartbeat;
            this.PhotoVerificationEnabled = e.PhotoVerificationEnabled;
            this.TimeAttendancePortal = e.TimeAttendancePortal;
            this.EMailEventsEnabled = e.EMailEventsEnabled;
            this.TransmitEventsEnabled = e.TransmitEventsEnabled;
            this.FileOutputEnabled = e.FileOutputEnabled;
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

        public AccessPortalProperties Clone(AccessPortalProperties e)
        {
            return new AccessPortalProperties(e);
        }

        public bool Equals(AccessPortalProperties other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalProperties other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalPropertiesUid != this.AccessPortalPropertiesUid)
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