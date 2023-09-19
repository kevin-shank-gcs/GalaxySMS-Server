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
    /// <summary>   The gcs application. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsApplicationBasic
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplicationBasic()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsApplication to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplicationBasic(gcsApplicationBasic e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsApplication. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.Roles = new ObservableCollection<gcsApplicationRoleBasic>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsApplication. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsApplication to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(gcsApplicationBasic e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationId = e.ApplicationId;
            //this.LanguageId = e.LanguageId;
            //this.SystemRoleId = e.SystemRoleId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationDescription = e.ApplicationDescription;
            if( e.Roles != null)
            this.Roles = e.Roles.ToObservableCollection();
            //this.AuthorizedRoles = e.AuthorizedRoles.ToObservableCollection();
            //this.UnauthorizedRoles = e.UnauthorizedRoles.ToObservableCollection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this gcsApplication. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsApplication to process. </param>
        ///
        /// <returns>   A copy of this gcsApplication. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplicationBasic Clone(gcsApplicationBasic e)
        {
            return new gcsApplicationBasic(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this gcsApplication is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(gcsApplicationBasic other)
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

        public bool IsPrimaryKeyEqual(gcsApplicationBasic other)
        {
            if (other == null)
                return false;

            if (other.ApplicationId != this.ApplicationId)
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
            return ApplicationName;
        }

    }
}
