////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessPortalLockPushButtonBehavior.cs
//
// summary:	Implements the access portal lock push button behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal lock push button behavior. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AccessPortalLockPushButtonBehavior
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalLockPushButtonBehavior()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalLockPushButtonBehavior to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalLockPushButtonBehavior(AccessPortalLockPushButtonBehavior e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortalLockPushButtonBehavior. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortalLockPushButtonBehavior. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalLockPushButtonBehavior to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AccessPortalLockPushButtonBehavior e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalLockPushButtonBehaviorUid = e.AccessPortalLockPushButtonBehaviorUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Code = e.Code;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessPortalLockPushButtonBehavior. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalLockPushButtonBehavior to process. </param>
        ///
        /// <returns>   A copy of this AccessPortalLockPushButtonBehavior. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalLockPushButtonBehavior Clone(AccessPortalLockPushButtonBehavior e)
        {
            return new AccessPortalLockPushButtonBehavior(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Tests if this AccessPortalLockPushButtonBehavior is considered equal to another.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AccessPortalLockPushButtonBehavior other)
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

        public bool IsPrimaryKeyEqual(AccessPortalLockPushButtonBehavior other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalLockPushButtonBehaviorUid != this.AccessPortalLockPushButtonBehaviorUid)
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
