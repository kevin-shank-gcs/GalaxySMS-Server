////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\PersonPersonalAccessGroup.cs
//
// summary:	Implements the person personal access group class
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
    /// <summary>   A person personal access group. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class PersonPersonalAccessGroup
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonPersonalAccessGroup() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonPersonalAccessGroup to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonPersonalAccessGroup(PersonPersonalAccessGroup e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonPersonalAccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            //AccessPortalUids = new HashSet<Guid>();
            
            //DynamicAccessGroupUids = new HashSet<Guid>();
            AccessPortals = new HashSet<AccessPortalUidItem>();
            DynamicAccessGroups = new HashSet<AccessGroupUidItem>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonPersonalAccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonPersonalAccessGroup to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(PersonPersonalAccessGroup e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.ClusterUid = e.ClusterUid;
            this.PersonalAccessGroupNumber = e.PersonalAccessGroupNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //if(e.AccessPortalUids != null)
            //    AccessPortalUids = e.AccessPortalUids.ToCollection();
            //if (e.DynamicAccessGroupUids != null)
            //    DynamicAccessGroupUids = e.DynamicAccessGroupUids.ToCollection();
            if (e.AccessPortals != null)
                AccessPortals = e.AccessPortals.ToCollection();
            if (e.DynamicAccessGroups != null)
                DynamicAccessGroups = e.DynamicAccessGroups.ToCollection();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this PersonPersonalAccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonPersonalAccessGroup to process. </param>
        ///
        /// <returns>   A copy of this PersonPersonalAccessGroup. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonPersonalAccessGroup Clone(PersonPersonalAccessGroup e)
        {
            return new PersonPersonalAccessGroup(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this PersonPersonalAccessGroup is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(PersonPersonalAccessGroup other)
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

        public bool IsPrimaryKeyEqual(PersonPersonalAccessGroup other)
        {
            if (other == null)
                return false;

            if (other.PersonClusterPermissionUid != this.PersonClusterPermissionUid)
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
