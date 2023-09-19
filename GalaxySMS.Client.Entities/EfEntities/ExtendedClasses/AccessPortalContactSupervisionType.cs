////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessPortalContactSupervisionType.cs
//
// summary:	Implements the access portal contact supervision type class
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
    /// <summary>   The access portal contact supervision type. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AccessPortalContactSupervisionType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalContactSupervisionType() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalContactSupervisionType to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalContactSupervisionType(AccessPortalContactSupervisionType e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortalContactSupervisionType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            //this.AccessPortalProperties = new HashSet<AccessPortalProperties>();
            this.gcsBinaryResource = new gcsBinaryResource();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessPortalContactSupervisionType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalContactSupervisionType to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AccessPortalContactSupervisionType e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessPortalContactSupervisionTypeUid = e.AccessPortalContactSupervisionTypeUid;
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
            this.BinaryResourceUid = e.BinaryResourceUid;
            //this.AccessPortalProperties = e.AccessPortalProperties.ToCollection();

            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            this.ResourceClassName = e.ResourceClassName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.UniqueResourceName = e.UniqueResourceName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessPortalContactSupervisionType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalContactSupervisionType to process. </param>
        ///
        /// <returns>   A copy of this AccessPortalContactSupervisionType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalContactSupervisionType Clone(AccessPortalContactSupervisionType e)
        {
            return new AccessPortalContactSupervisionType(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Tests if this AccessPortalContactSupervisionType is considered equal to another.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AccessPortalContactSupervisionType other)
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

        public bool IsPrimaryKeyEqual(AccessPortalContactSupervisionType other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalContactSupervisionTypeUid != this.AccessPortalContactSupervisionTypeUid)
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