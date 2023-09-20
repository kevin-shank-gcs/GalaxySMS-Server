////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessPortalAuxiliaryOutput.cs
//
// summary:	Implements the access portal auxiliary output class
////////////////////////////////////////////////////////////////////////////////////////////////////

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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal auxiliary output. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AccessPortalAuxiliaryOutput
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalAuxiliaryOutput() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalAuxiliaryOutput to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalAuxiliaryOutput(AccessPortalAuxiliaryOutput e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortalAuxiliaryOutput. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            //this.AccessPortalAuxiliaryOutputTriggeringEvents =
            //    new HashSet<AccessPortalAuxiliaryOutputTriggeringEvent>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortalAuxiliaryOutput. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalAuxiliaryOutput to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AccessPortalAuxiliaryOutput e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessPortalAuxiliaryOutputUid = e.AccessPortalAuxiliaryOutputUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.AccessPortalAuxiliaryOutputModeUid = e.AccessPortalAuxiliaryOutputModeUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.Description = e.Description;
            this.Tag = e.Tag;
            this.ActivationDelay = e.ActivationDelay;
            this.ActivationDuration = e.ActivationDuration;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.AccessPortalAuxiliaryOutputTriggeringEvents =
            //    e.AccessPortalAuxiliaryOutputTriggeringEvents.ToCollection();
            this.IllegalOpen = e.IllegalOpen;
            this.OpenTooLong = e.OpenTooLong;
            this.InvalidAttempt = e.InvalidAttempt;
            this.AccessGranted = e.AccessGranted;
            this.Duress = e.Duress;
            this.PassbackViolation = e.PassbackViolation;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessPortalAuxiliaryOutput. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalAuxiliaryOutput to process. </param>
        ///
        /// <returns>   A copy of this AccessPortalAuxiliaryOutput. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalAuxiliaryOutput Clone(AccessPortalAuxiliaryOutput e)
        {
            return new AccessPortalAuxiliaryOutput(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this AccessPortalAuxiliaryOutput is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AccessPortalAuxiliaryOutput other)
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

        public bool IsPrimaryKeyEqual(AccessPortalAuxiliaryOutput other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAuxiliaryOutputUid != this.AccessPortalAuxiliaryOutputUid)
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


        public bool IllegalOpenAllowed
        {
            get
            {
                if (AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled)
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => IllegalOpenAllowed, false);
            }
        }


        public bool AccessGrantedAllowed
        {
            get
            {
                if (AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows ||
                    AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled)
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => AccessGrantedAllowed, false);
            }
        }


        public bool DuressAllowed
        {
            get
            {
                if (AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows ||
                    AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled)
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => DuressAllowed, false);
            }
        }


        public bool InvalidAttemptAllowed
        {
            get
            {
                if (AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows ||
                    AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled)
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => InvalidAttemptAllowed, false);
            }
        }


        public bool OpenTooLongAllowed
        {
            get
            {
                if (AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled)
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => OpenTooLongAllowed, false);
            }
        }

        public bool PassbackAllowed
        {
            get
            {
                if (AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows ||
                    AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled)
                    return false;
                return true;
            }
            set
            {
                OnPropertyChanged(() => PassbackAllowed, false);
            }
        }


        public bool TimingControlsAllowed
        {
            get
            {
                if (AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Timeout)
                    return true;
                return false;
            }
            set
            {
                OnPropertyChanged(() => TimingControlsAllowed, false);
            }
        }

    }
}
