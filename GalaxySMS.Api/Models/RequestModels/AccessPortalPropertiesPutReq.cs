using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class AccessPortalPropertiesPutReq : PutRequestBase
    {
        public System.Guid AccessPortalPropertiesUid { get; set; }

        public System.Guid AccessPortalUid { get; set; }
        public System.Guid AutomaticForgivePassbackFrequencyUid { get; set; }

        public System.Guid PinRequiredModeUid { get; set; }

        public System.Guid AccessPortalContactSupervisionTypeUid { get; set; }

        public System.Guid AccessPortalDeferToServerBehaviorUid { get; set; }

        public System.Guid AccessPortalNoServerReplyBehaviorUid { get; set; }

        public System.Guid AccessPortalLockPushButtonBehaviorUid { get; set; }


        public Nullable<System.Guid> LiquidCrystalDisplayUid { get; set; }


        public Nullable<System.Guid> AccessPortalElevatorControlTypeUid { get; set; }


        public Nullable<System.Guid> OtisElevatorDecUid { get; set; }


        public Nullable<System.Guid> ElevatorRelayInterfaceBoardSectionUid { get; set; }

        public System.Guid AccessPortalMultiFactorModeUid { get; set; }


        public int UnlockDelay { get; set; }


        public int UnlockDuration { get; set; }


        public int RecloseDuration { get; set; }


        public bool AllowPassbackAccess { get; set; }


        public bool RequireTwoValidCredentials { get; set; }


        public bool UnlockOnREX { get; set; }


        public bool SuppressIllegalOpenLog { get; set; }


        public bool SuppressOpenTooLongLog { get; set; }


        public bool SuppressClosedLog { get; set; }


        public bool SuppressREXLog { get; set; }


        public bool GenerateDoorContactChangeLogs { get; set; }


        public bool LockWhenDoorCloses { get; set; }


        public bool EnableDuress { get; set; }


        public bool DoorGroupNotify { get; set; }


        public bool DoorGroupCanDisable { get; set; }


        public bool RelayOneOnDuringArmDelay { get; set; }


        public bool RequireValidAccessForAutoUnlock { get; set; }


        //public bool PINSpecifiesRecloseDuration { get; set; }


        public bool ValidAccessRequiresDoorOpen { get; set; }


        public bool DontDecrementLimitedSwipeExpireCount { get; set; }


        public bool IgnoreNotInSystem { get; set; }


        public bool ReaderSendsHeartbeat { get; set; }


        public bool PhotoVerificationEnabled { get; set; }


        public bool TimeAttendancePortal { get; set; }


        public bool EMailEventsEnabled { get; set; }


        public bool TransmitEventsEnabled { get; set; }


        public bool FileOutputEnabled { get; set; }

    }
}
