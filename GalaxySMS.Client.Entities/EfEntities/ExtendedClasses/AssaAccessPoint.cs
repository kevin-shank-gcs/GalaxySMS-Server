////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AssaAccessPoint.cs
//
// summary:	Implements the assa access point class
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
    /// <summary>   An assa access point. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AssaAccessPoint
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaAccessPoint()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AssaAccessPoint to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaAccessPoint(AssaAccessPoint e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AssaAccessPoint. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AssaAccessPoint. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AssaAccessPoint to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AssaAccessPoint e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaAccessPointUid = e.AssaAccessPointUid;
            this.AssaDsrUid = e.AssaDsrUid;
            this.AssaAccessPointTypeUid = e.AssaAccessPointTypeUid;
            this.SerialNumber = e.SerialNumber;
            this.AccessPointName = e.AccessPointName;
            this.FirmwareVersion = e.FirmwareVersion;
            this.AccessPointTypeDescription = e.AccessPointTypeDescription;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.SiteUid = e.SiteUid;
            this.AssaUniqueId = e.AssaUniqueId;
            this.AccessPoint = e.AccessPoint;
            //if( e.AssaAccessPointType != null )
            //    this.AssaAccessPointType = new AssaAccessPointType(e.AssaAccessPointType);
            //if( e.AssaDsr != null )
            //    this.AssaDsr = new AssaDsr(e.AssaDsr);
            //if (e.Site != null)
            //    this.Site = new Site(e.Site);
        }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Makes a deep copy of this AssaAccessPoint. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <param name="e">    The AssaAccessPoint to process. </param>
    ///
    /// <returns>   A copy of this AssaAccessPoint. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public AssaAccessPoint Clone(AssaAccessPoint e)
        {
            return new AssaAccessPoint(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this AssaAccessPoint is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AssaAccessPoint other)
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

        public bool IsPrimaryKeyEqual(AssaAccessPoint other)
        {
            if (other == null)
                return false;

            if (other.AssaAccessPointUid != this.AssaAccessPointUid)
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
