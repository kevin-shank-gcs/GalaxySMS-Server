////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessPortalProperties.cs
//
// summary:	Implements the access portal properties class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal properties. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AccessPortalProperties
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalProperties() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalProperties to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalProperties(AccessPortalProperties e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortalProperties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.AutomaticForgivePassbackFrequencyUid =
                GalaxySMS.Common.Constants.AutomaticForgivePassbackFrequencyIds.Never;
            this.PinRequiredModeUid = Common.Constants.PinRequiredModeIds.RequiredForAccessDecision;
            this.AccessPortalContactSupervisionTypeUid = Common.Constants.AccessPortalContactSupervisionTypeIds.None;
            this.AccessPortalDeferToServerBehaviorUid = Common.Constants.AccessPortalDeferToServerBehaviorIds.Never;
            this.AccessPortalNoServerReplyBehaviorUid =
                Common.Constants.AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision;
            this.AccessPortalLockPushButtonBehaviorUid = Common.Constants.AccessPortalLockPushButtonBehaviorIds.None;
            this.AccessPortalElevatorControlTypeUid = Common.Constants.AccessPortalElevatorControlTypeIds.None;
            this.UnlockDelay = 0;
            this.UnlockDuration = 500;
            this.RecloseDuration = 1500;
            this.UnlockOnREX = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortalProperties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalProperties to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AccessPortalProperties e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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
            //this.PINSpecifiesRecloseDuration = e.PINSpecifiesRecloseDuration;
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessPortalProperties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalProperties to process. </param>
        ///
        /// <returns>   A copy of this AccessPortalProperties. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalProperties Clone(AccessPortalProperties e)
        {
            return new AccessPortalProperties(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this AccessPortalProperties is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AccessPortalProperties other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(AccessPortalProperties other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalPropertiesUid != this.AccessPortalPropertiesUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
